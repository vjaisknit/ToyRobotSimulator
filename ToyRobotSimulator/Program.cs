using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobotSimulator.src.Interfaces;
using ToyRobotSimulator.src.Models;
using ToyRobotSimulator.src.Services;

var builder = Host.CreateDefaultBuilder(args);

// Register services in the dependency injection container
builder.ConfigureServices((hostContext, services) =>
{
    // Register your service implementations here
    services.AddSingleton<IRobotService, RobotService>();
});

var app = builder.Build();

// Accessing IHostApplicationLifetime for controlling app lifecycle
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();

lifetime.ApplicationStarted.Register(() =>
{
    var robotService = app.Services.GetRequiredService<IRobotService>();

    Console.WriteLine("=== Toy Robot Simulator ===");
    Console.WriteLine("Commands:");
    Console.WriteLine("PLACE X,Y,DIRECTION (e.g. PLACE 0,0,NORTH)");
    Console.WriteLine("MOVE");
    Console.WriteLine("LEFT");
    Console.WriteLine("RIGHT");
    Console.WriteLine("REPORT");
    Console.WriteLine("Type EXIT to quit.\n");

    while (true)
    {
        Console.Write("Enter command: ");
        var input = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(input))
            continue;

        if (input.Equals("EXIT", StringComparison.OrdinalIgnoreCase))
            break;

        try
        {
            if (input.StartsWith("PLACE", StringComparison.OrdinalIgnoreCase))
            {
                var argsPart = input.Substring(5).Trim();
                var tokens = argsPart.Split(',', StringSplitOptions.TrimEntries);

                if (tokens.Length == 3 &&
                    int.TryParse(tokens[0], out int x) &&
                    int.TryParse(tokens[1], out int y) &&
                    Enum.TryParse(typeof(Direction), tokens[2], true, out var directionObj))
                {
                    var direction = (Direction)directionObj;
                    robotService.Place(x, y, direction);
                }
                else
                {
                    Console.WriteLine("Invalid PLACE command format. Use: PLACE X,Y,DIRECTION");
                }
            }
            else if (input.Equals("MOVE", StringComparison.OrdinalIgnoreCase))
            {
                robotService.Move();
            }
            else if (input.Equals("LEFT", StringComparison.OrdinalIgnoreCase))
            {
                robotService.Left();
            }
            else if (input.Equals("RIGHT", StringComparison.OrdinalIgnoreCase))
            {
                robotService.Right();
            }
            else if (input.Equals("REPORT", StringComparison.OrdinalIgnoreCase))
            {
                var result = robotService.Report();
                if (!string.IsNullOrWhiteSpace(result))
                    Console.WriteLine($"Output: {result}");
            }
            else
            {
                Console.WriteLine("Invalid command.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    Environment.Exit(0); // gracefully shut down
});

app.Run(); // Run the application
