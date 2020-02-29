using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.Base
{
    class TypeFactory
    {
        public static object FromDbType(MySqlDbType dbType, object value)
        {
            switch (dbType)
            {
                case MySqlDbType.Decimal:
                    {
                        return Convert.ToDecimal(value);
                    }
                case MySqlDbType.Byte:
                    {
                        return Convert.ToByte(value);
                    }
                case MySqlDbType.Int16:
                    {
                        return Convert.ToInt16(value);
                    }
                case MySqlDbType.Int32:
                    {
                        return Convert.ToInt32(value);
                    }
                case MySqlDbType.Int64:
                    {
                        return Convert.ToInt64(value);
                    }
                case MySqlDbType.Float:
                    {
                        return float.Parse(value.ToString());
                    }
                case MySqlDbType.Double:
                    {
                        return Convert.ToDouble(value);
                    }
                case MySqlDbType.Timestamp:
                    {
                        return Convert.ToDateTime(value);
                    }
                case MySqlDbType.Date:
                    {
                        return Convert.ToDateTime(value);
                    }
                case MySqlDbType.Time:
                    {
                        return Convert.ToDateTime(value);
                    }
                case MySqlDbType.DateTime:
                    {
                        return Convert.ToDateTime(value);
                    }
                case MySqlDbType.Year:
                    {
                        return Convert.ToInt32(value);
                    }
                case MySqlDbType.Bit:
                    {
                        return Convert.ToBoolean(value);
                    }
                case MySqlDbType.String:
                    {
                        return Convert.ToString(value); ;
                    }
                case MySqlDbType.UInt16:
                    {
                        return Convert.ToUInt16(value);
                    }
                case MySqlDbType.UInt32:
                    {
                        return Convert.ToUInt32(value);
                    }
                case MySqlDbType.UInt64:
                    {
                        return Convert.ToUInt64(value);
                    }
                case MySqlDbType.Text:
                    {
                        return Convert.ToString(value);
                    }
                case MySqlDbType.Binary:
                    {
                        throw new Exception("Invalid type");
                    }
                case MySqlDbType.Guid:
                    {
                        throw new Exception("Invalid type");
                    }
                default:
                    {
                        throw new Exception("Invalid type");
                    }
            }
        }

        public static MySqlDbType ToDbType(Type type)
        {
            if (type==typeof(decimal))
            {
                return MySqlDbType.Decimal;
            }
            else if (type == typeof(string))
            {
                return MySqlDbType.String;
            }
            else if (type == typeof(byte))
            {
                return MySqlDbType.Byte;
            }
            else if (type == typeof(Int16))
            {
                return MySqlDbType.Int16;
            }
            else if (type == typeof(Int32))
            {
                return MySqlDbType.Int32;
            }
            else if (type == typeof(Int64))
            {
                return MySqlDbType.Int64;
            }
            else if (type == typeof(UInt16))
            {
                return MySqlDbType.UInt16;
            }
            else if (type == typeof(UInt32))
            {
                return MySqlDbType.UInt32;
            }
            else if (type == typeof(UInt64))
            {
                return MySqlDbType.UInt64;
            }
            else if (type == typeof(double))
            {
                return MySqlDbType.Double;
            }
            else if (type == typeof(float))
            {
                return MySqlDbType.Float;
            }
            else if (type == typeof(DateTime))
            {
                return MySqlDbType.DateTime;
            }
            else if (type == typeof(bool))
            {
                return MySqlDbType.Bit;
            }
            else
            {
                throw new Exception("Invalid type");
            }

        }
    }
}
