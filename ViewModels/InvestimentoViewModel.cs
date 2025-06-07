using InvestmentControl.Attributes;
using System.ComponentModel.DataAnnotations;

namespace InvestmentControl.ViewModels
{
    public class InvestimentoViewModel
    {
        public int InvestimentoId { get; set; }
        
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome não pode exceder 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O tipo é obrigatório")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        [NaoPermiteZero(ErrorMessage = "O valor deve ser maior que zero")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A data do investimento é obrigatória")]
        [Display(Name = "Data do Investimento")]
        [DataType(DataType.Date)]
        [DataNaoFutura(ErrorMessage = "A data não pode ser futura")]
        public DateTime DataInvestimento { get; set; }
    }
}
