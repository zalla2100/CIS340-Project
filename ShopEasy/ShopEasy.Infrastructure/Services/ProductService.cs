using System;
using System.Collections.Generic;
using System.Text;

namespace ShopEasy.Infrastructure
{
    public static class ProductService
    {
        public static bool DeleteProduct(int productId)
        {
            if (InvoiceService.DeleteInvoices(productId, "ProductId")) //checks if command executed w/o errors, though invoices may not have been deleted
            {
                try
                {
                    return ProductContext.DeleteProduct(productId);
                }
                catch
                {
                    return false;
                }
            }

            return false;
        }
    }
}
