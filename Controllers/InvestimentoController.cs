using InvestmentControl.Models;
using InvestmentControl.Repositories;
using InvestmentControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InvestmentControl.Controllers
{
    public class InvestimentoController : Controller
    {
        private readonly IInvestimentoRepository _investimentoRepository;

        public InvestimentoController(IInvestimentoRepository investimentoRepository)
        {
            _investimentoRepository = investimentoRepository;
        }

        public async Task<IActionResult> Index(string nomeBusca, string ordem, int numeroPagina)
        {
            var investimentos = _investimentoRepository.GetAllAsync();

            if (!String.IsNullOrEmpty(nomeBusca))
            {
                investimentos = investimentos.Where(i => i.Nome.Contains(nomeBusca));
            }

            ViewData["NomeOrdemParam"] = string.IsNullOrEmpty(ordem) ? "nome_desc" : "";
            ViewData["DataOrdemParam"] = ordem == "data_asc" ? "data_desc" : "data_asc";
            ViewData["ValorOrdemParam"] = ordem == "valor_asc" ? "valor_desc" : "valor_asc";

            switch(ordem)
            {
                case "nome_desc":
                    investimentos = investimentos.OrderByDescending(i => i.Nome);
                    break;

                case "data_asc":
                    investimentos = investimentos.OrderBy(i => i.DataInvestimento);
                    break;

                case "data_desc":
                    investimentos = investimentos.OrderByDescending(i => i.DataInvestimento);
                    break;

                case "valor_asc":
                    investimentos = investimentos.OrderBy(i => i.Valor);
                    break;

                case "valor_desc":
                    investimentos = investimentos.OrderByDescending(i => i.Valor);
                    break;

                default:
                    investimentos = investimentos.OrderBy(i => i.Nome);
                    break;
            }


            if (numeroPagina < 1)
            {
                numeroPagina = 1;
            }

            int tamanhoPagina = 5;

            return View(await PaginatedList<InvestimentoViewModel>.CreateAsync(investimentos, numeroPagina, tamanhoPagina));
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar(InvestimentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _investimentoRepository.AddAsync(model);
            TempData["MensagemSucesso"] = "Investimento adicionado com sucesso!";

            return RedirectToAction("Index", "Investimento");
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var investimento = await _investimentoRepository.GetByIdAsync(id);

            return View(investimento);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(InvestimentoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _investimentoRepository.UpdateAsync(model);
            TempData["MensagemSucesso"] = "Investimento editado com sucesso!";

            return RedirectToAction("Index", "Investimento");
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int id)
        {
            await _investimentoRepository.DeleteAsync(id);
            TempData["MensagemSucesso"] = "Investimento deletado com sucesso!";

            return RedirectToAction("Index", "Investimento");
        }
    }
}
