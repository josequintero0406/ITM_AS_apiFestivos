using Moq;
using apiFestivos.Aplicacion.Servicios;
using apiFestivos.Core.Interfaces.Servicios;
using apiFestivos.Core.Interfaces.Repositorios;
using apiFestivos.Pruebas.ModeloAyuda;
using apiFestivos.Dominio.Entidades;

namespace apiFestivos.Pruebas
{
    public class FestivoServicioPruebas
    {
        /// <summary>
        /// Declaraciones
        /// </summary>
        private readonly IFestivoServicio _festivoServicio;
        private readonly FestivoServicio festivoServicio;
        private readonly Mock<IFestivoRepositorio> _festivoRepositorioMock = new();

        /// <summary>
        /// Constructor
        /// </summary>
        public FestivoServicioPruebas()
        {
            _festivoServicio = new FestivoServicio(_festivoRepositorioMock.Object);
            festivoServicio = new FestivoServicio(_festivoRepositorioMock.Object);
        }

        /// <summary>
        /// 1 Verificar que, si la fecha coincide con una festiva, EsFestivo devuelve true (Caso Positivo)
        /// </summary>
        [Fact]
        public async Task EsFestivo_FechaFestiva_RetornaVerdadero()
        {
            // Arrange
            var fechaFestiva = new DateTime(2024, 12, 25);
            var festivo = new Festivo
            {
                Id = 1,
                Nombre = "Navidad",
                Mes = 12,
                Dia = 25,
                IdTipo = 1
            };
            var mockRepositorio = new Mock<IFestivoRepositorio>();
            mockRepositorio.Setup(repo => repo.ObtenerTodos()).ReturnsAsync(new List<Festivo> { festivo });
            var servicio = new FestivoServicio(mockRepositorio.Object);

            // Act
            var esFestivo = await servicio.EsFestivo(fechaFestiva);

            // Assert
            Assert.True(esFestivo);
        }

        /// <summary>
        /// 2. Probar una fecha que no esté en la lista de festivos y verificar que el resultado sea false
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task EsFestivo_FechaNoFestiva_RetornaFalso()
        {
            // Arrange
            var fechaFestiva = new DateTime(2024, 12, 25);
            var festivo = new Festivo // Especificar fecha no festiva
            {
                Id = 1,
                Nombre = "Navidad",
                Mes = 12,
                Dia = 26,
                IdTipo = 1
            };
            var mockRepositorio = new Mock<IFestivoRepositorio>();
            mockRepositorio.Setup(repo => repo.ObtenerTodos()).ReturnsAsync(new List<Festivo> { festivo });
            var servicio = new FestivoServicio(mockRepositorio.Object);

            // Act
            var esFestivo = await servicio.EsFestivo(fechaFestiva);

            // Assert
            Assert.False(esFestivo);
        }

        /// <summary>
        /// 2.1 Verificar que, al dar un festivo con tipo 1, se retorne la fecha esperada
        /// </summary>
        [Fact]
        public async void VerificarFestivoPrimerTipo_y_RetornarFechaEsperada()
        {
            // Arrange
            var listaFestivos = FestivoModeloAyuda.ListaFestivos.Where(item => item.IdTipo == 1).ToList();
            int year = 2013, mes = 7, dia = 20;
            DateTime.TryParse($"{year}-{mes}-{dia}", out DateTime fechaEsperada);
            _festivoRepositorioMock.Setup(f => f.ObtenerTodos()).ReturnsAsync(listaFestivos).Verifiable();

            // Act
            var resultado = await _festivoServicio.ObtenerAño(year);
            var fechaFestivaResultante = resultado.Where(item => item.Fecha == fechaEsperada).ToList();

            // Assert
            Assert.Equal(fechaEsperada, fechaFestivaResultante[0].Fecha);
            _festivoRepositorioMock.Verify(f => f.ObtenerTodos());
        }

        /// <summary>
        /// 2.2 Probar que un festivo movible (tipo 2) caiga en el lunes siguiente a la fecha inicial
        /// </summary>
        [Fact]
        public async void ProbarFestivoMovibleSiguienteLunes_y_RetornarVerdadero()
        {
            // Arrange
            var listaFestivos = FestivoModeloAyuda.ListaFestivos.Where(item => item.IdTipo == 2).ToList();
            int year = 2024, mes = 10, dia = 12;
            DateTime.TryParse($"{year}-{mes}-{dia}", out DateTime fechaInicial);
            DayOfWeek diaSemana = fechaInicial.DayOfWeek;
            int diasLunes = ((int)DayOfWeek.Monday - (int)diaSemana + 7) % 7;
            _festivoRepositorioMock.Setup(f => f.ObtenerTodos()).ReturnsAsync(listaFestivos).Verifiable();

            // Act
            var resultado = await _festivoServicio.ObtenerAño(year);
            var fechaLunesSiguiente = resultado
                .Where(item => item.Fecha == fechaInicial.AddDays(diasLunes)).ToList();

            // Assert
            Assert.Equal(fechaInicial.AddDays(diasLunes), fechaLunesSiguiente[0].Fecha);
            _festivoRepositorioMock.Verify(f => f.ObtenerTodos());
        }

        /// <summary>
        /// 2.3 Verificar un festivo que se desplaza a lunes basado en una fecha relativa a Semana Santa (tipo 4)
        /// </summary>
        [Fact]
        public async void VerificarFestivoEnSemanaSanta_y_RetornarResultadoVerdadero()
        {
            // Arrange
            var listaFestivos = FestivoModeloAyuda.ListaFestivos.Where(item => item.IdTipo == 4).ToList();
            int year = 2024;
            _festivoRepositorioMock.Setup(f => f.ObtenerTodos()).ReturnsAsync(listaFestivos).Verifiable();

            // Act
            var resultado = await _festivoServicio.ObtenerAño(year);

            // Assert
            Assert.Equal(new DateTime(2024, 5, 6), resultado.First().Fecha);
            _festivoRepositorioMock.Verify(f => f.ObtenerTodos());
        }
    }
}