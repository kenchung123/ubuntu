using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example_04.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClass _classService;
        public ClassController(IClass classService)
        {
            _classService = classService;
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
                _classService.Insert(Classes);
                _classService.Save();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Create));
        }
        public IActionResult Index()
        {
            return View( _classService.Get());
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            return View(_classService.GetById(Id));
        }
        public IActionResult Delete(int? Id)
        {
           
            return View(_classService.GetById(Id));
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
            _classService.Delete(id);
            _classService.Save();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult>Edit(Class classes)
        {
            _classService.Update(classes);
            _classService.Save();
            return RedirectToAction(nameof(Index));
        }

    }
}