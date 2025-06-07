using System.Diagnostics;
using InvestmentControl.Data;
using InvestmentControl.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public HomeController(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

        public IActionResult Index()
        {
            var dados = _investimentoRepository.GetTotalInvestidoPorTipos();

            var investimentos = _investimentoRepository.GetAllAsync();

            var ultimosCadastrados = investimentos.OrderByDescending(i => i.InvestimentoId)
                .Take(5).ToList();

            ViewBag.Ultimos = ultimosCadastrados;
            ViewBag.Dados = dados;
            ViewBag.Tipos = dados.Select(i => i.Tipo).ToList();
            ViewBag.Valores = dados.Select(d => d.TotalInvestido).ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
