using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    //Genel Bir Repository..Tüm projeler için geçerli.
    public interface IRepository<T,T1>
    {
        void Add(T item);
        void Update(T item);
        bool Delete(T1 Id); //Silme işlemi başarılı mı başarısız mı bu yüzden bool dedik.
        List<T> Get();
        T GetById(T1 Id); // CustomerID string olduğu için T1 dedik.
    }
}
