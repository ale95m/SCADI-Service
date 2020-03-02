using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public interface IStoreRepository<T> : IRepository<T> where T : IBaseStoreModel<T>
    {
        bool Create(BaseStoreModel<T> model);
        bool Update(BaseStoreModel<T> model);
    }
}
