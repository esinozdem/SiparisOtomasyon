﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using Abstract;
    using DAL.Abstract;
    using DAL.Concrete;
    using SiparisOtomasyon.DAL.Contex;

    public class CustomerBusiness : ICustomerBusiness
    {
        ICustomerRepo customerRepo; //Bağımlılığı azaltmak için böyle yaptık..
        public CustomerBusiness()
        {
            customerRepo = new CustomerRepo();
        }
        public void Add(Customer item)
        {
            customerRepo.Add(item);
        }

        public bool Delete(string id)
        {
            return customerRepo.Delete(id);
        }

        public List<Customer> Get()
        {
            return customerRepo.Get();
        }

        public Customer GetById(string id)
        {
            return customerRepo.GetById(id);
        }

        public void Update(Customer item)
        {
            customerRepo.Update(item);
        }
    }
}
