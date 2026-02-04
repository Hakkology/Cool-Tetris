using Avalonia;
using System;
using Velopack;

namespace AvaloniaTetris;

sealed class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        // VelopackRunner should be the first thing in your Main()
        VelopackApp.Build()
            .Run();

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
