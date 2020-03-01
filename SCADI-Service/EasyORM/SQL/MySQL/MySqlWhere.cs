using EasyORM.Attributes;
using MySql.Data.MySqlClient;
using MySqlRepository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.SQL
{
    class MySqlWhere
    {
        public int Id { get; private set; }
        public string ColumnName { get; private set; }
        public object Value { get; private set; }
        public string Operator { get; private set; }
        public MySqlParameter Parameter { get; private set; }

        public LogicOperator LogicOperator { get; private set; }

        public MySqlWhere(int id,string columnName, object value, string @operator, LogicOperator logicOperator= LogicOperator.AND)
        {
            Id = id;
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
