using Microsoft.EntityFrameworkCore;
using Climedio.Dominio.Entidades;


namespace Climedio.Repositorio;
public class ClimedioContexto : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Agendamento> Agendamentos { get; set; }

    public readonly DbContextOptions _options;

    public ClimedioContexto() : base(new DbContextOptions<ClimedioContexto>())
    {
    }

    public ClimedioContexto(DbContextOptions<ClimedioContexto> options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Filename=C:\Users\Noite\Desktop\Climedio.API\Climedio-Backend\Climedio.Repositorio\Climedio.sqlite");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AgendamentoConfiguracoes());
        modelBuilder.ApplyConfiguration(new UsuarioConfiguracoes());
    }
}
