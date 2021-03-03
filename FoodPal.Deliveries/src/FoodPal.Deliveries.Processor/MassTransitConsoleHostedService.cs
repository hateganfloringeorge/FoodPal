using MassTransit;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Processor
{
    internal class MassTransitConsoleHostedService : IHostedService
    {
        private readonly IBusControl _busControl;

        public MassTransitConsoleHostedService(IBusControl busControl)
        {
            this._busControl = busControl;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await this._busControl.StartAsync(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await this._busControl.StopAsync(cancellationToken);
        }
    }
}