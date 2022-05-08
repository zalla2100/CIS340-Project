using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class InvoiceService
    {
        public static bool DeleteInvoices(int productId)
        {
            try
            {
                InvoiceContext.DeleteInvoices(productId);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
