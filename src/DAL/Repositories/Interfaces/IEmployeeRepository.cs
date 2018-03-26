using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetAllActiveEmployees();
        int AddEmployee(Employee emp);
        int UpdateEmployee(Employee emp);

        int RemoveEmployee(int id);
    }
}
