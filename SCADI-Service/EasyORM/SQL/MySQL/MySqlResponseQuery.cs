using MyRepository.SQL;
using MyRepository.SQL.MySQL;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.SQL.MySql
{
    public class MySqlResponseQuery<T> : IResponseQuery<T> where T : IBaseModel<T>
    {
        IRepository<T> Repository { get; set; }
        public Queue<ISqlWhere> Wheres { get; private set; }
        private string OrderByColumn { get; set; }
        private bool WhithDeleted { get; set; } = false;
        private UInt16 ParametersCount { get; set; } = 0;

        OrderByMode OrderByMode { get; set; } = OrderByMode.ASC;

        public MySqlResponseQuery(IRepository<T> repository)
        {
            Repository = repository;
            Wheres = new Queue<ISqlWhere>();
        }

        public IResponseQuery<T> IncludeDeleteds()
        {
            WhithDeleted = true;
            return this;
        }


        public IResponseQuery<T> OrderBy(OrderByMode orderByMode)
        {
            OrderByMode = orderByMode;
            return this;
        }

        public IEnumerable<T> Get()
        {
            if (Repository.SoftDelete & !WhithDeleted)
            {
                this.WhereNull("deleted_at");
            }

            string orderByColumn = string.IsNullOrEmpty(OrderByColumn)
                ? Repository.PrimareKey
                : OrderByColumn;

            string wheres = Wheres.Count == 0 ? string.Empty : " WHERE";

            DbParameter[] parameters = new DbParameter[ParametersCount];
            ParametersCount = 0;

            while (Wheres.Count>0)
            {
                var where = Wheres.Dequeue();
                if (where is ISqlWhereComparer)
                {
                    parameters[ParametersCount++] = ((ISqlWhereComparer)where).Parameter;
                }
                wheres = string.Concat(wheres, where,
                    Wheres.Count > 0 ? where.LogicOperator.ToString() : string.Empty
                    );
            }

            string sintax = string.Format("SELECT * FROM {0}{1} ORDER BY {2} {3}",
                Repository.TableName, wheres, orderByColumn, OrderByMode);
            return Repository.ExecuteSelectQuery(sintax, parameters);
        }

        private void AddWhereComparer(string columnName, string @operator, object value, LogicOperator logicOperator = LogicOperator.AND)
        {
            ParametersCount++;
            Wheres.Enqueue(new MySqlWhereComparer(Wheres.Count, columnName, value, @operator,logicOperator));
        }

        public IResponseQuery<T> Where(string columnName, string @operator, object value, LogicOperator logicOperator = LogicOperator.AND)
        {
            this.AddWhereComparer(columnName, @operator, value, logicOperator);
            return this;
        }
        public IResponseQuery<T> Where(string columnName, object value, LogicOperator logicOperator = LogicOperator.AND)
        {
            this.AddWhereComparer(columnName, "=", value, logicOperator);
            return this;
        }
        public IResponseQuery<T> WhereNull(string columnName,LogicOperator logicOperator=LogicOperator.AND)
        {
            Wheres.Enqueue(new MySqlWhereNull(columnName, logicOperator));
            return this;
        }
        public IResponseQuery<T> WhereNotNull(string columnName, LogicOperator logicOperator = LogicOperator.AND)
        {
            Wheres.Enqueue(new MySqlWhereNotNull(columnName, logicOperator));
            return this;
        }
    }
}
