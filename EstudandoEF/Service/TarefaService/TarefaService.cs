using AutoMapper;
using TarefaApi.Models;
using TarefaApi.Repository;
using TarefaApi.Service.TarefaDTO;
using TarefaApi.Service.TarefaExceptions;

namespace TarefaApi.Service.TarefaService
{
    public class TarefaService
    {
        private readonly TarefaRepository _repository;
        private readonly IMapper _mapper;

        public TarefaService(TarefaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ListCategoryTarefaDTO>> ListarTarefas()
        {
            List<Tarefa> tarefa = await _repository.ListarTarefas();
            List<ListCategoryTarefaDTO> listdto = _mapper.Map<List<ListCategoryTarefaDTO>>(tarefa);
            return listdto;
        }

        public async Task AdicionarTarefa(AddTarefaDTO dto)
        {
            
            Tarefa tarefa = new Tarefa(dto.Name, dto.Description, dto.CategoryId, dto.Completed);
        

            await _repository.AdicionarTarefa(tarefa);


        }
    }
}
