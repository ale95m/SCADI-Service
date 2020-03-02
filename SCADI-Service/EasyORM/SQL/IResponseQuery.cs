using MyRepository.SQL;
using System.Collections.Generic;

namespace MySqlRepository.SQL
{
    public interface IResponseQuery<T> where T : BaseModel
    {
        IEnumerable<T> Get();
        IResponseQuery<T> OrderBy(OrderByMode orderByMode);
        IResponseQuery<T> IncludeDeleteds();
        IResponseQuery<T> WhereNull(string columnName, LogicOperator logicOperator = LogicOperator.AND);
        IResponseQuery<T> WhereNotNull(string columnName, LogicOperator logicOperator = LogicOperator.AND);
        IResponseQuery<T> Where(string columnName, object value, LogicOperator logicOperator = LogicOperator.AND);
        IResponseQuery<T> Where(string columnName, string @operator, object value, LogicOperator logicOperator = LogicOperator.AND);
    }
}