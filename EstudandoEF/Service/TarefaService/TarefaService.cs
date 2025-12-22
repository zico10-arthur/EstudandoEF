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

        public async Task ChangeName(ChangeNameDTO dto)
        {
            Tarefa tarefa = await _repository.BuscarId(dto.Id);

            if (tarefa == null)
            {
                throw new TarefaNotFound();
            }

            tarefa.ChangeName(dto.NewName);
            _repository.Save();
        }

        public async Task ChangeDescription(ChangeDescriptionDTO dto)
        {
            Tarefa tarefa = await _repository.BuscarId(dto.Id);

            if (tarefa == null)
            {
                throw new TarefaNotFound();
            }

            tarefa.ChangeDescription(dto.NewDescription);
            _repository.Save();
        }

        public async Task ChangeStatus(ChangeStatusDTO dto)
        {
            Tarefa tarefa = await _repository.BuscarId(dto.Id);

            if (tarefa == null)
            {
                throw new TarefaNotFound();
            }

            tarefa.ChangeStatus(dto.NewCompleted);
            _repository.Save();
        }

        public async Task ChangeCategoryId(ChangeCategoryIdDTO dto)
        {
            Tarefa tarefa = await _repository.BuscarId(dto.Id);

            if (tarefa == null)
            {
                throw new TarefaNotFound();
            }

            tarefa.ChangeCategoryId(dto.CategoryId);
            _repository.Save();
        }

        public async Task RemoveTarefa(Guid id)
        {
            Tarefa tarefa = await _repository.BuscarId(id);

            if (tarefa == null)
            {
                throw new TarefaNotFound();
            }
            _repository.RemoveTarefa(tarefa);
            
        }
    }
}
