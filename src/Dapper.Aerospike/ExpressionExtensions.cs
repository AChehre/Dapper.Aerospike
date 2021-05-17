using System;
using System.Linq.Expressions;

namespace Dapper.Aerospike
{
    public static class ExpressionExtensions
    {
        public static string GetPropertyName<TEntity, TReturn>(this Expression<Func<TEntity, TReturn>> property)
        {
            var expr = property.Body as MemberExpression;
            if (expr == null)
            {
                throw new InvalidOperationException("Invalid property type");
            }

            return expr.Member.Name;
        }


        public static string GetPropertyName<TEntity>(this Expression<Func<TEntity, object>> property)
        {
            if (property.Body is UnaryExpression unary)
            {
                return (unary.Operand as MemberExpression)?.Member.Name;
            }

            return (property.Body as MemberExpression)?.Member.Name;
        }
    }
}