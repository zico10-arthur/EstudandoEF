using System.Reflection.Metadata.Ecma335;
using TarefaApi.Data;
using TarefaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TarefaApi.Repository
{
    public class TarefaRepository
    {
        private readonly TarefaApiContext _context;

        public TarefaRepository(TarefaApiContext context)
        {
            _context = context;
        }

        public async Task<List<Tarefa>> ListarTarefas()
        {
            return await _context.Tarefas.Include(c => c.Category).OrderBy(t => t.Id).ToListAsync();
        }

        public async Task AdicionarTarefa(Tarefa tarefa)
        {
            _context.Tarefas.AddAsync(tarefa);
            Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Tarefa> BuscarId(Guid id)
        {
            Tarefa tarefabuscar =  await _context.Tarefas.FindAsync(id);
            return tarefabuscar;        
        }
    }
}
