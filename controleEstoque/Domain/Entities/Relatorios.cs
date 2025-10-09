namespace controleEstoque.Domain.Entidades
{
    public class Relatorios
    {
        public Guid Id { get; set; }

        public Guid MateriaisId { get; set; }
        public int TotalEntradas { get; set; }
        public int TotalSaidas { get; set; }
        public DateTime PeriodoReferencia { get; set; } // Ex: 01/08/2025
        public Material Materiais { get; set; }
    }
}
