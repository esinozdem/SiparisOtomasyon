﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisOtomasyon.BL.Concrete
{
    using Abstract;
    using DAL.Contex;
    using DAL.Abstract;
    using DAL.Concrete;

    public class EmployeeBusiness : IEmployeeBusiness
    {
        IEmployeeRepo employeeRepo;
        public EmployeeBusiness()
        {
            employeeRepo = new EmployeeRepo();
        }
        public void Add(Employee item)
        {
            employeeRepo.Add(item);
        }

        public bool Delete(int id)
        {
            return employeeRepo.Delete(id);
        }

        public List<Employee> Get()
        {
            return employeeRepo.Get();
        }

        public Employee GetById(int id)
        {
            return employeeRepo.GetById(id);
        }

        public void Update(Employee item)
        {
            employeeRepo.Update(item);
        }
    }
}
