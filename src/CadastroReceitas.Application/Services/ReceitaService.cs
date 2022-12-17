using CadastroReceitas.Application.Interfaces;
using CadastroReceitas.Domain.Models;
using CadastroReceitas.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace CadastroReceitas.Application.Services;
public class ReceitaService : IReceitaService
{
    private ApplicationDbContext _dataContext;
    public ReceitaService(ApplicationDbContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<List<Receita>> List()
    {
        return await _dataContext.Receitas.ToListAsync();
    }

    public async Task<Receita> Select(int id)
    {
        var receita = await _dataContext.Receitas.FirstOrDefaultAsync(x => x.Id == id);
        return receita;
    }

    public async Task<Receita> Insert(Receita receita)
    {
        _dataContext.Receitas.Add(receita);
        await _dataContext.SaveChangesAsync();
        return receita;
    }

    public async Task<Receita> Update(int id, Receita receita)
    {
        _dataContext.Update(receita);
        await _dataContext.SaveChangesAsync();
        return receita;
    }

    public async Task Delete(Receita receita)
    {
        _dataContext.Receitas.Remove(receita);
        await _dataContext.SaveChangesAsync();
    }
}
