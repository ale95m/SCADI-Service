using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.SQL.MySQL
{
    public class MySqlWhereNotNull: MySqlWhereNullOrNotNull
    {
        public MySqlWhereNotNull(string columnName, LogicOperator logicOperator = LogicOperator.AND) : base(columnName, "IS NOT NULL", logicOperator)
        {
        }
    }
}
