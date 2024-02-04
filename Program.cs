using Businnes;
using Interface.Businnes;
using Microsoft.Extensions.DependencyInjection;


class Program
{
    public static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddSingleton<ICodeGeneratorBS, CodeGeneratorBS>();
        services.AddSingleton<ICodeValidatorBS, CodeValidatorBS>();

        var serviceProvider = services.BuildServiceProvider();

        var consoleManager = new ConsoleManager(
            serviceProvider.GetRequiredService<ICodeGeneratorBS>(),
            serviceProvider.GetRequiredService<ICodeValidatorBS>()
        );

        try
        {
            consoleManager.Start();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
