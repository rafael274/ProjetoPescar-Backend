using controleEstoque.Domain.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace controleEstoque.Infra.Configuration
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> Builder)
        {           
            Builder.HasKey(u => u.Id);

            Builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            Builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            Builder.Property(u => u.Perfil)
                .IsRequired();

            Builder.Property(u => u.usuarioImagem)
                .IsRequired();

            Builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(100);

            Builder.ToTable("Usuarios");
        }
    }
}
