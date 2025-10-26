using Microsoft.AspNetCore.Mvc;
using OrmAPI.Data;
using OrmAPI.Modelo;
using OrmAPI.Repository;
using OrmAPI.ResponseQuery;
using static OrmAPI.Repository.INorthwindRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace OrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _NorthwindRepository;

        public NorthwindController(INorthwindRepository northwindRepository)
        {
            _NorthwindRepository = northwindRepository;
        }

        // 1. Obtener todos los empleados
        [HttpGet("TodosLosEmpleados")]
        public async Task<List<Employee>> GetAll()
        {
            return await _NorthwindRepository.ObtenerTodosLosEmpleados();
        }

        // 2. Obtener cantidad total de empleados
        [HttpGet("CantidadDeEmpleados")]
        public async Task<int> ObtenerLaCantidadDeEmpleados()
        {
            return await _NorthwindRepository.ObtenerlaCantidadDeEmpleados();
        }

        // 3. Obtener empleado por ID
        [HttpGet("EmpleadoPorId/{idEmpleado}")]
        public async Task<ActionResult<Employee>> ObtenerEmpleadoporId(int idEmpleado)
        {
            var empleado = await _NorthwindRepository.ObtenerEmpleadoporId(idEmpleado);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }

        // 4. Obtener empleado por nombre
        [HttpGet("EmpleadoPorNombre/{nombre}")]
        public async Task<ActionResult<Employee>> ObtenerEmpleadoporNombre(string nombre)
        {
            // usa el método ObternerEmpleadoporNombre del repositorio
            var empleado = await _NorthwindRepository.ObtenerEmpleadoporNombre(nombre);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }

        // 5. Obtener ID de empleado por título
        [HttpGet("EmpleadoIDPorTitulo/{titulo}")]
        public async Task<ActionResult<int>> ObtenerIDEmpleadoPorTitulo(string titulo)
        {
            var id = await _NorthwindRepository.ObtenerIDEmpleadoPorTitulo(titulo);
            return Ok(id);
        }

        // 6. Obtener empleado por país
        [HttpGet("EmpleadoPorPais/{country}")]
        public async Task<ActionResult<Employee>> ObtenerEmpleadoPorCountry(string country)
        {
            var empleado = await _NorthwindRepository.ObtenerEmpleadoPorCountry(country);
            if (empleado == null) return NotFound("Empleado no encontrado");
            return Ok(empleado);
        }

        // 7. Obtener empleados por título
        [HttpGet("EmpleadosPorTitulo/{titulo}")]
        public async Task<ActionResult<List<Employee>>> ObtenerEmpleadoPorTitulo(string titulo)
        {
            var empleados = await _NorthwindRepository.ObtenerEmpleadoPorTitulo(titulo);
            return Ok(empleados);
        }

        // 8. Obtener el empleado más grande
        [HttpGet("EmpleadoMasGrande")]
        public async Task<ActionResult<Employee>> ObtenerElEmpleadoMasGrande()
        {
            var empleado = await _NorthwindRepository.ObtenerElEmpleadoMasGrande();
            return Ok(empleado);
        }

        // 9. Obtener empleados por ciudad
        [HttpGet("EmpleadosPorCiudad/{ciudad}")]
        public async Task<ActionResult<List<Employee>>> ObtenerEmpleadoPorCiudad(string ciudad)
        {
            var empleados = await _NorthwindRepository.ObtenerEmpleadoPorCiudad(ciudad);
            return Ok(empleados);
        }

        // 10. Cantidad de empleados agrupados por título
        [HttpGet("CantidadEmpleadosPorTitulo")]
        public async Task<ActionResult<List<CantidadEmpleadosResponse>>> ObtenerEmpleadorPorTitulosGroupBy()
        {
            var resultado = await _NorthwindRepository.ObtenerEmpleadorPorTitulosGroupBy();
            return Ok(resultado);
        }

        // 11. Obtener productos y categorías
        [HttpGet("ProductosyCantegorias")]
        public async Task<ActionResult<List<ProductoCategoriaResponse>>> ObtenerProductosyCategorias()
        {
            var resultado = await _NorthwindRepository.ObtenerProductosyCategorias();
            return Ok(resultado);
        }

        // 12. Modificar nombre de empleado
        [HttpPut("ModificarNombreEmpleado/{idEmpleado}")]
        public async Task<ActionResult> ModificarNombreEmpleado(int idEmpleado, [FromQuery] string nombre)
        {
            var actualizado = await _NorthwindRepository.ModificarNombreEmpleado(idEmpleado, nombre);
            if (!actualizado) return NotFound("No se pudo actualizar el nombre del empleado");
            return Ok("Empleado actualizado correctamente");
        }

        // 13. Eliminar orden por ID
        [HttpDelete("EliminarOrden/{id}")]
        public async Task<ActionResult> EliminarOrdenPorID(int id)
        {
            var eliminado = await _NorthwindRepository.EliminarOrdenPorID(id);
            if (!eliminado) return NotFound("No se pudo eliminar la orden");
            return Ok("Orden eliminada correctamente");
        }

        // 14. Insertar nuevo empleado
        [HttpPost("InsertarEmpleado")]
        public async Task<ActionResult> InsertarEmpleado()
        {
            var insertado = await _NorthwindRepository.InsertarEmpleado();
            if (!insertado) return BadRequest("No se pudo insertar el empleado");
            return Ok("Empleado insertado correctamente");
        }
    }
}