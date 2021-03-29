using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json.Serialization;
using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;


namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLorawanPackagesController : ControllerBase
    {
        public Chapi_Context conexto = new();

        [HttpPost]
        public IActionResult Post(JsonDocument objectJSON)
        {
            if (objectJSON != null)
            {
                string _objectJSON = objectJSON.RootElement.ToString();
                if (!string.IsNullOrWhiteSpace(_objectJSON))
                {
                    string _objectJSON_unescape = Regex.Unescape(_objectJSON);
                    if (!string.IsNullOrWhiteSpace(_objectJSON_unescape))
                    {
                        _objectJSON_unescape = _objectJSON_unescape.Replace("\"{", "{");
                        _objectJSON_unescape = _objectJSON_unescape.Replace("}\"", "}");
                        ChevacaPacket_AUX _ChevacaPackets = JsonConvert.DeserializeObject<ChevacaPacket_AUX>(_objectJSON_unescape);
                        if (_ChevacaPackets != null)
                        {
                            if (_ChevacaPackets.ObjectJSON != null)
                            {
                                ObjetoJson_AUX _ObjetoJson_AUX = _ChevacaPackets.ObjectJSON;
                                if (_ObjetoJson_AUX != null)
                                {
                                    Payload _payload = new ();
                                    _payload.Alt = _ObjetoJson_AUX.alt;
                                    _payload.Hdop = _ObjetoJson_AUX.hdop;
                                    _payload.Info = _ObjetoJson_AUX.info;
                                    _payload.Lat = _ObjetoJson_AUX.lat;
                                    _payload.Lon = _ObjetoJson_AUX.lon;
                                    _payload.StartDateTime = DateTime.Now;
                                    _payload.DeviceName = _ChevacaPackets.DeviceName;
                                    _payload.DevEui = _ChevacaPackets.DevEui;
                                    _payload.DevAddr = _ChevacaPackets.DevAddr;
                                    _payload.ApplicationId = _ChevacaPackets.ApplicationId;
                                    _payload.ApplicationName = _ChevacaPackets.ApplicationName;

                                    ChevacaPacket _ChevacaPacket = new ();
                                    _ChevacaPacket.Adr = _ChevacaPackets.Adr;
                                    _ChevacaPacket.Data = _ChevacaPackets.Data;
                                    _ChevacaPacket.Dr = _ChevacaPackets.Dr;
                                    _ChevacaPacket.ApplicationId = _ChevacaPackets.ApplicationId;
                                    _ChevacaPacket.ApplicationName = _ChevacaPackets.ApplicationName;
                                    _ChevacaPacket.ConfirmedUplink = _ChevacaPackets.ConfirmedUplink;
                                    _ChevacaPacket.DevAddr = _ChevacaPackets.DevAddr;
                                    _ChevacaPacket.DevEui = _ChevacaPackets.DevEui;
                                    _ChevacaPacket.DeviceName = _ChevacaPackets.DeviceName;
                                    _ChevacaPacket.FCnt = _ChevacaPackets.FCnt;
                                    _ChevacaPacket.FPort = _ChevacaPackets.FPort;
                                    _ChevacaPacket.PacketId = _ChevacaPackets.PacketId;

                                    conexto.ChevacaPackets.Add(_ChevacaPacket);
                                    conexto.Payloads.Add(_payload);
                                    conexto.SaveChanges();
                                    return Ok();
                                }
                            }
                        }
                    }
                }
            }
            return BadRequest();
        }

        [HttpGet]
        public string Get()
        {
            return "IM OK.";
        }
    }
    
    class ChevacaPacket_AUX
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
        public ObjetoJson_AUX ObjectJSON { get; set; }
        public bool ConfirmedUplink { get; set; }
        public string DevAddr { get; set; }
    }
    
    class ObjetoJson_AUX
    {
        public int alt { get; set; }
        public decimal hdop { get; set; }
        public string info { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}