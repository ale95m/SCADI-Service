using MySqlRepository.Base;
using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.SQL.MySQL
{
    public abstract class MySqlWhereNullOrNotNull : ISqlWhere
    {
        public string ColumnName { get; private set; }
        public string Operator { get; private set; }
        public LogicOperator LogicOperator { get; private set; } = LogicOperator.AND;

        public MySqlWhereNullOrNotNull(string columnName,string @operator, LogicOperator logicOperator = LogicOperator.AND)
        {
            ColumnName = columnName.ToUnderscoreCase();
            Operator = @operator;
        }

        public override string ToString()
        {
            return string.Format(" {0} {1} ", ColumnName, Operator);
        }
    }
}
