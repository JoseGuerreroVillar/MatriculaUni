using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MatriculaUni.DataModel.Model
{
    public partial class MatriculaUntContext : DbContext
    {
        public MatriculaUntContext()
        {
        }

        public MatriculaUntContext(DbContextOptions<MatriculaUntContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alumno> Alumnos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4MS4TOR;Database=MatriculaUnt;User Id=sa;Password=abcABC123!;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Alumno>(entity =>
            {
                entity.HasKey(e => e.i_IdAlumnos);

                entity.Property(e => e.v_Carrera).HasMaxLength(50);

                entity.Property(e => e.v_Dni)
                    .HasMaxLength(8)
                    .IsFixedLength(true);

                entity.Property(e => e.v_NombresApellidos).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
