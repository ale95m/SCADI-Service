using MySqlRepository;
using SCADI_Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Repositories
{
    class AccessPointRepository : BaseRepository<AccessPoint>
    {
        private static readonly Lazy<AccessPointRepository> instance = new Lazy<AccessPointRepository>(() => new AccessPointRepository());
        public static AccessPointRepository Instance
        {
            get { return instance.Value; }
        }
        private AccessPointRepository():base() { }

        public override string TableName
        {
            get
            {
                return "access_points";
            }
        }

        protected override AccessPoint EmptyModel()
        {
            return new AccessPoint();
        }
    }
}
