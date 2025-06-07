using InvestmentControl.Data;
using InvestmentControl.Models;
using InvestmentControl.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace InvestmentControl.Repositories
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly AppDbContext _dbContext;

        public InvestimentoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(InvestimentoViewModel investimento)
        {
            var novoInvestimento = new Investimento()
            {
                Nome = investimento.Nome,
                Tipo = investimento.Tipo,
                Valor = investimento.Valor,
                DataInvestimento = investimento.DataInvestimento
            };

            await _dbContext.Investimentos.AddAsync(novoInvestimento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Investimento investimento = await _dbContext.Investimentos.FindAsync(id);
            _dbContext.Investimentos.Remove(investimento);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<InvestimentoViewModel> GetAllAsync()
        {
            var investimentos = _dbContext.Investimentos
            .Select(i => new InvestimentoViewModel
            {
                InvestimentoId = i.InvestimentoId,
                Nome = i.Nome,
                Tipo = i.Tipo,
                Valor = i.Valor,
                DataInvestimento = i.DataInvestimento
            });

            return investimentos;
        }

        public List<TotalInvestidoPorTipoDto> GetTotalInvestidoPorTipos()
        {
            var dados = _dbContext.Investimentos
                .GroupBy(i => i.Tipo)
                .Select(g => new TotalInvestidoPorTipoDto
                {
                    Tipo = g.Key,
                    TotalInvestido = g.Sum(i => i.Valor)
                })
                .ToList();
            
            return dados;
        }

        public async Task<InvestimentoViewModel> GetByIdAsync(int id)
        {
            var investimento = await _dbContext.Investimentos.FindAsync(id);

            var investimentoViewModel = new InvestimentoViewModel()
            {
                InvestimentoId = investimento.InvestimentoId,
                Nome = investimento.Nome,
                Tipo = investimento.Tipo,
                Valor = investimento.Valor,
                DataInvestimento = investimento.DataInvestimento
            };

            return investimentoViewModel;
        }

        public async Task UpdateAsync(InvestimentoViewModel investimentoUpdated)
        {
            var investimento = await _dbContext.Investimentos.FindAsync(investimentoUpdated.InvestimentoId);

            investimento.Nome = investimentoUpdated.Nome;
            investimento.Tipo = investimentoUpdated.Tipo;
            investimento.Valor = investimentoUpdated.Valor;
            investimento.DataInvestimento = investimentoUpdated.DataInvestimento;
            _dbContext.Investimentos.Update(investimento);
            await _dbContext.SaveChangesAsync();
        }
    }
}
