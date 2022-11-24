using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GreenLeaves.Models
{
    public partial class GreenLeavesContext : DbContext
    {
        public GreenLeavesContext()
        {
        }

        public GreenLeavesContext(DbContextOptions<GreenLeavesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Contacto> Contacto { get; set; }
        public virtual DbSet<Estado> Estado { get; set; }
        public virtual DbSet<Pais> Pais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=WORKSTATION-DEV\\SQLEXPRESS;Database=GreenLeaves;Trusted_Connection=False;User=sa;Password=123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.Iso)
                    .HasName("PK__Ciudad__C4979A228D431F33");

                entity.Property(e => e.Iso)
                    .HasColumnName("ISO")
                    .HasMaxLength(3);

                entity.Property(e => e.IsoEstado)
                    .IsRequired()
                    .HasColumnName("ISO_Estado")
                    .HasMaxLength(3);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IsoEstadoNavigation)
                    .WithMany(p => p.Ciudad)
                    .HasForeignKey(d => d.IsoEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Ciudad__ISO_Esta__29572725");
            });

            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.IsoCiudad)
                    .IsRequired()
                    .HasColumnName("ISO_Ciudad")
                    .HasMaxLength(3);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IsoCiudadNavigation)
                    .WithMany(p => p.Contacto)
                    .HasForeignKey(d => d.IsoCiudad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contacto__ISO_Ci__30F848ED");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.Iso)
                    .HasName("PK__Estado__C4979A226A13B140");

                entity.Property(e => e.Iso)
                    .HasColumnName("ISO")
                    .HasMaxLength(3);

                entity.Property(e => e.IsoPais)
                    .IsRequired()
                    .HasColumnName("ISO_Pais")
                    .HasMaxLength(3);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IsoPaisNavigation)
                    .WithMany(p => p.Estado)
                    .HasForeignKey(d => d.IsoPais)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Estado__ISO_Pais__267ABA7A");
            });

            modelBuilder.Entity<Pais>(entity =>
            {
                entity.HasKey(e => e.Iso)
                    .HasName("PK__Pais__C4979A22AB3A6F9E");

                entity.Property(e => e.Iso)
                    .HasColumnName("ISO")
                    .HasMaxLength(3);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
