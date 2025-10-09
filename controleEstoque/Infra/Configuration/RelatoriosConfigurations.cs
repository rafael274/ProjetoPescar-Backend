using controleEstoque.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleEstoque.Infra.Configuration
{
    public class RelatoriosConfigurations : IEntityTypeConfiguration<Relatorios>
    {
        public void Configure(EntityTypeBuilder<Relatorios> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.TotalEntradas)
                   .IsRequired();

            builder.Property(r => r.TotalSaidas)
                   .IsRequired();

            builder.Property(r => r.PeriodoReferencia)
                   .IsRequired();

            builder.HasOne(r => r.Materiais)
                   .WithMany()
                   .HasForeignKey(r => r.MateriaisId);

            builder.ToTable("Relatorios");
        }
    }
}
