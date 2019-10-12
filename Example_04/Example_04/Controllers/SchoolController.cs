using System.Threading.Tasks;
using Example_04.Models;
using Example_04.Repository;
using Example_04.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Example_04.Controllers
{
    public class SchoolController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public SchoolController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        } 
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Class classes)
        {
            var student = new Student()
            {
               MaSv = Request.Form["MaSV"],
               HoTen = Request.Form["HoTen"] 
            };
            var classe = new Class()
            {
                MaLop = Request.Form["MaLop"],
                TenLop = Request.Form["TenLop"]
            };
            
            if (ModelState.IsValid)
            {
                _unitOfWork.StudentRepository.Insert(student);
                _unitOfWork.ClassRepository.Insert(classe);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Create));
            }
            return RedirectToAction(nameof(Create));
        }

        
        
    }
}