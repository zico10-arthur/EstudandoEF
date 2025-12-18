using TarefaApi.Models;
using TarefaApi.Repository;

namespace TarefaApi.Service
{
    public class CategoryService
    {
        private readonly CategoryRepository _repository;
        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Category>> ListCategoriesAsync()
        {
            return await _repository.ListCategoriesAsync();
        }

        public async Task AddCategoriesAsnyc(Category category)
        {
            await _repository.AddCategorieAsync(category);
        }
    }
}
