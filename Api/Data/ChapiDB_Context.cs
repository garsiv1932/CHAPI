using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Models;

#nullable disable

namespace Api.Data
{
    public partial class ChapiDB_Context : DbContext
    {
        private Configuraciones _configuraciones = new();
        public ChapiDB_Context()
        {
        }

        public ChapiDB_Context(DbContextOptions<ChapiDB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<PaquetesLora> PaquetesLoras { get; set; }
        public virtual DbSet<Payload> Payloads { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    if (!string.IsNullOrWhiteSpace(_configuraciones.ConnectionString_chapi))
                    {
                        optionsBuilder.UseSqlServer(_configuraciones.ConnectionString_chapi);
                    }
                }
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

            modelBuilder.Entity<Payload>(entity =>
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
