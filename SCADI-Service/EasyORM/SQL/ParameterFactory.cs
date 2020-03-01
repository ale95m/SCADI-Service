using MySql.Data.MySqlClient;
using MySqlRepository.Base;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.SQL
{
    class ParameterFactory
    {
        public static MySqlParameter Create(string name, object value)
        {
            return new MySqlParameter(name, TypeFactory.ToDbType(value.GetType()))
            { Value = value };
        }
    }
}
