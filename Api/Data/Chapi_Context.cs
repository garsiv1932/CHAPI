using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Models;

#nullable disable

namespace Api.Data
{
    public partial class Chapi_Context : DbContext
    {
        private Configuraciones _configuraciones = new ();
        public Chapi_Context()
        {
        }

        public Chapi_Context(DbContextOptions<Chapi_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ChevacaPacket> ChevacaPackets { get; set; }
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

            modelBuilder.Entity<ChevacaPacket>(entity =>
            {
                entity.HasKey(e => e.PacketId);

                entity.Property(e => e.PacketId).HasColumnName("PacketID");

                entity.Property(e => e.Adr).HasColumnName("adr");

                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("applicationID");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("applicationName");

                entity.Property(e => e.ConfirmedUplink).HasColumnName("confirmedUplink");

                entity.Property(e => e.Data)
                    .IsUnicode(false)
                    .HasColumnName("data");

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("devAddr");

                entity.Property(e => e.DevEui)
                    .IsUnicode(false)
                    .HasColumnName("devEUI");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("deviceName");

                entity.Property(e => e.Dr).HasColumnName("dr");

                entity.Property(e => e.FCnt).HasColumnName("fCnt");

                entity.Property(e => e.FPort).HasColumnName("fPort");

                entity.Property(e => e.PaylodId).HasColumnName("paylodID");
            });

            modelBuilder.Entity<Payload>(entity =>
            {
                entity.HasKey(e => e.ObjectId)
                    .HasName("PK_ObjetoJson");

                entity.ToTable("Payload");

                entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

                entity.Property(e => e.Alt).HasColumnName("alt");

                entity.Property(e => e.ApplicationId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("applicationID");

                entity.Property(e => e.ApplicationName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("applicationName");

                entity.Property(e => e.DevAddr)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("devAddr");

                entity.Property(e => e.DevEui)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("devEUI");

                entity.Property(e => e.DeviceName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("deviceName");

                entity.Property(e => e.EndDateTime).HasColumnName("endDateTime");

                entity.Property(e => e.Hdop)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("hdop");

                entity.Property(e => e.Info)
                    .IsUnicode(false)
                    .HasColumnName("info");

                entity.Property(e => e.Lat)
                    .HasColumnType("decimal(12, 5)")
                    .HasColumnName("lat");

                entity.Property(e => e.Lon)
                    .HasColumnType("decimal(12, 5)")
                    .HasColumnName("lon");

                entity.Property(e => e.StartDateTime).HasColumnName("startDateTime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
