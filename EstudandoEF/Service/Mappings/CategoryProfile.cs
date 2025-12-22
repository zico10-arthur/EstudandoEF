using AutoMapper;
using TarefaApi.Models;
using TarefaApi.Service.CategoryDTO;
using TarefaApi.Service.TarefaDTO;

namespace TarefaApi.Service.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ListCategoryDTO>();
            CreateMap<Tarefa, ListTarefaDTO>();
            CreateMap<Category, ListCategorywtDTO>();
            CreateMap<Tarefa, ListCategoryTarefaDTO>();



        }
    }
}
