using EasyORM.Attributes;
using MySql.Data.MySqlClient;
using MySqlRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.Base
{
    public class DbColumn
    {
        public MySqlDbType DbType { get; private set; }
        public string Name { get; set; }
        public string ShowFormat { get; private set; }

        public PropertyInfo Property { get;private set; }

        public DbColumn(PropertyInfo property, IEnumerable<Attribute> attributes)
        {
            Property = property;
            DbType = TypeFactory.ToDbType(Property.PropertyType);
            var columnName = CheckAttribute(attributes, typeof(ColumnName));
            Name = columnName == null ? property.Name : ((ColumnName)columnName).Name;
            var showFormat = CheckAttribute(attributes, typeof(ShowFormat));
            ShowFormat = showFormat == null ? "{0}" : ((ShowFormat)showFormat).Format;
        }

        Attribute CheckAttribute(IEnumerable<Attribute> attributes, Type type)
        {
            foreach (var item in attributes)
            {
                if (item.GetType() == type)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
