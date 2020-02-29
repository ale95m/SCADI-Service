using MySqlRepository.Base;
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
        protected abstract T EmptyModel();
        protected IEnumerable<DbColumn> ModelColumns { get; set; }

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

        public IEnumerable<T> All()
        {
            var result = MyDbConnection.SelectQuery(TableName);
            foreach (DataRow row in result.Rows)
            {
                yield return CreateModel(row);
            }
            yield break;
        }

        public IEnumerable<T> Where(string condition)
        {
            var result = MyDbConnection.SelectConditionQuery(TableName,condition);
            foreach (DataRow row in result.Rows)
            {
                yield return CreateModel(row);
            }
            yield break;
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
    }
}
