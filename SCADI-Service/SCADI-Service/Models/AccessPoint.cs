using MySqlRepository;
using MySqlRepository.Attributes;
using SCADI_Service.Repositories;
using SCADI_Service.Ssh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SCADI_Service.Models
{
    class AccessPoint:BaseModel<AccessPoint>
    {
        Timer timer;    

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

        [NotMaped]
        ISshAccessPoint SSH { get; set; }
        [NotMaped]
        public List<Connection> Connections { get; private set; } = new List<Connection>();
        [NotMaped]
        protected override IRepository<AccessPoint> Repository { get; } = AccessPointRepository.Instance;

        public AccessPoint()
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Update();
        }

        public void Start() => timer.Start();
        public void Stop() => timer.Stop();
        public void Update()
        {

        }

        public void UpdateInfo(string description, string ip, int sshPort, string sshUser, string sshPassword, bool alarm, bool service)
        {
            Description = description;
            Ip = ip;
            SshPort = sshPort;
            SshUser = sshUser;
            SshPassword = sshPassword;
            Alarm = alarm;
            Service = service;
        }

        public void UpdateConnections()
        {
            SSH.UpdateConnections(this);
            for (int i = 0; i < Connections.Count; i++)
            {
                if (Connections[i].Checked)
                {
                    Connections[i].CheckOut();
                }
                else
                {
                    Connections[i].Close();
                    Connections.RemoveAt(i--);
                }
            }
        }
    }
}
