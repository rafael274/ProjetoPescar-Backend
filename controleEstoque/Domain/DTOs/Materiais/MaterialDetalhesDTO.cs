namespace controleEstoque.Domain.DTOs.Materiais
{
    public class MaterialDetalhesDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Quantidade { get; set; }
        public string UnidadeMedida { get; set; }
    }
}
