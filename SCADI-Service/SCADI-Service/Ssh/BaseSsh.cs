using Renci.SshNet;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Ssh
{
    class BaseSsh : ISsh
    {
        private SshClient mySshClient;
        protected virtual SshClient MySshClient
        { get { return mySshClient; } }


        public BaseSsh(AccessPoint ap)
        {
            mySshClient = new SshClient(ap.Ip, ap.SshPort, ap.SshUser, ap.SshPassword);
        }

        public bool Connect()
        {
            if (!MySshClient.IsConnected)
            {
                try
                {
                    MySshClient.Connect();
                }
                catch (Exception e)
                {
                    // logs 
                    return false;
                }
            }
            return true;
        }

        public bool Disconnect()
        {
            if (MySshClient.IsConnected)
            {
                try
                {
                    MySshClient.Disconnect();
                }
                catch (Exception e)
                {
                    // logs 
                    return false;
                }
            }
            return true;
        }

        public bool ExecuteCommand(string command)
        {
            if (Connect())
            {
                MySshClient.CreateCommand(command).Execute();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string ExecuteResponseCommand(string command)
        {
            if (Connect())
            {
                string result = MySshClient.CreateCommand(command).Execute();
                return result;
            }
            else
            {
                return String.Empty;
            }
        }
    }
}
