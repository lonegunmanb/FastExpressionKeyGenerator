﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastLambda
{
    public interface IExpressionCache<T> where T : class
    {
        T Get(Expression key, Func<Expression, T> creator);
    }
}
