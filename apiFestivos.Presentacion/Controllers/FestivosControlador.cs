using apiFestivos.Core.Interfaces.Servicios;
using apiFestivos.Dominio.DTOs;
using apiFestivos.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace apiFestivos.Presentacion.Controllers
{
    [ApiController]
    [Route("api/festivos")]
    public class FestivosControlador : ControllerBase
    {
        /// <summary>
        /// solo lectura
        /// </summary>
        private readonly IFestivoServicio servicio;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="servicio"></param>
        public FestivosControlador(IFestivoServicio servicio)
        {
            this.servicio = servicio;
        }
        /// <summary>
        /// listar
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar")]
        public async Task<ActionResult<IEnumerable<Festivo>>> ObtenerTodos()
        {
            return Ok(await servicio.ObtenerTodos());
        }
        /// <summary>
        /// obtener
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("obtener/{Id}")]
        public async Task<ActionResult<Festivo>> Obtener(int Id)
        {
            return Ok(await servicio.Obtener(Id));
        }
        /// <summary>
        /// buscar
        /// </summary>
        /// <param name="Dato"></param>
        /// <returns></returns>
        [HttpGet("buscar/{Dato}")]
        public async Task<ActionResult<Festivo>> Buscar(string Dato)
        {
            return Ok(await servicio.Buscar(Dato));
        }
        /// <summary>
        /// agregar
        /// </summary>
        /// <param name="Festivo"></param>
        /// <returns></returns>
        [HttpPost("agregar")]
        public async Task<ActionResult<Festivo>> Agregar([FromBody] Festivo Festivo)
        {
            return Ok(await servicio.Agregar(Festivo));
        }
        /// <summary>
        /// modificar
        /// </summary>
        /// <param name="Festivo"></param>
        /// <returns></returns>
        [HttpPut("modificar")]
        public async Task<ActionResult<Festivo>> Modificar([FromBody] Festivo Festivo)
        {
            return Ok(await servicio.Modificar(Festivo));
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

        //********** Consultas //**********
        /// <summary>
        /// obtener anio
        /// </summary>
        /// <param name="Year"></param>
        /// <returns></returns>
        [HttpGet("listar/{Year}")]
        public async Task<ActionResult<IEnumerable<FechaFestivo>>> ObtenerAnio(int Year)
        {
            return Ok(await servicio.ObtenerAnio(Year));
        }
        /// <summary>
        /// es festivo o no
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="Mes"></param>
        /// <param name="Dia"></param>
        /// <returns></returns>
        [HttpGet("Verificar/{Year}/{Mes}/{Dia}")]
        public async Task<ActionResult<bool>> EsFestivo(int Year, int Mes, int Dia)
        {
            // Validar que la fecha sea válida
            if (!DateTime.TryParse($"{Year}-{Mes}-{Dia}", out DateTime fecha))
            {
                return BadRequest("La fecha proporcionada no es válida.");
            }

            return Ok(await servicio.EsFestivo(fecha));
        }
    }
}
