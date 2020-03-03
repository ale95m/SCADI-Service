using MySqlRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCADI_Service.Models
{
    class Notification: BaseModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public int DeviceId { get; set; }
    }
}
