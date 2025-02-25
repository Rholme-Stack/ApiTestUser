using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTestUser.Data;
using Microsoft.IdentityModel.Tokens;
using ApiTestUser.Models;
using ApiTestUser.DTOs;
using ApiTestUser.Services;

namespace ApiTestUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly CategoriaService _CategoriaService;
        public CategoriaController(CategoriaService CategoriaService)
        {
            _CategoriaService = CategoriaService;
        }

        // Example method to use _context and avoid IDE0052 warning
        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult<List<CategoriaDTO>>>GetCategorias()
        {
            
       
            return Ok(await _CategoriaService.GetCategorias());
        }
    }
}
