namespace ShopEasy.UI
{
    partial class AddUpdateProductForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.productNameLbl = new System.Windows.Forms.Label();
            this.productNameTxtBx = new System.Windows.Forms.TextBox();
            this.productPriceLbl = new System.Windows.Forms.Label();
            this.productPriceBx = new System.Windows.Forms.NumericUpDown();
            this.productCategoryLbl = new System.Windows.Forms.Label();
            this.productCategoryList = new System.Windows.Forms.ComboBox();
            this.productSubcategoryLbl = new System.Windows.Forms.Label();
            this.productSubcategoryList = new System.Windows.Forms.ComboBox();
            this.productAddUpdateBtn = new System.Windows.Forms.Button();
            this.productCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productPriceBx)).BeginInit();
            this.SuspendLayout();
            // 
            // productNameLbl
            // 
            this.productNameLbl.AutoSize = true;
            this.productNameLbl.Location = new System.Drawing.Point(91, 60);
            this.productNameLbl.Name = "productNameLbl";
            this.productNameLbl.Size = new System.Drawing.Size(49, 20);
            this.productNameLbl.TabIndex = 0;
            this.productNameLbl.Text = "Name";
            // 
            // productNameTxtBx
            // 
            this.productNameTxtBx.Location = new System.Drawing.Point(216, 60);
            this.productNameTxtBx.Name = "productNameTxtBx";
            this.productNameTxtBx.Size = new System.Drawing.Size(373, 27);
            this.productNameTxtBx.TabIndex = 1;
            // 
            // productPriceLbl
            // 
            this.productPriceLbl.AutoSize = true;
            this.productPriceLbl.Location = new System.Drawing.Point(91, 131);
            this.productPriceLbl.Name = "productPriceLbl";
            this.productPriceLbl.Size = new System.Drawing.Size(41, 20);
            this.productPriceLbl.TabIndex = 2;
            this.productPriceLbl.Text = "Price";
            // 
            // productPriceBx
            // 
            this.productPriceBx.DecimalPlaces = 2;
            this.productPriceBx.Location = new System.Drawing.Point(216, 131);
            this.productPriceBx.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.productPriceBx.Name = "productPriceBx";
            this.productPriceBx.Size = new System.Drawing.Size(138, 27);
            this.productPriceBx.TabIndex = 3;
            // 
            // productCategoryLbl
            // 
            this.productCategoryLbl.AutoSize = true;
            this.productCategoryLbl.Location = new System.Drawing.Point(91, 202);
            this.productCategoryLbl.Name = "productCategoryLbl";
            this.productCategoryLbl.Size = new System.Drawing.Size(69, 20);
            this.productCategoryLbl.TabIndex = 4;
            this.productCategoryLbl.Text = "Category";
            // 
            // productCategoryList
            // 
            this.productCategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productCategoryList.FormattingEnabled = true;
            this.productCategoryList.Location = new System.Drawing.Point(216, 202);
            this.productCategoryList.Name = "productCategoryList";
            this.productCategoryList.Size = new System.Drawing.Size(272, 28);
            this.productCategoryList.TabIndex = 5;
            this.productCategoryList.SelectedIndexChanged += new System.EventHandler(this.productCategoryList_SelectedIndexChanged);
            // 
            // productSubcategoryLbl
            // 
            this.productSubcategoryLbl.AutoSize = true;
            this.productSubcategoryLbl.Location = new System.Drawing.Point(91, 287);
            this.productSubcategoryLbl.Name = "productSubcategoryLbl";
            this.productSubcategoryLbl.Size = new System.Drawing.Size(92, 20);
            this.productSubcategoryLbl.TabIndex = 6;
            this.productSubcategoryLbl.Text = "Subcategory";
            // 
            // productSubcategoryList
            // 
            this.productSubcategoryList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.productSubcategoryList.Enabled = false;
            this.productSubcategoryList.FormattingEnabled = true;
            this.productSubcategoryList.Location = new System.Drawing.Point(216, 284);
            this.productSubcategoryList.Name = "productSubcategoryList";
            this.productSubcategoryList.Size = new System.Drawing.Size(272, 28);
            this.productSubcategoryList.TabIndex = 7;
            // 
            // productAddUpdateBtn
            // 
            this.productAddUpdateBtn.Location = new System.Drawing.Point(164, 385);
            this.productAddUpdateBtn.Name = "productAddUpdateBtn";
            this.productAddUpdateBtn.Size = new System.Drawing.Size(94, 29);
            this.productAddUpdateBtn.TabIndex = 8;
            this.productAddUpdateBtn.Text = "AddUpdate";
            this.productAddUpdateBtn.UseVisualStyleBackColor = true;
            this.productAddUpdateBtn.Click += new System.EventHandler(this.productAddUpdateBtn_Click);
            // 
            // productCancel
            // 
            this.productCancel.Location = new System.Drawing.Point(482, 385);
            this.productCancel.Name = "productCancel";
            this.productCancel.Size = new System.Drawing.Size(94, 29);
            this.productCancel.TabIndex = 9;
            this.productCancel.Text = "Cancel";
            this.productCancel.UseVisualStyleBackColor = true;
            this.productCancel.Click += new System.EventHandler(this.productCancel_Click);
            // 
            // AddUpdateProductForm
            // 
            this.AcceptButton = this.productAddUpdateBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.productCancel;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.productCancel);
            this.Controls.Add(this.productAddUpdateBtn);
            this.Controls.Add(this.productSubcategoryList);
            this.Controls.Add(this.productSubcategoryLbl);
            this.Controls.Add(this.productCategoryList);
            this.Controls.Add(this.productCategoryLbl);
            this.Controls.Add(this.productPriceBx);
            this.Controls.Add(this.productPriceLbl);
            this.Controls.Add(this.productNameTxtBx);
            this.Controls.Add(this.productNameLbl);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUpdateProductForm";
            this.Text = "AddUpdateProductForm";
            this.Load += new System.EventHandler(this.AddUpdateProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productPriceBx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productNameLbl;
        private System.Windows.Forms.TextBox productNameTxtBx;
        private System.Windows.Forms.Label productPriceLbl;
        private System.Windows.Forms.NumericUpDown productPriceBx;
        private System.Windows.Forms.Label productCategoryLbl;
        private System.Windows.Forms.ComboBox productCategoryList;
        private System.Windows.Forms.Label productSubcategoryLbl;
        private System.Windows.Forms.ComboBox productSubcategoryList;
        private System.Windows.Forms.Button productAddUpdateBtn;
        private System.Windows.Forms.Button productCancel;
    }
}