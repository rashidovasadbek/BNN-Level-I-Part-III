namespace BackGraundService.BackGraundService;

public class BackGroundHostedService : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("Start backgraundService");
        return Task.CompletedTask;  
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
       Console.WriteLine("End backgraundService");
       return Task.CompletedTask;
    }
}