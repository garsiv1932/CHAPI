using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api.Models
{
    [Table("logs")]
    public partial class Log
    {
        [Key]
        [Column("Log_ID")]
        public int LogId { get; set; }
        [Column("Usuario_ID")]
        public int UsuarioId { get; set; }
        [Column("Fecha_creado", TypeName = "datetime")]
        public DateTime FechaCreado { get; set; }
        [Required]
        [StringLength(100)]
        public string Usuario { get; set; }
        [Required]
        [Column("IP_client")]
        [StringLength(100)]
        public string IpClient { get; set; }
        [Required]
        [StringLength(100)]
        public string Descripcion { get; set; }
        [Required]
        [Column("Dato_afectado")]
        [StringLength(150)]
        public string DatoAfectado { get; set; }
    }
}
