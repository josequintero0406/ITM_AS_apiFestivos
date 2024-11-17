using apiFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.Pruebas.ModeloAyuda
{
    public class TipoModeloAyuda
    {
        public static List<Tipo> ListaTipos => new()
        {
            new Tipo()
            {
                Id = 1,
                Nombre = "Fijo",
            },
            new Tipo()
            {
                Id = 2,
                Nombre = "Ley Puente Festivo"
            },
            new Tipo()
            {
                Id = 3,
                Nombre = "Basado en Pascua"
            },
            new Tipo()
            {
                Id = 4,
                Nombre = "Basado en Pascua y Ley Puente Festivo"
            }
        };

    }
}
