using MySqlRepository;
using MySqlRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseModel<T> : IBaseModel<T> where T : IBaseModel<T>
    {
        [NotMaped]
        protected abstract IRepository<T> Repository { get; }
        public int Id { get; protected set; } = 0;
    }
}
