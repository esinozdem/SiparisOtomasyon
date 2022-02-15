using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiparisOtomasyon.WinUI
{
    using BL.Abstract;
    using BL.Concrete;
    using DAL.Contex;
    using Helper;
    using DAL.VM;
    public partial class ProductListForm : Form
    {
        IProductBusiness productBusiness;
        public ProductListForm()
        {
            InitializeComponent();
            productBusiness = new ProductBusiness();
        }

        private void ProductListForm_Load(object sender, EventArgs e)
        {
            FillColumnMapping();
            FillGrid();
        }

        private void FillGrid()
        {
            grdProductList.DataSource = null;
            grdProductList.DataSource = productBusiness.GetProductsVM();
        }

        private void FillColumnMapping()
        {
            grdProductList.AutoGenerateColumns = false;
            grdProductList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("ProductName", "ProductName", "Ürün Adı"));
            grdProductList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("CategoryName", "CategoryName", "Kategori Adı"));
            grdProductList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("SupplierName", "SupplierName", "Tedarikçi Adı"));
            grdProductList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("UnitPrice", "UnitPrice", "Fiyat"));
            grdProductList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("UnitsInStock", "UnitsInStock", "Mevcut Stok"));
        }



        private void grdProductList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var product = (grdProductList.DataSource as List<ProductVM>)[e.RowIndex];
            if (product != null)
            {
                var form = new ProductForm();
                form.MdiParent = this.MdiParent;
                form.Tag = product.ProductId;
                form.FormClosing += Form_FormClosing;
                form.Show();
            }
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            FillGrid();
        }

       
    }
}
