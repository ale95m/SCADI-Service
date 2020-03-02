using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class AccesPoint
    {
        public string Description { get; set; }
        public string SshUser { get; set; }
        public string SshPassword { get; set; }
        public int SshPort { get; set; }
        public int AccessPointTypeId { get; set; }
        public string Ip { get; set; }
        public bool Alarm { get; set; }
        public string Location { get; set; }
        public bool Service { get; set; }
        public bool ServiceApplied { get; set; }
    }
}
