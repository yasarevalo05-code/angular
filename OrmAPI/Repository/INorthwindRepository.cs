using OrmAPI.Modelo;
using OrmAPI.ResponseQuery;

namespace OrmAPI.Repository
{
  
        public interface INorthwindRepository
        {
            // Empleados
            Task<List<Employee>> ObtenerTodosLosEmpleados();
            Task<int> ObtenerlaCantidadDeEmpleados();
            Task<Employee> ObtenerEmpleadoporId(int idEmpleado);
            Task<Employee> ObtenerEmpleadoporNombre (string ApellidoEmpleado);
            Task<int> ObtenerIDEmpleadoPorTitulo(string titulo);
            Task<List<Employee>> ObtenerTodosLosEmpleadosPorPais(string country);
            Task<Employee> ObtenerEmpleadoPorCountry (string country);
            Task<Employee> ObtenerElEmpleadoMasGrande ();

            // Estadísticas
            Task<List<CantidadEmpleadosResponse>> ObtenerEmpleadorPorTitulosGroupBy();

            // Productos
            Task<List<ProductoCategoriaResponse>> ObtenerProductosyCategorias();
            Task<List<Products>> ObtenerProductosQueContienen(string palabra);


        }
    }


