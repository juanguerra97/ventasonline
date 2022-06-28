using ventasonline.Domain.Common;

namespace ventasonline.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
