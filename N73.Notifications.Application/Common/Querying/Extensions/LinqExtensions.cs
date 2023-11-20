using N73.Notifications.Application.Common.Models.Quering;

namespace N73.Notifications.Application.Common.Querying.Extensions;

public static class LinqExtensions
{
    public static IQueryable<TSourse> ApplyPagination<TSourse>(this IQueryable<TSourse> sourse,
        FilterPagination filterPagination)
    {
        return sourse.Skip((int)((filterPagination.PageToken - 1) * filterPagination.PageSize))
            .Take((int)filterPagination.PageSize);
    }

    public static IEnumerable<TSourse> ApplyPagination<TSourse>(this IEnumerable<TSourse> sourse,
        FilterPagination filterPagination)
    {
        return sourse.Skip((int)((filterPagination.PageToken - 1) * filterPagination.PageSize))
            .Take((int)filterPagination.PageSize);
    }
}