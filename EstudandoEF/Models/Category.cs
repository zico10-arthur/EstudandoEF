namespace TarefaApi.Models
{
    public class Category
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = string.Empty;

        public List<Tarefa> Tarefas { get; private set; } = new();

    }
}
