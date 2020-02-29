using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    class MyDbConnection
    {
        const string server = "127.0.0.1";
        const string user = "root";
        const string password = "";
        const string database = "SCADI";

        private static MySqlConnection Con()
            => new MySqlConnection(String.Format("Server={0}; Database={1}; Uid={2}; Pwd={3};",
                server, database, user, password));

        public static int Query(string query, MySqlParameter[] parameters = null)
        {
            var con = Con();
            con.Open();
            MySqlCommand command = new MySqlCommand(query, con);
            if (parameters != null)
            {
                command.Parameters.AddRange(parameters);
            }
            var result = command.ExecuteNonQuery();
            con.Close();
            return result;

        }

        static public DataTable ResponseQuery(string query)
        {
            var con = Con();
            con.Open();
            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(query, con);
            da.Fill(ds);
            da.Dispose();
            con.Close();
            return ds.Tables[0];
        }


        public static int Delete(string table, int id)
        {
            string query = String.Format("DELETE {0} WHERE id={1}", table, id);
            return Query(query);
        }

        #region SELECT
        static public object SelectSingleValue(string table, string column)
        {
            string query = String.Format("SELECT {0} FROM {1}", column, table);
            return ResponseQuery(query).Rows[0][0];
        }

        static public object SelectSingleValue(string table, string column, int id)
        {
            string query = String.Format("SELECT {0} FROM {1} WHERE id={2}", column, table, id);
            return ResponseQuery(query).Rows[0][0];
        }

        static public object SelectMaxValue(string table, string column)
        {
            string query = String.Format("SELECT MAX({0}) FROM {1}", column, table);
            return ResponseQuery(query).Rows[0][0];
        }

        static public DataTable SelectQuery(string table, params string[] selectFields)
        {
            string select = selectFields.Length > 0 ? String.Join(", ", selectFields) : "*";
            string query = String.Format("SELECT {0} FROM {1}",
                select, table);
            return ResponseQuery(query);
        }
        static public DataRow SelectById(string table, int id)
        {
            string query = String.Format("SELECT * FROM {0} WHERE id={1}",
                table, id);
            var result = ResponseQuery(query);
            return result.Rows.Count == 0
                ? null
                : result.Rows[0];
        }

        static public DataRow SelectFirst(string table, string column = "id", bool asscending = true)
        {
            string query = String.Format("SELECT * FROM {0} ORDER BY {1} {2}",
                table, column, asscending ? "ASC" : "DESC");
            var result = ResponseQuery(query);
            return result.Rows.Count == 0
                ? null
                : result.Rows[0];
        }

        static public DataTable SelectConditionQuery(string table, string condition, params string[] selectFields)
        {
            string select = selectFields.Length > 0 ? String.Join(", ", selectFields) : "*";
            string query = String.Format("SELECT {0} FROM {1} WHERE {2}",
                select, table, condition);
            return ResponseQuery(query);
        }


        #endregion

        static public int UpdateSingleValue(string table, string column, object value, int id = 1)
        {
            string query = String.Format("UPDATE {0} SET {1}={2} WHERE id={3}", table, column, value, id);
            return Query(query);
        }
    }
}
