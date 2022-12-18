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
        model.DataInclusao = DateTime.Now;
        if (ModelState.IsValid)
        {
            await _receitaService.Insert(model);
            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var receita = await _receitaService.Select(id);
        return View(receita);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Receita receita)
    {
        if (ModelState.IsValid) 
        {
            await _receitaService.Update(receita.Id, receita);
            return RedirectToAction("Index");
        }

        return View(receita);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var receita = await _receitaService.Select(id);
        await _receitaService.Delete(receita);
        return RedirectToAction("Index");
    }
}
