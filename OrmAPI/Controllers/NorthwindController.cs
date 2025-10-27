using Microsoft.AspNetCore.Mvc;
using OrmAPI.Data;
using OrmAPI.Modelo;
using OrmAPI.Repository;
using OrmAPI.ResponseQuery;
using static OrmAPI.Repository.INorthwindRepository;

namespace OrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;
        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        // 1. Obtener todos los empleados
        [HttpGet("TodosLosEmpleados")]
        public async Task<List<Employee>> GetAll()
        {
            return await _repository.ObtenerTodosLosEmpleados();
        }

        // 2. Obtener cantidad total de empleados
        [HttpGet("CantidadDeEmpleados")]
        public async Task<int> ObtenerLaCantidadDeEmpleados()
        {
            return await _repository.ObtenerlaCantidadDeEmpleados();
        }

        // 3. Obtener empleado por ID
        [HttpGet("EmpleadoPorId/{idEmpleado}")]
        public async Task<ActionResult<Employee>> ObtenerEmpleadoporId(int idEmpleado)
        {
            var empleado = await _repository.ObtenerEmpleadoporId(idEmpleado);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }

        // 4. Obtener empleado por nombre
        [HttpGet("EmpleadoPorNombre/{nombre}")]
        public async Task<ActionResult<Employee>> ObtenerEmpleadoporNombre(string nombre)
        {
            var empleado = await _repository.ObtenerEmpleadoporNombre(nombre);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }

        // 5. Obtener ID de empleado por título
        [HttpGet("EmpleadoIDPorTitulo/{titulo}")]
        public async Task<ActionResult<int>> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var id = await _repository.ObtenerIDEmpleadoPorTitulo(titulo);
            return Ok(id);
        }

        // 6. Obtener empleado por país
        [HttpGet("EmpleadoPorPais/{country}")]
        public async Task<ActionResult<Employee>> ObtenerEmpleadoPorCountry(string country)
        {
            var empleado = await _repository.ObtenerEmpleadoPorCountry(country);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }


        // 7. Obtener todos los empleados por pais
        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Employee>>> ObtenerTodosLosEmpleadosPorPais([FromQuery] string country)
        {
            var empleados = await _repository.ObtenerTodosLosEmpleadosPorPais(country);
            if (empleados == null || !empleados.Any()) return NotFound("No hay empleados en ese país");
            return Ok(empleados);
        }


        // 8. Obtener el empleado más grande
        [HttpGet("EmpleadoMasGrande")]
        public async Task<ActionResult<Employee>> ObtenerElEmpleadoMasGrande()
        {
            var empleado = await _repository.ObtenerElEmpleadoMasGrande();
            return Ok(empleado);
        }


        // 9. Cantidad de empleados agrupados por título
        [HttpGet("CantidadEmpleadosPorTitulo")]
        public async Task<ActionResult<List<CantidadEmpleadosResponse>>> ObtenerEmpleadorPorTitulosGroupBy()
        {
            var resultado = await _repository.ObtenerEmpleadorPorTitulosGroupBy();
            return Ok(resultado);
        }

        // 10. Obtener productos y categorías
        [HttpGet("ProductosyCantegorias")]
        public async Task<ActionResult<List<ProductoCategoriaResponse>>> ObtenerProductosyCategorias()
        {
            var resultado = await _repository.ObtenerProductosyCategorias();
            return Ok(resultado);
        }

        // 11. Obtener producto por palabra
        [HttpGet("ObtenerProductosQueContienen")]
        public async Task<ActionResult<List<Products>>> ObtenerProductosQueContienen([FromQuery] string palabra)
        {
            var productos = await _repository.ObtenerProductosQueContienen(palabra);
            if (productos == null || !productos.Any()) return NotFound("No se encontraron productos");
            return Ok(productos);
        }
    }
}