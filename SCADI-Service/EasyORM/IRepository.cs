using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public interface IRepository<T> where T:BaseModel
    {
        string TableName { get; }
        IEnumerable<T> All();
        T Find(int id);
        T FirstOrFail(int id);
    }
}
