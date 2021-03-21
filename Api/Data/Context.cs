using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Api.Models;

#nullable disable

namespace Api.Data
{
    public partial class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public virtual DbSet<ChevacaPacket> ChevacaPackets { get; set; }
        public virtual DbSet<ObjetoJson> ObjetoJsons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=CHAPIDB;User Id=SA; Password=13aBr2009;");
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

                entity.Property(e => e.ApplicationId).HasColumnName("applicationID");

                entity.Property(e => e.ApplicationName).HasColumnName("applicationName");

                entity.Property(e => e.ConfirmedUplink).HasColumnName("confirmedUplink");

                entity.Property(e => e.Data).HasColumnName("data");

                entity.Property(e => e.DevAddr).HasColumnName("devAddr");

                entity.Property(e => e.DevEui).HasColumnName("devEUI");

                entity.Property(e => e.DeviceName).HasColumnName("deviceName");

                entity.Property(e => e.Dr).HasColumnName("dr");

                entity.Property(e => e.FCnt).HasColumnName("fCnt");

                entity.Property(e => e.FPort).HasColumnName("fPort");

                entity.Property(e => e.ObjectJsonobjectId).HasColumnName("objectJSONObjectID");

                entity.HasOne(d => d.ObjectJsonobject)
                    .WithMany(p => p.ChevacaPackets)
                    .HasForeignKey(d => d.ObjectJsonobjectId);
            });

            modelBuilder.Entity<ObjetoJson>(entity =>
            {
                entity.HasKey(e => e.ObjectId);

                entity.ToTable("ObjetoJson");

                entity.Property(e => e.ObjectId).HasColumnName("ObjectID");

                entity.Property(e => e.Alt).HasColumnName("alt");

                entity.Property(e => e.DeviceName).HasColumnName("deviceName");

                entity.Property(e => e.EndDateTime).HasColumnName("endDateTime");

                entity.Property(e => e.Hdop)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("hdop");

                entity.Property(e => e.Info).HasColumnName("info");

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
