using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Device
    {
        public string IP { get; set; }
        public string Mac { get; set; }
        public string Description { get; set; }
        public int ClientId { get; set; }
        public int DeviceTypeId { get; set; }
    }
}
