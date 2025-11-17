using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.DTOs.Usuario
{
    public class UsuarioAdicionarDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string ConfirmarSenha { get; set; } = string.Empty;
        public EnumPerfil Perfil { get; set; }
        public string usuarioImagem { get; set; } = string.Empty;
    }
}
