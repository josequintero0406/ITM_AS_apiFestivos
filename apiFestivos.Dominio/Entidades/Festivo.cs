using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiFestivos.Dominio.Entidades
{
    [Table("Festivo")]
    public class Festivo
    {
        /// <summary>
        /// id
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// nombre
        /// </summary>
        [Column("Nombre"), StringLength(100)]
        public string? Nombre { get; set; }
        /// <summary>
        /// dia
        /// </summary>
        [Column("Dia")]
        public int Dia { get; set; }
        /// <summary>
        /// mes
        /// </summary>
        [Column("Mes")]
        public int Mes { get; set; }
        /// <summary>
        /// dias de pascua
        /// </summary>
        [Column("DiasPascua")]
        public int DiasPascua { get; set; }
        /// <summary>
        /// id tipo
        /// </summary>
        [Column("IdTipo")]
        public int IdTipo { get; set; }
        /// <summary>
        /// tipo
        /// </summary>
        public Tipo? Tipo { get; set; }

    }
}
