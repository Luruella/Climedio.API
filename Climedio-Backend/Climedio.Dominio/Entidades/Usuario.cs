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
    private string _telefone;
    private string _endereco;
    private DateTime _dataNascimento;


    private TipoUsuario tipoUsuarioId;
    private bool _ativo;


    #endregion

    #region Propriedades

    public int Id { get; set; }

    public string Email { get; set; }

    public string Cpf { get; set; }

    public string Senha { get; set; }

    public string Nome { get; set; }

    public string Telefone { get; set; }

    public string Endereco { get; set; }

    public DateOnly DataNascimento { get; set; }

    public TipoUsuario TipoUsuarioId { get; set; }

    public bool Ativo { get; set; }

    public List<Agendamento> Agendamentos{get; set;}


    #endregion

    #region Construtores

    public Usuario()
    {
        Ativo = true;
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