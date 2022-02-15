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
    public partial class CustomerForm : Form
    {
        ICustomerBusiness customerBusiness;
        public CustomerForm()
        {
            InitializeComponent();
            customerBusiness = new CustomerBusiness();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            FillData();
        }
        Customer selectedCustomer = null;
        private void FillData()
        {
            string id = this.Tag?.ToString(); //Null kontrolü yaptık => Tag? => Null değilse devam et.
            if (!string.IsNullOrWhiteSpace(id))
            {
                this.selectedCustomer = customerBusiness.GetById(id);
                if (this.selectedCustomer != null)
                {
                    txtCompanyName.Text = this.selectedCustomer.CompanyName;
                    txtContactName.Text = this.selectedCustomer.ContactName;
                    txtContactTittle.Text = this.selectedCustomer.ContactTitle;
                    txtPostCode.Text = this.selectedCustomer.PostalCode;
                    txtPhone.Text = this.selectedCustomer.Phone;
                    txtFax.Text = this.selectedCustomer.Fax;
                    txtCountry.Text = this.selectedCustomer.Country;
                    txtCity.Text = this.selectedCustomer.City;
                    txtRegion.Text = this.selectedCustomer.Region;
                    txtAddress.Text = this.selectedCustomer.Address;
                }
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void FormClear()
        {
            //Tag ve selectedcustomer bu customer formuna ait olduğu için genelden almadık.
            this.Tag = null; //Yeni butonuna basınca yeni müşteri girmek istiyorum.
            this.selectedCustomer = null;
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
                if (this.selectedCustomer == null)
                {
                    this.selectedCustomer = new Customer();
                    this.selectedCustomer.CustomerID = GenerateCustomerCode(5);

                }
                this.selectedCustomer.CompanyName = txtCompanyName.Text;
                this.selectedCustomer.ContactTitle = txtContactTittle.Text;
                this.selectedCustomer.ContactName = txtContactName.Text;
                this.selectedCustomer.PostalCode = txtPostCode.Text;
                this.selectedCustomer.Country = txtCountry.Text;
                this.selectedCustomer.City = txtCity.Text;
                this.selectedCustomer.Phone = txtPhone.Text;
                this.selectedCustomer.Fax = txtFax.Text;
                this.selectedCustomer.Region = txtRegion.Text;
                this.selectedCustomer.Address = txtAddress.Text;
                string id = this.Tag?.ToString();
                if (!string.IsNullOrWhiteSpace(id)) //Tagında ıd varsa Update işlemi
                {
                    customerBusiness.Update(this.selectedCustomer);
                }
                else //Tagında ıd yoksa Insert olayı
                {
                    customerBusiness.Add(this.selectedCustomer);
                    this.Tag = this.selectedCustomer.CustomerID;
                }
                UICoreUtility.Successmessage(" İşlem başarılı bir şekilde yapıldı.");
            }
            catch (Exception ex)
            {
                UICoreUtility.Errormessage(ex.Message);
            }

        }

        static Random rnd = new Random();

        //Karakter dizisinden random bir şekilde çekiliş yapıyorum. new string kısmı
        //Enumerable => sayılabilir. Karakter setinden 5 kere çağırıcam.
        //Select le her defasında seçtiğimi geri dönüyor. Char karakterini diziye çevirip string veriyor.
        private string GenerateCustomerCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUWXZ0123456789";
            return new string(Enumerable.Repeat(chars, 5).Select(t0 => t0[rnd.Next(t0.Length)]).ToArray());

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FormDelete();
        }

        private void FormDelete()
        {
            try
            {
                if (UICoreUtility.DialogMessage("Bu Kaydı Sİlmek İstiyor Musunuz?") == DialogResult.OK)
                {
                    if (customerBusiness.Delete(this.selectedCustomer.CustomerID))
                    {
                        UICoreUtility.Successmessage("Silme İşlemi Başarılı");
                        this.Close();
                    }
                    else
                    {
                        UICoreUtility.Errormessage("Silme İşlemi sırasında hata meydana geldi.");
                    }

                }
            }
            catch (Exception ex)
            {

                UICoreUtility.Errormessage(ex.Message);
            }
        }
    }
}
