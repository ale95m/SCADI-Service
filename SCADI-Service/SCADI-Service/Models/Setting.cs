using MySqlRepository;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Setting: BaseStoreModel<Setting>
    {
        protected override IStoreRepository<Setting> Repository { get; } = SettingRepository.Instance;

        public bool UpdateAccesPoints { get; private set; }

        public void SeAccesUpdatedPoints()
        {
            UpdateAccesPoints = true;
        }
    }
}
