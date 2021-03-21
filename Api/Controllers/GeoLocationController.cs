using System;
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
        public Context conexto;

        public GeoLocationController(IServiceProvider services)
        {
            conexto = services.GetRequiredService<Context>();
        }

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
                            ChevacaPacket _ChevacaPackets = JsonConvert.DeserializeObject<ChevacaPacket>(jet);
                            if (_ChevacaPackets != null)
                            {
                                if (_ChevacaPackets.ObjectJsonobject != null)
                                {
                                    ObjetoJson _objectJSON = _ChevacaPackets.ObjectJsonobject;
                                    if (_objectJSON != null)
                                    {
                                        _objectJSON.StartDateTime = DateTime.Now;
                                        _objectJSON.DeviceName = _ChevacaPackets.DeviceName;
                                    }
                                }

                                conexto.ChevacaPackets.Add(_ChevacaPackets);
                                conexto.SaveChanges();
                                return Ok();
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
}