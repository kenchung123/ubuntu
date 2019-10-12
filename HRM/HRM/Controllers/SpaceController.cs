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
  public class SpaceController : ControllerBase
  {

    ISpaceService _spaceService;
    public SpaceController(ISpaceService spaceService)
    {
      _spaceService = spaceService;
    }

    // GET: api/Space
    [HttpGet]          
    public async Task<object> Get()
    {
      var spaces = await _spaceService.GetAllAsync();
      return spaces;
    }

    // GET: api/Space/5                 
    [HttpGet("Space/{id}")]
    public Space Get(Guid id)
    {
      var space = _spaceService.Get(id);
      return space;
    }

    // POST: api/Space
    [HttpPost]
    public Space Post([FromBody] Space space)
    {
      var s = _spaceService.Create(space);
      return s;
    }

    // PUT: api/Space/5
    [HttpPut("{id}")]
    public Space Put(Guid id, [FromBody] Space space)
    {
      space.Id = id;
      var s = _spaceService.Update(space);
      return s;
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public Space Delete(Guid id)
    {
      var c = _spaceService.Delete(id);
      return c;
    }
  }
}
