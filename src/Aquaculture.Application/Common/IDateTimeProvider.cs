﻿namespace Aquaculture.Application.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
