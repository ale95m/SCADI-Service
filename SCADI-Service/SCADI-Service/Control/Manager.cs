using SCADI_Service.Models;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SCADI_Service.Control
{
    class Manager
    {
        Timer timer;
        private static readonly Lazy<Manager> instance = new Lazy<Manager>(() => new Manager());
        public static Manager Instance
        {get { return instance.Value; } }
        private Manager() 
        {
            timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            CheckUpdateDevices();
        }

        List<AccessPoint> APs { get; } = new List<AccessPoint>();
        AccessPointRepository RepositoryAP { get; } = AccessPointRepository.Instance;
        SettingRepository RepositorySetting { get; } = SettingRepository.Instance;

        public void CheckUpdateDevices()
        {
            var setting = RepositorySetting.GetSetting();
            if (setting.UpdateAccessPoint)
            {
                setting.SeAccessUpdatedPoints();
                RepositorySetting.Save(setting);
                LoadAccessPoints();
            }
        }

        public void Start()
        {
            LoadAccessPoints();
            timer.Start(); 
        }
        public void Stop() => timer.Stop();

        /// <summary>
        /// Actualiza Los equipos desde la base de datos
        /// </summary>
        public void LoadAccessPoints()
        {
            List<int> updates = new List<int>();
            foreach (AccessPoint ap in RepositoryAP.All())
            {
                updates.Add(ap.Id);
                LoadSingleAP(ap);
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

        private void LoadSingleAP(AccessPoint ap)
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
