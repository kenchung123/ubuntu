using System.Collections;
using System.Collections.Generic;
using Example_04.Models;

namespace Example_04.Services
{
    public  interface IStudent 
    {
        IEnumerable<Student> GetStudents();
        Student GetById(int? id);
        void InsertStudent(Student student);
        void DeleteStudent(int id);
        void UpdateStudent(Student student);
        void Save();
    }
}