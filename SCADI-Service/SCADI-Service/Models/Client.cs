using MySqlRepository;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Client: BaseStoreModel
    {
        private ClientRepository Repository { get; } = ClientRepository.Instance;

        public string Name { get; set; }
        public string First_surname { get; set; }
        public string second_surname { get; set; }
        public string ci { get; set; }
        public int service_id { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

        protected override bool Create()
        {
            return Repository.Create(this);
        }

        protected override bool Update()
        {
            return Repository.Update(this);
        }
    }
}
