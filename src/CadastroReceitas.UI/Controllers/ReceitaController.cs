using CadastroReceitas.Application.Interfaces;
using CadastroReceitas.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CadastroReceitas.UI.Controllers;
[Authorize]
public class ReceitaController : Controller
{
    private readonly IReceitaService _receitaService;
    public ReceitaController(IReceitaService receitaService)
    {
        _receitaService = receitaService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var receitas = await _receitaService.List();
        return View(receitas);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Receita model)
    {
        ModelState.Remove("Id");
        model.DataInclusao = DateTime.Now;
        if (ModelState.IsValid)
        {
            await _receitaService.Insert(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }
}
