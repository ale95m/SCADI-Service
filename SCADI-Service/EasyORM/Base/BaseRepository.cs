using MySql.Data.MySqlClient;
using MySqlRepository.Base;
using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        public abstract string TableName { get; }
        public virtual string PrimareKey { get; } = "id";

        protected abstract T EmptyModel();
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
            var result = MyDbConnection.SelectQuery(TableName);
            return CreateModelCollection(result.Rows);
        }



        public virtual T Find(int id)
        {
            DataRow row = MyDbConnection.SelectById(TableName, id);
            if (row==null)
            {
                return null;
            }
            return CreateModel(row);
        }

        public T FirstOrFail(int id)
        {
            return Find(id) ?? throw new Exception("Not found");
        }

        IEnumerable<T> IRepository<T>.ExecuteSelectQuery(string query, MySqlParameter[] parameters)
        {
            var result = MyDbConnection.ResponseQuery(query, parameters);
            return CreateModelCollection(result.Rows);
        }

        public IResponseQuery<T> Where(string columnName, string @operator, object value)
        {
            MysqlResponseQuery<T> query = new MysqlResponseQuery<T>(this);
            return query.Where(columnName, @operator, value);
        }

        public IResponseQuery<T> Where(string columnName, object value)
        {
            MysqlResponseQuery<T> query = new MysqlResponseQuery<T>(this);
            return query.Where(columnName, value);
        }
    }
}
