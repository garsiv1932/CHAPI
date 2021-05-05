using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Models;

#nullable disable

namespace Api.Data
{
    public partial class ChapiDB_Context : DbContext
    {
        public ChapiDB_Context()
        {
        }

        public ChapiDB_Context(DbContextOptions<ChapiDB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<PaquetesLora> PaquetesLora { get; set; }
        public virtual DbSet<Payloads> Payloads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=chapidb;User Id=chevaca_login;Password=chevaca1234; Trusted_Connection=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<PaquetesLora>(entity =>
            {
                entity.Property(e => e.ApplicationId).IsUnicode(false);

                entity.Property(e => e.ApplicationName).IsUnicode(false);

                entity.Property(e => e.Data).IsUnicode(false);

                entity.Property(e => e.DevAddr).IsUnicode(false);

                entity.Property(e => e.DevEui).IsUnicode(false);

                entity.Property(e => e.DeviceName).IsUnicode(false);
            });

            modelBuilder.Entity<Payloads>(entity =>
            {
                entity.Property(e => e.Alt).IsUnicode(false);

                entity.Property(e => e.ApplicationId).IsUnicode(false);

                entity.Property(e => e.ApplicationName).IsUnicode(false);

                entity.Property(e => e.DevAddr).IsUnicode(false);

                entity.Property(e => e.DevEui).IsUnicode(false);

                entity.Property(e => e.DeviceName).IsUnicode(false);

                entity.Property(e => e.Gateway).IsUnicode(false);

                entity.Property(e => e.Hdop).IsUnicode(false);

                entity.Property(e => e.Info).IsUnicode(false);

                entity.Property(e => e.Latitud).IsUnicode(false);

                entity.Property(e => e.Longitud).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
