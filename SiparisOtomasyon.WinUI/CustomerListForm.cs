using SiparisOtomasyon.BL.Abstract;
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
    public partial class CustomerListForm : Form
    {
        ICustomerBusiness customerBusiness;
        public CustomerListForm()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
        }

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            FillColumnMapping();
            FillGrid();
        }

        private void FillColumnMapping()
        {
            grdCustomerList.AutoGenerateColumns = false;
            grdCustomerList.Columns.Add(generateDataGridViewTextBoxcolumn("CompanyName", "CompanyName", "Müşteri Adı"));
            grdCustomerList.Columns.Add(generateDataGridViewTextBoxcolumn("ContactName", "ContactName", "İlgili Kişi"));
            grdCustomerList.Columns.Add(generateDataGridViewTextBoxcolumn("ContactTitle", "ContactTitle", "İlgili Ünvan"));
            grdCustomerList.Columns.Add(generateDataGridViewTextBoxcolumn("Phone", "Phone", "Telefon"));
        }

        private void FillGrid()
        {
            grdCustomerList.DataSource = null;

            grdCustomerList.DataSource = customerBusiness.Get();
        }
        public DataGridViewTextBoxColumn generateDataGridViewTextBoxcolumn(string name, string dataPropertyName, string headerText)
        {
            return new DataGridViewTextBoxColumn()
            {
                Name = name,
                DataPropertyName = dataPropertyName,
                HeaderText = headerText
            };
        }

        private void grdCustomerList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var customer = (grdCustomerList.DataSource as List<Customer>)[e.RowIndex];
            var form = new CustomerForm();
            form.MdiParent = this.MdiParent;
            form.Tag = customer.CustomerID;
            form.FormClosed += Form_FormClosed;
            form.Show();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            FillGrid();
        }
    }
}
