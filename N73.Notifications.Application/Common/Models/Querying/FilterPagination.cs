namespace N73.Notifications.Application.Common.Models.Quering;

public class FilterPagination
{
    public uint PageSize { get; set; } = 10;

    public uint PageToken { get; set; } = 1;
}