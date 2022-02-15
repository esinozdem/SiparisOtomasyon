﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.DAL.Abstract
{
    using Contex;
    using VM;
    public interface IOrderRepo:IRepository<Order,int>
    {
        List<OrderVM> GetOrderVM();
    }
}
