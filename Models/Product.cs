using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório")]
        [MinLength(3,ErrorMessage="Este campo deve conter no minimo 3 caracteres")]
        [MaxLength(60,ErrorMessage="Este campo deve conter no maximo 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(1024,ErrorMessage="Este campo deve conter no máximo 1024 caracteres")]
        public string Description { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="O produto deve ter seu valor maior que zero")]
        public decimal Price { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage="Este campo deve ter valor maior que zero")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }



    }
}