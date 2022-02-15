using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    using Contex;
    using Abstract;
    using DAL.VM;

    public class OrderDetailRepo : IOrderDetailRepo
    {
        NorthwndContex DB;
        public OrderDetailRepo()
        {
            DB = new NorthwndContex();
        }
        public void Add(Order_Detail item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Added;
            DB.SaveChanges();
        }

        public bool Delete(int OrderId, int ProductId)
        {
            var orderDetail = DB.Order_Details.FirstOrDefault(t0 => t0.OrderID == OrderId && t0.ProductID == ProductId);
            if (orderDetail != null)
            {
                DB.Entry(orderDetail).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(int OrderId)
        {
            var orderDetails = DB.Order_Details.Where(t0 => t0.OrderID == OrderId).ToList();
            if (orderDetails!=null)
            {
                foreach (var item in orderDetails)
                {
                    DB.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Order_Detail> Get(int OrderId)
        {
            return DB.Order_Details.Where(t0 => t0.OrderID == OrderId).ToList();
        }

        public Order_Detail GetById(int orderId, int productId)
        {
            return DB.Order_Details.FirstOrDefault(t0 => t0.OrderID == orderId && t0.ProductID == productId);
        }

        public List<OrderDetailVM> GetOrderDetailVM(int OrderID)
        {
            var result = (from t0 in DB.Order_Details
                          where t0.OrderID == OrderID
                          select new OrderDetailVM()
                          {
                              OrderID = t0.OrderID,
                              Discount=t0.Discount,
                              ProductID=t0.ProductID,
                              ProductName=t0.Product.ProductName,
                              Quantity=t0.Quantity,
                              UnitPrice=t0.UnitPrice
                          }).ToList();
            return result;
        }

        public void Update(Order_Detail item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
