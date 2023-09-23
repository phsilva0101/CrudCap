using System.Linq.Expressions;

namespace CrudCap.CrossCutting.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> OrderByDynamic<T>(this IQueryable<T> q, string sortField, bool ascending)
        {
            try
            {
                var param = Expression.Parameter(typeof(T), "p");
                var prop = Expression.Property(param, sortField);
                var exp = Expression.Lambda(prop, param);
                var method = ascending ? "OrderBy" : "OrderByDescending";
                var types = new Type[] { q.ElementType, exp.Body.Type };
                var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);
                return q.Provider.CreateQuery<T>(mce);
            }
            catch
            {
                return q;
            }
        }
    }
}
