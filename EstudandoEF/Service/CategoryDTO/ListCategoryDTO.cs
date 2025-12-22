using TarefaApi.Models;
using TarefaApi.Service.TarefaDTO;

namespace TarefaApi.Service.CategoryDTO
{
    public class ListCategoryDTO
    {
        public Guid Id { get; private set; } 

        public string Name { get; private set; } = string.Empty;

        public List<ListTarefaDTO> Tarefas { get; private set; } = new();
    }
}
