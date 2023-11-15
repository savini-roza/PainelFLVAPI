using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using PainelFLVAPI.Model;

namespace PainelFLVAPI.Repositories.Contexts
{
    public class FLVDbContext : DbContext
    {
        public FLVDbContext(DbContextOptions<FLVDbContext> dbContextOptions) : base(dbContextOptions)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Produtor> Produtor { get; set; }
        public DbSet<Comprador> Comprador{ get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Embalagem> Embalagem { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<ProdutoProdutor> ProdutoProdutor { get; set; }
        public DbSet<ProdutoComprador> ProdutoComprador { get; set; }
        public DbSet<ContatoCompradorProdutor> ContatoCompradorProdutor { get; set; }
        public DbSet<ContatoProdutorFornecedor> ContatoProdutorFornecedor { get; set; }
        public DbSet<AvaliacaoCompradorProdutor> AvaliacaoCompradorProdutor { get; set; }
        public DbSet<AvaliacaoProdutorFornecedor> AvaliacaoProdutorFornecedor { get; set; }
    }
}
