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
    /// <summary>
    /// Form for customers to order desired product
    /// </summary>
    public partial class ProductOrderForm : Form
    {
        //Fields
        private ShopEasyDBContext context;
        private Products product;
        private Customers customer;
        private Invoices invoice = new Invoices();

        private static readonly CultureInfo ci = new CultureInfo("en-us");

        /// <summary>
        /// Constructor. Initializes form based on selected product.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="productId"></param>
        /// <param name="context"></param>
        public ProductOrderForm(Customers customer, int productId, ref ShopEasyDBContext context)
        {
            InitializeComponent();

            this.customer = customer;
            this.context = context;
            product = context.Products.Find(productId);

            invoice.ProductId = productId;
            invoice.CustomerId = customer.Id;
            invoice.ItemPrice = product.Price;
            invoice.Tax = 0.00m; //Tax not calculated

            productNameText.Text = product.Name;
            priceText.Text = FormatCurrency(product.Price);

            this.quantityInput_ValueChanged(null, null); //calulcate totals and intialize form values
        }

        /// <summary>
        /// Calculates subtotal, discount, and total for the invoice according to selected product and customer status.
        /// <para>Updates respective form text.</para>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void quantityInput_ValueChanged(object sender, EventArgs e)
        {
            invoice.Quantity = (int)quantityInput.Value;
            invoice.SubTotal = Math.Round(invoice.ItemPrice * invoice.Quantity, 2);

            //Discount based on veteran and senior status. In the event of both, only the veteran discount is applied.
            if (customer.IsVeteran)
            {
                //10% veteran discount
                invoice.Discount = Math.Round(invoice.SubTotal * 0.10m, 2);
            }
            else if (customer.IsSenior)
            {
                //5% senior discount
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

        /// <summary>
        /// Displays confirmation then adds invoice to DB.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Displays confirmation. If confirmed, closes the form and all modifications are lost.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to cancel?\nYou have unsaved changes.",
                                    "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        /// <summary>
        /// Formats monetary value into a user friendly string
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A string in USD money format</returns>
        private string FormatCurrency(decimal value)
        {
            return value.ToString("C", ci);
        }
    }
}
