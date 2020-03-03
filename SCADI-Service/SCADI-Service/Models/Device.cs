using MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Device: BaseModel
    {
        public string Ip { get; set; }
        public string Mac { get; set; }
        public string Description { get; set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime UpdatedAt { get; private set; }
        public Device(){ }
        public Device(string ip, string mac)
        {
            Ip = ip;
            Mac = mac;
            Description = "Unautorized";
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
    }
}
