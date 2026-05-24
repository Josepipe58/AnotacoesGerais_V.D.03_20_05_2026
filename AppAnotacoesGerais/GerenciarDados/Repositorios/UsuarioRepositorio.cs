using AppAnotacoesGerais.AcessarDados;
using AppAnotacoesGerais.AcessarDados.Entidades;

namespace AppAnotacoesGerais.GerenciarDados.Repositorios;

public class UsuarioRepositorio : Repositorio<Usuario>
{
    public static bool AutenticarUsuario(string senha)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(senha)) return false;
            using Contexto contexto = new();
            return contexto.TUsuario.Any(x => x.Senha == senha);
        }
        catch (Exception ex)
        {
            Mensagens.NomeDoMetodo = "AutenticarUsuario";
            Mensagens.ErroDeExcecaoENomeDoMetodo(ex, Mensagens.NomeDoMetodo);
            return false;
        }
    }
}
