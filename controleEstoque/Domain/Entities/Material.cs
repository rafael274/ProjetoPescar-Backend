namespace controleEstoque.Domain.Entidades
{
    public class Material
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }
        public ICollection<Movimentacoes> Movimentacoes { get; set; }
    }
}
