using ApiTestUser.Data;
using ApiTestUser.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTestUser.Services
{
    public class CategoriaService
    {
        private readonly ApplicationDbContext _context;
        public CategoriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<CategoriaDTO>>> GetCategorias()
        {

            var listaDTO = new List<CategoriaDTO>();
            var listaBD = await _context.Categorias.ToListAsync();

            foreach (var categoria in listaBD)
            {
                listaDTO.Add(new CategoriaDTO
                {
                    IdCategoria = categoria.IdCategoria,
                    Nombre = categoria.Nombre,
                    Nivel = categoria.Nivel,
                    Descripcion = categoria.Descripcion,
                    SalarioBase = categoria.SalarioBase
                });
            }
            return listaDTO;
        }

    }
}
