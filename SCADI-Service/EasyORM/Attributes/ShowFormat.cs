using EasyORM.Attributes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.Attributes
{
    class ShowFormat : Attribute
    {
        public string Format { get; private set; }
        public ShowFormat(string format)
        {
            Format = format;
        }
    }
}
