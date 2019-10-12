using System.Collections;
using System.Collections.Generic;
using Training_Ex4.Models;
using Training_Ex4.Services;

namespace Training_Ex4.Services
{
    public class StudentRepository : IStudent
    {
        private SchoolDbContext _context;

        public StudentRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        public Student GetStudentById(int student)
        {
            return _context.Students.Find(student);
        }

        public Student InsertStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }
        public void DeleteStudent(int Id)
        {
            var student = _context.Students.Find(Id);
            if (student != null)
            {
               _context.Students.Remove(student);
                _context.SaveChanges();
            }
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