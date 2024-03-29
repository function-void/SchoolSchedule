﻿using SchoolSchedule.Domain.Common;

namespace SchoolSchedule.Domain.SeedWork;

public interface IDomainEvent
{
    Guid EventId { get; }
    Guid AggregateId { get; }
    DateTime CreatedAt { get; }
    AggregateType AggregateType { get; }
}