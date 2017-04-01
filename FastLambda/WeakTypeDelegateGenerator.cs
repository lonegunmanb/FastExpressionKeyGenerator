﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastLambda
{
    public class WeakTypeDelegateGenerator : ExpressionVisitor
    {
        private List<ParameterExpression> m_parameters;

        public Delegate Generate(Expression exp)
        {
            this.m_parameters = new List<ParameterExpression>();

            var body = this.Visit(exp);
            var lambda = Expression.Lambda(body, this.m_parameters.ToArray());
            return lambda.Compile();
        }

        protected override Expression VisitConstant(ConstantExpression c)
        {
            var p = Expression.Parameter(c.Type, "p" + this.m_parameters.Count);
            this.m_parameters.Add(p);
            return p;
        }
    }
}
