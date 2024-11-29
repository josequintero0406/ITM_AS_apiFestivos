using apiFestivos.Core.Interfaces.Repositorios;
using apiFestivos.Core.Interfaces.Servicios;
using apiFestivos.Dominio.Entidades;

namespace apiFestivos.Aplicacion.Servicios
{
    public class TipoServicio : ITipoServicio
    {
        /// <summary>
        /// solo lectura
        /// </summary>
        private readonly ITipoRepositorio repositorio;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repositorio"></param>
        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        /// <summary>
        /// obtener
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Tipo> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }
        /// <summary>
        /// obtener todos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Tipo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
        /// <summary>
        /// buscar
        /// </summary>
        /// <param name="Dato"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Tipo>> Buscar(string Dato)
        {
            return await repositorio.Buscar(Dato);
        }
        /// <summary>
        /// agregar
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public async Task<Tipo> Agregar(Tipo Tipo)
        {
            return await repositorio.Agregar(Tipo);
        }
        /// <summary>
        /// modificar
        /// </summary>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public async Task<Tipo> Modificar(Tipo Tipo)
        {
            return await repositorio.Modificar(Tipo);
        }
        /// <summary>
        /// eliminar
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> Eliminar(int Id)
        {
            return await repositorio.Eliminar(Id);
        }
    }
}
