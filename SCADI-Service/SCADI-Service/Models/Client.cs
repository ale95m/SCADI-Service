using MySqlRepository;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Client : BaseStoreModel<Client>
    {
        protected override IStoreRepository<Client> Repository => ClientRepository.Instance;

        public string Name { get;private set; }
        public string FirstSurname { get; private set; }
        public string SecondSurname { get; private set; }
        public string Ci { get; private set; }
        public int ServiceId { get; private set; }
    }
}
