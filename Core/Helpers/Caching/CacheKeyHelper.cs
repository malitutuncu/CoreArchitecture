using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers.Caching
{
    public static class CacheKeyHelper
    {
        public static string GetKeyUserRoles(int userId)
        {
            return $"UserRoles:{userId}";
        }
    }
}
