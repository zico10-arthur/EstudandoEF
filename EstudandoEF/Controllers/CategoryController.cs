using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TarefaApi.Models;
using TarefaApi.Service;

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
                List<Category> category = await _service.ListCategoriesAsync();
                return Ok(category);

            }
            catch(Exception ex)
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
       


    }
}
