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
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Ci { get; set; }
        public int ServiceId { get; set; }

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
