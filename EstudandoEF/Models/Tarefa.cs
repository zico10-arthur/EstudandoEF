namespace TarefaApi.Models
{
    public class Tarefa
    {
        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public bool Completed { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }

        public Tarefa()
        {
            
        }
        public Tarefa(string name, string description, Guid categoryId, bool completed)
        {
            Name = name;
            Description = description;
            Completed = completed;
            CategoryId = categoryId;
        }


    }
}
