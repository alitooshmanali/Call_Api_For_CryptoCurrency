﻿
namespace Infrastructure.Services
{
    public class SystemDateTime : ISystemDateTime
    {
        public DateTimeOffset UtcNow => DateTimeOffset.UtcNow;
    }
}
