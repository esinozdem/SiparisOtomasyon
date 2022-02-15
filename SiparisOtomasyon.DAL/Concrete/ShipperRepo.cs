using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    using Contex;
    using Abstract;
    //ShipperRepo Genericrepodan kalıtım alır. IshipperRepo'yu implemente eder.
  public  class ShipperRepo:GenericRepo<Shipper,int>, IShipperRepo
    {


    }

}
