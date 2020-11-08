using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace StarWars.Common.Extensions
{
    public static class ExpressionExtensions
    {
        public static string? GetExpressionPath<T>(this Expression<Func<T, object>> expression)
        {
            List<Expression>? arguments = (expression.Body as MethodCallExpression)
                   ?.Arguments
                   ?.ToList();

            if (arguments != null)
            {
                string path = string.Join(".", arguments.Select(x =>
                {
                    if (x is MemberExpression memberExpression)
                        return memberExpression.Member.Name;
                    else if (x is LambdaExpression lambdaExpression)
                        return (lambdaExpression.Body as MemberExpression)?.Member?.Name;
                    return string.Empty;
                }));

                return path;
            }

            return null;
        }

        public static Expression<Func<T, bool>> ShouldEqual<T>(this Expression<Func<T, int>> keyExpression, int id)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));

            Expression<Func<T, bool>> lambda = Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(
                            Expression.Property(parameter, keyExpression.Body.ToString().Substring(2)),
                            Expression.Constant(id, typeof(int))
                        ),
                        parameter
                    );

            return lambda;
        }
    }
}