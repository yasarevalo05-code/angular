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

        // 1. Todos los empleados
        public async Task<List<Employee>> ObtenerTodosLosEmpleados()
        {
            return await this._NorthwindDataContext.Employees.ToListAsync();
        }

        // 2. Cantidad total de empleados
        public async Task<int> ObtenerlaCantidadDeEmpleados()
        {
            var result = await _NorthwindDataContext.Employees.CountAsync();
            return result;
        }

        // 3. Empleado por ID
        public async Task<Employee> ObtenerEmpleadoporId(int idEmpleado)
        {
            var result = await _NorthwindDataContext.Employees.Where(e => e.EmployeeID == idEmpleado).FirstOrDefaultAsync();
            return result;
        }

        // 4. Empleado por nombre
        public async Task<Employee> ObtenerEmpleadoporNombre(string nombreEmpleado)
        {
            var result = await _NorthwindDataContext.Employees.FirstOrDefaultAsync(e => e.FirstName == nombreEmpleado);
            return result;
        }

        // 5. ID del empleado por título
        public async Task<int> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var result = from emp in _NorthwindDataContext.Employees where emp.Title == titulo select emp.EmployeeID;
            return await result.FirstAsync();
        }

        // 6. Empleado por país
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

        //  7. Todos los empleados por país
        public async Task<List<Employee>> ObtenerTodosLosEmpleadosPorPais(string country)
        {
            return await _NorthwindDataContext.Employees
                .Where(e => e.Country == country)
                .OrderBy(e => e.FirstName)
                .ToListAsync();
        }


        // 8. Empleado más grande (mayor edad)
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

        // 9. Cantidad de empleados agrupados por título
        public async Task<List<CantidadEmpleadosResponse>> ObtenerEmpleadorPorTitulosGroupBy()
        {
            var result = await (from emp in _NorthwindDataContext.Employees
                                group emp by emp.Title into g

                                select new CantidadEmpleadosResponse
                                {
                                    Title = g.Key,
                                    CountEmployees = g.Count()
                                }).ToListAsync();
            return result;
        }

        // 10. Productos con su categoría
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

        //  11. Productos que contienen una palabra en su nombre
        public async Task<List<Products>> ObtenerProductosQueContienen(string palabra)
        {
            return await _NorthwindDataContext.Products
                .Where(p => p.ProductName.Contains(palabra))
                .ToListAsync();
        }

    }
    
}
