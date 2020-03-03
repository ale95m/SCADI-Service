using SCADI_Service.Models;
using SCADI_Service.Repositories;
using SCADI_Service.Ssh.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Ssh.Ubiquiti
{
    class UbiquitiSshAp : BaseSsh, ISshAccessPoint
    {


        public UbiquitiSshAp(AccessPoint ap) : base(ap) { }

        public bool BlockMac(string mac)
        {
            throw new NotImplementedException();
        }

        public bool DisableAccsesList()
        {
            throw new NotImplementedException();
        }

        public bool DisconnectMac(string mac)
        {
            throw new NotImplementedException();
        }

        public bool EnableAccsesList()
        {
            throw new NotImplementedException();
        }

        public bool Reboot()
        {
            return ExecuteCommand(UbiquitiSshCommand.Reboot());
        }

        public bool StartWlan()
        {
            return ExecuteCommand(UbiquitiSshCommand.WirelessEnebled())
                & Reboot();
        }

        public bool StopWlan()
        {
            return ExecuteCommand(UbiquitiSshCommand.WirelessDisable());
        }

        public void UpdateConnections(AccessPoint ap)
        {
            string result = ExecuteResponseCommand(UbiquitiSshCommand.GetRegistrationTable());
            string[] spliter = new string[] { "\"mac\": \"" };
            string[] results = result.Split(spliter, StringSplitOptions.None);
            for (int i = 1; i < results.Length; i++)
            {
                string mac;
                string ip;
                double upload;
                double download;
                int uptime;
                int signal;
                ExtractConnectionInfo(results[i],
                        out mac,
                        out ip,
                        out upload,
                        out download,
                        out uptime,
                        out signal);

                var connection = ap.Connections.FirstOrDefault(x => x.Mac == mac);
                if (connection == null)
                {
                    TimeSpan currentUptime = new TimeSpan(0, 0, uptime);
                    DateTime start = DateTime.Now - currentUptime;
                    var device= DeviceRepository.Instance.FindByMac(mac,ip);
                    connection = new Connection(ap, download, upload, ip, mac, signal, start,device);
                    ap.Connections.Add(connection);
                }
                else
                {
                    connection.UpdateInfo(ip, upload, download, signal);
                }
                ConnectionRepository.Instance.Save(connection);
            }
        }
        

        void ExtractConnectionInfo(string info, out string mac, out string ip, out double upload, out double download, out int uptime, out int signal)
        {
            //mac
            mac = info.Substring(0, info.IndexOf('"'));

            //ip
            string[] spliter = new string[] { "\"lastip\" : \"" };
            string aux = info.Split(spliter, 2, StringSplitOptions.None)[1];
            ip = aux.Substring(0, aux.IndexOf('"'));

            //signal
            spliter[0] = "\"signal\" : ";
            aux = info.Split(spliter, 2, StringSplitOptions.None)[1];
            signal = Convert.ToInt32(aux.Substring(0, aux.IndexOf(',')));

            //uptime
            spliter[0] = "\"uptime\" : ";
            aux = info.Split(spliter, 2, StringSplitOptions.None)[1];
            uptime = Convert.ToInt32(aux.Substring(0, aux.IndexOf(',')));

            //download and upload en Bytes
            spliter[0] = "\"rx_bytes\" : ";
            aux = info.Split(spliter, 2, StringSplitOptions.None)[1];
            download = Convert.ToDouble(aux.Substring(0, aux.IndexOf(',')));

            spliter[0] = "\"tx_bytes\" : ";
            aux = info.Split(spliter, 2, StringSplitOptions.None)[1];
            upload = Convert.ToDouble(aux.Substring(0, aux.IndexOf(',')));
        }

    }
}
