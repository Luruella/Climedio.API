namespace Climedio.Aplicacao;
namespace Climedio.Dominio.Entidades;

public class ProdutoAplicacao : IAgendamentoAplicacao
{
    private readonly IAgendaementoRepositorio _produtoRepositorio;

    public ProdutoAplicacao(IAgendamentoRepositorio agendaementoRepositorio)
    {
        _produtoRepositorio = agendaementoRepositorio;
    }

    public async Task Atualizar(int produtoId, string nome, decimal preco, int quantidade)
    {
        Agendamento agendamento = await _produtoRepositorio.ObterPorId(produtoId);

        if (agendamento == null)
        {
            throw new Exception("O produto não foi encontrado.");
        }

        agendamento.data_hora = nome;
        agendamento.observacao = preco;
        agendamento.Quantidade = quantidade;

        VerificarProduto(agendamento);

        await _produtoRepositorio.Atualizar(agendamento);
    }

    public async Task Criar(Agendamemento produto)
    {
        VerificarProduto(produto);

        await _produtoRepositorio.Salvar(produto);
    }

    public async Task<List<Produto>> Listar(int id, bool ativo)
    {
        var lista = await _produtoRepositorio.Listar(id);

        var listaProdutos = lista.Where(x => x.Ativo == ativo).ToList();
        
        if(listaProdutos.Count == 0)
        {
            throw new Exception("Nenhum produto foi encontrado para a categoria.");
        }

        return listaProdutos;
    }

    public async Task Remover(int id)
    {
        var produto = await _produtoRepositorio.ObterPorId(id);

        if (produto == null)
        {
            throw new Exception("O produto não foi encontrado.");
        }

        produto.Ativo = false;

        await _produtoRepositorio.Atualizar(produto);
    }

    public void VerificarProduto(Produto produto)
    {
        if (produto == null)
        {
            throw new Exception("O produto não pode ser vazio.");
        }

        if (string.IsNullOrWhiteSpace(produto.Nome))
        {
            throw new Exception("O nome do produto não pode ser vazio.");
        }

        if (produto.Preco <= 0 )
        {
            throw new Exception("O preço do produto não pode ser zero ou negativo.");
        }

        if (produto.Quantidade < 0)
        {
            throw new Exception("A quantidade do produto não pode ser negativa.");
        }

        if (produto.CategoriaId <= 0)
        {
            throw new Exception("O usuário do produto não pode ser vazio.");
        }
    }
}