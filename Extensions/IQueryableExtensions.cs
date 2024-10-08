using System.Linq.Expressions;

namespace ElektroJohnAPI.Extensions;

public static class IQueryableExtensions
{
    public static IQueryable<T> WhereIfNotNull<T>(this IQueryable<T> query, object? value, Expression<Func<T, bool>> predicate)
    {
        if (value is null)
            return query;
        
        return query.Where(predicate);
    }
}