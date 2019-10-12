using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Services;
using Microsoft.AspNetCore.Mvc;
namespace Example_04.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _studentService;
        public StudentController(IStudent studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Student Students)
        {
            if (ModelState.IsValid)
            {
                _studentService.Insert(Students);
                _studentService.Save();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Index()
        {
            return View( _studentService.Get());
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            return View(_studentService.GetById(Id));
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Student student)
        {
            _studentService.Update(student);
            _studentService.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {      
            return View(_studentService.GetById(Id));
        }
        // POST: Loggin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _studentService.Delete(id);
            _studentService.Save();
            return RedirectToAction(nameof(Index));
        }    
    }
}