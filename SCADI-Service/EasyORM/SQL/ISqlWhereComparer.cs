using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRepository.SQL
{
    public interface ISqlWhereComparer: ISqlWhere
    {
        object Value { get; }
        DbParameter Parameter { get; }
    }
}
