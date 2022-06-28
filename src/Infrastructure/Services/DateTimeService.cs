using ventasonline.Application.Common.Interfaces;

namespace ventasonline.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
