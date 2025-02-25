using ApiTestUser.Data;
using ApiTestUser.DTOs;
using ApiTestUser.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTestUser.Services
{
    public class UsuarioService
    {
        private readonly ApplicationDbContext _context;
        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<List<UsuarioDTO>>> GetList()
        {
            var listaDTO = new List<UsuarioDTO>();
            var listaBD = await _context.Usuarios.Include(c => c.CategoriaReferencia).ToListAsync();
            foreach (var usuario in listaBD)
            {
                listaDTO.Add(new UsuarioDTO
                {
                    idUsuario = usuario.idUsuario,
                    nombre = usuario.nombre,
                    apellido = usuario.apellido,
                    email = usuario.email,
                    FechaNasc = usuario.FechaNasc,
                    idCategoria = usuario.idCategoria,
                    nivelCategoria = usuario.CategoriaReferencia.Nivel,
                    nombreCategoria = usuario.CategoriaReferencia.Nombre
                });
            }
            return listaDTO;
        }


        public async Task<ActionResult<UsuarioDTO>> GetUser(int id)
        {
            var UsuarioDTO = new UsuarioDTO();
            var UsuarioDB = await _context.Usuarios.Include(c => c.CategoriaReferencia)
                .Where(u => u.idUsuario == id).FirstAsync();


            UsuarioDTO.idUsuario = id;
            UsuarioDTO.nombre = UsuarioDB.nombre;
            UsuarioDTO.apellido = UsuarioDB.apellido;
            UsuarioDTO.email = UsuarioDB.email;
            UsuarioDTO.FechaNasc = UsuarioDB.FechaNasc;
            UsuarioDTO.idCategoria = UsuarioDB.idCategoria;
            UsuarioDTO.nivelCategoria = UsuarioDB.CategoriaReferencia.Nivel;
            UsuarioDTO.nombreCategoria = UsuarioDB.CategoriaReferencia.Nombre;


            return UsuarioDTO;
        }


        public async Task<ActionResult<UsuarioDTO>> SaveUser(UsuarioDTO usuarioDTO)
        {
            
            var usuarioDB = new Usuario
            {
                nombre = usuarioDTO.nombre,
                apellido = usuarioDTO.apellido,
                email = usuarioDTO.email,
                FechaNasc = usuarioDTO.FechaNasc,
                idCategoria = usuarioDTO.idCategoria
            };

            await _context.Usuarios.AddAsync(usuarioDB);
            await _context.SaveChangesAsync();

            return new UsuarioDTO
            {
                idUsuario = usuarioDB.idUsuario, 
                nombre = usuarioDB.nombre,
                apellido = usuarioDB.apellido,
                email = usuarioDB.email,
                FechaNasc = usuarioDB.FechaNasc,
                idCategoria = usuarioDB.idCategoria
            };
        }




    }
}
