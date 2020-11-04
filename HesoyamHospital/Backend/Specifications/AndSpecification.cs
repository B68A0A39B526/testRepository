// File:    AndSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 17:22:53
// Purpose: Definition of Class AndSpecification

using System;

namespace Backend.Specifications
{
    public class AndSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _leftSpecification;
        private ISpecification<T> _rightSpecification;


        public AndSpecification(CompositeSpecification<T> compositeSpecification, ISpecification<T> other)
        {
            _leftSpecification = compositeSpecification;
            _rightSpecification = other;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _leftSpecification.IsSatisfiedBy(candidate) && _rightSpecification.IsSatisfiedBy(candidate);
        }
    }
}