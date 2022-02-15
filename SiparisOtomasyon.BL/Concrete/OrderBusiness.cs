﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using Abstract;
    using DAL.Contex;
    using DAL.Concrete;
    using DAL.Abstract;
    using SiparisOtomasyon.DAL.VM;

    public class OrderBusiness : IOrderBusiness
    {
        IOrderRepo orderRepo;
        public OrderBusiness()
        {
            orderRepo = new OrderRepo();
        }
        public void Add(Order item)
        {
            orderRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return orderRepo.Delete(id);
        }

        public List<Order> Get()
        {
          return orderRepo.Get();
        }

        public Order GetById(int id)
        {
            return orderRepo.GetById(id);
        }

        public List<OrderVM> GetOrderVM()
        {
            return orderRepo.GetOrderVM();
        }

        public void Update(Order item)
        {
            orderRepo.Update(item);
        }
    }
}
