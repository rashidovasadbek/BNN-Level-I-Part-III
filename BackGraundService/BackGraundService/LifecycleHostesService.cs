namespace BackGraundService.BackGraundService;

public class LifecycleHostesService : IHostedLifecycleService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle Service Start");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle Service Stop");
        return Task.CompletedTask;
    }

    public Task StartedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle Service Started");
        return Task.CompletedTask;
    }

    public Task StoppedAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle Service Stopped");
        return Task.CompletedTask;
    }
    
    public Task StartingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle Service Starting");
        return Task.CompletedTask;
    }

    public Task StoppingAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Lifecycle Service Stopping");
        return Task.CompletedTask;
    }

}