using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseFirst_BackEnd.Services;
using DataBaseFirst_BackEnd.DataAccess;
using DataBaseFirst_BackEnd.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwnd.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employees> Get() {
            var employees = new EmployeesService().GetAllEmployees().Select(s => new Employees {
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                Address = s.Address
            }).ToList();
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employees Get(int id) {
            var employee = new EmployeesService().GetEmployeeById(id);
            return employee;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] EmployeeModel newEmployee) {
            new EmployeesService().AddEmployee(newEmployee);

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] string newNameEmployee) {
            new EmployeesService().UpdateEmployeeFirstNameById(id,newNameEmployee);
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            new EmployeesService().DeleteEmployeeById(id);
        }
    }
}
