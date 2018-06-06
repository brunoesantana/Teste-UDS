using System.ComponentModel.DataAnnotations;

namespace TesteUds.Models
{
    public class ProdutoFiltroViewModel
    {
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Display(Name = "Preço Unitário")]
        public decimal PrecoUnitario { get; set; }
    }
}