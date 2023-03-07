using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Teste.Variacao.Domain.Entities;

namespace Teste.Variacao.Infrastructure.Mappings
{
    internal class VariacaoAtivoMap : IEntityTypeConfiguration<VariacaoAtivo>
    {
        public void Configure(EntityTypeBuilder<VariacaoAtivo> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Dia);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Valor);
            builder.Property(x => x.Data).HasColumnType("timestamp");
            builder.Property(x => x.CreatedAt).HasColumnType("timestamp");
            builder.Property(x => x.UpdatedAt).HasColumnType("timestamp");
        }
    }
}