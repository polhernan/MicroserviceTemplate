﻿namespace MicroservicePHC.Domain.Common
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public int ExpirationMinutes { get; set; }
    }
}
