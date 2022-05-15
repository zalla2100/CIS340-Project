using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ShopEasy.UI
{
    public partial class ProductOrderForm : Form
    {
        private ShopEasyDBContext context;
        private Products product;
        private Customers customer;
        private Invoices invoice = new Invoices();

        private static readonly CultureInfo ci = new CultureInfo("en-us");

        public ProductOrderForm(Customers customer, int productId, ref ShopEasyDBContext context)
        {
            InitializeComponent();

            this.customer = customer;
            this.context = context;
            product = context.Products.Find(productId);

            invoice.ProductId = productId;
            invoice.CustomerId = customer.Id;
            invoice.ItemPrice = product.Price;
            invoice.Tax = 0.00m;

            productNameText.Text = product.Name;
            priceText.Text = FormatCurrency(product.Price);

            this.quantityInput_ValueChanged(null, null);
        }

        private void quantityInput_ValueChanged(object sender, EventArgs e)
        {
            invoice.Quantity = (int)quantityInput.Value;
            invoice.SubTotal = Math.Round(invoice.ItemPrice * invoice.Quantity, 2);

            if (customer.IsVeteran)
            {
                invoice.Discount = Math.Round(invoice.SubTotal * 0.10m, 2);
            }
            else if (customer.IsSenior)
            {
                invoice.Discount = Math.Round(invoice.SubTotal * 0.05m, 2);
            }
            else
            {
                invoice.Discount = 0.00m;
            }

            invoice.TotalValue = Math.Round(invoice.SubTotal - invoice.Discount, 2);

            discountText.Text = FormatCurrency(invoice.Discount);
            subtotalText.Text = FormatCurrency(invoice.SubTotal);
            totalText.Text = FormatCurrency(invoice.TotalValue);
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            var orderMessage = $"{product.Name}\nQuantity: {invoice.Quantity}\nTotal: {FormatCurrency(invoice.TotalValue)}";
            var confirmOrder = MessageBox.Show(orderMessage, "Confirm Order", MessageBoxButtons.OKCancel);

            if (confirmOrder == DialogResult.OK)
            {
                try
                {
                    invoice.TimeStamp = DateTime.Now;
                    context.Invoices.Add(invoice);
                    context.SaveChanges();
                    this.Close();
                    MessageBox.Show("Order successfully submitted.");
                }
                catch
                {
                    MessageBox.Show("Failed to order product.");
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to cancel?\nYou have unsaved changes.",
                                    "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private string FormatCurrency(decimal value)
        {
            return value.ToString("C", ci);
        }
    }
}
