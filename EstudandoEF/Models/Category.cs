namespace Tarefa.Models
{
    public class Category
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public List<Tarefa> Tarefas { get; private set; } = new();

        public IReadOnlyList<Tarefa> tarefa => Tarefas;
    }
}
