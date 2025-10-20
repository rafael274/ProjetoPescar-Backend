using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.DTOs.Movimentacoes
{
    public class MovimentacaoAdicionarDTO
    {
        public Guid MaterialId { get; set; }
        public int Quantidade { get; set; }
        public EnumTipo Tipo { get; set; } // "Entrada" ou "Saída"
        public DateOnly Data { get; set; }
    }
}
