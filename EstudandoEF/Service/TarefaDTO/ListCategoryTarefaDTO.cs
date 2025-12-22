using TarefaApi.Models;
using TarefaApi.Service.CategoryDTO;

namespace TarefaApi.Service.TarefaDTO
{
    public class ListCategoryTarefaDTO
    {
        public Guid Id { get; private set; } 

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public bool Completed { get; private set; }

        public ListCategorywtDTO Category { get; set; }
    }
}
