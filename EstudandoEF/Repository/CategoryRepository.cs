using TarefaApi.Data;
using TarefaApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TarefaApi.Repository
{
    public class CategoryRepository 
    {
        private readonly TarefaApiContext _context;
        public CategoryRepository(TarefaApiContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> ListCategoriesAsync()
        {
            return await _context.Categories.Include(t => t.Tarefas).OrderBy(c => c.Name).ToListAsync();
        }

        public async Task AddCategorieAsync(Category category)
        {
           await  _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> BuscarId(Guid id)
        {
            Category? buscar = await _context.Categories.FindAsync(id);
            return buscar;
        }

        public async Task RemoveCategory(Category category)
        {

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        
    }
}
