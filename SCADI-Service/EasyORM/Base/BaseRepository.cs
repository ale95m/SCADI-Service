using MyRepository.Base;
using MySql.Data.MySqlClient;
using MySqlRepository.Base;
using MySqlRepository.SQL;
using MySqlRepository.SQL.MySql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbColumn = MySqlRepository.Base.DbColumn;

namespace MySqlRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : IBaseModel, new ()
    {
        public abstract string TableName { get; }
        public virtual string PrimareKey { get; } = "id";

        protected T EmptyModel()
        {
            return new T();
        }
        protected IEnumerable<DbColumn> ModelColumns { get; set; }

        public virtual bool SoftDelete => false;
        public virtual bool TimeTamps => false;

        protected BaseRepository()
        {
            ModelColumns = ColumnsFactory.GetColumns(typeof(T));
        }
        private T CreateModel(DataRow row)
        {
            T model = EmptyModel();
            foreach (DbColumn column in ModelColumns)
            {
                string value = row[column.Name].ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    column.Property.SetValue(model, TypeFactory.FromDbType(column.DbType, value));
                }
            }
            return model;
        }
        private IEnumerable<T> CreateModelCollection(DataRowCollection rows)
        {
            foreach (DataRow row in rows)
            {
                yield return CreateModel(row);
            }
            yield break;
        }

        public IEnumerable<T> All()
        {
            MySqlResponseQuery<T> query = new MySqlResponseQuery<T>(this);
            return query.Get();
        }


        public T FirstOrFail(int id)
        {
            DataRow row = MyDbConnection.SelectById(TableName, id);
            if (row == null)
            {
                throw new Exception("Not found");
            }
            return CreateModel(row);
        }
        public T FirstOrDefault(int id)
        {
            DataRow row = MyDbConnection.SelectById(TableName, id);
            if (row == null)
            {
                return EmptyModel();
            }
            return CreateModel(row);
        }

        public IEnumerable<T> ExecuteSelectQuery(string query, DbParameter[] parameters)
        {
            var result = MyDbConnection.ResponseQuery(query, parameters);
            return CreateModelCollection(result.Rows);
        }

        public IResponseQuery<T> Where(string columnName, string @operator, object value)
        {
            MySqlResponseQuery<T> query = new MySqlResponseQuery<T>(this);
            return query.Where(columnName, @operator, value);
        }

        public IResponseQuery<T> Where(string columnName, object value)
        {
            MySqlResponseQuery<T> query = new MySqlResponseQuery<T>(this);
            return query.Where(columnName, value);
        }

        public T Refresh(T model)
        {
            model = this.FirstOrDefault(model.Id);
            return model;
        }
    }
}
