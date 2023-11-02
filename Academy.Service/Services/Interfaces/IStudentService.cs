using Academy.Core.Enums;
using System;
using System.Collections.Generic;

namespace Academy.Service.Services.Implementations
{
    public interface IStudentService
    {
        public Task<string> CreateAsync(string fullname, string group, double average, EducationCategory educationCategory);
        public Task<string> UpdateAsync(string fullname, string group, double average, EducationCategory educationCategory);
        public Task<string> RemoveAsync(string id);
        public Task<string> GetAsync(string id);
        public Task GetAllAsync();


    }
}
