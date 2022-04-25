using System;
using System.Linq.Expressions;
using System.Reflection;

namespace DAL
{
    internal class Helper
    {
        internal static Expression<Func<T, bool>> GetExpression<T>(string propertyName, object value)
        {
            var pe = Expression.Parameter(typeof(T), typeof(T).Name);
            Expression eLastName = Expression.Property(pe, propertyName);
            //Expression cId = Expression.Constant(value);
            Expression cId = Expression.Convert(Expression.Constant(value), eLastName.Type);
            Expression e1 = Expression.Equal(eLastName, cId);
            var exp = Expression.Lambda<Func<T, bool>>(e1, pe);
            return exp;
        }

        internal static Expression<Func<T, bool>> GetCallExpression<T>(string propertyName, string value, MethodInfo method)
        {
            var pe = Expression.Parameter(typeof(T), typeof(T).Name);
            Expression eLastName = Expression.Property(pe, propertyName);
            //Expression cId = Expression.Constant(value);
            Expression cId = Expression.Convert(Expression.Constant(value), eLastName.Type);

            Expression e1 = Expression.Call(eLastName,method, cId);
            var exp = Expression.Lambda<Func<T, bool>>(e1, pe);
            return exp;



            

        }
    }
}