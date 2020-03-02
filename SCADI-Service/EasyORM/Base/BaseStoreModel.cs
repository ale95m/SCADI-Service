using MySqlRepository;
using MySqlRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseStoreModel<T> : IBaseStoreModel<T> where T : IBaseStoreModel<T>
    {
        public int Id {get; protected set;}

        [NotMaped]
        protected abstract IStoreRepository<T> Repository { get; }
        public virtual bool Save()
        {
            return Id == 0
                    ? Create()
                    : Update();
        }
        protected virtual bool Create() => Repository.Create(this);
        protected virtual bool Update() => Repository.Update(this);
        public BaseStoreModel() { }
    }
}
