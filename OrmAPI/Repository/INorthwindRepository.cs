using OrmAPI.Modelo;
using OrmAPI.ResponseQuery;

namespace OrmAPI.Repository
{
  
        public interface INorthwindRepository
        {
            Task<List<Employee>> ObtenerTodosLosEmpleados();
            Task<int> ObtenerlaCantidadDeEmpleados();
            Task<Employee> ObtenerEmpleadoporId(int idEmpleado);
            Task<Employee> ObtenerEmpleadoporNombre (string ApellidoEmpleado);
            Task<Employee> ObtenerElEmpleadoMasGrande ();
            Task<int> ObtenerIDEmpleadoPorTitulo(string titulo);
            Task<Employee> ObtenerEmpleadoPorCountry (string country);
            Task<List<Employee>> ObtenerEmpleadoPorTitulo(string titulo);
            Task<List<Employee>> ObtenerEmpleadoPorCiudad (string titulo);
            Task<List<CantidadEmpleadosResponse>> ObtenerEmpleadorPorTitulosGroupBy();
            Task<List<ProductoCategoriaResponse>> ObtenerProductosyCategorias();
            Task<bool> EliminarOrdenPorID(int id);
            Task<bool> ModificarNombreEmpleado(int id, string nombre);
            Task<bool> InsertarEmpleado();

        }
    }


