using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBaseFirst_BackEnd.Services;
using DataBaseFirst_BackEnd.DataAccess;
using DataBaseFirst_BackEnd.Models;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiRestNorthwnd.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {

        private EmployeesService employeesService = new EmployeesService();

        // GET: api/<EmployeeController>
        [HttpGet]
        public IActionResult Get() {
            var employees = employeesService.GetAllEmployees().Select(s => new Employees {
                EmployeeId = s.EmployeeId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                BirthDate = s.BirthDate,
                Address = s.Address
            }).ToList();

            // OK(json employees)
            return Ok(employees);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            try {
                var employee = employeesService.GetEmployeeById(id);
                return Ok(employee);
            } catch(Exception e) {
                return ThrowInternalErrorServer(e);
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeModel newEmployee) {
            try {
                employeesService.AddEmployee(newEmployee);
                return Ok();
            } catch(Exception e) {
                return ThrowInternalErrorServer(e);
            }
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] string newNameEmployee) {
            try {
                employeesService.UpdateEmployeeFirstNameById(id,newNameEmployee);
                return Ok();
            } catch(Exception e) {
                return ThrowInternalErrorServer(e);
            }
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            try {
                employeesService.DeleteEmployeeById(id);
                return Ok();
            } catch(Exception e) {
                return ThrowInternalErrorServer(e);
            }
        }

        #region helpers

        private IActionResult ThrowInternalErrorServer(Exception e) {
            return StatusCode(StatusCodes.Status500InternalServerError,e.Message);
        }

        #endregion 
    }
}
