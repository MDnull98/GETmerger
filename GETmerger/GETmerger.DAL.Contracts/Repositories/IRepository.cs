﻿using System.Collections.Generic;

namespace GETmerger.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T Get(int? id);

        void Create(T item);
        void Delete(int id);
        void Update(T item);
    }
}