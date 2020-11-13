using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scarpa.Common.Entities;
using Scarpa.Common.Requests;
using Scarpa.Common.Responses;
using Scarpa.Web.Data;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Scarpa.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return _context.Usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuarios usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }
            return Ok(usuarios);
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios([FromRoute] int id, [FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuarios.UsuId)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //POST: api/Usuarios
        [HttpPost]
        public async Task<IActionResult> PostUsuarios([FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuarios", new { id = usuarios.UsuId }, usuarios);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("GetUserByCelular")]
        public async Task<IActionResult> GetUserByCelular([FromBody] UsrLogin usr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var usua = await _context.Usuarios.
                Include(p=>p.Pue).Include(d=>d.Dep).Include(c=>c.Cla).
                FirstOrDefaultAsync(p => p.UsuTelefono == usr.Celular);

            if (usua != null)
            {
                if (usr.Contra == usua.UsuContra)
                {
                    Usuarios nuevo = new Usuarios
                    {
                        UsuNombre = usua.UsuNombre,
                        UsuId = usua.UsuId,
                        UsuActivo = usua.UsuActivo,
                        UsuClaveNomina = usua.UsuClaveNomina,
                        UsuEmail = usua.UsuEmail,
                        UsuRfc = usua.UsuRfc,
                        UsuCurp = usua.UsuCurp,
                        UsuDireccion = usua.UsuDireccion,
                        UsuTelefono = usua.UsuTelefono,
                        Dep = new AsisDepartamento { DepDescripcion = usua.Dep.DepDescripcion, DepId = usua.Dep.DepId },
                        Pue = new AsisPuesto { PueDescripcion = usua.Pue.PueDescripcion,PueId = usua.Dep.DepId },
                        Cla = new AsisClasificacion { ClaId = (int)usua.ClaId, ClaDescripcion = usua.Cla.ClaDescripcion },
                        UsuFechaInicial = usua.UsuFechaInicial,
                        UsuNacimiento = usua.UsuNacimiento,                        
                        UsuFoto = usua.UsuFoto
                    };
                    var rep = new Response<Usuarios> { IsSuccess = true, Message = "", Result = nuevo };
                    return Ok(rep);
                }
                else
                {
                    return NotFound("Contraseña incorrecta");
                }
            }
            else
            {
                return NotFound("No existe el celular");
            }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Usuarios usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return Ok(usuarios);
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.UsuId == id);
        }
    }
}