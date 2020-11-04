// File:    NotSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:23:38
// Purpose: Definition of Class NotSpecification

using System;

namespace Backend.Specifications
{
    public class NotSpecification<T> : CompositeSpecification<T>
    {
        private ISpecification<T> _leftSpecification;
        private ISpecification<T> _rightSpecification;

        public NotSpecification(CompositeSpecification<T> compositeSpecification, ISpecification<T> other)
        {
            _leftSpecification = compositeSpecification;
            _rightSpecification = other;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _leftSpecification.IsSatisfiedBy(candidate) && !_rightSpecification.IsSatisfiedBy(candidate);
        }
    }
}