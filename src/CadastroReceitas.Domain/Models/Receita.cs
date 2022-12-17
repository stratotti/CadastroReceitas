using System.ComponentModel.DataAnnotations;

namespace CadastroReceitas.Domain.Models;
public class Receita
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Favor preencher o campo {0}")]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Favor preencher o campo {0}")]
    public string Ingredientes { get; set; }

    [Display(Name = "Modo de Preparo")]
    [Required(ErrorMessage = "Favor preencher o campo {0}")]
    public string ModoPreparo { get; set; }
    public DateTime DataInclusao { get; set; }

    [Display(Name = "Url Imagem")]
    public string Imagem { get; set; }
}
