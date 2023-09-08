using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TALLER_MECANICA.Models;

public partial class TallerMecanicaContext : DbContext
{
    public TallerMecanicaContext()
    {
    }

    public TallerMecanicaContext(DbContextOptions<TallerMecanicaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empledo> Empledos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-0PAI4P6R\\SQLEXPRESS; Database=TALLER_MECANICA; Trusted_Connection=true; TrustServerCertificate=true ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__CLIENTES__3214EC27A8157CEB");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cedula).HasColumnName("CEDULA");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
            entity.Property(e => e.Primerapellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMERAPELLIDO");
            entity.Property(e => e.Segundoapellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SEGUNDOAPELLIDO");
            entity.Property(e => e.Telefono).HasColumnName("TELEFONO");
        });

        modelBuilder.Entity<Empledo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EMPLEDOS__3214EC27FFDA7431");

            entity.ToTable("EMPLEDOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Cedula).HasColumnName("CEDULA");
            entity.Property(e => e.Cliente).HasColumnName("CLIENTE");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Primerapellido)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PRIMERAPELLIDO");
            entity.Property(e => e.TarjetaProfesional).HasColumnName("TARJETA_PROFESIONAL");
            entity.Property(e => e.Vehiculo).HasColumnName("VEHICULO");

            entity.HasOne(d => d.ClienteNavigation).WithMany(p => p.Empledos)
                .HasForeignKey(d => d.Cliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEDOS__CLIENT__286302EC");

            entity.HasOne(d => d.VehiculoNavigation).WithMany(p => p.Empledos)
                .HasForeignKey(d => d.Vehiculo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__EMPLEDOS__VEHICU__29572725");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VEHICULO__3214EC2752340A2A");

            entity.ToTable("VEHICULOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("COLOR");
            entity.Property(e => e.FechaSoat)
                .HasColumnType("date")
                .HasColumnName("FECHA_SOAT");
            entity.Property(e => e.FechaTecno)
                .HasColumnType("date")
                .HasColumnName("FECHA_TECNO");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MARCA");
            entity.Property(e => e.Placa)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PLACA");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
