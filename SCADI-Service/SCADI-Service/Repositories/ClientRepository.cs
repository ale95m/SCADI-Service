using MySqlRepository;
using MySqlX.XDevAPI.Common;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Repositories
{
    class ClientRepository : BaseStoreRepository<Client>
    {
        private static readonly Lazy<ClientRepository> instance = new Lazy<ClientRepository>(() => new ClientRepository());
        public static ClientRepository Instance { get => instance.Value; }
        private ClientRepository():base() { }

        public override string TableName => "clients";

        protected override Client EmptyModel()
        {
            return new Client();
        }
    }
}
