using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefaApi.Service.CategoryService;
using TarefaApi.Service.TarefaService;
using TarefaApi.Models;
using TarefaApi.Service.TarefaDTO;

namespace TarefaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _service;

        public TarefaController(TarefaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> ListarTarefas()
        {
            try
            {
               List<ListCategoryTarefaDTO> tarefa = await _service.ListarTarefas();
                return Ok(tarefa);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AdicionarTarefa([FromBody]AddTarefaDTO dto)
        {
            try
            {
                await _service.AdicionarTarefa(dto);
                return Created();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
