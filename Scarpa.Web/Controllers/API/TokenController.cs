using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Scarpa.Common.Requests;
using Scarpa.Common.Services;
using Scarpa.Web.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Scarpa.Web.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private DataContext _dataContext;
        private IConfiguration _configuration;
        
        public TokenController(DataContext dataContext,IConfiguration configuration)
        {
            _dataContext = dataContext;
            _configuration = configuration;        
        }
        // GET: api/<TokenController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TokenController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TokenController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPost]
        [Route("CreateToken")]
        public async Task<IActionResult> CreateToken([FromBody] UsrLogin model)
        {
            if (ModelState.IsValid)
            {
                var user = await _dataContext.Usuarios.FirstOrDefaultAsync(u => u.UsuTelefono == model.Celular);
                if (user != null)
                {
                    Claim[] claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UsuTelefono),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Tokens:Issuer"],
                        _configuration["Tokens:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMonths(12),
                        signingCredentials: credentials);
                    var results = new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    };
                    return Created(string.Empty, results);
                }
                else
                {
                    return BadRequest("No encontré: " + model.Celular);
                }
            }
            return BadRequest("Modelo inválido");
        }
        // PUT api/<TokenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TokenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }        
    }
}
