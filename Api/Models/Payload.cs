using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Payload
    {
        public int ObjectId { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Alt { get; set; }
        public decimal Hdop { get; set; }
        public string Info { get; set; }
        public decimal Lat { get; set; }
        public decimal Lon { get; set; }
        public string DeviceName { get; set; }
        public string DevEui { get; set; }
        public string DevAddr { get; set; }
        public string ApplicationId { get; set; }
        public string ApplicationName { get; set; }
    }
}
