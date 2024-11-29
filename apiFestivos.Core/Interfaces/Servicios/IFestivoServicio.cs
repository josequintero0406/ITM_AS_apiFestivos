using apiFestivos.Dominio.DTOs;
using apiFestivos.Dominio.Entidades;

namespace apiFestivos.Core.Interfaces.Servicios
{
    public interface IFestivoServicio
    {
        /// <summary>
        /// obtener todos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Festivo>> ObtenerTodos();
        /// <summary>
        /// obtener
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Festivo> Obtener(int Id);
        /// <summary>
        /// buscar
        /// </summary>
        /// <param name="Dato"></param>
        /// <returns></returns>
        Task<IEnumerable<Festivo>> Buscar(string Dato);
        /// <summary>
        /// agregar
        /// </summary>
        /// <param name="Festivo"></param>
        /// <returns></returns>
        Task<Festivo> Agregar(Festivo Festivo);
        /// <summary>
        /// modificar
        /// </summary>
        /// <param name="Festivo"></param>
        /// <returns></returns>
        Task<Festivo> Modificar(Festivo Festivo);
        /// <summary>
        /// eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<bool> Eliminar(int Id);

        //********** Consultas //**********
        /// <summary>
        /// obtener anio
        /// </summary>
        /// <param name="Año"></param>
        /// <returns></returns>
        Task<IEnumerable<FechaFestivo>> ObtenerAnio(int Año);
        /// <summary>
        /// es festivo o no
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        Task<bool> EsFestivo(DateTime Fecha);
    }
}
