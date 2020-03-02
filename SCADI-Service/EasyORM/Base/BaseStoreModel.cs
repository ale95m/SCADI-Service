using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseStoreModel<T> : BaseModel where T : BaseStoreModel<T>
    {
        protected abstract IStoreRepository<T> Repository { get; }
        public virtual bool Save()
        {
            return Id == 0
                    ? Create()
                    : Update();
        }
        protected virtual bool Create() => Repository.Create(this);
        protected virtual bool Update() => Repository.Update(this);
    }
}
