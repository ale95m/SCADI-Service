using MyRepository.Base;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Repositories
{
    class DeviceRepository : SingletonBaseStoreRepository<DeviceRepository, Device>
    {
        public override string TableName => "devices";

        public Device FindByMac(string mac, string currentIp)
        {
            var devices = Where("mac", mac).IncludeDeleteds().Get();
            if (devices.Count()==0)
            {
                Device device = new Device(currentIp, mac);
                return Save(device);
            }
            else
            {
                return devices.First();
            }
        }
    }
}
