using System;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Api.Data
{
    public partial class Chapi_Context : DbContext
    {
        private Configuraciones _configuraciones = new();
        public Chapi_Context()
        {
        }

        public Chapi_Context(DbContextOptions<Chapi_Context> options)
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
                entity.HasKey(e => e.PaqueteLoraId);

                entity.ToTable("paquetes_lora");

                entity.Property(e => e.PaqueteLoraId).HasColumnName("Paquete_lora_ID");

                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApplicationID");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Data)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DevEui)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DevEUI");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fcnt).HasColumnName("FCnt");

                entity.Property(e => e.Fport).HasColumnName("FPort");

                entity.Property(e => e.PayloadId).HasColumnName("Paylod_ID");
            });

            modelBuilder.Entity<Payload>(entity =>
            {
                entity.ToTable("payloads");

                entity.Property(e => e.PayloadId).HasColumnName("Payload_ID");

                entity.Property(e => e.Alt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApplicationID");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DatetimeFin).HasColumnName("Datetime_Fin");

                entity.Property(e => e.DatetimeInicio).HasColumnName("Datetime_Inicio");

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DevEui)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DevEUI");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gateway)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Hdop)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Info)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Latitud)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Longitud)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
