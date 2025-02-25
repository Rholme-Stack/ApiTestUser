using ApiTestUser.Data;
using ApiTestUser.DTOs;
using ApiTestUser.Models;
using ApiTestUser.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTestUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {   
        private readonly UsuarioService _usuarioService;
        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<UsuarioDTO>>>GetAction()
        {
            
            return Ok(await _usuarioService.GetList());
        }

        [HttpGet]
        [Route("User/{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUser(int id)
        {
                        
            return Ok(await _usuarioService.GetUser(id));
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult<UsuarioDTO>> SaveUser(UsuarioDTO usuarioDTO)
        {
            var ansewr = await _usuarioService.SaveUser(usuarioDTO);

            if (ansewr is null)
            {
                return BadRequest("Error al guardar el usuario.");
            }

            return Ok("El usuario ha sido agregado.");     
        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<UsuarioDTO>> EditUser(UsuarioDTO usuarioDto)
        {
            var UsuarioDB = await _context.Usuarios
               .Where(u => u.idUsuario == usuarioDto.idUsuario).FirstAsync();

            UsuarioDB.nombre = usuarioDto.nombre;
            UsuarioDB.apellido = usuarioDto.apellido;
            UsuarioDB.email = usuarioDto.email;
            UsuarioDB.FechaNasc = usuarioDto.FechaNasc;
            UsuarioDB.idCategoria = usuarioDto.idCategoria;

            _context.Usuarios.Update(UsuarioDB);
            await _context.SaveChangesAsync();

            return Ok("Registro updated.");
        }

        [HttpDelete]
        [Route("delete{id}")]
        public async Task<ActionResult<UsuarioDTO>> DeleteUser(int id)
        {
            var UsuarioDB = await _context.Usuarios.FindAsync(id);
               

            
            if( UsuarioDB is null){
                return NotFound("Usuario no encontrado.");
            }

            _context.Usuarios.Remove(UsuarioDB);
            await _context.SaveChangesAsync();

            return Ok("Registro Eliminado.");


        }













    }
}
