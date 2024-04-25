using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eDnevnik.Services.Database
{
    public partial class eDnevnikContext : DbContext
    {
        public eDnevnikContext()
        {
        }

        public eDnevnikContext(DbContextOptions<eDnevnikContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Proizvodi> Proizvodis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost, 1433;Initial Catalog=eDnevnik; user=sa; Password=test; TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proizvodi>(entity =>
            {
                entity.HasKey(e => e.ProizvodId)
                    .HasName("PK__Proizvod__21A8BE18C3F1E2BC");

                entity.ToTable("Proizvodi");

                entity.Property(e => e.ProizvodId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProizvodID");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Naziv).HasMaxLength(255);

                entity.Property(e => e.Sifra).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
