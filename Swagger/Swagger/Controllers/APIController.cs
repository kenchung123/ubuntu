using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swagger.Models;

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : Controller
    {
        private readonly SinhVienDbContext _context;

        public APIController(SinhVienDbContext context)
        {
            _context = context;

            if (!_context.SinhViens.Any())
            {
                _context.SinhViens.Add(new SinhVien() {Name = "Item1"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhVien()
        {       
              return await _context.SinhViens.ToListAsync();      
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVien>> GetSinhVien(int id)
        {
            var sv = await _context.SinhViens.FindAsync(id);
            if (sv == null)
            {
                return NotFound();
            }
            return sv;
        }

        [HttpPost]
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien item)
        {
            var svien = _context.SinhViens.Where(s => s.Name == item.Name).FirstOrDefault<SinhVien>();
            if (svien != null)
            {
                return StatusCode((int) HttpStatusCode.BadRequest, ("the same name"));
            }
            if (item.Name.Length > 30)
            {
                return StatusCode((int) HttpStatusCode.LengthRequired, ("The name exceed 30 characters"));
            }

            var sv = await _context.SinhViens.FindAsync(item.Id);
            if (sv != null)
            {
                return StatusCode((int) HttpStatusCode.BadRequest, ("the same Id"));
            }

            try
            {
                _context.SinhViens.Add(item);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetSinhVien), new {id = item.Id}, item);
            }
            catch (Exception e)
            {
                return StatusCode((int) HttpStatusCode.BadRequest,e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien(int id, SinhVien item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(int id)
        {
            var sv = await _context.SinhViens.FindAsync(id);

            if (sv== null)
            {
                return NotFound();
            }

            _context.SinhViens.Remove(sv);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        public enum ValueType
        {
            Number,
            Text
        }
    }
}