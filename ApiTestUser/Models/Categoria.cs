using System.ComponentModel.DataAnnotations;

namespace ApiTestUser.Models
{
    public class Categoria
    {

        [Key] // Clave primaria
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nivel es obligatorio.")]
        [Range(1, 5, ErrorMessage = "El nivel debe estar entre 1 y 5.")]
        public int Nivel { get; set; }

        [MaxLength(100, ErrorMessage = "La descripción no puede superar los 100 caracteres.")]
        public string? Descripcion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal SalarioBase { get; set; }

        public virtual ICollection<Usuario> UsuariosReferencia { get; set; }


    }
}
