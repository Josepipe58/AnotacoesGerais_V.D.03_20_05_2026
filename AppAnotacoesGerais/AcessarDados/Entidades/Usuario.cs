using System.ComponentModel.DataAnnotations;

namespace AppAnotacoesGerais.AcessarDados.Entidades;

public class Usuario
{
    [Key]
    public int Id { get; set; }

    [Required, StringLength(50)]
    public string Senha { get; set; }
}
