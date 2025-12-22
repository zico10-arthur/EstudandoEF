namespace TarefaApi.Service.TarefaExceptions
{
    public class TarefaJaExiste : Exception 
    {
        public TarefaJaExiste()
            : base ("Tarefa já existe") { }
            
        
    }
}
