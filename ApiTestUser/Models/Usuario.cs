using System.ComponentModel.DataAnnotations;

namespace ApiTestUser.Models
{
    public class Usuario
    {

        [Key]
        public int idUsuario { get; set; }

        [Required(ErrorMessage ="El Nombre es obligatorio.")]
        [MaxLength(50)]
        public string nombre { get; set; }

        [MaxLength(50)]
        public string apellido { get; set; }

        
        [EmailAddress]
        public string email { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaNasc { get; set; }

        [Required(ErrorMessage = "El ID Categoria es obligatorio.")]
        public int idCategoria { get; set; }

        public virtual Categoria CategoriaReferencia { get; set; }


    }
}
