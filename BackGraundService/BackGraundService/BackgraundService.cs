namespace BackGraundService.BackGraundService;

public class BackgraundService : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        Console.WriteLine("BackgraundService");
        return Task.CompletedTask;
    }
}