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
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Api.Models;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetLorawanPackagesController : ControllerBase
    {
        public ChapiDB_Context conexto = new();

        [HttpPost]
        public IActionResult Post(JsonDocument objectJSON)
        {
            // Logger variables
            System.Diagnostics.StackTrace stackTrace = new(true);
            System.Diagnostics.StackFrame stackFrame = new();
            string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name;
            string methodName = stackFrame.GetMethod().Name;

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
                        PaquetesLora_AUX _paquetesLora_AUX = JsonConvert.DeserializeObject<PaquetesLora_AUX>(_objectJSON_unescape);
                        if (_paquetesLora_AUX != null)
                        {
                            if (_paquetesLora_AUX.ObjectJSON != null)
                            {
                                Payload_AUX _payload_AUX = _paquetesLora_AUX.ObjectJSON;
                                if (_payload_AUX != null)
                                {
                                    Payload _payload = new();
                                    _payload.Alt = _payload_AUX.alt.ToString();
                                    _payload.Hdop = _payload_AUX.hdop.ToString();
                                    _payload.Info = _payload_AUX.info;
                                    _payload.Latitud = _payload_AUX.lat.ToString();
                                    _payload.Longitud = _payload_AUX.lon.ToString();
                                    _payload.DatetimeInicio = DateTime.Now;
                                    _payload.DatetimeFin = DateTime.Now;
                                    _payload.DeviceName = _paquetesLora_AUX.DeviceName;
                                    _payload.DevEui = _paquetesLora_AUX.DevEui;
                                    _payload.DevAddr = _paquetesLora_AUX.DevAddr;
                                    _payload.ApplicationId = _paquetesLora_AUX.ApplicationId;
                                    _payload.ApplicationName = _paquetesLora_AUX.ApplicationName;

                                    PaquetesLora _paquetesLora = new();
                                    _paquetesLora.PayloadId = _paquetesLora_AUX.PacketId;
                                    _paquetesLora.Adr = _paquetesLora_AUX.Adr;
                                    _paquetesLora.Data = _paquetesLora_AUX.Data;
                                    _paquetesLora.Dr = _paquetesLora_AUX.Dr;
                                    _paquetesLora.ApplicationId = _paquetesLora_AUX.ApplicationId;
                                    _paquetesLora.ApplicationName = _paquetesLora_AUX.ApplicationName;
                                    _paquetesLora.ConfirmedUplink = _paquetesLora_AUX.ConfirmedUplink;
                                    _paquetesLora.DevAddr = _paquetesLora_AUX.DevAddr;
                                    _paquetesLora.DevEui = _paquetesLora_AUX.DevEui;
                                    _paquetesLora.DeviceName = _paquetesLora_AUX.DeviceName;
                                    _paquetesLora.Fcnt = _paquetesLora_AUX.FCnt;
                                    _paquetesLora.Fport = _paquetesLora_AUX.FPort;

                                    conexto.PaquetesLoras.Add(_paquetesLora);
                                    conexto.Payloads.Add(_payload);
                                    try
                                    {
                                        conexto.SaveChanges();
                                    }
                                    catch (ValidationException ex)
                                    {
                                        Logs_Service.Log_AgregarExcepcion("Excepcion. Guardando en la BD. ERROR:", className, methodName, ex.Message);
                                        return BadRequest();
                                    }
                                    catch (DbUpdateException ex)
                                    {
                                        Logs_Service.Log_AgregarExcepcion("Excepcion. Guardando en la BD. ERROR:", className, methodName, ex.Message);
                                        return BadRequest();
                                    }
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
    
    class PaquetesLora_AUX
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
        public Payload_AUX ObjectJSON { get; set; }
        public bool ConfirmedUplink { get; set; }
        public string DevAddr { get; set; }
    }
    
    class Payload_AUX
    {
        public int alt { get; set; }
        public decimal hdop { get; set; }
        public string info { get; set; }
        public decimal lat { get; set; }
        public decimal lon { get; set; }
    }
}