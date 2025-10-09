using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.DTOs.Movimentacoes
{
    public class MovimentacaoListarDTO
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public int Quantidade { get; set; }
        public EnumTipo Tipo { get; set; }
        public string Material { get; set; }
    }
}
