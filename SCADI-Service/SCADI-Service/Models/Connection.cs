using EasyORM.Attributes;
using MySqlRepository;
using MySqlRepository.Attributes;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Connection:BaseStoreModel<Connection>
    {
        #region Properties
        public int AccessPointId { get;private set; }
        public double Upload { get; private set; }
        public double Download { get; private set; }
        public string Ip { get; private set; }
        public int SignalStrength { get; private set; }
        public string Mac { get; private set; }
        [ColumnName("created_at")]
        public DateTime Start { get; private set; }
        public bool Ended { get; private set; }
        [NotMaped]
        public bool Checked { get; private set; } = true;

        protected override IStoreRepository<Connection> Repository { get; } = ConnectionRepository.Instance;
        #endregion

        public Connection() { }
        public Connection(AccessPoint ap, double download, double upload, string ip, string mac, int signal, DateTime start)
        {
            AccessPointId = ap.Id;
            Download = download;
            Upload = upload;
            Ip = ip;
            Mac = mac;
            SignalStrength = signal;
        }

        public void UpdateInfo(string ip, double upload, double download, int signal)
        {
            Ip = ip;
            Upload = upload;
            Download = download;
            SignalStrength = signal;
            Start = DateTime.Now;
            CheckIn();
        }

        public void CheckIn()
        {
            Checked = true;
        }
        public void CheckOut()
        {
            Checked = false;
        }

        public bool Close()
        {
            Ended = true;
            return Update();
        }
    }
}
