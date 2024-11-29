using apiFestivos.Core.Interfaces.Repositorios;
using apiFestivos.Core.Interfaces.Servicios;
using apiFestivos.Dominio.DTOs;
using apiFestivos.Dominio.Entidades;

namespace apiFestivos.Aplicacion.Servicios
{
    public class FestivoServicio : IFestivoServicio
    {
        /// <summary>
        /// solo lectura
        /// </summary>
        private readonly IFestivoRepositorio repositorio;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="repositorio"></param>
        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }
        /// <summary>
        /// obtener
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<Festivo> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }
        /// <summary>
        /// obtener todos
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Festivo>> ObtenerTodos()
        {
            return await repositorio.ObtenerTodos();
        }
        /// <summary>
        /// buscar
        /// </summary>
        /// <param name="Dato"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Festivo>> Buscar(string Dato)
        {
            return await repositorio.Buscar(Dato);
        }
        /// <summary>
        /// agregar
        /// </summary>
        /// <param name="Festivo"></param>
        /// <returns></returns>
        public async Task<Festivo> Agregar(Festivo Festivo)
        {
            return await repositorio.Agregar(Festivo);
        }
        /// <summary>
        /// modificar
        /// </summary>
        /// <param name="Festivo"></param>
        /// <returns></returns>
        public async Task<Festivo> Modificar(Festivo Festivo)
        {
            return await repositorio.Modificar(Festivo);
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

        //********** Consultas //**********
        /// <summary>
        /// obtener inicio de semana santa
        /// </summary>
        /// <param name="año"></param>
        /// <returns></returns>
        private DateTime ObtenerInicioSemanaSanta(int año)
        {
            int a = año % 19;
            int b = año % 4;
            int c = año % 7;
            int d = (19 * a + 24) % 30;

            int dias = d + (2 * b + 4 * c + 6 * d + 5) % 7;

            int dia = 15 + dias;
            int mes = 3;
            if (dia > 31)
            {
                dia = dia - 31;
                mes = 4;
            }
            return new DateTime(año, mes, dia);
        }
        /// <summary>
        /// agregar dias
        /// </summary>
        /// <param name="fecha"></param>
        /// <param name="dias"></param>
        /// <returns></returns>
        private DateTime AgregarDias(DateTime fecha, int dias)
        {
            return fecha.AddDays(dias);
        }
        /// <summary>
        /// siguiente lunes
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        private DateTime SiguienteLunes(DateTime fecha)
        {
            DayOfWeek diaSemana = fecha.DayOfWeek;
            int diasLunes = ((int)DayOfWeek.Monday - (int)diaSemana + 7) % 7;
            return AgregarDias(fecha, diasLunes);
        }
        /// <summary>
        /// obtener festivo
        /// </summary>
        /// <param name="año"></param>
        /// <param name="festivo"></param>
        /// <returns></returns>
        private FechaFestivo ObtenerFestivo(int año, Festivo festivo)
        {
            FechaFestivo fechaFestivo = null!;
            switch (festivo.IdTipo)
            {
                case 1:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = new DateTime(año, festivo.Mes, festivo.Dia),
                        Nombre = festivo.Nombre!
                    };
                    break;
                case 2:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = SiguienteLunes(new DateTime(año, festivo.Mes, festivo.Dia)),
                        Nombre = festivo.Nombre!
                    };
                    break;
                case 3:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = AgregarDias(ObtenerInicioSemanaSanta(año), festivo.DiasPascua),
                        Nombre = festivo.Nombre!
                    };
                    break;
                case 4:
                    fechaFestivo = new FechaFestivo
                    {
                        Fecha = SiguienteLunes(AgregarDias(ObtenerInicioSemanaSanta(año), festivo.DiasPascua)),
                        Nombre = festivo.Nombre!
                    };
                    break;
            }
            return fechaFestivo;
        }
        /// <summary>
        /// obtener anio
        /// </summary>
        /// <param name="Año"></param>
        /// <returns></returns>
        public async Task<IEnumerable<FechaFestivo>> ObtenerAnio(int Año)
        {
            var festivos = await repositorio.ObtenerTodos();

            List<FechaFestivo> fechaFestivos = new List<FechaFestivo>();
            foreach (var festivo in festivos)
            {
                fechaFestivos.Add(ObtenerFestivo(Año, festivo));
            }
            return fechaFestivos;
        }
        /// <summary>
        /// es festivo o no
        /// </summary>
        /// <param name="Fecha"></param>
        /// <returns></returns>
        public async Task<bool> EsFestivo(DateTime Fecha)
        {
            // Obtener los festivos para el año específico
            var festivos = await ObtenerAnio(Fecha.Year);

            // Verificar si la fecha existe en la lista de festivos
            return festivos.Any(f => f.Fecha.Date == Fecha.Date);
        }
    }

}
