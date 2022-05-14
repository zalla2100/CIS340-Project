using ShopEasy.Core;
using ShopEasy.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShopEasy.UI
{
    public partial class AddUpdateProductForm : Form
    {
        private ShopEasyDBContext context;
        private Products product;
        private bool isAdd;

        public AddUpdateProductForm(Products product, ref ShopEasyDBContext context)
        {
            InitializeComponent();

            this.context = context;
            this.isAdd = product == null;
            this.product = product == null ? new Products() : product;

            productCategoryList.Items.Clear();
            productCategoryList.Items.AddRange(context.ProductCategories.Where(x => x.ParentId == null).Select(x => x.Name).ToArray());

            if(!isAdd)
            {
                this.Text = "Update Product";
                productAddUpdateBtn.Text = "Update";
                productNameTxtBx.Text = product.Name;
                productPriceBx.Value = product.Price;
                productCategoryList.SelectedIndex = productCategoryList.Items.IndexOf(product.Category);

                productSubcategoryList.Items.Clear();
                var categoryId = context.ProductCategories.FirstOrDefault(x => x.ParentId == null && x.Name == product.Category).Id;
                var subCategories = context.ProductCategories.Where(x => x.ParentId == categoryId).Select(x => x.Name); 
                if(subCategories.Count() > 0)
                {
                    productSubcategoryList.Items.AddRange(subCategories.ToArray());
                    productSubcategoryList.SelectedIndex = Array.IndexOf(subCategories.ToArray(),product.SubCategory);
                    productSubcategoryList.Enabled = true;
                }
                else
                {
                    productSubcategoryList.Enabled = false;
                }
            }
            else
            {
                this.Text = "Add Product";
                productAddUpdateBtn.Text = "Add";
            }
        }

        private void productCategoryList_SelectedIndexChanged(object sender, EventArgs e)
        {
            productSubcategoryList.Items.Clear();
            productSubcategoryList.SelectedIndex = -1;

            string categoryName = (string)productCategoryList.SelectedItem;
            var categoryId = context.ProductCategories.FirstOrDefault(x => x.ParentId == null && x.Name == categoryName).Id;
            var subCategories = context.ProductCategories.Where(x => x.ParentId == categoryId).Select(x => x.Name);
            if (subCategories.Count() > 0)
            {
                productSubcategoryList.Items.AddRange(subCategories.ToArray());
                productSubcategoryList.Enabled = true;
            }
            else
            {
                productSubcategoryList.Enabled = false;
            }
        }

        private void productAddUpdateBtn_Click(object sender, EventArgs e)
        {
            string errors = Validator.ValidProduct(productNameTxtBx.Text.Trim(), productCategoryList.SelectedIndex,
                productSubcategoryList.Enabled, productSubcategoryList.SelectedIndex);

            if (errors != string.Empty)
            {
                MessageBox.Show(errors);
                return;
            }

            this.product.Name = productNameTxtBx.Text.Trim();
            this.product.Price = productPriceBx.Value;
            this.product.Category = (string)productCategoryList.Items[productCategoryList.SelectedIndex];
            this.product.SubCategory = productSubcategoryList.SelectedIndex > -1 ?
                (string)productSubcategoryList.Items[productSubcategoryList.SelectedIndex] : "N/A";

            if (isAdd)
            {
                try
                {
                    context.Products.Add(product);
                    context.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Failed to add product.");
                }
            }
            else
            {
                try
                {
                    context.Products.Update(product);
                    context.SaveChanges();
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Failed to update product.");
                }
            }
        }

        private void productCancel_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show($"Are you sure you want to cancel?\nYou have unsaved changes.",
                                    "Confirm Cancel", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
