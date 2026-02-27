using ControleGR.API.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleGR.API.Infrastructure.Configurations;
public class TransacaoConfiguration : IEntityTypeConfiguration<Transacao>
{
    public void Configure(EntityTypeBuilder<Transacao> builder)
    {
        builder.Property(t => t.TipoTransacao)
            .HasConversion<string>()
            .IsRequired();
    }
}
