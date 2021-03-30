using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class PaquetesLora
    {
        public int PaqueteLoraId { get; set; }
        public int? PayloadId { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string DeviceName { get; set; }
        public string DevEui { get; set; }
        public bool Adr { get; set; }
        public int Dr { get; set; }
        public int Fcnt { get; set; }
        public int Fport { get; set; }
        public string Data { get; set; }
        public bool ConfirmedUplink { get; set; }
        public string DevAddr { get; set; }
    }
}
