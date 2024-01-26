using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Obilet.Core.Interfaces;

namespace Obilet.Core.Services.CronJobs;

public class BusLocationsCron(IServiceProvider serviceProvider) : IHostedService, IDisposable
{
    private Timer _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromDays(7)); // Her 7 günde çalıştır

        return Task.CompletedTask;
    }

    private void DoWork(object state)
    {
        Console.WriteLine("Cron job is running at: " + DateTime.Now);

        // using (var scope = serviceProvider.CreateScope())
        // {
        //     var busLocationService = scope.ServiceProvider.GetRequiredService<IBusLocationService>();
        //     busLocationService.UpdateBusLocationOnRedisAsync().GetAwaiter().GetResult();
        // }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);

        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}