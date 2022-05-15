namespace ShopEasy.UI
{
    partial class ProductOrderForm
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
            this.productLbl = new System.Windows.Forms.Label();
            this.productNameText = new System.Windows.Forms.Label();
            this.quantityLbl = new System.Windows.Forms.Label();
            this.quantityInput = new System.Windows.Forms.NumericUpDown();
            this.priceLbl = new System.Windows.Forms.Label();
            this.priceText = new System.Windows.Forms.Label();
            this.subtotalLbl = new System.Windows.Forms.Label();
            this.subtotalText = new System.Windows.Forms.Label();
            this.taxLbl = new System.Windows.Forms.Label();
            this.taxText = new System.Windows.Forms.Label();
            this.discountLbl = new System.Windows.Forms.Label();
            this.discountText = new System.Windows.Forms.Label();
            this.totalLbl = new System.Windows.Forms.Label();
            this.totalText = new System.Windows.Forms.Label();
            this.orderBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.quantityInput)).BeginInit();
            this.SuspendLayout();
            // 
            // productLbl
            // 
            this.productLbl.AutoSize = true;
            this.productLbl.Location = new System.Drawing.Point(43, 30);
            this.productLbl.Name = "productLbl";
            this.productLbl.Size = new System.Drawing.Size(60, 20);
            this.productLbl.TabIndex = 0;
            this.productLbl.Text = "Product";
            // 
            // productNameText
            // 
            this.productNameText.AutoSize = true;
            this.productNameText.Location = new System.Drawing.Point(174, 30);
            this.productNameText.Name = "productNameText";
            this.productNameText.Size = new System.Drawing.Size(101, 20);
            this.productNameText.TabIndex = 1;
            this.productNameText.Text = "productName";
            // 
            // quantityLbl
            // 
            this.quantityLbl.AutoSize = true;
            this.quantityLbl.Location = new System.Drawing.Point(43, 138);
            this.quantityLbl.Name = "quantityLbl";
            this.quantityLbl.Size = new System.Drawing.Size(65, 20);
            this.quantityLbl.TabIndex = 2;
            this.quantityLbl.Text = "Quantity";
            // 
            // quantityInput
            // 
            this.quantityInput.Location = new System.Drawing.Point(174, 138);
            this.quantityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityInput.Name = "quantityInput";
            this.quantityInput.Size = new System.Drawing.Size(101, 27);
            this.quantityInput.TabIndex = 3;
            this.quantityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityInput.ValueChanged += new System.EventHandler(this.quantityInput_ValueChanged);
            // 
            // priceLbl
            // 
            this.priceLbl.AutoSize = true;
            this.priceLbl.Location = new System.Drawing.Point(43, 86);
            this.priceLbl.Name = "priceLbl";
            this.priceLbl.Size = new System.Drawing.Size(41, 20);
            this.priceLbl.TabIndex = 4;
            this.priceLbl.Text = "Price";
            // 
            // priceText
            // 
            this.priceText.AutoSize = true;
            this.priceText.Location = new System.Drawing.Point(174, 86);
            this.priceText.Name = "priceText";
            this.priceText.Size = new System.Drawing.Size(44, 20);
            this.priceText.TabIndex = 5;
            this.priceText.Text = "$0.00";
            // 
            // subtotalLbl
            // 
            this.subtotalLbl.AutoSize = true;
            this.subtotalLbl.Location = new System.Drawing.Point(43, 210);
            this.subtotalLbl.Name = "subtotalLbl";
            this.subtotalLbl.Size = new System.Drawing.Size(65, 20);
            this.subtotalLbl.TabIndex = 6;
            this.subtotalLbl.Text = "Subtotal";
            // 
            // subtotalText
            // 
            this.subtotalText.AutoSize = true;
            this.subtotalText.Location = new System.Drawing.Point(174, 210);
            this.subtotalText.Name = "subtotalText";
            this.subtotalText.Size = new System.Drawing.Size(44, 20);
            this.subtotalText.TabIndex = 7;
            this.subtotalText.Text = "$0.00";
            // 
            // taxLbl
            // 
            this.taxLbl.AutoSize = true;
            this.taxLbl.Location = new System.Drawing.Point(43, 276);
            this.taxLbl.Name = "taxLbl";
            this.taxLbl.Size = new System.Drawing.Size(30, 20);
            this.taxLbl.TabIndex = 8;
            this.taxLbl.Text = "Tax";
            // 
            // taxText
            // 
            this.taxText.AutoSize = true;
            this.taxText.Location = new System.Drawing.Point(174, 276);
            this.taxText.Name = "taxText";
            this.taxText.Size = new System.Drawing.Size(44, 20);
            this.taxText.TabIndex = 9;
            this.taxText.Text = "$0.00";
            // 
            // discountLbl
            // 
            this.discountLbl.AutoSize = true;
            this.discountLbl.Location = new System.Drawing.Point(43, 335);
            this.discountLbl.Name = "discountLbl";
            this.discountLbl.Size = new System.Drawing.Size(67, 20);
            this.discountLbl.TabIndex = 10;
            this.discountLbl.Text = "Discount";
            // 
            // discountText
            // 
            this.discountText.AutoSize = true;
            this.discountText.Location = new System.Drawing.Point(174, 335);
            this.discountText.Name = "discountText";
            this.discountText.Size = new System.Drawing.Size(44, 20);
            this.discountText.TabIndex = 11;
            this.discountText.Text = "$0.00";
            // 
            // totalLbl
            // 
            this.totalLbl.AutoSize = true;
            this.totalLbl.Location = new System.Drawing.Point(43, 402);
            this.totalLbl.Name = "totalLbl";
            this.totalLbl.Size = new System.Drawing.Size(42, 20);
            this.totalLbl.TabIndex = 12;
            this.totalLbl.Text = "Total";
            // 
            // totalText
            // 
            this.totalText.AutoSize = true;
            this.totalText.Location = new System.Drawing.Point(174, 402);
            this.totalText.Name = "totalText";
            this.totalText.Size = new System.Drawing.Size(44, 20);
            this.totalText.TabIndex = 13;
            this.totalText.Text = "$0.00";
            // 
            // orderBtn
            // 
            this.orderBtn.Location = new System.Drawing.Point(74, 524);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(94, 29);
            this.orderBtn.TabIndex = 14;
            this.orderBtn.Text = "Order";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(340, 524);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(94, 29);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ProductOrderForm
            // 
            this.AcceptButton = this.orderBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(649, 588);
            this.ControlBox = false;
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.orderBtn);
            this.Controls.Add(this.totalText);
            this.Controls.Add(this.totalLbl);
            this.Controls.Add(this.discountText);
            this.Controls.Add(this.discountLbl);
            this.Controls.Add(this.taxText);
            this.Controls.Add(this.taxLbl);
            this.Controls.Add(this.subtotalText);
            this.Controls.Add(this.subtotalLbl);
            this.Controls.Add(this.priceText);
            this.Controls.Add(this.priceLbl);
            this.Controls.Add(this.quantityInput);
            this.Controls.Add(this.quantityLbl);
            this.Controls.Add(this.productNameText);
            this.Controls.Add(this.productLbl);
            this.Name = "ProductOrderForm";
            this.Text = "Order";
            ((System.ComponentModel.ISupportInitialize)(this.quantityInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label productLbl;
        private System.Windows.Forms.Label productNameText;
        private System.Windows.Forms.Label quantityLbl;
        private System.Windows.Forms.NumericUpDown quantityInput;
        private System.Windows.Forms.Label priceLbl;
        private System.Windows.Forms.Label priceText;
        private System.Windows.Forms.Label subtotalLbl;
        private System.Windows.Forms.Label subtotalText;
        private System.Windows.Forms.Label taxLbl;
        private System.Windows.Forms.Label taxText;
        private System.Windows.Forms.Label discountLbl;
        private System.Windows.Forms.Label discountText;
        private System.Windows.Forms.Label totalLbl;
        private System.Windows.Forms.Label totalText;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}