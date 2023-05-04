using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class IespinozaProgramacionNcapasGm2023Context : DbContext
{
    public IespinozaProgramacionNcapasGm2023Context()
    {
    }

    public IespinozaProgramacionNcapasGm2023Context(DbContextOptions<IespinozaProgramacionNcapasGm2023Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Alumno> Alumnos { get; set; }

    public virtual DbSet<Semestre> Semestres { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database= IespinozaProgramacionNcapasGm2023; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alumno>(entity =>
        {
            entity.HasKey(e => e.IdAlumno).HasName("PK__Alumno__460B47407D2A93C3");

            entity.ToTable("Alumno");

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdSemestreNavigation).WithMany(p => p.Alumnos)
                .HasForeignKey(d => d.IdSemestre)
                .HasConstraintName("FK_AlumnoSemestre");
        });

        modelBuilder.Entity<Semestre>(entity =>
        {
            entity.HasKey(e => e.IdSemestre);

            entity.ToTable("Semestre");

            entity.Property(e => e.IdSemestre).ValueGeneratedOnAdd();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
