using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DungeonAdmin.Controllers
{
    [Produces("application/json")]
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        readonly ILogger _logger;

        public EmployeeController(IUnitOfWork unitOfWork, ILogger<EmployeeController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            var allEmployees = _unitOfWork.Employees.GetAllActiveEmployees();
            return Ok(Mapper.Map<IEnumerable<Employee>>(allEmployees));
        }


        // GET: api/values
        [HttpGet]
        public IActionResult AddEmployee(Employee emp)
        {
            _unitOfWork.Employees.Add(emp);
            _unitOfWork.SaveChanges();
            return Ok();
        }
    }
}