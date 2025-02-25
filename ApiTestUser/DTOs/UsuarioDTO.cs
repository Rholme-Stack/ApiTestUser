using System.ComponentModel.DataAnnotations;

namespace ApiTestUser.DTOs
{
    public class UsuarioDTO
    {
        public int idUsuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public DateTime FechaNasc { get; set; }
        public int idCategoria { get; set; }
        public int nivelCategoria { get; set; }
        public string nombreCategoria { get; set; }

    }
}
