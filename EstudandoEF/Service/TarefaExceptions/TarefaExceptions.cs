namespace TarefaApi.Service.TarefaExceptions
{
    public class TarefaJaExiste : Exception 
    {
        public TarefaJaExiste()
            : base ("Tarefa já existe") { }


    }

    public class TarefaNotFound : Exception 
    {
        public TarefaNotFound()

          : base("tarefa não existe") { }
        
    }

}
