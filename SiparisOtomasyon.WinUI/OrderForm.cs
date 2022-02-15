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
    using DAL.Contex;
    using BL.Concrete;
    using Helper;
    using DAL.VM;
    public partial class OrderForm : Form
    {
        ICustomerBusiness customerBusiness;
        IEmployeeBusiness employeeBusiness;
        IShippersBusiness shippersBusiness;
        IProductBusiness productBusiness;
        IOrderBusiness orderBusiness;
        IOrderDetailBusiness orderDetailBusiness;
        public OrderForm()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
            employeeBusiness = new EmployeeBusiness();
            shippersBusiness = new ShipperBusiness();
            productBusiness = new ProductBusiness();
            orderBusiness = new OrderBusiness();
            orderDetailBusiness = new OrderDetailBusiness();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
            FillControl();
            FillOrderDetailGridMapping();
            FillDataOrder();

        }

        private void FillOrderDetailGridMapping()
        {
            gridOrderDetail.AutoGenerateColumns = false;

            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("ProductName", "ProductName", "Ürün Adı"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("UnitPrice", "UnitPrice", "Birim Fiyatı"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("Quantity", "Quantity", "Adet"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("Discount", "Discount", "İndirim"));
            gridOrderDetail.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("Total", "Total", "Satır Toplam"));
            gridOrderDetail.Columns["Total"].DefaultCellStyle.Format = "N2"; //Virgülden sonra iki hane.
        }

        Order selectedorder = null;
        private void FillDataOrder()
        {
            int id = Convert.ToInt32(this.Tag);
            if (id > 0)
            {
                var order = orderBusiness.GetById(id);
                if (order != null)
                {
                    selectedorder = order;
                    cmbCustomer.SetSelectedValue(order.CustomerID);
                    cmbEmployee.SetSelectedValue(order.EmployeeID);
                    cmbShipVia.SetSelectedValue(order.ShipVia);
                    dtOrderDate.Value = Convert.ToDateTime(order.OrderDate);
                    dtRequiredDate.Value = Convert.ToDateTime(order.RequiredDate);
                    dtShippedDate.Value = Convert.ToDateTime(order.ShippedDate);
                    nuFreight.Value = Convert.ToDecimal(order.Freight);
                    txtShipName.Text = order.ShipName;
                    txtShipCiyt.Text = order.ShipCity;
                    txtShipCountry.Text = order.ShipCountry;
                    txtShipAddress.Text = order.ShipAddress;
                    txtShipPostalCode.Text = order.ShipPostalCode;
                    txtShipRegion.Text = order.ShipRegion;

                    FillDataOrderDetail(id);

                    
                }
            }
        }
        //Sipariş Detayını doldurmak için kullanılacak.
        private void FillDataOrderDetail(int id)
        {
            if (id>0)
            {
                var orderDetail = orderDetailBusiness.GetOrderDetailVM(id);
                gridOrderDetail.DataSource = null;
                gridOrderDetail.DataSource = orderDetail;
            }
        }

        private void FillControl()
        {
            FillCustomer();
            FillPersonal();
            FillShippers();
            FillProduct();
        }

        private void FillShippers()
        {
            var shippers = shippersBusiness.Get();
            cmbShipVia.SetDataSourceFirstItems<int, Shipper>(shippers, "CompanyName", "ShipperID", "Seçiniz");
        }

        private void FillCustomer()
        {
            cmbCustomer.DataSource = customerBusiness.Get();
            cmbCustomer.DisplayMember = "CompanyName";
            cmbCustomer.ValueMember = "CustomerID";

        }
        public void FillPersonal()
        {
            var employess = employeeBusiness.Get();
            cmbEmployee.SetDataSourceFirstItems<int, Employee>(employess, "FirstName", "EmployeeID", "Seçiniz");
        }
        public void FillProduct()
        {
            var products = productBusiness.Get();
            cmbProduct.SetDataSourceFirstItems<int, Product>(products, "ProductName", "ProductID", "Seçiniz");
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FormSave();
        }

        private void FormSave()
        {
            try
            {

                if (this.selectedorder == null)
                {
                    selectedorder = new Order();
                }
                selectedorder.CustomerID = cmbCustomer.SelectedValue.ToString();
                selectedorder.EmployeeID = cmbEmployee.GetValue<int, Employee>();
                selectedorder.ShipVia = cmbShipVia.GetValue<int, Shipper>();
                selectedorder.OrderDate = dtOrderDate.Value;
                selectedorder.RequiredDate = dtRequiredDate.Value;
                selectedorder.ShippedDate = dtShippedDate.Value;
                selectedorder.Freight = nuFreight.Value;
                selectedorder.ShipName = txtShipName.Text;
                selectedorder.ShipAddress = txtShipAddress.Text;
                selectedorder.ShipCity = txtShipCiyt.Text;
                selectedorder.ShipCountry = txtShipCountry.Text;
                selectedorder.ShipPostalCode = txtShipPostalCode.Text;
                selectedorder.ShipRegion = txtShipRegion.Text;

                if (Convert.ToInt32(this.Tag)>0)
                {
                    orderBusiness.Update(this.selectedorder);
                }
                else
                {
                    orderBusiness.Add(this.selectedorder);
                    this.Tag = selectedorder.OrderID;
                }
                UICoreUtility.Successmessage("İşlem başarılı bir şekilde gerçekleşti.");

            }
            catch (Exception ex)
            {
                UICoreUtility.Errormessage(ex.Message);
            }
            
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            UICoreUtility.FormClear(this);
            this.selectedorder = null;
            this.selectedOrderDetail = null;
            this.Tag = 0;
            gridOrderDetail.DataSource = null;
        }

        //OrderDetail Ekleme.
        Order_Detail selectedOrderDetail;
        private void btnOrderDetailAdd_Click(object sender, EventArgs e)
        {
            try
            {
                bool isAdded = false;
                if (selectedorder == null)
                {
                    UICoreUtility.Errormessage("Lütfen Önce Sipariş Kaydı Yapınız.");
                    return;
                }
                if (cmbCustomer.SelectedValue == null)
                {
                    UICoreUtility.Errormessage("Lütfen Bir ürün Seçimi Yapınız.");
                    cmbProduct.Focus();
                    return;
                }
                if (nuUnitPrice.Value == 0)
                {
                    UICoreUtility.Errormessage("Lütfen ürün fiyat Girişi Yapınız.");
                    nuUnitPrice.Focus();
                    return;
                }
                if (nuQuantity.Value == 0)
                {
                    UICoreUtility.Errormessage("Lütfen Miktar Girişi Yapınız.");
                    nuQuantity.Focus();
                    return;
                }
                if (selectedOrderDetail == null)
                {
                    selectedOrderDetail = new Order_Detail();
                    isAdded = true;
                }

                selectedOrderDetail.OrderID = selectedorder.OrderID;
                if(isAdded)
                selectedOrderDetail.ProductID = cmbProduct.GetValue<int, Product>().Value;
                selectedOrderDetail.UnitPrice = nuUnitPrice.Value;
                selectedOrderDetail.Quantity = Convert.ToInt16(nuQuantity.Value);
                selectedOrderDetail.Discount = Convert.ToSingle(nuDiscount.Value);

                if (isAdded)
                {
                    orderDetailBusiness.Add(selectedOrderDetail);
                }
                else
                {
                    orderDetailBusiness.Update(selectedOrderDetail);
                }
                FormOrderDetailClear();
                FillDataOrderDetail(selectedorder.OrderID);
                UICoreUtility.Successmessage("İşlem başarılı bir şekilde gerçekleşti.");
            }
            catch (Exception ex)
            {
                UICoreUtility.Errormessage(ex.Message);
                
            }
         
               
        }

        private void gridOrderDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var orderdetailItem = (gridOrderDetail.DataSource as List<OrderDetailVM>)[e.RowIndex];
            if (orderdetailItem!= null)
            {
                //selectedOrderDetail = orderdetailItem;
                cmbProduct.SelectedValue = orderdetailItem.ProductID;
                nuUnitPrice.Value = orderdetailItem.UnitPrice;
                nuQuantity.Value = orderdetailItem.Quantity;
                nuDiscount.Value = Convert.ToDecimal(orderdetailItem.Discount);
                selectedOrderDetail = new Order_Detail() // Orderdetail vm'i orderdetaile çeviriyorum.
                {
                    OrderID=orderdetailItem.OrderID,
                    Discount=orderdetailItem.Discount,
                    ProductID=orderdetailItem.ProductID,
                    Quantity=orderdetailItem.Quantity,
                    UnitPrice=orderdetailItem.UnitPrice
                };
            }
        }
        private void FormOrderDetailClear()
        {
            selectedOrderDetail = null;
            UICoreUtility.FormClear(panel5);
        }

        

        private void btnOrderDetailDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridOrderDetail.SelectedRows.Count > 0)
                {
                    var dialogresult = UICoreUtility.DialogMessage("Seçilen Kayıtları Silmek İstiyor musunuz ?");
                    if (dialogresult == DialogResult.OK)
                    {
                        foreach (DataGridViewRow row in gridOrderDetail.SelectedRows)
                        {
                            var item = (row.DataBoundItem as OrderDetailVM);
                            orderDetailBusiness.Delete(item.OrderID, item.ProductID);
                          
                        }
                        UICoreUtility.Successmessage("İşlem Başarılı bir şekilde gerçekleşti.");
                        FillDataOrderDetail(this.selectedorder.OrderID);
                        UICoreUtility.FormClear(panel5);
                    }

                }
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
                int id = Convert.ToInt32(this.Tag);
                if (id > 0)
                {
                    var dialog = UICoreUtility.DialogMessage("Kaydı silmek istediğinizden emin misiniz ?");
                    if (dialog == DialogResult.OK)
                    {
                        orderDetailBusiness.Delete(id);
                        orderBusiness.Delete(id);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                UICoreUtility.Errormessage(ex.Message);
                
            }
        }

        private void TotalUpdate()
        {
            var orderDetail = (gridOrderDetail.DataSource as List<OrderDetailVM>);
            if (orderDetail != null)
            {
                lblTotal.Text =  $"Toplam Tutar:{ orderDetail.Sum(t0 => t0.Total).ToString("N2")}";
            }
        }

        private void gridOrderDetail_DataSourceChanged(object sender, EventArgs e)
        {
            TotalUpdate();
        }
    }
}

