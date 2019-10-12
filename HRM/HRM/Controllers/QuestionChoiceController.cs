using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartUp.Confluence.Model.Entities.Confluence;
using StartUp.Confluence.Service.Shared.Confluence;

namespace StartUp.Confluence.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionChoiceController : ControllerBase
    {
        IQuestionChoiceService _questionChoiceService;

        public QuestionChoiceController(IQuestionChoiceService  questionChoiceService)
        {
            _questionChoiceService = questionChoiceService;
        }

        // GET: api/QuestionChoice
        [HttpGet]
        public async Task<object> Get()
        {
            var questionChoice = await _questionChoiceService.GetAllAsync();
            return questionChoice;
        }

        // GET: api/QuestionChoice/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/QuestionChoice
        [HttpPost]
        public QuestionChoice Post([FromBody] QuestionChoice questionChoice)
        {
            var c = _questionChoiceService.Create(questionChoice);
            return c;

        }

        // PUT: api/QuestionChoice/5
        [HttpPut("{id}")]       
        public QuestionChoice Put(Guid id, [FromBody] QuestionChoice questionChoice)
        {
            questionChoice.Id = id;
            var c = _questionChoiceService.Update(questionChoice);
            return c;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public QuestionChoice Delete(Guid id)
        {
            var c = _questionChoiceService.Delete(id);
            return c;
        }
    }
}
