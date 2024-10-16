using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentRecordz.Models;

public partial class StudentRecordsContext : DbContext
{
    public StudentRecordsContext()
    {
    }

    public StudentRecordsContext(DbContextOptions<StudentRecordsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BEG6RIV;Database=StudentRecords;User Id=Abdullahi Onimisi;Password=Abdul131; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Result__3214EC0749E849B7");

            entity.ToTable("Result");

            entity.Property(e => e.Grade)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Subject)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.Results)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Result_Student");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC0759078E1B");

            entity.ToTable("Student");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
