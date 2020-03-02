using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.SQL.MySQL
{
    public class MySqlWhereNull : MySqlWhereNullOrNotNull
    {
        public MySqlWhereNull(string columnName, LogicOperator logicOperator = LogicOperator.AND) : base(columnName, "IS NULL", logicOperator)
        {
        }
    }
}
