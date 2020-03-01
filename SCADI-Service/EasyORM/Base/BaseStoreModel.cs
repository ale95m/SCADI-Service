using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseStoreModel: BaseModel
    {
        public virtual bool Save()
        {
            return Id == 0
                    ? Create()
                    : Update();
        }
        protected abstract bool Create();
        protected abstract bool Update();
    }
}
