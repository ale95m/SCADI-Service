using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.SQL
{
    public interface ISqlWhere
    {
        string ColumnName { get; }
        string Operator { get; }
        LogicOperator LogicOperator { get; }
    }
}
