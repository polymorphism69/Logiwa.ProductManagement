namespace Logiwa.ProductManagement
{
    partial class MainMenu
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
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnListProduct = new System.Windows.Forms.Button();
            this.btnListCategories = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(21, 79);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 37);
            this.btnAddProduct.TabIndex = 0;
            this.btnAddProduct.Text = "Add/Delete Product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(102, 79);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(75, 37);
            this.btnAddCategory.TabIndex = 1;
            this.btnAddCategory.Text = "Add Delete Categories";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // btnListProduct
            // 
            this.btnListProduct.Location = new System.Drawing.Point(183, 79);
            this.btnListProduct.Name = "btnListProduct";
            this.btnListProduct.Size = new System.Drawing.Size(75, 37);
            this.btnListProduct.TabIndex = 2;
            this.btnListProduct.Text = "List Products";
            this.btnListProduct.UseVisualStyleBackColor = true;
            this.btnListProduct.Click += new System.EventHandler(this.btnListProduct_Click);
            // 
            // btnListCategories
            // 
            this.btnListCategories.Location = new System.Drawing.Point(264, 79);
            this.btnListCategories.Name = "btnListCategories";
            this.btnListCategories.Size = new System.Drawing.Size(75, 37);
            this.btnListCategories.TabIndex = 3;
            this.btnListCategories.Text = "List Categories";
            this.btnListCategories.UseVisualStyleBackColor = true;
            this.btnListCategories.Click += new System.EventHandler(this.btnListCategories_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 154);
            this.Controls.Add(this.btnListCategories);
            this.Controls.Add(this.btnListProduct);
            this.Controls.Add(this.btnAddCategory);
            this.Controls.Add(this.btnAddProduct);
            this.Name = "MainMenu";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.Button btnListProduct;
        private System.Windows.Forms.Button btnListCategories;
    }
}

