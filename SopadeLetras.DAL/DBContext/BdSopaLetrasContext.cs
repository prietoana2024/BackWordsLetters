using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using SopadeLetras.MODELS;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SopadeLetras.DAL.DBContext
{

    public partial class BdSopaLetrasContext : DbContext
    {
        public BdSopaLetrasContext()
        {
        }

        public BdSopaLetrasContext(DbContextOptions<BdSopaLetrasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Caractere> Caracteres { get; set; }

        public virtual DbSet<Palabra> Palabras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caractere>(entity =>
            {
                entity.HasKey(e => e.IdCaracteres).HasName("PK__Caracter__DE4E1B97EB16D87E");

                entity.Property(e => e.IdCaracteres).HasColumnName("idCaracteres");
                entity.Property(e => e.Caracteres)
                    .HasMaxLength(378)
                    .IsUnicode(false)
                    .HasColumnName("caracteres");
            });

            modelBuilder.Entity<Palabra>(entity =>
            {
                entity.HasKey(e => e.IdPalabras).HasName("PK__Palabras__B55AC079E5471167");

                entity.Property(e => e.IdPalabras).HasColumnName("idPalabras");
                entity.Property(e => e.Palabras)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("palabras");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
