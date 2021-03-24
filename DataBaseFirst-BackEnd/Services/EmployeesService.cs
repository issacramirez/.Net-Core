using DataBaseFirst_BackEnd.DataAccess;
using DataBaseFirst_BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBaseFirst_BackEnd.Services {
    public class EmployeesService : BaseService {

        public Employees GetEmployeeByName(string name = "Rolando") {
            return dataContext.Employees.Where(w => w.FirstName == name).FirstOrDefault();
        }

        public Employees GetEmployeeById(int id) {
            var employee =  GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
            if(employee == null)
                throw new Exception("El id ingresado no existe en la base de datos.");
            return employee;
        }

        public void DeleteEmployeeById(int id) {
            var employee = GetEmployeeById(id);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        public void UpdateEmployeeFirstNameById(int id,string newName) {
            Employees currentEmployee = GetEmployeeById(id);
            if(currentEmployee == null) {
                throw new Exception("No se encontro el id del empleado proporcionado");
            }
            currentEmployee.FirstName = newName;
            dataContext.SaveChanges();
        }

        public IQueryable<Employees> GetAllEmployees() {
            return dataContext.Employees.Select(s => s);
        }

        public void AddEmployee(EmployeeModel newEmployee) {
            var newEmployeeRegister = new Employees() {
                FirstName = newEmployee.Name,
                LastName = newEmployee.FamilyName
            };
            dataContext.Employees.Add(newEmployeeRegister);
            dataContext.SaveChanges();

        }

    }
}
