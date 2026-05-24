using AppAnotacoesGerais.ExibirDados.Comandos;
using AppAnotacoesGerais.ExibirDados.Views;
using AppAnotacoesGerais.ExibirDados.Views.AnotacoesGeraisView;
using AppAnotacoesGerais.ExibirDados.Views.InformacoesPessoaisView;
using AppAnotacoesGerais.ExibirDados.Views.Menus;
using AppAnotacoesGerais.ExibirDados.Views.TelaSenha;
using AppAnotacoesGerais.GerenciarDados.Repositorios;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace AppAnotacoesGerais.ExibirDados.ViewModels.TelaPrincipal;

public partial class TelaPrincipalViewModel// TelaPrincipalComandos
{
    #region | Comandos da Página Inicial, AnotacoesGerais, InformacoesPessoais e ConsumoGas |

    private ICommand _comandoPaginaInicial;
    public ICommand ComandoPaginaInicial
    {
        get
        {
            if (_comandoPaginaInicial == null)
            {
                _comandoPaginaInicial = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new PaginaInicial();
                });
            }
            return _comandoPaginaInicial;
        }
    }

    private ICommand _comandoAnotacaoGeral;
    public ICommand ComandoAnotacaoGeral
    {
        get
        {
            if (_comandoAnotacaoGeral == null)
            {
                _comandoAnotacaoGeral = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new AnotacaoGeralView();
                });
            }
            return _comandoAnotacaoGeral;
        }
    }

    private ICommand _comandoInformacaoPessoal;
    public ICommand ComandoInformacaoPessoal
    {
        get
        {
            if (_comandoInformacaoPessoal == null)
            {
                _comandoInformacaoPessoal = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new TelaSenhaView();
                });
            }
            return _comandoInformacaoPessoal;
        }
    }

    private ICommand _comandoConsumoGas;
    public ICommand ComandoConsumoGas
    {
        get
        {
            if (_comandoConsumoGas == null)
            {
                _comandoConsumoGas = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new ConsumoGasView();
                });
            }
            return _comandoConsumoGas;
        }
    }
    #endregion    

    #region | Senha Para Acessar Informações Pessoais |

    private void VerificarSenha()
    {
        if (string.IsNullOrWhiteSpace(Senha))
        {
            MessageBox.Show("Digite sua senha para logar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
            SelecionarControleDeUsuario = new TelaSenhaView();
            return;
        }

        bool autenticado = UsuarioRepositorio.AutenticarUsuario(Senha);

        if (autenticado)
        {
            SelecionarControleDeUsuario = new InformacaoPessoalView();
            Senha = null;
        }
        else
        {
            MessageBox.Show("Senha incorreta, tente novamente.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            SelecionarControleDeUsuario = new TelaSenhaView();
            Senha = null;
        }
    }

    private ICommand _comandoVerificarSenha;
    public ICommand ComandoVerificarSenha
    {
        get
        {
            if (_comandoVerificarSenha == null)
            {
                _comandoVerificarSenha = new RelayCommand<object>(param => VerificarSenha());
            }
            return _comandoVerificarSenha;
        }
    }

    private ICommand _comandoExecutarSenha;
    public ICommand ComandoExecutarSenha
    {
        get
        {
            _comandoExecutarSenha ??= new RelayCommand<object>(param =>
            {
                if (param is KeyEventArgs e && e.Key == Key.Enter)
                {
                    VerificarSenha();
                }
            });
            return _comandoExecutarSenha;
        }
    }
    #endregion

    #region | Comandos de Categorias, Subcategorias e Nome da Descrição|

    private ICommand _comandoCategoria;
    public ICommand ComandoCategoria
    {
        get
        {
            if (_comandoCategoria == null)
            {
                _comandoCategoria = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new CategoriaView();
                });
            }
            return _comandoCategoria;
        }
    }

    private ICommand _comandoSubcategoria;
    public ICommand ComandoSubcategoria
    {
        get
        {
            if (_comandoSubcategoria == null)
            {
                _comandoSubcategoria = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new SubcategoriaView();
                });
            }
            return _comandoSubcategoria;
        }
    }

    private ICommand _comandoNomeDescricao;
    public ICommand ComandoNomeDescricao
    {
        get
        {
            if (_comandoNomeDescricao == null)
            {
                _comandoNomeDescricao = new RelayCommand<object>(param =>
                {
                    SelecionarControleDeUsuario = new NomeDescricaoView();
                });
            }
            return _comandoNomeDescricao;
        }
    }
    #endregion

    #region | Banco de Dados e Sair do Aplicativo |

    private ICommand _comandoBancoDados;
    public ICommand ComandoBancoDados
    {
        get
        {
            if (_comandoBancoDados == null)
            {
                _comandoBancoDados = new RelayCommand<object>(param =>
                {
                    Process.Start("C:\\Program Files (x86)\\Microsoft SQL Server Management Studio 20\\Common7\\IDE\\Ssms.exe");
                });
            }
            return _comandoBancoDados;
        }
    }

    private ICommand _comandoSairAplicativo;
    public ICommand ComandoSairAplicativo
    {
        get
        {
            if (_comandoSairAplicativo == null)
            {
                _comandoSairAplicativo = new RelayCommand<object>(param =>
                {
                    Application.Current.Shutdown();
                });
            }
            return _comandoSairAplicativo;
        }
    }
    #endregion
}
