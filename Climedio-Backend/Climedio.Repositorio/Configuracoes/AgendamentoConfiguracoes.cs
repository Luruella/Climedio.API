using Climedio.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Climedio.Repositorio
{
    public class AgendamentoConfiguracoes : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos").HasKey(x => x.Id);

            builder.Property(nameof(Agendamento.Id))
            .HasColumnName("AgendamentoId").IsRequired();

            builder.Property(nameof(Agendamento.DataHora))
            .HasColumnName("DataHora").IsRequired();

            builder.Property(nameof(Agendamento.Observacao))
            .HasColumnName("Observacao").IsRequired(false);

            builder.Property(nameof(Agendamento.Valor))
            .HasColumnName("Valor").IsRequired();

            builder.Property(nameof(Agendamento.UsuarioIdProfissional))
                    .HasColumnName("UsuarioIdProfissional")
                    .IsRequired();

            builder.Property(nameof(Agendamento.UsuarioIdPaciente))
            .HasColumnName("UsuarioIdPaciente").IsRequired();

            builder.Property(nameof(Agendamento.Ativo)).HasColumnName("Ativo").IsRequired();

            builder.HasOne(a => a.UsuarioProfissional).WithMany(u => u.AgendamentosProfissional) // Um Usuario pode ter vários Agendamentos
            .HasForeignKey(x => x.UsuarioIdProfissional).OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(a => a.UsuarioPaciente).WithMany(u => u.AgendamentosPaciente) // Um Usuario pode ter vários Agendamentos
            .HasForeignKey(x => x.UsuarioIdPaciente).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
