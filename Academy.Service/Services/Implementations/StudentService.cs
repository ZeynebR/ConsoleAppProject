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
                return "Average can not be less or equal to 0";

            Student student = new Student(fullname, group, average,educationCategory);
            student.CreatedAt = DateTime.UtcNow.AddHours(4);
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
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found ";
            
          await   _studentRepository.RemoveAsync(student);
            return "Student removed successfully";
        }

        public async Task<string> UpdateAsync(string id,string fullname, string group, double average, EducationCategory educationCategory)
        {
            Student student = await _studentRepository.GetAsync(x => x.Id == id);
            if (student == null)
                return "Student not found ";
            if (string.IsNullOrWhiteSpace(fullname))
                return "Fullname can not be empty";
            if (string.IsNullOrWhiteSpace(group))
                return "Group can not be empty";
            if (average <= 0)
                return "Average can not be less than 0";

            student.FullName = fullname;    
            student.Group = group;
            student.Average = average;
            student.EducationCategory = educationCategory;  
            student.UpdatedAt = DateTime.UtcNow.AddHours(4);

            return "Student updated successfully";
        }
    }
}
