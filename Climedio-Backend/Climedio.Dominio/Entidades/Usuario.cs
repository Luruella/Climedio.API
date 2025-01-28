using Climedio.Dominio.Enumeradores;

namespace Climedio.Dominio.Entidades;
public class Usuario
{
    #region Atributos

    private int _id;

    private string _email;
    private string _cpf;
    private string _senha;


    private string _nome;
    private string _nomeSocial;
    private string _telefone;
    private string _endereco;
    private DateTime _dataNascimento;


    private TipoUsuario tipoUsuarioId;
    private bool _ativo;
    private DateOnly dateOnly;


    #endregion

    #region Propriedades

    public int Id { get; set; }

    public string Email { get; set; }

    public string Cpf { get; set; }

    public string Senha { get; set; }

    public string Nome { get; set; }
    public string NomeSocial { get; set; }

    public string Telefone { get; set; }

    public string Endereco { get; set; }

    public DateOnly DataNascimento { get; set; }

    public TipoUsuario TipoUsuarioId { get; set; }

    public bool Ativo { get; set; }

    public List<Agendamento> AgendamentosProfissional {get; set;}
    public List<Agendamento> AgendamentosPaciente { get; set;}


    #endregion

    #region Construtores

    public Usuario(string nome)
    {
        Ativo = true;
        Nome = nome;
    }

    public Usuario(string nome, string email, DateOnly dateOnly, string senha) : this(nome)
    {
        Email = email;
        this.dateOnly = dateOnly;
        Senha = senha;
    }

    #endregion

    #region Métodos

    public void Deletar()
    {
        Ativo = false;
    }
    public void Restaurar()
    {
        Ativo = true;
    }
   

    #endregion
}