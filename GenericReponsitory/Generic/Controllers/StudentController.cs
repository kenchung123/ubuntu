using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Services;
using Microsoft.AspNetCore.Mvc;
namespace Example_04.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _context;
        public StudentController(IStudent studentRepository)
        {
            _context = studentRepository;
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
                _context.InsertStudent(Students);
                 _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Index()
        {
            return View( _context.GetStudents());
        }
//        public IActionResult Delete()
//        {
//            return View();
//        }
//        public IActionResult Update()
//        {
//            return View();
//        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            return View(_context.GetById(Id));
        }
        public IActionResult Details()
        {
            return View();
        }
        public IActionResult Delete(int? Id)
        {
           
            return View(_context.GetById(Id));
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
            _context.DeleteStudent(id);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Student student)
        {
            _context.UpdateStudent(student);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }
      
    }
}