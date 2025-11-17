using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.DTOs.Usuario
{
    public class UsuarioListarDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Perfil { get; set; }
        public string usuarioImagem { get; set; } = string.Empty;
    }
}
