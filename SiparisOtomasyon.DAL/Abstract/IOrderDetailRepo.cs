using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    using DAL.Contex;
    using DAL.VM;
   public interface IOrderDetailRepo
    {
        void Add(Order_Detail item);
        void Update(Order_Detail item);
        List<Order_Detail> Get(int OrderId);
        List<OrderDetailVM> GetOrderDetailVM(int OrderID);
        Order_Detail GetById(int orderId, int productId);
        bool Delete(int OrderId, int ProductId);
        bool Delete(int OrderId);
       
    }
}
