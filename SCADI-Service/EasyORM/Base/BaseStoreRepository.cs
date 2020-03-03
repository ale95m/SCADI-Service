using MySql.Data.MySqlClient;
using MySqlRepository;
using MySqlRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseStoreRepository<T> : BaseRepository<T>, IStoreRepository<T> where T : IBaseModel, new()
    {
        protected BaseStoreRepository() : base() { }

        private bool SetId(T model, object id)
        {
            foreach (var column in ModelColumns)
            {
                if (column.Name == PrimareKey)
                {
                    column.Property.SetValue(model, id);
                    return true;
                }
            }
            return false;
        }

        public T Save(T model)
        {
            return model.Id == 0
                        ? Create(model)
                        : Update(model);
        }
        public T Create(T model)
        {
            MySqlParameter[] parameters = GetStoreValues(model);
            if (parameters.Length == 0)
            {
                throw new Exception("The array cannot be empty");
            }
            string columns = parameters[0].ParameterName,
                values = String.Concat("@", parameters[0].ParameterName);

            for (int i = 1; i < parameters.Length; i++)
            {
                columns = string.Concat(columns, ", ", parameters[i].ParameterName);
                values = string.Concat(values, ", @", parameters[i].ParameterName);
            }

            string query = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                TableName, columns, values);

            var result = MyDbConnection.Query(query, parameters) == 1;
            var id = Convert.ToInt32(MyDbConnection.ResponseQuery("SELECT LAST_INSERT_ID() as id").Rows[0][0]);
            if (SetId(model, id))
            {
                return model;
            }
            else
            {
                throw new Exception("Invalid primary key");
            }
        }
        public T Update(T model)
        {
            MySqlParameter[] parameters = GetUpdateValues(model);
            if (parameters.Length == 0)
            {
                throw new Exception("The array cannot be empty");
            }
            string sintax = String.Format("{0} = @{0}", parameters[0].ParameterName);

            for (int i = 1; i < parameters.Length; i++)
            {
                sintax = String.Format("{0}, {1} = @{1}", sintax, parameters[i].ParameterName);
            }

            string query = String.Format("UPDATE {0} SET {1} WHERE id={2}",
                TableName, sintax, model.Id);

            MyDbConnection.Query(query, parameters);
            return model;
        }

        protected virtual MySqlParameter[] GetStoreValues(IBaseModel model)
        {
            int length = ModelColumns.Count();
            MySqlParameter[] parameters = new MySqlParameter[length];
            int counter = 0;
            foreach (DbColumn column in ModelColumns)
            {
                parameters[counter++] = new MySqlParameter(column.Name, column.DbType)
                { Value = column.Property.GetValue(model) };
            }
            return parameters;
        }
        protected virtual MySqlParameter[] GetUpdateValues(IBaseModel model) => GetStoreValues(model);

        public int Delete(T model)
        {
            return MyDbConnection.Delete(TableName, model.Id);
        }
    }
}
