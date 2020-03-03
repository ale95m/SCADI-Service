using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public interface IStoreRepository<T> : IRepository<T> where T : IBaseModel
    {
        T Create(T model);
        T Update(T model);
        T Save(T model);
    }
}
