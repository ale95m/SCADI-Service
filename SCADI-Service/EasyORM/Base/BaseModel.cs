using MyRepository.Base;
using MySqlRepository;
using MySqlRepository.Attributes;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository
{
    public abstract class BaseModel : IBaseModel
    {
        public int Id { get; protected set; } = 0;
    }
}
