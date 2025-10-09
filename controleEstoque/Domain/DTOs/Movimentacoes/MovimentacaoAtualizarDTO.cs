using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.DTOs.Movimentacoes
{
    public class MovimentacaoAtualizarDTO
    {
        public int Quantidade { get; set; }

        public EnumTipo Tipo { get; set; }
    }
}
