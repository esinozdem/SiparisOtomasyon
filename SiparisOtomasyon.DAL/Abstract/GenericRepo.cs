using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    using Contex;
    using System.Data.Entity;

    //T ve T1 belli olmayan tiplerler çalışcaz.
    //T tipi = nesnenin tipi.
    //T1 tipide customer tabblosu üzerinde yazılmış id için belirtilen tip.
    public abstract class GenericRepo<T, T1> : IRepository<T, T1>
        where T:class  //Tip belirlemesi yaptık.T tipi referans tipi bir nesne tipinde olması lazım.
                       //Kısıtlama Yaptık.
    {
        //abstrac bir class olduğu için _Db yi kalıtım alanlarda kullanıcak.
        private NorthwndContex _DB; // Özellik oluşturduk.
     
        public NorthwndContex DB
        {
            get 
            {
                if (_DB == null) 
                    _DB = new NorthwndContex();
                return _DB;
            }
            
        }

        
        public GenericRepo()
        {
            
            
        }
        //virtual dememimizin nedeni. İsteyen repository bu metodu kullansın.
        public virtual void Add(T item)
        {
            //DB.Set benden bir nesne istediği için yukarda T'yi kısıtladım.
            DB.Set<T>().Add(item); //T tipi customer olabilir. Order olabilir. Product olabilir. Genel bir tip belirledik.
            DB.SaveChanges();
        }

        public virtual bool Delete(T1 Id)
        {
          var dbItem = DB.Set<T>().Find(Id); //Find kısmı pirmarykey alanına göre çalışır.
            if (dbItem != null)
            {
                DB.Set<T>().Remove(dbItem);
                DB.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual List<T> Get()
        {
            return DB.Set<T>().ToList();
        }

        public virtual T GetById(T1 Id)
        {
            return DB.Set<T>().Find(Id);
        }

        public virtual void Update(T item)
        {
            DB.Entry(item).State = EntityState.Modified;
            DB.SaveChanges();
        }
    }
}
