using MySqlRepository;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Repositories
{
    class ConnectionRepository : BaseStoreRepository<Connection>
    {
        private static readonly Lazy<ConnectionRepository> instance = new Lazy<ConnectionRepository>(() => new ConnectionRepository());
        public static ConnectionRepository Instance { get; } = instance.Value;
        private ConnectionRepository() { }

        public override string TableName
        {
            get
            {
               return "connections";
            }
        }

        protected override Connection EmptyModel()
        {
            return new Connection();
        }
    }
}
