// File:    CompositeSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:20:27
// Purpose: Definition of Class CompositeSpecification

using System;

namespace Backend.Specifications
{
    public abstract class CompositeSpecification<T> : ISpecification<T>
    {
        public ISpecification<T> And(ISpecification<T> other)
        {
            return new AndSpecification<T>(this, other);
        }

        public abstract bool IsSatisfiedBy(T candidate);

        public ISpecification<T> Not(ISpecification<T> other)
        {
            return new NotSpecification<T>(this, other);
        }

        public ISpecification<T> Or(ISpecification<T> other)
        {
            return new OrSpecification<T>(this, other);
        }
    }
}