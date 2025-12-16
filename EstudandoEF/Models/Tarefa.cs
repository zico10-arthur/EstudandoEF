namespace TarefaApi.Models
{
    public class Tarefa
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; } = string.Empty;

        public string Description { get; private set; } = string.Empty;

        public bool Completed { get; private set; }

        public Guid CategoryId { get; private set; }

        public Category Category { get; private set; }



    }
}
