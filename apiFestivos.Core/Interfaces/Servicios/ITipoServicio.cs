using apiFestivos.Dominio.Entidades;

namespace apiFestivos.Core.Interfaces.Servicios
{
    public interface ITipoServicio
    {
        /// <summary>
        /// obtener todos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Tipo>> ObtenerTodos();
        /// <summary>
        /// obtener
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<Tipo> Obtener(int Id);
        /// <summary>
        /// buscar
        /// </summary>
        /// <param name="Dato"></param>
        /// <returns></returns>
        Task<IEnumerable<Tipo>> Buscar(string Dato);
        /// <summary>
        /// agregar
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        Task<Tipo> Agregar(Tipo Tipo);
        /// <summary>
        /// modificar
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        Task<Tipo> Modificar(Tipo Tipo);
        /// <summary>
        /// eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<bool> Eliminar(int Id);
    }
}
