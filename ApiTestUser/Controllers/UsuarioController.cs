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
            var result = await _usuarioService.GetUser(id);

            if (result is null)
            {
                return BadRequest("El usuario no existe en DB.");
            }

            return result;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<ActionResult<UsuarioDTO>> SaveUser(UsuarioDTO usuarioDTO)
        {
            var result = await _usuarioService.SaveUser(usuarioDTO);

            if (result is null)
            {
                return BadRequest("Error al guardar el usuario.");
            }

            return Ok("El usuario ha sido agregado.");     
        }

        [HttpPut]
        [Route("editar")]
        public async Task<ActionResult<UsuarioDTO>> EditUser(UsuarioDTO usuarioDto)
        {
            var result = await _usuarioService.EditUser(usuarioDto);

            if (result is null)
            {
                return BadRequest("Error al guardar el usuario.");
            }

            return Ok("El usuario ha sido modificado.");
        }

        [HttpDelete]
        [Route("delete{id}")]
        public async Task<ActionResult<UsuarioDTO>> DeleteUser(int id)
        {
            var result = await _usuarioService.DeleteUser(id);

            if (result is false)
            {
                return BadRequest("No se ha encontrado este usuario.");
            }

            return Ok("El usuario ha sido eliminado.");

        }













    }
}
