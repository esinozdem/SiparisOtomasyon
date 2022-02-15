using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using DAL.Contex;
    using DAL.Concrete;
    using DAL.Abstract;
    using Abstract;

    public class ShipperBusiness : IShippersBusiness
    {
        ShipperRepo shipperRepo;
        public ShipperBusiness()
        {
            shipperRepo = new ShipperRepo();
        }

        public void Add(Shipper item)
        {
            shipperRepo.Add(item);
        }

        public bool Delete(int Id)
        {
            return shipperRepo.Delete(Id);
        }

        public List<Shipper> Get()
        {
            return shipperRepo.Get();
        }

        public Shipper GetById(int Id)
        {
            return shipperRepo.GetById(Id);
        }

        public void Update(Shipper item)
        {
            shipperRepo.Update(item);
        }
    }
}
