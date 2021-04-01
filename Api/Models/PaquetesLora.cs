using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Api.Models
{
    [Table("paquetes_lora")]
    public partial class PaquetesLora
    {
        [Key]
        [Column("Paquete_lora_ID")]
        public int PaqueteLoraId { get; set; }
        [Column("Payload_ID")]
        public int? PayloadId { get; set; }
        [Column("ApplicationID")]
        [StringLength(50)]
        public string ApplicationId { get; set; }
        [StringLength(50)]
        public string ApplicationName { get; set; }
        [StringLength(50)]
        public string DeviceName { get; set; }
        [Column("DevEUI")]
        [StringLength(100)]
        public string DevEui { get; set; }
        public bool Adr { get; set; }
        public int Dr { get; set; }
        [Column("FCnt")]
        public int Fcnt { get; set; }
        [Column("FPort")]
        public int Fport { get; set; }
        [StringLength(200)]
        public string Data { get; set; }
        public bool ConfirmedUplink { get; set; }
        [StringLength(100)]
        public string DevAddr { get; set; }
    }
}
