using MySqlRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.Base
{
    class ColumnsFactory
    {
        public static IEnumerable<DbColumn> GetColumns(Type type)
        {
            foreach (PropertyInfo property in type.GetProperties())
            {
                var attributes = property.GetCustomAttributes();
                if (attributes.Count(x=>x is NotMaped)==0)
                {
                    yield return new DbColumn(property, attributes);
                }
            }
            yield break;
        }
    }
}
