using System.ComponentModel.DataAnnotations;

namespace TesteUds.Models
{
    public class ProdutoViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O código é obrigatório.")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Range(0.01, 9999999.99, ErrorMessage = "O preço unitário deve estar entre R$ 0,01 e R$ 9999999,99.")]
        [DisplayFormat(DataFormatString = "{0:0,00}")]
        [Required(ErrorMessage = "O preço unitário é obrigatório.")]
        [Display(Name = "Preço Unitário")]
        public decimal? PrecoUnitario { get; set; }
    }
}