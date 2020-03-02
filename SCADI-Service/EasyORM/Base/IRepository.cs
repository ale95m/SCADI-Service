﻿using MySql.Data.MySqlClient;
using MySqlRepository.SQL;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public interface IRepository<T> where T: IBaseModel<T>
    {
        string PrimareKey { get; }
        bool TimeTamps { get; }
        bool SoftDelete { get; }
        string TableName { get; }
        IEnumerable<T> All();
        T Find(int id);
        T FirstOrFail(int id);
        IEnumerable<T> ExecuteSelectQuery(string query, DbParameter[] parameters);

        IResponseQuery<T> Where(string columnName, string @operator, object value);
        IResponseQuery<T> Where(string columnName, object value);
    }
}
