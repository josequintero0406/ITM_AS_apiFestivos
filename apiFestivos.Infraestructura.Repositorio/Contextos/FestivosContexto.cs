using apiFestivos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace apiFestivos.Infraestructura.Repositorio.Contextos
{
    public class FestivosContexto : DbContext
    {
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="options"></param>
        public FestivosContexto(DbContextOptions<FestivosContexto> options)
           : base(options)
        {
        }
        /// <summary>
        /// tipos
        /// </summary>
        public DbSet<Tipo> Tipos { get; set; }
        /// <summary>
        /// festivos
        /// </summary>
        public DbSet<Festivo> Festivos { get; set; }
        /// <summary>
        /// crear modelo
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tipo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Festivo>(entidad =>
            {
                entidad.HasKey(e => e.Id);
                entidad.HasIndex(e => e.Nombre).IsUnique();
            });

            modelBuilder.Entity<Festivo>()
              .HasOne(f => f.Tipo)
              .WithMany()
              .HasForeignKey(f => f.IdTipo)
              .IsRequired(false);
        }
    }
}
