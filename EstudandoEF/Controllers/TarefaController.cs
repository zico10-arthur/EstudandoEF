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
        [HttpPut]
        public async Task<IActionResult> ChangeName([FromBody] ChangeNameDTO dto)
        {
            try
            {
                await _service.ChangeName(dto);
                return Ok("nome alterado com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("alterardescricao")]

        public async Task<IActionResult> ChangeDescription([FromBody] ChangeDescriptionDTO dto)
        {
            try
            {
                await _service.ChangeDescription(dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("alterarstatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatusDTO dto)
        {
            try
            {
                await _service.ChangeStatus(dto);
                return Ok("Status alterado com sucesso");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("alterarcategoriaid")]

        public async Task<IActionResult> ChangeCategoryId([FromBody] ChangeCategoryIdDTO dto)
        {
            try
            {
                await _service.ChangeCategoryId(dto);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> RemoveTarefa([FromRoute] Guid id)
        {
            try
            {
                await _service.RemoveTarefa(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
