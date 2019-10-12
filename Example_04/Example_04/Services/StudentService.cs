using System.Collections.Generic;
using Example_04.Models;
using Example_04.Repository;
using Example_04.UnitOfWork;

namespace Example_04.Services
{
    public class StudentService : IStudent
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Student> Get()
        {
            return _unitOfWork.StudentRepository.Get();
            
        }
        public Student GetById(int? id)
        {
            return _unitOfWork.StudentRepository.GetById(id);
        }
        public void Insert(Student student)
        {
           _unitOfWork.StudentRepository.Insert(student);
            
          
        }
        public void Delete(int id)
        {
            _unitOfWork.StudentRepository.Delete(id);
            
        }
        public void Update(Student student)
        {
            _unitOfWork.StudentRepository.Update(student);
            
        }
        public void Save()
        {
           _unitOfWork.StudentRepository.Save();
        }
    }
    
}