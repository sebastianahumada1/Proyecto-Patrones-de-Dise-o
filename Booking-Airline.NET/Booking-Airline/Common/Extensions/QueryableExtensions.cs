using System.Linq.Expressions;

namespace Booking_Airline.Common.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<T> OptionalWhere<T, U>(
        this IQueryable<T> query, U? entity, Expression<Func<T, bool>> predicate)
    {
        return entity is not null ? query.Where(predicate) : query;
    }
}
