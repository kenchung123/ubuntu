using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StartUp.Confluence.Model.Entities.Spaces;
using StartUp.Confluence.Service.Shared.Spaces;

namespace StartUp.Confluence.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DocumentController : ControllerBase
  {

    IDocumentService _documentService;
    public DocumentController(IDocumentService documentService)
    {
      _documentService = documentService;
    }

    // GET: api/Document
    [HttpGet]
    public async Task<object> Get()
    {
      var documents = await _documentService.GetAllAsync();
      return documents;
    }

    // GET: api/Document/5                 
    [HttpGet("Document/{id}")]
    public Document Get(Guid id)
    {
      var document = _documentService.Get(id);
      return document;
    }

    // POST: api/Document
    [HttpPost]
    public Document Post([FromBody] Document document)
    {
      var c = _documentService.Create(document);
      return c;
    }

    // PUT: api/Document/5
    [HttpPut("{id}")]
    public Document Put(Guid id, [FromBody] Document document)
    {
      document.Id = id;
      var c = _documentService.Update(document);
      return c;
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public Document Delete(Guid id)
    {
      var c = _documentService.Delete(id);
      return c;
    }
  }
}
