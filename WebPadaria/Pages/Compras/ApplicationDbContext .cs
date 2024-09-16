using Microsoft.EntityFrameworkCore;
using WebPadaria.Models;

namespace WebPadaria.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Compra>()
                .HasOne<Cliente>()
                .WithMany()
                .HasForeignKey(c => c.Cliente_Id);

            modelBuilder.Entity<Compra>()
                .HasOne<Produto>()
                .WithMany()
                .HasForeignKey(c => c.Produto_Id);
        }
    }
}
