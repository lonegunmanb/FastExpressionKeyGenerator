using System;
using System.Linq.Expressions;
using Xunit;

namespace FastExpressionKeyGenerator.Test
{
    public class BaseTest
    {
        [Fact]
        public void same_expressions_using_same_constant_should_equal()
        {
            Expression<Func<int, bool>> exp1 = i => i > 10 || i % 2 == 0;
            Expression<Func<int, bool>> exp2 = i => i > 10 || i % 2 == 0;
            Assert.Equal(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_different_constant_should_not_equal()
        {
            Expression<Func<int, bool>> exp1 = i => i > 10 || i % 2 == 0;
            Expression<Func<int, bool>> exp2 = i => i > 11 || i % 2 == 0;
            Assert.NotEqual(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_same_variable_should_equal()
        {
            int int1 = 10;
            int int2 = 10;
            Expression<Func<int, bool>> exp1 = i => i > int1;
            Expression<Func<int, bool>> exp2 = i => i > int2;
            Assert.Equal(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_different_variables_should_not_equal()
        {
            int int1 = 10;
            int int2 = 11;
            Expression<Func<int, bool>> exp1 = i => i > int1;
            Expression<Func<int, bool>> exp2 = i => i > int2;
            Assert.NotEqual(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_same_property_should_equal()
        {
            Tuple<int, int> tuple1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> tuple2 = new Tuple<int, int>(1, 1);
            Expression<Func<int, bool>> exp1 = i => i > tuple1.Item1;
            Expression<Func<int, bool>> exp2 = i => i > tuple2.Item1;
            Assert.Equal(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_different_property_should_not_equal()
        {
            Tuple<int, int> tuple1 = new Tuple<int, int>(1, 1);
            Tuple<int, int> tuple2 = new Tuple<int, int>(2, 2);
            Expression<Func<int, bool>> exp1 = i => i > tuple1.Item1;
            Expression<Func<int, bool>> exp2 = i => i > tuple2.Item1;
            Assert.NotEqual(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_method_with_same_argument_should_equal()
        {
            string string1 = "1";
            string string2 = "1";
            Expression<Func<int, bool>> exp1 = i => i == int.Parse(string1);
            Expression<Func<int, bool>> exp2 = i => i == int.Parse(string2);
            Assert.Equal(exp1.GetKey(false), exp2.GetKey(false));
        }

        [Fact]
        public void same_expressions_using_method_with_different_argument_should_not_equal()
        {
            string string1 = "1";
            string string2 = "2";
            Expression<Func<int, bool>> exp1 = i => i == int.Parse(string1);
            Expression<Func<int, bool>> exp2 = i => i == int.Parse(string2);
            Assert.NotEqual(exp1.GetKey(false), exp2.GetKey(false));
        }
    }
}
