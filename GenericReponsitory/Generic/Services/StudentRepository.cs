using System.Collections.Generic;
using Example_04.Models;
using Example_04.Services;

namespace Example_04.Services
{
    public class StudentRepository :IStudent
    {
        private  SChoolDbContext _context;

        public StudentRepository(SChoolDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        public Student GetById(int? id)
        {
            return _context.Students.Find(id);
        }

        public void InsertStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            Student student = _context.Students.Find(id);
            _context.Students.Remove(student);
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }

   
}