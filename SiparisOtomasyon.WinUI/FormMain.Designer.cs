
namespace SiparisOtomasyon.WinUI
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.müşteriİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCustomerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CustomerListMenuıtem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newProductMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProductlistMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.siparişİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOrderMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newOrderListmenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tanımlamalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.müşteriİşlemleriToolStripMenuItem,
            this.ürünİşlemleriToolStripMenuItem,
            this.siparişİşlemleriToolStripMenuItem,
            this.tanımlamalarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // müşteriİşlemleriToolStripMenuItem
            // 
            this.müşteriİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCustomerMenuItem,
            this.CustomerListMenuıtem});
            this.müşteriİşlemleriToolStripMenuItem.Name = "müşteriİşlemleriToolStripMenuItem";
            this.müşteriİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.müşteriİşlemleriToolStripMenuItem.Text = "Müşteri İşlemleri";
            // 
            // newCustomerMenuItem
            // 
            this.newCustomerMenuItem.Name = "newCustomerMenuItem";
            this.newCustomerMenuItem.Size = new System.Drawing.Size(149, 22);
            this.newCustomerMenuItem.Text = "Yeni Müşteri";
            this.newCustomerMenuItem.Click += new System.EventHandler(this.newCustomerMenuItem_Click);
            // 
            // CustomerListMenuıtem
            // 
            this.CustomerListMenuıtem.Name = "CustomerListMenuıtem";
            this.CustomerListMenuıtem.Size = new System.Drawing.Size(149, 22);
            this.CustomerListMenuıtem.Text = "Müşteri Listesi";
            this.CustomerListMenuıtem.Click += new System.EventHandler(this.CustomerListMenuıtem_Click);
            // 
            // ürünİşlemleriToolStripMenuItem
            // 
            this.ürünİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProductMenuItem,
            this.ProductlistMenuItem});
            this.ürünİşlemleriToolStripMenuItem.Name = "ürünİşlemleriToolStripMenuItem";
            this.ürünİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.ürünİşlemleriToolStripMenuItem.Text = "Ürün İşlemleri";
            // 
            // newProductMenuItem
            // 
            this.newProductMenuItem.Name = "newProductMenuItem";
            this.newProductMenuItem.Size = new System.Drawing.Size(135, 22);
            this.newProductMenuItem.Text = "Yeni Ürün";
            this.newProductMenuItem.Click += new System.EventHandler(this.newProductMenuItem_Click);
            // 
            // ProductlistMenuItem
            // 
            this.ProductlistMenuItem.Name = "ProductlistMenuItem";
            this.ProductlistMenuItem.Size = new System.Drawing.Size(135, 22);
            this.ProductlistMenuItem.Text = "Ürün Listesi";
            this.ProductlistMenuItem.Click += new System.EventHandler(this.ProductlistMenuItem_Click);
            // 
            // siparişİşlemleriToolStripMenuItem
            // 
            this.siparişİşlemleriToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newOrderMenuItem,
            this.newOrderListmenuItem});
            this.siparişİşlemleriToolStripMenuItem.Name = "siparişİşlemleriToolStripMenuItem";
            this.siparişİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.siparişİşlemleriToolStripMenuItem.Text = "Sipariş İşlemleri";
            // 
            // newOrderMenuItem
            // 
            this.newOrderMenuItem.Name = "newOrderMenuItem";
            this.newOrderMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newOrderMenuItem.Text = "Yeni Sipariş";
            this.newOrderMenuItem.Click += new System.EventHandler(this.newOrderMenuItem_Click);
            // 
            // newOrderListmenuItem
            // 
            this.newOrderListmenuItem.Name = "newOrderListmenuItem";
            this.newOrderListmenuItem.Size = new System.Drawing.Size(143, 22);
            this.newOrderListmenuItem.Text = "Sipariş Listesi";
            this.newOrderListmenuItem.Click += new System.EventHandler(this.newOrderListmenuItem_Click);
            // 
            // tanımlamalarToolStripMenuItem
            // 
            this.tanımlamalarToolStripMenuItem.Name = "tanımlamalarToolStripMenuItem";
            this.tanımlamalarToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.tanımlamalarToolStripMenuItem.Text = "Tanımlamalar";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 415);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Siparis Otomasyon";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem müşteriİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCustomerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CustomerListMenuıtem;
        private System.Windows.Forms.ToolStripMenuItem ürünİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem siparişİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tanımlamalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newProductMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProductlistMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newOrderListmenuItem;
    }
}

