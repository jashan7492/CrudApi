using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.Models
{
    public partial class studentContext : DbContext
    {
        public studentContext()
        {
        }

        public studentContext(DbContextOptions<studentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Tbstudent> Tbstudent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-5KE9QV2J\\SQLEXPRESS;Initial Catalog=student;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.User)
                    .HasName("PK__tmp_ms_x__7FC76D738DF842DB");

                entity.ToTable("login");

                entity.HasIndex(e => e.Pass)
                    .HasName("UQ__tmp_ms_x__8320F63EA83B84B6")
                    .IsUnique();

                entity.Property(e => e.User)
                    .HasColumnName("user")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tbstudent>(entity =>
            {
                entity.HasKey(e => e.Stuid)
                    .HasName("PK__tmp_ms_x__AEC8BBF7542ADAED");

                entity.ToTable("tbstudent");

                entity.HasIndex(e => e.Stufatnam)
                    .HasName("UQ__tmp_ms_x__A850B379A0BF48CB")
                    .IsUnique();

                entity.Property(e => e.Stuid)
                    .HasColumnName("stuid")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stuage).HasColumnName("stuage");

                entity.Property(e => e.Stucls)
                    .HasColumnName("stucls")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Stufatnam)
                    .HasColumnName("stufatnam")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stumotnam)
                    .HasColumnName("stumotnam")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Stuname)
                    .HasColumnName("stuname")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
