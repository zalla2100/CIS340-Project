using ShopEasy.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static ShopEasy.Core.ProductCategories;

namespace ShopEasy.UI
{
    public partial class AddUpdateProductForm : Form
    {
        private ShopEasyDBContext context;
        private Products product;
        private bool isAdd;

        public AddUpdateProductForm(Products product, ref ShopEasyDBContext context)
        {
            this.context = context;
            this.isAdd = product == null;
            this.product = product == null ? new Products() : product;
            InitializeComponent();

            productCategoryList.Items.AddRange(ProductCategories.Categories.Select(x => x.Name).ToArray());

            if(!isAdd)
            {
                this.Text = "Update Product";
                productAddUpdateBtn.Text = "Update";
                productNameTxtBx.Text = product.Name;
                productPriceBx.Value = product.Price;
                productCategoryList.SelectedIndex = productCategoryList.Items.IndexOf(product.Category);

                var category = ProductCategories.Categories.Find(x => x.Name == product.Category);
                if(category.SubCategories.Count > 0)
                {
                    productSubcategoryList.Items.AddRange(category.SubCategories.ToArray());
                    productSubcategoryList.SelectedIndex = category.SubCategories.IndexOf(product.Category);
                    productSubcategoryList.Enabled = true;
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
            string categoryName = (string)productCategoryList.SelectedItem;
            ProductCategory category = ProductCategories.Categories.Find(x => x.Name == categoryName);
            productSubcategoryList.SelectedIndex = -1;
            productSubcategoryList.Items.Clear();

            if (category.SubCategories.Count > 0)
            {
                productSubcategoryList.Items.AddRange(category.SubCategories.ToArray());
                productSubcategoryList.Enabled = true;
            }
            else
            {
                productSubcategoryList.Enabled = false;
            }
        }

        private void productAddUpdateBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(productNameTxtBx.Text))
            {
                MessageBox.Show("Product name cannot be empty.");
                return;
            }
            if (productNameTxtBx.Text.Length > 40)
            {
                MessageBox.Show("Product name cannot be greater than 40 characters.");
                return;
            }
            if (productCategoryList.SelectedIndex == -1)
            {
                MessageBox.Show("Category is required.");
                return;
            }
            if (productSubcategoryList.Enabled && productSubcategoryList.SelectedIndex == -1)
            {
                MessageBox.Show("Subcategory is required.");
                return;
            }

            this.product.Name = productNameTxtBx.Text;
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
