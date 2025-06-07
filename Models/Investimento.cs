namespace InvestmentControl.Models
{
    public class Investimento 
    {
        public int InvestimentoId { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataInvestimento { get; set; }
    }
}
