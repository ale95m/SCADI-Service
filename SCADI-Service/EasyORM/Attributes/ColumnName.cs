using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace EasyORM.Attributes
{
    class ColumnName : Attribute
    {
        public string Name { get; private set; }
        public ColumnName(string name)
        {
            Name = name;
        }
    }
}
