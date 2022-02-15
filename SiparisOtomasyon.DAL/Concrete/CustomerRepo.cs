using SiparisOtomasyon.DAL.Abstract;
using SiparisOtomasyon.DAL.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    public class CustomerRepo : ICustomerRepo
    {
        private NorthwndContex DB;
        public CustomerRepo()
        {
            DB = new NorthwndContex();
        }
        public void Add(Customer item)
        {
            DB.Customers.Add(item);
            DB.SaveChanges();
        }

        public bool Delete(string Id)
        {
            var dbItem = DB.Customers.FirstOrDefault(t0 => t0.CustomerID == Id);
            if (dbItem != null)
            {
                DB.Customers.Remove(dbItem);
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Customer> Get()
        {

            var result = DB.Customers.AsNoTracking().ToList(); //İzleme yapmicak database.
            return result;
        }

        public Customer GetById(string Id)
        {
            
            return DB.Customers.FirstOrDefault(t0 => t0.CustomerID == Id);
        }

        public void Update(Customer item)
        {
            DB.Entry(item).State = System.Data.Entity.EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
