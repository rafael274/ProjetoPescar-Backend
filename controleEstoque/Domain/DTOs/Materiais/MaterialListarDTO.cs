namespace controleEstoque.Domain.DTOs.Materiais
{
    public class MaterialListarDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public int EstoqueMinimo { get; set; }
        public Guid CategoriaId { get; set; }
        public string Categoria { get; set; }

    }
}
