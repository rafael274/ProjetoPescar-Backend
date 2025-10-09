namespace controleEstoque.Domain.DTOs.Materiais
{
    public class MaterialAdicionarDTO
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }
        public Guid CategoriaId { get; set; }
    }
}
