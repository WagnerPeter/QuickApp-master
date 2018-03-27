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
            return _appContext.Employees.Where(x => x.User.IsEnabled).ToList();
        }      

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
