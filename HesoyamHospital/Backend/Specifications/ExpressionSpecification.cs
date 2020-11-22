// File:    ExpressionSpecification.cs
// Author:  Geri
// Created: 19. maj 2020 18:28:49
// Purpose: Definition of Class ExpressionSpecification

using System;

namespace Backend.Specifications
{
    public class ExpressionSpecification<T> : CompositeSpecification<T>
    {
        private Func<T, bool> _expression;

        public ExpressionSpecification(Func<T, bool> expression)
        {
            if (expression == null)
                throw new ArgumentNullException();
            else
                _expression = expression;
        }

        public override bool IsSatisfiedBy(T candidate)
        {
            return _expression(candidate);
        }
    }
}