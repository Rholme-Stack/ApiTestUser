using System.ComponentModel.DataAnnotations;

namespace ApiTestUser.DTOs
{
    public class CategoriaDTO
    {

        public int IdCategoria { get; set; }               
        public string Nombre { get; set; } = string.Empty;
        public int Nivel { get; set; }    
        public string? Descripcion { get; set; }       
        public decimal SalarioBase { get; set; }

    }
}
