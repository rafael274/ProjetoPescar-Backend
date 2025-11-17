using controleEstoque.Domain.entidades;
using controleEstoque.Domain.Entidades;
using controleEstoque.Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace controleEstoque.Infra.Context
{
    public class EstoqueContext : DbContext
    {
        public DbSet<Material> MateriaisSet { get; set; }
        public DbSet<Usuario> UsuariosSet { get; set; }
        public DbSet<Movimentacoes> MovimentacoesSet { get; set; }
        public DbSet<Relatorios> RelatoriosSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MateriaisConfigurations());
            modelBuilder.ApplyConfiguration(new UsuarioConfigurations());
            modelBuilder.ApplyConfiguration(new MovimentacoesConfigurations());
            modelBuilder.ApplyConfiguration(new RelatoriosConfigurations());

            base.OnModelCreating(modelBuilder);
            // Configurações adicionais do modelo podem ser feitas aqui
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            const string conexao = "Server=127.0.0.1;Port=3306;Database=ControleEstoque;Uid=root;";
            optionsBuilder.UseMySql(conexao, ServerVersion.AutoDetect(conexao));

            base.OnConfiguring(optionsBuilder);
        }
    }
}