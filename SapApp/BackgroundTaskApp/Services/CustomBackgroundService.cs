using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTaskApp.Services
{
    public class CustomBackgroundService : BackgroundService
    {
        private readonly ILogger<CustomBackgroundService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public CustomBackgroundService(ILogger<CustomBackgroundService> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    _logger.LogInformation($"CustomBackgroundService.ExecuteAsync running {DateTime.Now}");
                    var scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();
                    scopedService.Write();
                    await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
                }
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CustomBackgroundService.StopAsync running {DateTime.Now}");
            return base.StopAsync(cancellationToken);
        }
    }
}
