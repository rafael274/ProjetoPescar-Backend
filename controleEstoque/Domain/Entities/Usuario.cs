using controleEstoque.Domain.Entidades;
using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public EnumPerfil Perfil { get; set; }
        public string usuarioImagem { get; set; } = string.Empty;
    }
}
