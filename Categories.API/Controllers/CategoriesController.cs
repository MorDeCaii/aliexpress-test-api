using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Categories.Core.DTO;
using Categories.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Categories.API.Controllers
{
    [Route("{controller}")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryReadDto>>> GetAll()
        {
            var result =  await _categoryService.GetAll();
            return Ok(result);
        }

        [Route("{id}")]
        public async Task<ActionResult<CategoryReadDto>> Get(int id)
        {
            var result = await _categoryService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
        
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]CategoryCreateDto category)
        {
            if (category == null)
            {
                return NoContent();
            }
            
            var result = await _categoryService.Create(category);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPatch]
        public async Task<ActionResult> Update([FromBody]CategoryUpdateDto category)
        {
            if (category == null)
            {
                return NoContent();
            }

            var result = await _categoryService.Update(category);
            if (result)
            {
                return Ok();
            }

            return NotFound();
        }
    }
}