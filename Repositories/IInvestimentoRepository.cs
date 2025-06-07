using InvestmentControl.Models;
using InvestmentControl.ViewModels;

namespace InvestmentControl.Repositories
{
    public interface IInvestimentoRepository
    {
        Task<InvestimentoViewModel> GetByIdAsync(int id);
        IQueryable<InvestimentoViewModel> GetAllAsync();
        Task AddAsync(InvestimentoViewModel investimento);
        Task UpdateAsync(InvestimentoViewModel investimento);
        Task DeleteAsync(int id);
        List<TotalInvestidoPorTipoDto> GetTotalInvestidoPorTipos();
    }
}
