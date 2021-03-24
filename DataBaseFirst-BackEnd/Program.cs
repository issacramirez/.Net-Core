using DataBaseFirst_BackEnd.DataAccess;
using DataBaseFirst_BackEnd.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataBaseFirst_BackEnd {
    class Program {

        public static EmployeesService employeesService = new EmployeesService();
        public static OrdersService ordersService = new OrdersService();
        public static ProductServices productServices = new ProductServices();

        public static void Excercise1() {
            var empleyeeQry = employeesService.GetAllEmployees();
            var output = empleyeeQry.ToList();
        }

        public static void Excercise2() {
            var employeeQuery = employeesService.GetAllEmployees().Select(s => new {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");

            var output = employeeQuery.ToList();
            output.ForEach(fe => Console.WriteLine("Titulo: " + fe.Title + " Nombre: " + fe.FirstName + " Apellido: " + fe.LastName));
        }

        public static void Excercise3() {
            var employeeQuery = employeesService.GetAllEmployees().Where(w => w.Title != "Sales Representative").Select(s => new {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title
            });

            var output = employeeQuery.ToList();
        }

        public static void Excersice4(int id) {
            employeesService.UpdateEmployeeFirstNameById(id,"Alejandra");
        }

        public static void Excercise5() {
            productServices.AddNewProduct("Jugo del Valle 1lt",15.50m);
        }

        public static void Escercise6(int id = 13,string name = "Rolando") {
            employeesService.DeleteEmployeeById(id);
        }

        public static void Excercise7(int orderID = 10248) {
            var qry = ordersService.GetOrderByID(orderID).Select(s => new {
                Cliente = s.Customer.CompanyName,
                Vendedor = s.Employee.FirstName,
                Productos = s.OrderDetails.Select(se => se.Product.ProductName)
            });
            var result = qry.ToList();
        }

        static void Main(string[] args) {
            Excercise1();
            Excercise2();
            Excercise3();
            Excersice4(id: 1);
            Excercise5();
            Escercise6(1,"Marco");
            Excercise7();
            Console.WriteLine("Hello World!");
        }
    }
}
