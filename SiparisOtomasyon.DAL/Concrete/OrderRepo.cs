using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    using Abstract;
    using Contex;
    using SiparisOtomasyon.DAL.VM;

    public class OrderRepo : GenericRepo<Order, int>, IOrderRepo
    {
        public List<OrderVM> GetOrderVM()
        {
            var result = (from t0 in DB.Orders
                          select new OrderVM()
                          {
                              OrderId= t0.OrderID,
                              CargoName= t0.Shipper.CompanyName,
                              CustomerName= t0.Customer.CompanyName,
                              OrderDate= t0.OrderDate,
                              PersonalName= t0.Employee.FirstName + " " + t0.Employee.LastName,
                              ShipName=t0.ShipName
                          }).ToList();
            return result;
        }
    }
}
