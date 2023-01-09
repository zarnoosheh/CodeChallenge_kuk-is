using System.Linq.Expressions;

namespace Infrastructure.Repositories;

public static class QueryableHelper
{
    public static IQueryable<T> WhereIf<T>(this IQueryable<T> query, Expression<Func<T, bool>> filterExpression, bool condition)
    {
        return condition
            ? query.Where(filterExpression)
            : query;
    }

    public static IQueryable<T> ToPaged<T>(this IQueryable<T> query, int page, int pageSize)
    {
        var skip = (page - 1) * pageSize;

        return query
            .Skip(skip)
            .Take(pageSize);
    }
}