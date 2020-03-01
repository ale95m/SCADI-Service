using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlRepository.Base
{
    public static class Extensions
    {
        public static string ToUnderscoreCase(this string camelCase)
        {
            return string.Concat(
                camelCase.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())
                ).ToLower();
        }
    }
}
