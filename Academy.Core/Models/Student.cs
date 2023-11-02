using Academy.Core.Enums;
using Academy.Core.Models.BaseModels;
using System;
using System.Collections.Generic;

namespace Academy.Core.Models
{
    public class Student: BaseModel
    {
        static int _id;
        public string FullName { get; set; }    
        public string Group { get; set; }
        public double Average { get; set; } 
        public EducationCategory EducationCategory { get; set; }

        public Student(string fullname, string group, double average, EducationCategory educationCategory)
        {
            _id++;
            FullName = fullname;    
            Group = group;  
            Average = average;  
            EducationCategory = educationCategory;
            Id = $"{EducationCategory.ToString()[0]}-{_id}";
        }
    }
}
