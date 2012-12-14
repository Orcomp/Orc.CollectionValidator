namespace Orc.CollectionValidator.Utilits
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;
using System.Reflection;

    internal static class ExpressionAnalizer
    {
        public static PropertyInfo GetProppertyInfo<T>(Expression<Func<T, object>> propertyExpression)
        {
            dynamic body;
            if (propertyExpression.Body is UnaryExpression)
            {
                dynamic unaryBody = propertyExpression.Body;
                body = unaryBody.Operand;
            }
            else
            {
                body = propertyExpression.Body;
            }

            return typeof(T).GetProperty(body.Member.Name);
        }
    }
}
