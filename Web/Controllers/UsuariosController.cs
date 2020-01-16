using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datos;
using Entidades.Usuario;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController: ControllerBase
    {
        private readonly DbContextSistema _context;
        public UsuariosController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario([FromRoute] int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return usuario;
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.id}, usuario);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> UpdateUsuario(Usuario usuario, int id)
        {
            var user = await _context.Usuarios.FindAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            user.name = usuario.name;
            user.username = usuario.username;
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
