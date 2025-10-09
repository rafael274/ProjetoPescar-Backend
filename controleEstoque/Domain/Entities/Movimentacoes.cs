using controleEstoque.Domain.entidades;
using controleEstoque.Domain.Enum;

namespace controleEstoque.Domain.Entidades
{
    public class Movimentacoes
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public Material Material { get; set; }
        public int Quantidade { get; set; }
        public EnumTipo Tipo { get; set; } // "Entrada" ou "Saída"
        public DateTime Data { get; set; }
    }
}
