using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example_04.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClass _context;
        public ClassController(IClass classRepository)
        {
            _context = classRepository;
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Class Classes)
        {
            if (ModelState.IsValid)
            {
                _context.InsertClass(Classes);
                _context.Save();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Index()
        {
            return View( _context.GetClass());
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
//        public IActionResult Details()
//        {
//            return View();
//        }
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
            _context.DeleteClass(id);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Class classes)
        {
            _context.UpdateClass(classes);
            _context.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}