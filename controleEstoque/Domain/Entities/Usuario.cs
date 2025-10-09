using controleEstoque.Domain.Entidades;

namespace controleEstoque.Domain.entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        //public ICollection<Movimentacoes> Movimentacoes { get; set; } = new List<Movimentacoes>();
        //public ICollection<Relatorios> Relatorios { get; set; } = new List<Relatorios>();

    }
}
