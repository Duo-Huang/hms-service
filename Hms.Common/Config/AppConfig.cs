namespace Hms.Common.Config;

public sealed class AppConfig
{
    public required string JwtIssuer { get; set; }

    public required string JwtSecret { get; set; }

    public long JwtTokenExpiredTime { get; set; }

    public int SseHeartbeatIntervalOfSec { get; set; }
}