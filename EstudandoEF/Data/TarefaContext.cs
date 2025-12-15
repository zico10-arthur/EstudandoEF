using Tarefa.Models;
using Microsoft.EntityFrameworkCore;

namespace Tarefa.Data
{
    public class TarefaContext : DbContext
    {
        public TarefaContext(DbContextOptions<TarefaContext> opt) : base(opt)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<TarefaTask> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
