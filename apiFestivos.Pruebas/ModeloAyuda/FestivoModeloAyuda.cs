using apiFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.Pruebas.ModeloAyuda
{
    public class FestivoModeloAyuda
    {
        public static List<Festivo> ListaFestivos => new()
        {
            new Festivo
                {
                    Id = 1,
                    Nombre = "Año nuevo",
                    Dia = 1,
                    Mes = 1,
                    DiasPascua = 0,
                    IdTipo = 1,
                },
                new Festivo
                {
                    Id = 2,
                    Nombre = "Santos Reyes",
                    Dia = 6,
                    Mes = 1,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 3,
                    Nombre = "San José",
                    Dia = 19,
                    Mes = 3,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 4,
                    Nombre = "Jueves Santo",
                    Dia = 0,
                    Mes = 0,
                    DiasPascua = -3,
                    IdTipo = 3,
                },
                new Festivo
                {
                    Id = 5,
                    Nombre = "Viernes Santo",
                    Dia = 0,
                    Mes = 0,
                    DiasPascua = -2,
                    IdTipo = 3,
                },
                new Festivo
                {
                    Id = 6,
                    Nombre = "Domingo de Pascua",
                    Dia = 0,
                    Mes = 0,
                    DiasPascua = 0,
                    IdTipo = 3,
                },
                new Festivo
                {
                    Id = 7,
                    Nombre = "Día del Trabajo",
                    Dia = 1,
                    Mes = 5,
                    DiasPascua = 0,
                    IdTipo = 1,
                },
                new Festivo
                {
                    Id = 8,
                    Nombre = "Ascensión del Señor",
                    Dia = 0,
                    Mes = 0,
                    DiasPascua = 40,
                    IdTipo = 4,
                },
                new Festivo
                {
                    Id = 9,
                    Nombre = "Corpus Christi",
                    Dia = 0,
                    Mes = 0,
                    DiasPascua = 61,
                    IdTipo = 4,
                },
                new Festivo
                {
                    Id = 10,
                    Nombre = "Sagrado Corazón de Jesús",
                    Dia = 0,
                    Mes = 0,
                    DiasPascua = 68,
                    IdTipo = 4,
                },
                new Festivo
                {
                    Id = 11,
                    Nombre = "San Pedro y San Pablo",
                    Dia = 29,
                    Mes = 6,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 12,
                    Nombre = "Independencia Colombia",
                    Dia = 20,
                    Mes = 7,
                    DiasPascua = 0,
                    IdTipo = 1,
                },
                new Festivo
                {
                    Id = 13,
                    Nombre = "Batalla de Boyacá",
                    Dia = 7,
                    Mes = 8,
                    DiasPascua = 0,
                    IdTipo = 1,
                },
                new Festivo
                {
                    Id = 14,
                    Nombre = "Asunción de la Virgen",
                    Dia = 15,
                    Mes = 8,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 15,
                    Nombre = "Día de la Raza",
                    Dia = 12,
                    Mes = 10,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 16,
                    Nombre = "Todos los santos",
                    Dia = 1,
                    Mes = 11,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 17,
                    Nombre = "Independencia de Cartagena",
                    Dia = 11,
                    Mes = 11,
                    DiasPascua = 0,
                    IdTipo = 2,
                },
                new Festivo
                {
                    Id = 18,
                    Nombre = "Inmaculada Concepción",
                    Dia = 8,
                    Mes = 12,
                    DiasPascua = 0,
                    IdTipo = 1,
                },
                new Festivo
                {
                    Id = 19,
                    Nombre = "Navidad",
                    Dia = 25,
                    Mes = 12,
                    DiasPascua = 0,
                    IdTipo = 1,
                }
        };
    }
}
