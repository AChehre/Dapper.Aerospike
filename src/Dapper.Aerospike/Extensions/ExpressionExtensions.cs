using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Dapper.Aerospike
{
    public static class ExpressionExtensions
    {
        public static Func<object, object> GenerateGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(object));
            return Expression.Lambda<Func<object, object>>(propertyObjExpr, objParameterExpr).Compile();
        }
        public static Func<object, Guid> GenerateGuidGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(Guid));
            return Expression.Lambda<Func<object, Guid>>(propertyObjExpr, objParameterExpr).Compile();
        }
        public static Func<object, Guid?> GenerateNullableGuidGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(Guid?));
            return Expression.Lambda<Func<object, Guid?>>(propertyObjExpr, objParameterExpr).Compile();
        }
        public static Func<object, decimal> GenerateDecimalGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(decimal));
            return Expression.Lambda<Func<object, decimal>>(propertyObjExpr, objParameterExpr).Compile();
        }

        public static Func<object, decimal?> GenerateNullableDecimalGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(decimal?));
            return Expression.Lambda<Func<object, decimal?>>(propertyObjExpr, objParameterExpr).Compile();
        }

        public static Func<object, DateTime> GenerateDateTimeGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(DateTime));
            return Expression.Lambda<Func<object, DateTime>>(propertyObjExpr, objParameterExpr).Compile();
        }

        public static Func<object, DateTime?> GenerateNullableDateTimeGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(DateTime?));
            return Expression.Lambda<Func<object, DateTime?>>(propertyObjExpr, objParameterExpr).Compile();
        }



        public static Func<object, DateTimeOffset> GenerateDateTimeOffsetGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(DateTimeOffset));
            return Expression.Lambda<Func<object, DateTimeOffset>>(propertyObjExpr, objParameterExpr).Compile();
        }

        public static Func<object, DateTimeOffset?> GenerateNullableDateTimeOffsetGetterLambda(this PropertyInfo property)
        {
            var objParameterExpr = Expression.Parameter(typeof(object), "instance");
            var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            var propertyExpr = Expression.Property(instanceExpr, property);
            var propertyObjExpr = Expression.Convert(propertyExpr, typeof(DateTimeOffset?));
            return Expression.Lambda<Func<object, DateTimeOffset?>>(propertyObjExpr, objParameterExpr).Compile();
        }


        public static PropertyInfo GetPropertyInfo<TEntity, TReturn>(this Expression<Func<TEntity, TReturn>> property)
        {
            var expr = (MemberExpression) property.Body;
            var propertyInfo = (PropertyInfo) expr.Member;
            return propertyInfo;
        }

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