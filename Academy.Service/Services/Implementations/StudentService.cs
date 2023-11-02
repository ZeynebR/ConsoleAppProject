using Academy.Core.Enums;
using Academy.Core.Models;
using Academy.Core.Repositories;
using Academy.Data.Repositories;
using System;
using System.Collections.Generic;

namespace Academy.Service.Services.Implementations
{
    public class StudentService : IStudentService
    {

        IStudentRepository _studentRepository= new StudentRepository();

        public async Task<string> CreateAsync(string fullname, string group, double average, EducationCategory educationCategory)
        {
            if (string.IsNullOrWhiteSpace(fullname))
                return "Fullname can not be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty";
            if (average <= 0)
                return "Average can not be less than 0";

            Student student = new Student(fullname, group, average,educationCategory);
             await _studentRepository.AddAsync(student);
            return "Created successfully";

        }

        public async Task GetAllAsync()
        {
           List<Student> students = await _studentRepository.GetAllAsync(); 
            foreach (Student student in students) 
            {
                Console.WriteLine($"Id: {student.Id} / Fullname: {student.FullName} / Group: {student.Group} / Average: {student.Average} / Education category: {student.EducationCategory} / Created at: {student.CreatedAt} / Updated at: {student.UpdatedAt}");
            }
        }

        public async Task<string> GetAsync(string id)
        {
            Student student = await _studentRepository.GetAsync(x=>x.Id==id);
            if (student == null)
                return "Student not found ";
            Console.WriteLine($"Id: {student.Id} / Fullname: {student.FullName} / Group: {student.Group} / Average: {student.Average} / Education category: {student.EducationCategory} / Created at: {student.CreatedAt} / Updated at: {student.UpdatedAt}");
            return "The process is successful";
        }

        public async Task<string> RemoveAsync(string id)
        {
            
        }

        public Task<string> UpdateAsync(string fullname, string group, double average, EducationCategory educationCategory)
        {
            throw new NotImplementedException();
        }
    }
}
