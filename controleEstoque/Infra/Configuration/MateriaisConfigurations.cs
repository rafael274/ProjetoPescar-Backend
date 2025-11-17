using controleEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleEstoque.Infra.Configuration
{
    public class MateriaisConfigurations : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.HasKey(m => m.Id);

            builder.Property(m => m.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(m => m.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(m => m.Quantidade)
                .IsRequired();

            builder.Property(m => m.EstoqueMinimo)
                .IsRequired();

            builder.ToTable("Materiais");

        }
    }
}
