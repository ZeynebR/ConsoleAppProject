using System;
using System.Collections.Generic;

namespace Academy.Core.Models.BaseModels
{
    public abstract class BaseModel
    {
        public string Id { get; set; } 
        public DateTime CreatedAt { get; set; } 
        public DateTime UpdatedAt { get; set;} 
    }
}

