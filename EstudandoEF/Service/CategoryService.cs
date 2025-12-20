using Microsoft.AspNetCore.Identity;
using TarefaApi.Models;
using TarefaApi.Repository;
using TarefaApi.Service.ExceptionsCategory;

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

        public async Task AddCategoriesAsync(AddCategoryDTO dto)
        {
            Category category = new Category(dto.Name);
            await _repository.AddCategorieAsync(category);
        }

        public async Task ChangeCategoryAsync(ChangeCategoryDTO dto)
        {
            Category categoryexiste = await _repository.BuscarId(dto.Id);

            if (categoryexiste == null)
            {
                throw new CategoryDontExist();
            }
            categoryexiste.ChangeName(dto.NewName);

            await _repository.Save();
            
        }

        public async Task RemoveCategoryAsync(Guid id)
        {
            Category categoryexiste = await _repository.BuscarId(id);

            if (categoryexiste == null)
            {
                throw new CategoryDontExist();
            }

            await _repository.RemoveCategory(categoryexiste);
        }
    }
}
