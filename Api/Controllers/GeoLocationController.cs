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
    public class GeoLocationController : ControllerBase
    {
        public Context conexto = new Context();

        // public GeoLocationController(IServiceProvider services)
        // {
        //     conexto = services.GetRequiredService<Context>();
        // }

        [HttpPost]
        public IActionResult Post(JsonDocument objectJSON)
        {
            if (objectJSON != null)
            {
                string jeti = objectJSON.RootElement.ToString();
                if (!string.IsNullOrWhiteSpace(jeti))
                {
                    string jet = Regex.Unescape(jeti);
                    if (!string.IsNullOrWhiteSpace(jet))
                    {
                        jet = jet.Replace("\"{", "{");
                        jet = jet.Replace("}\"", "}");

                        try
                        {
                            ChevacaPacket_AUX _ChevacaPackets = JsonConvert.DeserializeObject<ChevacaPacket_AUX>(jet);
                            if (_ChevacaPackets != null)
                            {
                                if (_ChevacaPackets.ObjectJSON != null)
                                {
                                    ObjetoJson_AUX _objectJSON = _ChevacaPackets.ObjectJSON;
                                    if (_objectJSON != null)
                                    {
                                        //_objectJSON.StartDateTime = DateTime.Now;
                                        //_objectJSON.DeviceName = _ChevacaPackets.DeviceName;
                                        
                                        //
                                        Payload _payload = new Payload();
                                        _payload.Alt = _objectJSON.alt;
                                        _payload.Hdop = _objectJSON.hdop;
                                        _payload.Info= _objectJSON.info;
                                        _payload.Lat= _objectJSON.lat;
                                        _payload.Lon = _objectJSON.lon;
                                        _payload.StartDateTime=DateTime.Now;
                                        _payload.DeviceName = _ChevacaPackets.DeviceName;
                                        _payload.DevEui = _ChevacaPackets.DevEui;
                                        _payload.DevAddr = _ChevacaPackets.DevAddr;
                                        _payload.ApplicationId = _ChevacaPackets.ApplicationId;
                                        _payload.ApplicationName = _ChevacaPackets.ApplicationName;
                                        
                                        //
                                        ChevacaPacket cp = new ChevacaPacket();
                                        cp.Adr = _ChevacaPackets.Adr;
                                        cp.Data = _ChevacaPackets.Data;
                                        cp.Dr = _ChevacaPackets.Dr;
                                        cp.ApplicationId = _ChevacaPackets.ApplicationId;
                                        cp.ApplicationName = _ChevacaPackets.ApplicationName;
                                        cp.ConfirmedUplink= _ChevacaPackets.ConfirmedUplink;
                                        cp.DevAddr = _ChevacaPackets.DevAddr;
                                        cp.DevEui = _ChevacaPackets.DevEui;
                                        cp.DeviceName= _ChevacaPackets.DeviceName;
                                        cp.FCnt = _ChevacaPackets.FCnt;
                                        cp.FPort= _ChevacaPackets.FPort;
                                        cp.PacketId= _ChevacaPackets.PacketId;
                                
                                        conexto.ChevacaPackets.Add(cp);
                                        conexto.Payloads.Add(_payload);
                                        conexto.SaveChanges();
                                        return Ok();
                                        
                                    }
                                }

                                
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                }
            }

            return BadRequest();
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