using System.Collections.Generic;

namespace MySqlRepository.SQL
{
    public interface IResponseQuery<T> where T : BaseModel
    {
        IEnumerable<T> Get();
        MysqlResponseQuery<T> OrderBy(OrderByMode orderByMode);
        MysqlResponseQuery<T> Where(string columnName, object value);
        MysqlResponseQuery<T> Where(string columnName, string @operator, object value);
    }
}