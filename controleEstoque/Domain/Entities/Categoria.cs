namespace controleEstoque.Domain.Entidades
{
    public class Categoria
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public ICollection<Material> Materiais { get; set; }
    }
}
