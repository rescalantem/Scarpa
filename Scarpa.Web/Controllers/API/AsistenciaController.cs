using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;
using Scarpa.Common.Entities;
using Scarpa.Common.Responses;
using Scarpa.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scarpa.Web.Controllers.API
{    
    [Route("api/[controller]")]
    [ApiController]
    public class AsistenciaController : ControllerBase
    {
        private string respuesta;
        private readonly DataContext _context;
        public AsistenciaController(DataContext context)
        {
            _context = context;
        }
        // GET: api/<AsistenciaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AsistenciaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AsistenciaController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] asisChecada asisChecada)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Usuarios usua = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuTelefono == asisChecada.Celular);

            if (usua.UsuActivo)
            {
                if (!HayExcepciones(usua.UsuId))
                {
                    string res = AltaIncidencia(usua.UsuId, DateTime.Now, asisChecada.Guid);
                    var rep = new Response { IsSuccess = true, Message = res, Result = null };
                    if (res != "") return Ok(rep); else return Ok("Hoy no checas");
                }
            }
            else
            {
                return Ok("Lo siento, pero estás suspendido.");
            }
            return BadRequest("Error interno");
        }

        public string AltaIncidencia(int usuId, DateTime fechahora, string guid)
        {
            int tieId = (from gui in _context.AsisGuid
                         join caj in _context.TiendaCajas on gui.CajId equals caj.CajId
                         join tie in _context.Tiendas on caj.TieId equals tie.TieId
                         where gui.GuiValor == guid
                         select tie.TieId).FirstOrDefault();

            if (tieId==0) return "QR Inválido, intenta de nuevo!";

            AsisHorario hor = (from Rol in _context.AsisRoles
                             join Hor in _context.AsisHorario on Rol.HorId equals Hor.HorId
                             join Usu in _context.Usuarios on Rol.UsuId equals Usu.UsuId
                             where Rol.RolActual && Rol.UsuId == usuId
                             select Rol.Hor).FirstOrDefault();

            if (hor == null) return "No tienes un horario asignado";
            
            if (hor.TieId != tieId) return "No checas en ésta tienda, verifica!";

            if (!ChecaEntrada(hor, 1)) return "El día de hoy no asistes a laborar";

            var asis = _context.AsisAsistencia.Where(asi => asi.AsiIncidencia.Date == fechahora.Date && asi.UsuId == usuId).OrderBy(asi => asi.AsiNumero);

            AsisAsistencia checada = new AsisAsistencia();
            checada.UsuId = usuId;
            if (asis.Count() == 0 || asis == null)
            {
                checada.AsiIncidencia = fechahora;
                checada.AsiNumero = 0;
                checada.AsiRetardo = hor.HorRetardo;
                checada.AsiEnSistema = Entrada(hor, 1);
                respuesta = "1a Entrada";                
                _context.AsisAsistencia.Add(checada);
            }
            else
            {
                if (asis.Count() == 1)
                {
                    checada.AsiIncidencia = fechahora;
                    checada.AsiEnSistema = Salida(hor, 1);
                    checada.AsiRetardo = hor.HorRetardo;
                    checada.AsiNumero = 1;
                    _context.AsisAsistencia.Add(checada);
                    respuesta = "1a Salida";
                }
                if (asis.Count() == 2)
                {
                    if (ChecaEntrada(hor, 2))
                    {
                        checada.AsiIncidencia = fechahora;
                        checada.AsiEnSistema = Entrada(hor, 2);
                        checada.AsiRetardo = hor.HorRetardo;
                        checada.AsiNumero = 2;
                        _context.AsisAsistencia.Add(checada);
                        respuesta = "2a Entrada";
                    }
                    else
                    {
                        return "No hay mas checadas hoy";
                    }
                }
                if (asis.Count() == 3)
                {
                    checada.AsiIncidencia = fechahora;
                    checada.AsiEnSistema = Salida(hor, 2);
                    checada.AsiRetardo = hor.HorRetardo;
                    checada.AsiNumero = 3;
                    _context.AsisAsistencia.Add(checada);
                    respuesta = "2a Salida";
                }
                if (asis.Count() == 4)
                {
                    if (ChecaEntrada(hor, 3))
                    {
                        checada.AsiIncidencia = fechahora;
                        checada.AsiEnSistema = Entrada(hor, 3);
                        checada.AsiRetardo = hor.HorRetardo;
                        checada.AsiNumero = 4;
                        _context.AsisAsistencia.Add(checada);
                        respuesta = "3a Entrada";
                    }
                    else
                    {
                        return "No hay mas checadas hoy";
                    }
                }
                if (asis.Count() == 5)
                {
                    checada.AsiIncidencia = fechahora;
                    checada.AsiEnSistema = Salida(hor, 3);
                    checada.AsiRetardo = hor.HorRetardo;
                    checada.AsiNumero = 5;
                    _context.AsisAsistencia.Add(checada);
                    respuesta = "3a Salida";
                }                
            }

            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return respuesta + " (" + fechahora.ToString("hh:mm:ss tt") + ")";
        }
        public bool ChecaEntrada(AsisHorario horario, int num)
        {
            if (num == 1)
            {
                switch ((int)DateTime.Now.DayOfWeek)
                {
                    case 0:
                        return horario.HorDUnoEntrada == null ? false : true;
                    case 1:
                        return horario.HorLUnoEntrada == null ? false : true;
                    case 2:
                        return horario.HorMUnoEntrada == null ? false : true;
                    case 3:
                        return horario.HorEUnoEntrada == null ? false : true;
                    case 4:
                        return horario.HorJUnoEntrada == null ? false : true;
                    case 5:
                        return horario.HorVUnoEntrada == null ? false : true;
                    case 6:
                        return horario.HorSUnoEntrada == null ? false : true;
                }
            }
            if (num == 2)
            {
                switch ((int)DateTime.Now.DayOfWeek)
                {
                    case 0:
                        return horario.HorDDosEntrada == null ? false : true;
                    case 1:
                        return horario.HorLDosEntrada == null ? false : true;
                    case 2:
                        return horario.HorMDosEntrada == null ? false : true;
                    case 3:
                        return horario.HorEDosEntrada == null ? false : true;
                    case 4:
                        return horario.HorJDosEntrada == null ? false : true;
                    case 5:
                        return horario.HorVDosEntrada == null ? false : true;
                    case 6:
                        return horario.HorSDosEntrada == null ? false : true;
                }
            }
            switch ((int)DateTime.Now.DayOfWeek)
            {
                case 0:
                    return horario.HorDTresEntrada == null ? false : true;
                case 1:
                    return horario.HorLTresEntrada == null ? false : true;
                case 2:
                    return horario.HorMTresEntrada == null ? false : true;
                case 3:
                    return horario.HorETresEntrada == null ? false : true;
                case 4:
                    return horario.HorJTresEntrada == null ? false : true;
                case 5:
                    return horario.HorVTresEntrada == null ? false : true;
                case 6:
                    return horario.HorSTresEntrada == null ? false : true;
            }
            return false;
        }

        public DateTime Entrada(AsisHorario hor, int reg)
        {
            switch (reg)
            {
                case 1:
                    switch ((int)DateTime.Now.DayOfWeek)
                    {
                        case 0:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorDUnoEntrada.Value.Hours, hor.HorDUnoEntrada.Value.Minutes, hor.HorDUnoEntrada.Value.Seconds);
                        case 1:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorLUnoEntrada.Value.Hours, hor.HorLUnoEntrada.Value.Minutes, hor.HorLUnoEntrada.Value.Seconds);
                        case 2:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorMUnoEntrada.Value.Hours, hor.HorMUnoEntrada.Value.Minutes, hor.HorMUnoEntrada.Value.Seconds);
                        case 3:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorEUnoEntrada.Value.Hours, hor.HorEUnoEntrada.Value.Minutes, hor.HorEUnoEntrada.Value.Seconds);
                        case 4:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorJUnoEntrada.Value.Hours, hor.HorJUnoEntrada.Value.Minutes, hor.HorJUnoEntrada.Value.Seconds);
                        case 5:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorVUnoEntrada.Value.Hours, hor.HorVUnoEntrada.Value.Minutes, hor.HorVUnoEntrada.Value.Seconds);
                        case 6:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorSUnoEntrada.Value.Hours, hor.HorSUnoEntrada.Value.Minutes, hor.HorSUnoEntrada.Value.Seconds);
                    }
                    break;
                case 2:
                    switch ((int)DateTime.Now.DayOfWeek)
                    {
                        case 0:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorDDosEntrada.Value.Hours, hor.HorDDosEntrada.Value.Minutes, hor.HorDDosEntrada.Value.Seconds);
                        case 1:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorLDosEntrada.Value.Hours, hor.HorLDosEntrada.Value.Minutes, hor.HorLDosEntrada.Value.Seconds);
                        case 2:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorMDosEntrada.Value.Hours, hor.HorMDosEntrada.Value.Minutes, hor.HorMDosEntrada.Value.Seconds);
                        case 3:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorEDosEntrada.Value.Hours, hor.HorEDosEntrada.Value.Minutes, hor.HorEDosEntrada.Value.Seconds);
                        case 4:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorJDosEntrada.Value.Hours, hor.HorJDosEntrada.Value.Minutes, hor.HorJDosEntrada.Value.Seconds);
                        case 5:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorVDosEntrada.Value.Hours, hor.HorVDosEntrada.Value.Minutes, hor.HorVDosEntrada.Value.Seconds);
                        case 6:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorSDosEntrada.Value.Hours, hor.HorSDosEntrada.Value.Minutes, hor.HorSDosEntrada.Value.Seconds);
                    }
                    break;
                case 3:
                    switch ((int)DateTime.Now.DayOfWeek)
                    {
                        case 0:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorDTresEntrada.Value.Hours, hor.HorDTresEntrada.Value.Minutes, hor.HorDTresEntrada.Value.Seconds);
                        case 1:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorLTresEntrada.Value.Hours, hor.HorLTresEntrada.Value.Minutes, hor.HorLTresEntrada.Value.Seconds);
                        case 2:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorMTresEntrada.Value.Hours, hor.HorMTresEntrada.Value.Minutes, hor.HorMTresEntrada.Value.Seconds);
                        case 3:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorETresEntrada.Value.Hours, hor.HorETresEntrada.Value.Minutes, hor.HorETresEntrada.Value.Seconds);
                        case 4:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorJTresEntrada.Value.Hours, hor.HorJTresEntrada.Value.Minutes, hor.HorJTresEntrada.Value.Seconds);
                        case 5:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorVTresEntrada.Value.Hours, hor.HorVTresEntrada.Value.Minutes, hor.HorVTresEntrada.Value.Seconds);
                        case 6:
                            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hor.HorSTresEntrada.Value.Hours, hor.HorSTresEntrada.Value.Minutes, hor.HorSTresEntrada.Value.Seconds);
                    }
                    break;              
            }
            return new DateTime(2000, 1, 1, 0, 0, 0, 0);
        }

        public DateTime Salida(AsisHorario hor, int cad)
        {
            TimeSpan hora = new TimeSpan();
            switch (cad)
            {
                case 1:
                    switch ((int)DateTime.Now.DayOfWeek)
                    {
                        case 0:
                            hora = hor.HorDUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorDUnoHoras));
                            break;
                        case 1:
                            hora = hor.HorLUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorLUnoHoras));
                            break;
                        case 2:
                            hora = hor.HorMUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorMUnoHoras));
                            break;
                        case 3:
                            hora = hor.HorEUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorEUnoHoras));
                            break;
                        case 4:
                            hora = hor.HorJUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorJUnoHoras));
                            break;
                        case 5:
                            hora = hor.HorVUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorVUnoHoras));
                            break;
                        case 6:
                            hora = hor.HorSUnoEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorSUnoHoras));
                            break;
                    }
                    break;
                case 2:
                    switch ((int)DateTime.Now.DayOfWeek)
                    {
                        case 0:
                            hora = hor.HorDDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorDDosHoras));
                            break;
                        case 1:
                            hora = hor.HorLDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorLDosHoras));
                            break;
                        case 2:
                            hora = hor.HorMDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorMDosHoras));
                            break;
                        case 3:
                            hora = hor.HorEDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorEDosHoras));
                            break;
                        case 4:
                            hora = hor.HorJDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorJDosHoras));
                            break;
                        case 5:
                            hora = hor.HorVDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorVDosHoras));
                            break;
                        case 6:
                            hora = hor.HorSDosEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorSDosHoras));
                            break;
                    }
                    break;
                case 3:
                    switch ((int)DateTime.Now.DayOfWeek)
                    {
                        case 0:
                            hora = hor.HorDTresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorDTresHoras));
                            break;
                        case 1:
                            hora = hor.HorLTresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorLTresHoras));
                            break;
                        case 2:
                            hora = hor.HorMTresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorMTresHoras));
                            break;
                        case 3:
                            hora = hor.HorETresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorETresHoras));
                            break;
                        case 4:
                            hora = hor.HorJTresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorJTresHoras));
                            break;
                        case 5:
                            hora = hor.HorVTresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorVTresHoras));
                            break;
                        case 6:
                            hora = hor.HorSTresEntrada.Value.Add(TimeSpan.FromHours((double)hor.HorSTresHoras));
                            break;
                    }
                    break;
            }
            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hora.Hours, hora.Minutes, hora.Seconds);
        }
        private bool HayExcepciones(int usuId)
        {            
            bool ex = _context.AsisBitacora.Any(b => b.BitFecha.Date == DateTime.Now.Date && b.UsuId == usuId);
            return ex;
        }

        // PUT api/<AsistenciaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AsistenciaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
