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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void newCustomerMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMidiForm(new CustomerForm());


        }
        private void newProductMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMidiForm(new ProductForm());
        }

        private void CustomerListMenuıtem_Click(object sender, EventArgs e)
        {
            this.ShowMidiForm(new CustomerListForm());
        }
        private void ProductlistMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMidiForm(new ProductListForm());
        }
        public void ShowMidiForm(Form form)
        {
            chechOpenForms();
            form.MdiParent = this;
            form.Dock = DockStyle.Fill;
            form.Show();
        }
        public void chechOpenForms()
        {
            //Form clouseForm = null;
            //foreach (Form openForm in Application.OpenForms)
            //{
            //    if (openForm.MdiParent != null)
            //        clouseForm = openForm;
            //}
            //if (clouseForm != null)
            //    clouseForm.Close();

            //.....YA DA.......//
            for (int i = 0; i < Application.OpenForms.Count; i++) //ilkini kapatıp ikincisine geçicek.
            {
                if (Application.OpenForms[i].MdiParent != null)
                {
                    Application.OpenForms[i].Close();
                    i--; 
                }
            }
        }

        private void newOrderMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMidiForm(new OrderForm());
        }

        private void newOrderListmenuItem_Click(object sender, EventArgs e)
        {
            this.ShowMidiForm(new OrderListForm());
        }
    }
}
