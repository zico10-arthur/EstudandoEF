using AutoMapper;
using Microsoft.AspNetCore.Identity;
using TarefaApi.Models;
using TarefaApi.Repository;
using TarefaApi.Service.CategoryDTO;
using TarefaApi.Service.ExceptionsCategory;

namespace TarefaApi.Service.CategoryService
{
    public class CategoryService
    {
        private readonly CategoryRepository _repository;
        private readonly IMapper _mapper;
        public CategoryService(CategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ListCategoryDTO>> ListCategoriesAsync()
        {
            List<Category> category = await _repository.ListCategoriesAsync();
            List<ListCategoryDTO> dtoList = _mapper.Map<List<ListCategoryDTO>>(category);
            return dtoList;

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
