using MyRepository.Base;
using MySqlRepository;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Repositories
{
    class ConnectionRepository : SingletonBaseStoreRepository<ConnectionRepository,Connection>
    {
        public override string TableName
        {
            get
            {
               return "connections";
            }
        }
    }
}
