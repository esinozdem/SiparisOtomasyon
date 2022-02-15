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

    public partial class OrderListForm : Form
    {
        IOrderBusiness orderBusiness;
        public OrderListForm()
        {
            InitializeComponent();
            orderBusiness = new OrderBusiness();
        }

        private void OrderListForm_Load(object sender, EventArgs e)
        {
            FillMaping();
            FillData();
        }

        private void FillData()
        {
            grdOrderList.DataSource = null;
            grdOrderList.DataSource = orderBusiness.GetOrderVM();
        }

        private void FillMaping()
        {
            grdOrderList.AutoGenerateColumns = false;

            grdOrderList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("CustomerName", "CustomerName","Müşteri Adı"));
            grdOrderList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("PersonalName", "PersonalName","Personel Adı"));
            grdOrderList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("OrderDate", "OrderDate","Tarih"));
            grdOrderList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("CargoName", "CargoName", "Kargo Firması"));
            grdOrderList.Columns.Add(UICoreUtility.generateDataGridViewTextBoxcolumn("ShipName","ShipName", "Alıcı"));
        }

        private void grdOrderList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var order = (grdOrderList.DataSource as List<OrderVM>)[e.RowIndex];
            var form = new OrderForm();
            form.MdiParent = this.MdiParent;
            form.Dock = DockStyle.Fill;
            form.Tag = order.OrderId;
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillData();
        }
    }
}
