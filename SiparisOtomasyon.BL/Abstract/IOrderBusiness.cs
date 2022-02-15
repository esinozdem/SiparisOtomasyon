﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Abstract
{
    using DAL.Contex;
    using DAL.VM;
  public interface IOrderBusiness: IBusiness<Order,int>
    {
        List<OrderVM> GetOrderVM();
    }
}
