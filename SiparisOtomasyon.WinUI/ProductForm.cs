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
    using DAL.Contex;
    using BL.Abstract;
    using BL.Concrete;
    using Helper;

    public partial class ProductForm : Form
    {
        ICategoryBusiness categoryBusiness;
        ISupplierBusiness supplierBusiness;
        IProductBusiness productBusiness;
        public ProductForm()
        {
            InitializeComponent();
            productBusiness = new ProductBusiness();
            categoryBusiness = new CategoryBusiness();
            supplierBusiness = new SupplierBusiness();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillData();
        }

        private void FillControl()
        {
            FillCategory();
            Fillsuppliers();
        }

        private void Fillsuppliers()
        {
            var dataSource = supplierBusiness.Get();
            cmbSupplier.SetDataSourceFirstItems<int, Supplier>(dataSource, "CompanyName", "SupplierID", "Seçiniz");
        }

        private void FillCategory()
        {

            var categories = categoryBusiness.Get();
            cmbCategory.SetDataSourceFirstItems<int, Category>(categories, "CategoryName", "CategoryID", "Seçiniz");
        }

        Product selectedProduct = null;
        private void FillData()
        {
            int ProductId = Convert.ToInt32(this.Tag);
            if (ProductId > 0)
            {
                this.selectedProduct = productBusiness.GetById(ProductId);
                if (this.selectedProduct != null)
                {
                    txtProductName.Text = this.selectedProduct.ProductName;
                    txtQuantityPerUnit.Text = this.selectedProduct.QuantityPerUnit;
                    cmbCategory.SetSelectedValue(this.selectedProduct.CategoryID);
                    cmbSupplier.SetSelectedValue(this.selectedProduct.SupplierID);
                    nuUnitPrice.Value = Convert.ToDecimal(selectedProduct.UnitPrice);
                    nuUnitsInStock.Value = Convert.ToDecimal(selectedProduct.UnitsInStock);
                    nuUnitsOnOrder.Value = Convert.ToDecimal(selectedProduct.UnitsOnOrder);
                    nuReorderLevel.Value = Convert.ToDecimal(selectedProduct.ReorderLevel);
                    chkDiscontiuned.Checked = this.selectedProduct.Discontinued;
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            this.Tag = null;
            this.selectedProduct = null;
            UICoreUtility.FormClear(this);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            FormSave();

        }

        private void FormSave()
        {
            try
            {
                if (this.selectedProduct == null)
                {
                    this.selectedProduct = new Product();

                }
                this.selectedProduct.ProductName = txtProductName.Text;
                this.selectedProduct.QuantityPerUnit = txtQuantityPerUnit.Text;
                this.selectedProduct.UnitPrice = nuUnitPrice.Value;
                this.selectedProduct.UnitsInStock = Convert.ToInt16(nuUnitsInStock.Value);
                this.selectedProduct.UnitsOnOrder = Convert.ToInt16(nuUnitsOnOrder.Value);
                this.selectedProduct.ReorderLevel = Convert.ToInt16(nuReorderLevel.Value);
                this.selectedProduct.Discontinued = chkDiscontiuned.Checked;
                if (Convert.ToInt32(this.Tag) == 0)
                {
                    productBusiness.Add(this.selectedProduct);
                    this.Tag = this.selectedProduct.ProductID;
                }
                else
                {
                    productBusiness.Update(this.selectedProduct);
                }
                UICoreUtility.Successmessage("İşlem Başarılı Bir Şekilde Yapıldı");
            }
            catch (Exception ex)
            {

                UICoreUtility.Errormessage(ex.Message);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();
        }

        private void FormDelete()
        {
            try
            {
                if (UICoreUtility.DialogMessage("Bu Kaydı Silmek İstiyor Musunuz ? ") == DialogResult.OK)
                {
                    if (productBusiness.Delete(this.selectedProduct.ProductID))
                    {
                        UICoreUtility.Successmessage("Silme İşlemi Başarılı");
                        this.Close();
                    }
                    else
                    {
                        UICoreUtility.Errormessage("Silme İşlemi Sırasında hata Meydana Geldi.");
                    }

                }
            }
            catch (Exception ex)
            {

                UICoreUtility.Errormessage(ex.Message);
            }
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
