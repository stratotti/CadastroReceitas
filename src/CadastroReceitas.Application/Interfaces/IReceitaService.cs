using CadastroReceitas.Domain.Models;

namespace CadastroReceitas.Application.Interfaces;
public interface IReceitaService
{
    Task<List<Receita>> List();
    Task<Receita> Select(int id);
    Task<Receita> Insert(Receita receita);
    Task<Receita> Update(int id, Receita receita);
    Task Delete(Receita receita);
}
