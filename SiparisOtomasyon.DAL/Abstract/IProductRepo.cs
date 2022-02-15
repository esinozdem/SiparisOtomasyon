using SiparisOtomasyon.DAL.Contex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    using Contex;
    using VM;
    public interface IProductRepo:IRepository<Product,int>
    {
        //productRepoya özel o yüzden ayrı bir metot yazıyorum. IProductRepository yazmamın nedeni..
        List<ProductVM> GetProductsVM();

    }
}
