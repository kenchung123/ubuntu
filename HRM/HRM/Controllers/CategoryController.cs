using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartUp.Confluence.Model.Entities.Confluence;
using StartUp.Confluence.Service.Shared.Confluence;
using StartUp.Confluence.UnitOfWork.Collections;

namespace StartUp.Confluence.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/Category                                 
        [HttpGet]
        public async Task<object> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return categories;
        }

        //GET: api/Category/Questions/5
        [HttpGet("Questions/{id}")]
        public async Task<object> Get(Guid id)
        {
            var category = await _categoryService.GetQuestions(id);
            return category;
        }

        // POST: api/Category
        [HttpPost]
        public Category Post([FromBody] Category category)
        {
            var c = _categoryService.Create(category);
            return c;
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public Category Put(Guid id, [FromBody] Category category)
        {
            category.Id = id;
            var c = _categoryService.Update(category);
            return c;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Category Delete(Guid id)
        {
            var c = _categoryService.Delete(id);
            return c;
        }
    }
}
