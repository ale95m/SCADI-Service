using MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    abstract class Nomenclator: BaseModel
    {
        public string Name { get; protected set; }
    }
}
