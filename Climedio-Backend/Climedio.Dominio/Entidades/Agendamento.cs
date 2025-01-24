namespace Climedio.Dominio.Entidades
{
    public class Agendamento
    {

        #region Atributos

        private int _id;
        private DateTime _data_hora;
        private string _observacao;
        private decimal _valor;
        private int _usuarioIdProfissional;
        private int _usuarioIdPaciente;
        private bool _ativo;

        #endregion


        #region Propriedades

        public int Id { get; set; }

        public DateTime DataHora { get; set; }

        public string Observacao { get; set; }

        public decimal Valor { get; set; }

        public int UsuarioIdProfissional { get; set; }

        public int UsuarioIdPaciente { get; set; }

        public bool Ativo { get; set; }

        public Usuario UsuarioProfissional { get; set; }
        public Usuario UsuarioPaciente { get; set; }

        #endregion


        #region Construtores
        public Agendamento(){}
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
}

