using Aquaculture.Application.Common;

namespace Aquaculture.Infrastructure;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
