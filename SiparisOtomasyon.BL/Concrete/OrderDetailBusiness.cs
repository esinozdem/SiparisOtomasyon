using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using DAL.Abstract;
    using Abstract;
    using DAL.Contex;
    using DAL.Concrete;
    using SiparisOtomasyon.DAL.VM;

    public class OrderDetailBusiness : IOrderDetailBusiness
    {
        IOrderDetailRepo orderDetailRepo;
        public OrderDetailBusiness()
        {
            orderDetailRepo = new OrderDetailRepo();

        }

        public void Add(Order_Detail item)
        {
            orderDetailRepo.Add(item);
        }

        public bool Delete(int OrderId, int ProductId)
        {
            return orderDetailRepo.Delete(OrderId, ProductId);
        }

        public bool Delete(int OrderId)
        {
            return orderDetailRepo.Delete(OrderId);
        }

        public List<Order_Detail> Get(int OrderId)
        {
            return orderDetailRepo.Get(OrderId);
        }

        public Order_Detail GetById(int orderId, int productId)
        {
            return orderDetailRepo.GetById(orderId, productId);
        }

        public List<OrderDetailVM> GetOrderDetailVM(int OrderID)
        {
            return orderDetailRepo.GetOrderDetailVM(OrderID);
        }

        public void Update(Order_Detail item)
        {
            orderDetailRepo.Update(item);
        }
    }
}
