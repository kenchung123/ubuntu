using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StartUp.Confluence.Model.Entities.Confluence;
using StartUp.Confluence.UnitOfWork.Collections;
using StartUp.Confluence.Service.Shared.Confluence;
using System;

namespace StartUp.Confluence.Api.Controllers
{
    [Route("api/Question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {

        IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        // GET: api/Question
        [HttpGet]
        public async Task<object> Get()
        {
            var questions = await _questionService.GetAllAsync();
            return questions;
        }

        // GET: api/Question/5
        [HttpGet("{id}")]
        public object Get(Guid id)
        {
            var q = _questionService.Get(id);
            return q;
        }

        // POST: api/Question
        [HttpPost]
        public object Post([FromBody] Question question)
        {
            var q = _questionService.CreateWithQuestionChoices(question);
            return q;
        }

        // PUT: api/Question/5
        [HttpPut("{id}")]
        public object Put(Guid id, [FromBody] Question question)
        {
            question.Id = id;
            var q = _questionService.Update(question);
            return q;
        }

        // DELETE: api/Question/5
        [HttpDelete("{id}")]
        public object Delete(Guid id)
        {
            var q = _questionService.Delete(id);
            return q;
        }
    }
}
