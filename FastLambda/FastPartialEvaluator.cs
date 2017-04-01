using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace FastLambda
{
    public class FastPartialEvaluator : PartialEvaluatorBase
    {
        public FastPartialEvaluator()
            : base(new FastEvaluator())
        { }
    }
}
