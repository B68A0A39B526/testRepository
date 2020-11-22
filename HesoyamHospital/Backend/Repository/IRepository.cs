// File:    IRepository.cs
// Author:  Geri
// Created: 20. maj 2020 12:36:50
// Purpose: Definition of Interface IRepository

using System;
using System.Collections.Generic;

namespace Backend.Repository
{
    public interface IRepository<T, ID>
    {
        IEnumerable<T> GetAll();

        T GetByID(ID id);

        T Create(T entity);

        void Update(T entity);

        void Delete(T entity);

        IEnumerable<T> Find(Specifications.ISpecification<T> criteria);

    }
}