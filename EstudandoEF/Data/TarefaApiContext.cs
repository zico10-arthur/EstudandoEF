using TarefaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TarefaApi.Data
{
    public class TarefaApiContext : DbContext
    {
        public TarefaApiContext(DbContextOptions<TarefaApiContext> opt) : base(opt)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tarefa>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tarefas)
                .HasForeignKey(t => t.CategoryId);
        }
    }
}
