using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class AdminService
    {
        public static bool IsAdmin(int userId)
        {
            try
            {
                return AdminContext.IsUserAdmin(userId);
            }
            catch
            {
                return false;
            }
        }
    }
}
