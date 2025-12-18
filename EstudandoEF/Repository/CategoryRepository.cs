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
            return await _context.Categories.ToListAsync();
        }

        public async Task AddCategorieAsync(Category category)
        {
           await  _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        
    }
}
