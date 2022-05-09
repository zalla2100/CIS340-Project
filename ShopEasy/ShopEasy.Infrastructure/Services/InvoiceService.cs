using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class InvoiceService
    {
        public static bool DeleteInvoices(int id, string column)
        {
            try
            {
                InvoiceContext.DeleteInvoices(id, column);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
