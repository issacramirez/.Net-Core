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
        

        public static void Excercise1()
        {
            // select * from employees
            /* NORTHWNDContext dataContext = new NORTHWNDContext();*/

            // se establece el query
            var empleyeeQry = employeesService.GetAllEmployees();

            // como obtener order_details de Orders
            // var orderDetail = dataContext.Orders.Where(w => w.OrderId == 1).SelectMany(sm => sm.OrderDetails);

            // Materializamos el Query (ejecutar el query)
            var output = empleyeeQry.ToList();

        }

        public static void Excercise2()
        {
            // select tittle, FirstName, LastName FROM employees where tittle = 'Sales Representative'

            /*var dbContext = new NORTHWNDContext();*/

            // usando proyeccion no anonima (para mas usos)
            //var employeeQry = DbContext.Employees.Select(s => new Employees {
            //    Title = s.Title,
            //    FirstName = s.FirstName,
            //    LastName = s.LastName
            //}).Where(w => w.Title == "Sales Representative");

            /*var employeeQuery = dataContext.Employees.Select(s => new {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");*/

            // usando pryeccion anonima
            var employeeQuery = employeesService.GetAllEmployees().Select(s => new {
                s.Title,
                s.FirstName,
                s.LastName
            }).Where(w => w.Title == "Sales Representative");

            var output = employeeQuery.ToList();

            output.ForEach(fe => Console.WriteLine("Titulo: " + fe.Title + " Nombre: " + fe.FirstName + " Apellido: " + fe.LastName));

        }

        public static void Excercise3()
        {

            // select FirstName as Nombre, LastName as Apellido, Tittle as Puesto From Employees Where Tittle<> "Sales Representative"

            /*var dbContext = new NORTHWNDContext();*/

            /*var employeeQuery = dataContext.Employees.Where(w => w.Title != "Sales Representative").Select(s => new {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title
            });*/

            var employeeQuery = employeesService.GetAllEmployees().Where(w => w.Title != "Sales Representative").Select(s => new {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title
            });

            // otra manera de hacerlo, con el where despues, pero puede ser mas optimo la otra manera
            /*var employeeQuery = dbContext.Employees.Select(s => new { 
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title
            }).Where(w => w.Puesto != "Sales Representative");*/

            var output = employeeQuery.ToList();

        }

        // se le puede poner un parametro por defecto default donde ya estará incializado, si se le pone un signo de interrogacion será opcional
        public static void Excersice4(int id)
        {
            // update Employees SET NAME = 'Alejandra' Where id = 1
            employeesService.UpdateEmployeeFirstNameById(id, "Alejandra");

        }

        public static void Excercise5()
        {
            // insertar nuevo producto en la tabla a Products
            productServices.AddNewProduct("Jugo del Valle 1lt", 15.50m);
        }

        

        public static void Escercise6(int id = 13, string name = "Rolando")
        {
            // borrar un empleado por el id
            employeesService.DeleteEmployeeById(id);

            // eliminar por nombre
            /*var employee = GetEmployeeByName(name);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();*/

        }

        public static void Excercise7(int orderID = 10248)
        {

            // obtener los productos, el cliente y el empleado por ID de order
            // se pone where primero para que filtre la busqueda primero y mejorar la concurrencia, tambien puede ir despues del select.
            var qry = ordersService.GetOrderByID(orderID).Select(s => new
            {
                Cliente = s.Customer.CompanyName,
                Vendedor = s.Employee.FirstName,
                Productos = s.OrderDetails.Select(se => se.Product.ProductName)
            });

            var result = qry.ToList();
        }

        static void Main(string[] args) {
                /*Excercise1();
                Excercise2();
                Excercise3();*/
                Excersice4(id: 1); // puede ser así cuando tienes muchos parametros, con el nombre de este parametro
                Excercise5();
                Escercise6(1, "Marco");
                Excercise7();
                Console.WriteLine("Hello World!");
            }
    }
}
