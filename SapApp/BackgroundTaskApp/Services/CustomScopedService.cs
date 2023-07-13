using Microsoft.Extensions.Logging;
using System;

namespace BackgroundTaskApp.Services
{
    public class CustomScopedService : IScopedService
    {
        private readonly ILogger<CustomScopedService> _logger;
        public Guid Id { get; set; }

        public CustomScopedService(ILogger<CustomScopedService> logger)
        {
            _logger = logger;
            Id = Guid.NewGuid(); 
        }

        public void Write()
        {
            _logger.LogInformation($"CustomScopedService {Id}");
        }
    }
}
