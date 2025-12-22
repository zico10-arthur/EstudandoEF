using TarefaApi.Models;

namespace TarefaApi.Service.TarefaDTO
{
    public class AddTarefaDTO
    {
        public string Name { get;  set; } = string.Empty;

        public string Description { get;  set; } = string.Empty;

        public bool Completed { get;  set; }

        public Guid CategoryId { get;  set; }


    }
}
