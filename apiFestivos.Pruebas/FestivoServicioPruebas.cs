using apiFestivos.Aplicacion.Servicios;
using apiFestivos.Core.Interfaces.Servicios;
using apiFestivos.Core.Interfaces.Repositorios;
using apiFestivos.Dominio.Entidades;
using Moq;

namespace apiFestivos.Pruebas
{
    public class FestivoServicioPruebas
    {
        private readonly IFestivoServicio _festivoServicio;
        private readonly Mock<IFestivoRepositorio> _festivoRepositorioMock = new();
        private readonly Mock<IFestivoServicio> _festivoServicioMock = new();

        public FestivoServicioPruebas()
        {
            _festivoServicio = new FestivoServicio(_festivoRepositorioMock.Object);
        }

        [Fact]
        public async void PruebaIgualdad()
        {
            // Arrange
            Festivo festivo = new Festivo();
            festivo.Id = 0;

            _festivoRepositorioMock.Setup(f => f.Obtener(festivo.Id)).ReturnsAsync(festivo).Verifiable();

            // Act
            await _festivoServicio.Obtener(festivo.Id);

            // Assert
            Assert.True(festivo.Id == 0);
        }
    }
}