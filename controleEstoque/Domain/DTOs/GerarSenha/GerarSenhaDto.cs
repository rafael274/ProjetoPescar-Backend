namespace controleEstoque.Domain.DTOs.GerarSenha
{
    public class GerarSenhaDto
    {
        // Id do usuário (GUID como string)
        public string UsuarioId { get; set; }

        // Email do usuário (usado apenas para validação de correspondência)
        public string Email { get; set; }
    }
}