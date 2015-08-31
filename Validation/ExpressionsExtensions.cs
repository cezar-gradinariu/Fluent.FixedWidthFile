using System;
using System.Linq.Expressions;

namespace Validation
{
    public static class ExpressionsExtensions
    {
        public static string PropertyName<T, TU>(this Expression<Func<T, TU>> e)
        {
            var member = (MemberExpression) e.Body;
            return member.Member.Name;
        }

        public static TU PropertyValue<T, TU>(this Expression<Func<T, TU>> e, T argument)
        {
            return e.Compile()(argument);
        }
    }
}