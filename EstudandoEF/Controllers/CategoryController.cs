using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefaApi.Models;
using TarefaApi.Service.CategoryDTO;
using TarefaApi.Service.CategoryService;

namespace TarefaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _service;
        public CategoryController(CategoryService service)
        {
            _service = service;
        }

        [HttpGet]

        public async Task<IActionResult> ListCategories()
        {
            try
            {
                List<ListCategoryDTO> category = await _service.ListCategoriesAsync();
                return Ok(category);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> AddCategories([FromBody] AddCategoryDTO dto)
        {
            try
            {
                await _service.AddCategoriesAsync(dto);
                return Created();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]

        public async Task<IActionResult> ChangeCategory([FromBody] ChangeCategoryDTO dto)
        {
            try
            {
                await _service.ChangeCategoryAsync(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCategory( Guid id)
        {
            try
            {
                await _service.RemoveCategoryAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
       


    }
}
