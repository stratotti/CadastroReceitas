using CadastroReceitas.Application.Interfaces;
using CadastroReceitas.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace CadastroReceitas.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReceitaController : Controller
{
    private readonly IReceitaService _receitaService;
    public ReceitaController(IReceitaService receitaService)
    {
        _receitaService = receitaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Receita>>> Get()
    {
        var receitas = await _receitaService.List();
        return receitas;
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult<Receita>> Get(int id)
    {
        var receita = await _receitaService.Select(id);
        if (receita == null)
            return NotFound();

        return receita;
    }

    [HttpPost]
    public async Task<ActionResult<Receita>> Post(Receita receita)
    {
        if (ModelState.IsValid)
        {
            receita = await _receitaService.Insert(receita);
            return Created($"/api/receita/{receita.Id}", receita);
        }

        return BadRequest(ModelState);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<ActionResult<Receita>> Put(int id, Receita receita)
    {
        if (ModelState.IsValid)
        {
            receita = await _receitaService.Update(id, receita);
            return receita;
        }

        return BadRequest(ModelState);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var receita = await _receitaService.Select(id);
        if (receita == null)
            return NotFound();

        await _receitaService.Delete(receita);
        return NoContent();
    }
}
