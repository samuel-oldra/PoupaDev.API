using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Persistence;

namespace PoupaDev.API.Jobs
{
    public class RendimentoAutomaticoJob : IHostedService
    {
        private Timer _timer;
        public IServiceProvider ServiceProvider { get; set; }
        public RendimentoAutomaticoJob(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(RenderSaldo, null, 0, 10000);

            return Task.CompletedTask;
        }

        public void RenderSaldo(object? state) {
            using (var scope = ServiceProvider.CreateScope()) {
                var context = scope.ServiceProvider.GetRequiredService<PoupaDevDbContext>();

                var objetivos = context
                    .Objetivos
                    .Include(o => o.Operacoes)
                    .ToList();

                foreach (var objetivo in objetivos) {
                    objetivo.Render();
                }

                context.SaveChanges();
            }
        } 
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}