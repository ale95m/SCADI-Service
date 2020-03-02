using SCADI_Service.Models;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Control
{
    class Manager
    {
        private static readonly Lazy<Manager> instance = new Lazy<Manager>(() => new Manager());
        public static Manager Instance
        {get { return instance.Value; } }
        private Manager() { }

        List<AccessPoint> APs { get; } = new List<AccessPoint>();
        AccessPointRepository RepositoryAP { get; } = AccessPointRepository.Instance;
        SettingRepository RepositorySetting { get; } = SettingRepository.Instance;

        public void CheckUpdateDevices()
        {
            var setting = RepositorySetting.GetSetting();
            if (setting.UpdateAccesPoints)
            {
                setting.SeAccesUpdatedPoints();
                setting.Save();
                LoadDevices();
            }
        }

        /// <summary>
        /// Actualiza Los equipos desde la base de datos
        /// </summary>
        public void LoadDevices()
        {
            List<int> updates = new List<int>();
            foreach (AccessPoint ap in RepositoryAP.All())
            {
                updates.Add(ap.Id);
                LoadAP(ap);
            }
            for (int i = 0; i < APs.Count; i++)
            {
                if (!updates.Contains(APs[i].Id))
                {
                    APs[i].Stop();
                    APs.RemoveAt(i--);
                }
            }
        }

        private void LoadAP(AccessPoint ap)
        {
            AccessPoint old = APs.FirstOrDefault(x => x.Id == ap.Id);
            if (old == null)
            {
                APs.Add(ap);
                ap.Start();
            }
            else
            {
                old.UpdateInfo(ap.Description, ap.Ip, ap.SshPort, ap.SshUser, ap.SshPassword, ap.Alarm, ap.Service);
            }
        }
    }
}
