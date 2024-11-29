using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace apiFestivos.Dominio.Entidades
{
    [Table("Tipo")]
    public class Tipo
    {
        /// <summary>
        /// id
        /// </summary>
        [Column("Id")]
        public int Id { get; set; }
        /// <summary>
        /// tipo
        /// </summary>
        [Column("Tipo"), StringLength(100)]
        public string? Nombre { get; set; }
    }
}
