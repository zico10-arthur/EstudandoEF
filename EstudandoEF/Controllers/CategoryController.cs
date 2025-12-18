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
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public async Task<IActionResult> AddCategories([FromBody] Category category)
        {
            try
            {
                await _service.AddCategoriesAsnyc(category);
                return Ok("categoria incluida");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


    }
}
