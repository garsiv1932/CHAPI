using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class ChevacaPacket
    {
        public int PacketId { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
        public string DeviceName { get; set; }
        public string DevEui { get; set; }
        public bool Adr { get; set; }
        public int Dr { get; set; }
        public int FCnt { get; set; }
        public int FPort { get; set; }
        public string Data { get; set; }
        public int? PaylodId { get; set; }
        public bool ConfirmedUplink { get; set; }
        public string DevAddr { get; set; }
    }
}
