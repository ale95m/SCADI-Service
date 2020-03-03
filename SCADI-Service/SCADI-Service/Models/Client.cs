using EasyORM.Attributes;
using MySqlRepository;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Client : BaseModel
    {

        public string Name { get;set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Ci { get; set; }
        public int ServiceId { get; set; }
    }
}
