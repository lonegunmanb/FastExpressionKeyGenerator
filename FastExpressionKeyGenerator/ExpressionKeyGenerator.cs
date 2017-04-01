using System;
using System.Linq;
using System.Linq.Expressions;

namespace FastExpressionKeyGenerator
{
    /// <summary>
    /// Extension methods for query cache.
    /// </summary>
    /// <remarks>
    /// Copyright (c) 2010 Pete Montgomery.
    /// http://petemontgomery.wordpress.com
    /// Licenced under GNU LGPL v3.
    /// http://www.gnu.org/licenses/lgpl.html
    /// </remarks>
    public static class ExpressionKeyGenerator
    {
        /// <summary>
        /// Gets a cache key for the specified <see cref="IQueryable"/>.
        /// </summary>
        /// <param name="expression">The Expression that you wanna get a key represent it</param>
        /// <param name="hashKey">Hash return key my md5 in case the key is potentially very long</param>
        /// <returns>A unique key for the specified <see cref="IQueryable"/></returns>
        public static string GetKey(this Expression expression, bool hashKey = true)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }
            // locally evaluate as much of the query as possible
            expression = Evaluator.PartialEval(expression, ExpressionKeyGenerator.CanBeEvaluatedLocally);

            // support local collections
            expression = LocalCollectionExpander.Rewrite(expression);

            // use the string representation of the expression for the cache key
            string key = expression.ToString();

            // the key is potentially very long, so use an md5 fingerprint
            // (fine if the query result data isn't critically sensitive)
            if (hashKey)
            {
                key = key.ToMd5Fingerprint();
            }

            return key;
        }

        static Func<Expression, bool> CanBeEvaluatedLocally
        {
            get
            {
                return expression =>
                {
                    // don't evaluate parameters
                    if (expression.NodeType == ExpressionType.Parameter)
                        return false;

                    // can't evaluate queries
                    if (typeof(IQueryable).IsAssignableFrom(expression.Type))
                        return false;

                    return true;
                };
            }
        }
    }
}
