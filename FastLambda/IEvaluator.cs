﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastLambda
{
    public interface IEvaluator
    {
        object Eval(Expression exp);
    }
}
