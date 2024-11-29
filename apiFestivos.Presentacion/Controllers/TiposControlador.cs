using apiFestivos.Core.Interfaces.Servicios;
using apiFestivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace apiFestivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/tipos")]
    public class TiposControlador : ControllerBase
    {
        /// <summary>
        /// solo lectura
        /// </summary>
        private readonly ITipoServicio servicio;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="servicio"></param>
        public TiposControlador(ITipoServicio servicio)
        {
            this.servicio = servicio;
        }
        /// <summary>
        /// listar
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Tipo>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }
        /// <summary>
        /// obtener
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("obtener/{Id}")]
        public async Task<ActionResult<Tipo>> Obtener(int Id)
        {
            return Ok(await servicio.Obtener(Id));
        }
        /// <summary>
        /// buscar
        /// </summary>
        /// <param name="Dato"></param>
        /// <returns></returns>
        [HttpGet("buscar/{Tipo}/{Dato}")]
        public async Task<ActionResult<Tipo>> Buscar(string Dato)
        {
            return Ok(await servicio.Buscar(Dato));
        }
        /// <summary>
        /// agregar
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        [HttpPost("agregar")]
        public async Task<ActionResult<Tipo>> Agregar([FromBody] Tipo Tipo)
        {
            return Ok(await servicio.Agregar(Tipo));
        }
        /// <summary>
        /// modificar
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        [HttpPut("modificar")]
        public async Task<ActionResult<Tipo>> Modificar([FromBody] Tipo Tipo)
        {
            return Ok(await servicio.Modificar(Tipo));
        }
        /// <summary>
        /// eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("eliminar/{Id}")]
        public async Task<ActionResult<bool>> Eliminar(int Id)
        {
            return Ok(await servicio.Eliminar(Id));
        }
    }
}
