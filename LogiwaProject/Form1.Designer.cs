namespace LogiwaProject
{
    partial class Form1
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
            this.btnAddDeleteProduct = new System.Windows.Forms.Button();
            this.btnAddDeleteCategories = new System.Windows.Forms.Button();
            this.btnListProducts = new System.Windows.Forms.Button();
            this.btnListCategories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddDeleteProduct
            // 
            this.btnAddDeleteProduct.Location = new System.Drawing.Point(33, 74);
            this.btnAddDeleteProduct.Name = "btnAddDeleteProduct";
            this.btnAddDeleteProduct.Size = new System.Drawing.Size(75, 43);
            this.btnAddDeleteProduct.TabIndex = 0;
            this.btnAddDeleteProduct.Text = "Add/Delete Products";
            this.btnAddDeleteProduct.UseVisualStyleBackColor = true;
            this.btnAddDeleteProduct.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddDeleteCategories
            // 
            this.btnAddDeleteCategories.Location = new System.Drawing.Point(114, 74);
            this.btnAddDeleteCategories.Name = "btnAddDeleteCategories";
            this.btnAddDeleteCategories.Size = new System.Drawing.Size(75, 43);
            this.btnAddDeleteCategories.TabIndex = 1;
            this.btnAddDeleteCategories.Text = "Add/DeleteCategories";
            this.btnAddDeleteCategories.UseVisualStyleBackColor = true;
            this.btnAddDeleteCategories.Click += new System.EventHandler(this.btnAddDeleteCategories_Click);
            // 
            // btnListProducts
            // 
            this.btnListProducts.Location = new System.Drawing.Point(195, 74);
            this.btnListProducts.Name = "btnListProducts";
            this.btnListProducts.Size = new System.Drawing.Size(75, 43);
            this.btnListProducts.TabIndex = 2;
            this.btnListProducts.Text = "List Products";
            this.btnListProducts.UseVisualStyleBackColor = true;
            this.btnListProducts.Click += new System.EventHandler(this.btnListProducts_Click);
            // 
            // btnListCategories
            // 
            this.btnListCategories.Location = new System.Drawing.Point(276, 74);
            this.btnListCategories.Name = "btnListCategories";
            this.btnListCategories.Size = new System.Drawing.Size(75, 43);
            this.btnListCategories.TabIndex = 3;
            this.btnListCategories.Text = "List Categories";
            this.btnListCategories.UseVisualStyleBackColor = true;
            this.btnListCategories.Click += new System.EventHandler(this.btnListCategories_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 169);
            this.Controls.Add(this.btnListCategories);
            this.Controls.Add(this.btnListProducts);
            this.Controls.Add(this.btnAddDeleteCategories);
            this.Controls.Add(this.btnAddDeleteProduct);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddDeleteProduct;
        private System.Windows.Forms.Button btnAddDeleteCategories;
        private System.Windows.Forms.Button btnListProducts;
        private System.Windows.Forms.Button btnListCategories;
    }
}

