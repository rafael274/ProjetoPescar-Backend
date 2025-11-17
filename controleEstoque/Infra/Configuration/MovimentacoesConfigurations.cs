using controleEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleEstoque.Infra.Configuration
{
    public class MovimentacoesConfigurations : IEntityTypeConfiguration<Movimentacoes>
    {
        public void Configure(EntityTypeBuilder<Movimentacoes> builder)
        {           
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Tipo)
                 .IsRequired();

            builder.Property(m => m.Quantidade)
                .IsRequired();

            builder.Property(m => m.Data)
                .IsRequired();

            builder.Property(m => m.usuarioId)
                .IsRequired();

            builder.HasOne(m => m.Material)
                .WithMany(mat => mat.Movimentacoes)
                .HasForeignKey(m => m.MaterialId);

            builder.ToTable("Movimentacoes");
        }
    }
}
