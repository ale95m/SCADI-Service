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
    public abstract class BaseStoreRepository<T> :BaseRepository<T>, IStoreRepository<T> where T : IBaseStoreModel<T>
    {
        protected BaseStoreRepository() : base() { }
        
        public virtual bool Create(BaseStoreModel<T> model)
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

            return MyDbConnection.Query(query, parameters) == 1;
        }
        public virtual bool Update(BaseStoreModel<T> model)
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

            return MyDbConnection.Query(query, parameters) == 1;
        }

        protected virtual MySqlParameter[] GetStoreValues(BaseStoreModel<T> model)
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
        protected virtual MySqlParameter[] GetUpdateValues(BaseStoreModel<T> model) => GetStoreValues(model);

        public int Delete(T model)
        {
            return MyDbConnection.Delete(TableName, model.Id);
        }
    }
}
