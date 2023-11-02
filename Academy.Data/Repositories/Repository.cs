using Academy.Core.Models.BaseModels;
using Academy.Core.Repositories;
using System;
using System.Collections.Generic;

namespace Academy.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T: BaseModel
    {
        List <T> values = new List <T> ();
        public async Task AddAsync(T entity)
        {
            values.Add (entity);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return values;
        }

        public async Task<List<T>> GetAllAsync(Func<T, bool> func)
        {
            return values.Where(func).ToList(); 
        }


        public async Task<T> GetAsync(Func<T, bool> func)
        {
            return values.FirstOrDefault(func);
        }

        public async Task RemoveAsync(T entity)
        {
          values.Remove (entity);   
        }
    }
}
