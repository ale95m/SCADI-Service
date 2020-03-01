using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.SQL
{
    public class MysqlResponseQuery<T> : IResponseQuery<T> where T : BaseModel
    {
        IRepository<T> Repository { get; set; }
        Queue<MySqlWhere> Wheres { get; set; }
        string OrderByColumn { get; set; }
        bool WhithDeleted { get; set; } = false;


        OrderByMode OrderByMode { get; set; } = OrderByMode.ASC;

        public MysqlResponseQuery(IRepository<T> repository)
        {
            Repository = repository;
            Wheres = new Queue<MySqlWhere>();
        }

        public MysqlResponseQuery<T> IncludeDeleteds()
        {
            WhithDeleted = true;
            return this;
        }


        public MysqlResponseQuery<T> OrderBy(OrderByMode orderByMode)
        {
            OrderByMode = orderByMode;
            return this;
        }

        public MysqlResponseQuery<T> Where(string columnName, string @operator, object value)
        {
            Wheres.Enqueue(new MySqlWhere(Wheres.Count, columnName, value, @operator));
            return this;
        }
        public MysqlResponseQuery<T> Where(string columnName, object value)
        {
            Wheres.Enqueue(new MySqlWhere(Wheres.Count, columnName, value, "="));
            return this;
        }

        public IEnumerable<T> Get()
        {
            string orderByColumn = string.IsNullOrEmpty(OrderByColumn)
                ? Repository.PrimareKey
                : OrderByColumn;
            int top = Wheres.Count;
            string wheres = top == 0 ? string.Empty : " WHERE";
            MySqlParameter[] parameters = new MySqlParameter[top--];

            for (int i = 0; i <= top; i++)
            {
                var where = Wheres.Dequeue();
                parameters[i] = where.Parameter;
                wheres = string.Concat(wheres, where,
                    i < top ? where.LogicOperator.ToString() : string.Empty
                    );
            }
            string sintax = string.Format("SELECT * FROM {0}{1} ORDER BY {2} {3}",
                Repository.TableName, wheres, orderByColumn, OrderByMode);
            return Repository.ExecuteSelectQuery(sintax, parameters);
        }
    }
}
