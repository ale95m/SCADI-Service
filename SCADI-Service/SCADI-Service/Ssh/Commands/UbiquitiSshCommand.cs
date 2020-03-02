using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Ssh.Commands
{
    public class UbiquitiSshCommand
    {
        public static string WirelessEnebled(string interfaceName = "wifi0")
            => String.Format("ifconfig {0} up", interfaceName);

        public static string WirelessDisable(string interfaceName = "wifi0")
            => String.Format("ifconfig {0} down", interfaceName);

        public static string Reboot()
            => "reboot";

        public static string GetRegistrationTable()
                    => "wstalist -i ath0";
    }
}
