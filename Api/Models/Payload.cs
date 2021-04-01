using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api.Models
{
    [Table("payloads")]
    public partial class Payload
    {
        [Key]
        [Column("Payload_ID")]
        public int PayloadId { get; set; }
        [Column("Datetime_Inicio")]
        public DateTime DatetimeInicio { get; set; }
        [Column("Datetime_Fin")]
        public DateTime DatetimeFin { get; set; }
        [StringLength(50)]
        public string Alt { get; set; }
        [StringLength(50)]
        public string Hdop { get; set; }
        [StringLength(200)]
        public string Info { get; set; }
        [StringLength(50)]
        public string Latitud { get; set; }
        [StringLength(50)]
        public string Longitud { get; set; }
        [StringLength(50)]
        public string DeviceName { get; set; }
        [Column("DevEUI")]
        [StringLength(100)]
        public string DevEui { get; set; }
        [StringLength(100)]
        public string DevAddr { get; set; }
        [Column("ApplicationID")]
        [StringLength(50)]
        public string ApplicationId { get; set; }
        [StringLength(50)]
        public string ApplicationName { get; set; }
        [StringLength(50)]
        public string Gateway { get; set; }
    }
}
