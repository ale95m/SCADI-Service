using MySqlRepository;
using SCADI_Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Setting: BaseModel
    {
        public bool UpdateAccessPoint { get; private set; }

        public void SeAccessUpdatedPoints()
        {
            UpdateAccessPoint = true;
        }
    }
}
