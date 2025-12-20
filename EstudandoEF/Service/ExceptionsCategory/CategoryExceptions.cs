namespace TarefaApi.Service.ExceptionsCategory
{
    public class CategoryDontExist : Exception
    {
        public CategoryDontExist()
        
            : base("Essa categoria não existe") { }
        
    }
}
