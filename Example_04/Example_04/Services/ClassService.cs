using System.Collections.Generic;
using Example_04.Models;
using Example_04.Repository;
using Example_04.UnitOfWork;

namespace Example_04.Services
{
    public  class ClassService : IClass
    {
        private readonly IUnitOfWork _unitOfWork;
        public ClassService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Class> Get()
        {
             return _unitOfWork.ClassRepository.Get();       
        }
        public Class GetById(int? id)
        {
            return _unitOfWork.ClassRepository.GetById(id);
        }
        public void Insert(Class classes)
        {
           _unitOfWork.ClassRepository.Insert(classes);
          
        }
        public void Delete(int id)
        {
            _unitOfWork.ClassRepository.Delete(id);
           
        }
        public void Update(Class classes)
        {
            _unitOfWork.ClassRepository.Update(classes);
           
        }
        public void Save()
        {
           _unitOfWork.ClassRepository.Save();
        }
    }
}