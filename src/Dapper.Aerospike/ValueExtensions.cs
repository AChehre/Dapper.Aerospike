using System;
using System.Reflection;
using Expression = System.Linq.Expressions.Expression;

namespace Dapper.Aerospike
{
    public static class ValueExtensions
    {
        public static Func<object, object> GenerateGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(object));
            return Expression.Lambda<Func<object, object>>(propertyObjExpr, objParameterExpr).Compile();
        }
    }
}