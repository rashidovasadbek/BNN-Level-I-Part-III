namespace Cashing.Infra.Infrastructure.Common.Settings;

public class CacheSettings
{
    public int AbsoluteExpirationInMinutes { get; set; }
    
    public int SlidingExpirationInMinutes { get; set; }
}