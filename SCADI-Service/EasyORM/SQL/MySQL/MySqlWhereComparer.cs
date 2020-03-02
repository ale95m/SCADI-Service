using EasyORM.Attributes;
using MyRepository.SQL;
using MySql.Data.MySqlClient;
using MySqlRepository.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.SQL
{
    class MySqlWhereComparer : ISqlWhereComparer
    {
        public int Id { get; private set; }
        public string ColumnName { get; private set; }
        public object Value { get; private set; }
        public string Operator { get; private set; }
        public DbParameter Parameter { get; private set; }

        public LogicOperator LogicOperator { get; private set; }


        public MySqlWhereComparer(int id,string columnName, object value, string @operator, LogicOperator logicOperator= LogicOperator.AND)
        {
            ColumnName = columnName.ToUnderscoreCase();
            Value = value;
            Operator = @operator;
            string parameterName = "SqlWere" + id;
            Parameter = ParameterFactory.Create(parameterName, value);
        }
        public override string ToString()
        {
            return string.Format(" {0} {1} @{2} ", ColumnName, Operator, Parameter.ParameterName);
        }
    }
}
