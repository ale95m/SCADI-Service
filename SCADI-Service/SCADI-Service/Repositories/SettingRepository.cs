using MySqlRepository;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Repositories
{
    class SettingRepository : BaseStoreRepository<Setting>
    {
        private static readonly Lazy<SettingRepository> instance = new Lazy<SettingRepository>(() => new SettingRepository());
        public static SettingRepository Instance { get; } = instance.Value;
        private SettingRepository() { }

        public override string TableName { get; } = "settings";

        protected override Setting EmptyModel()
        {
            return new Setting();
        }

        public Setting GetSetting()
        {
            return FirstOrFail(1);
        }
    }
}
