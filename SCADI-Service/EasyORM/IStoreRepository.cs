using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public interface IStoreRepository<T> : IRepository<T> where T : BaseModel
    {
        bool Create(T model);
        bool Update(T model);
    }
}
