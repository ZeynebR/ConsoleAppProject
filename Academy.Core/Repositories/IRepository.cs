﻿using System;
using System.Collections.Generic;

namespace Academy.Core.Repositories
{
    public interface IRepository<T>
    {
        public Task AddAsync (T entity);
        public Task RemoveAsync(T entity);
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> GetAllAsync(Func<T, bool> func);
        public Task<T> GetAsync(Func<T, bool> func);
    }
}