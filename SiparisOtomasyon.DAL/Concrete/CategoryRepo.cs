using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Concrete
{
    using Abstract;
    using Contex;
   public class CategoryRepo:GenericRepo<Category,int>, ICategoryRepo
    {
        
    }
}
