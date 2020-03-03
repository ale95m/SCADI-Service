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
    class Connection : BaseModel
    {
        #region Properties
        public int AccessPointId { get; private set; }
        public double Upload { get; private set; }
        public double Download { get; private set; }
        public string Ip { get; private set; }
        public int SignalStrength { get; private set; }
        public int DeviceId { get; private set; }
        public string Mac { get; private set; }
        [ColumnName("created_at")]
        public DateTime Start { get; private set; }
        [ColumnName("updated_at")]
        public DateTime Updated { get; private set; }
        public bool Ended { get; private set; }
        [NotMaped]
        public bool Checked { get; private set; } = true;

        [NotMaped]
        public Device Device { get; private set; }

        #endregion

        public Connection() { }
        public Connection(AccessPoint ap, double download, double upload, string ip, string mac, int signal, DateTime start, Device device)
        {
            AccessPointId = ap.Id;
            Download = download;
            Upload = upload;
            Ip = ip;
            Mac = mac;
            SignalStrength = signal;
            Start = DateTime.Now;
            Updated= DateTime.Now;
            Device = device;
            DeviceId = device.Id;
        }

        public void UpdateInfo(string ip, double upload, double download, int signal)
        {
            Ip = ip;
            Upload = upload;
            Download = download;
            SignalStrength = signal;
            Updated = DateTime.Now;
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

        public void Close()
        {
            Ended = true;
        }
    }
}
