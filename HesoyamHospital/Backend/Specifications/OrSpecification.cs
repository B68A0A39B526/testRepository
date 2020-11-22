// File:    OrSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:23:37
// Purpose: Definition of Class OrSpecification

using System;

namespace Backend.Specifications
{
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _leftSpecification;
        private ISpecification<T> _rightSpecification;


        public OrSpecification(CompositeSpecification<T> compositeSpecification, ISpecification<T> other)
        {
            _leftSpecification = compositeSpecification;
            _rightSpecification = other;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _leftSpecification.IsSatisfiedBy(candidate) || _rightSpecification.IsSatisfiedBy(candidate);
        }
    }
}