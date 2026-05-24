using AppAnotacoesGerais.ExibirDados.Comandos;
using AppAnotacoesGerais.ExibirDados.Views.Menus;

namespace AppAnotacoesGerais.ExibirDados.ViewModels.TelaPrincipal;

public partial class TelaPrincipalViewModel : ViewModelBase
{
    public int _dataAtual;
    public int DataAtual
    {
        get
        {
            return _dataAtual;
        }
        set
        {
            _dataAtual = value;
            OnPropertyChanged(nameof(DataAtual));
        }
    }

    private string _senha;
    public string Senha
    {
        get => _senha;
        set
        {
            _senha = value;
            OnPropertyChanged(nameof(Senha));
        }
    }

    private object _selecionarControleDeUsuario;
    public object SelecionarControleDeUsuario
    {
        get => _selecionarControleDeUsuario;
        set
        {
            _selecionarControleDeUsuario = value;
            OnPropertyChanged(nameof(SelecionarControleDeUsuario));
        }
    }

    public TelaPrincipalViewModel()
    {
        SelecionarControleDeUsuario = new PaginaInicial();
        DataAtual = DateTime.Now.Year;
    }
}
