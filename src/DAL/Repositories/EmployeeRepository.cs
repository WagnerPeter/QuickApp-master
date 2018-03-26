// ====================================================
// More Templates: https://www.ebenmonney.com/templates
// Email: support@ebenmonney.com
// ====================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        { }


        public IEnumerable<Employee> GetAllActiveEmployees()
        {
            return _appContext.Employees.Where(x => x.IsEnabled).ToList();
        }

        public Employee GetEmployee(int id)
        {
            return _appContext.Employees.FirstOrDefault(x => x.Id == id);
        }

        public int AddEmployee(Employee emp)
        {
            _appContext.Employees.Add(emp);
            return _appContext.SaveChanges();
        }

        public int RemoveEmployee(int id)
        {
            var emp = _appContext.Employees.FirstOrDefault(x => x.Id == id);
            _appContext.Employees.Remove(emp);
            return _appContext.SaveChanges();
        }

        public int UpdateEmployee(Employee emp)
        {
            _appContext.Employees.Update(emp);
            return _appContext.SaveChanges();
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
