using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Ssh
{
    interface ISshAccessPoint:ISsh
    {
        bool Reboot();
        bool EnableAccsesList();
        bool DisableAccsesList();
        void UpdateConnections(AccessPoint ap);
        bool StartWlan();
        bool StopWlan();
        bool DisconnectMac(string mac);
        bool BlockMac(string mac);
    }
}
