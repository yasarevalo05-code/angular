using OrmAPI.Modelo;
using OrmAPI.Data;
using Microsoft.EntityFrameworkCore;
using OrmAPI.ResponseQuery;
using static Azure.Core.HttpHeader;
using System.Diagnostics.Metrics;
using System.Net;

namespace OrmAPI.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        // la clase
        private readonly DataContext _NorthwindDataContext;

        public NorthwindRepository(DataContext context)
        {
            _NorthwindDataContext = context;
        }
        public async Task<List<Employee>> ObtenerTodosLosEmpleados()
        {
            return await this._NorthwindDataContext.Employees.ToListAsync();
        }


        public async Task<int> ObtenerlaCantidadDeEmpleados()
        {
            var result = await _NorthwindDataContext.Employees.CountAsync();
            return result;
        }
        public async Task<Employee> ObtenerEmpleadoporId(int idEmpleado)
        {
            var result = await _NorthwindDataContext.Employees.Where(e => e.EmployeeID == idEmpleado).FirstOrDefaultAsync();
            return result;
        }
        public async Task<Employee> ObtenerEmpleadoporNombre(string nombreEmpleado)
        {
            var result = await _NorthwindDataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }
        public async Task<int> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var result = from emp in _NorthwindDataContext.Employees where emp.Title == titulo select emp.EmployeeID;
            return await result.FirstAsync();
        }
        public async Task<Employee> ObtenerEmpleadoPorCountry(string country)
        {
            var result = await (from emp in _NorthwindDataContext.Employees
                                where emp.Country == country
                                select new Employee
                                {
                                    FirstName = emp.FirstName,
                                    LastName = emp.LastName,
                                    Country = emp.Country,

                                }).FirstOrDefaultAsync();
            return result;
        }
        public async Task<List<Employee>> ObtenerEmpleadoPorTitulo(string titulo)
        {
            var result = await (from emp in _NorthwindDataContext.Employees
                                where emp.Title == titulo
                                orderby emp.FirstName
                                select emp).ToListAsync();
            return result;
        }
        public async Task<Employee> ObtenerElEmpleadoMasGrande()
        {
            var result = await (from emp in _NorthwindDataContext.Employees
                                orderby emp.BirthDate
                                select emp).FirstOrDefaultAsync();
            return result;
        }

        public async Task<List<Employee>> ObtenerEmpleadoPorCiudad(string titulo)
        {
            var result = await (from emp in _NorthwindDataContext.Employees
                                where emp.City.Contains(titulo)
                                orderby emp.FirstName
                                select emp).ToListAsync();
            return result;
        }
        public async Task<List<CantidadEmpleadosResponse>> ObtenerEmpleadorPorTitulosGroupBy()
        {
            var result = await (from emp in _NorthwindDataContext.Employees
                                group emp by emp.Title into g

                                select new CantidadEmpleadosResponse
                                {
                                    Title = g.Key,
                                    CountEmploees = g.Count()
                                }).ToListAsync();
            return result;
        }
        public async Task<List<ProductoCategoriaResponse>> ObtenerProductosyCategorias()
        {
            var result = await (from pro in _NorthwindDataContext.Products
                                join cat in _NorthwindDataContext.Categories on pro.CategoryID equals cat.CategoryID
                                
                                select new ProductoCategoriaResponse
                                {
                                    Categories = cat.CategoryName,
                                    Producto = pro.ProductName
                                }).ToListAsync();
            return result;
        }
        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actulizado = false;
            Employee result = await _NorthwindDataContext.Employees.Where(r => r.EmployeeID == idEmpleado).FirstOrDefaultAsync();

            var resultado = (result != null) ? true : false;

            if (result != null)
            {
                result.FirstName = nombre;
                var resulta = _NorthwindDataContext.SaveChanges();
                actulizado = true;
            }
            return actulizado;
        }
        public async Task<bool> EliminarOrdenPorID(int orderID)
        {
            Orders? orden = await _NorthwindDataContext.Orders.Where(r => r.OrderID == orderID).FirstOrDefaultAsync();
            OrderDetails? orderDetail = await _NorthwindDataContext.OrderDetails.Where(r => r.OrderID == orden.OrderID).FirstOrDefaultAsync();

            _NorthwindDataContext.OrderDetails.Remove(orderDetail);
            _NorthwindDataContext.Orders.Remove(orden);

            var resulta = _NorthwindDataContext.SaveChanges();
            return true;
        }
        public async Task<bool> InsertarEmpleado()
        {
            Employee employee = new Employee();
            employee.Title = "Sales Representative";
            employee.City = "Rosario";
            employee.FirstName = "Yasmin";
            employee.LastName = "Arevalo";
            employee.HireDate = DateTime.Now;
            employee.BirthDate = DateTime.Now;
   
        var newEmploee = await _NorthwindDataContext.AddAsync(employee);
            var result = _NorthwindDataContext.SaveChanges();

            return (result > 0);

        }
    }
    
}
