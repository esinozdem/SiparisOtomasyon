using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Abstract
{
    using DAL.Contex;
    using DAL.VM;
   public interface IProductBusiness: IBusiness<Product,int>
    {
        List<ProductVM> GetProductsVM();
    }
}
