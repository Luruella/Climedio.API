namespace Climedio.Repositorio;
public abstract class BaseRepositorio
{
    protected readonly ClimedioContexto _contexto;

    protected BaseRepositorio(ClimedioContexto contexto)
    {
        _contexto = contexto;
    }
}