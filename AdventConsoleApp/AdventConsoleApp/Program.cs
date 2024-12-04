using System.Diagnostics;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;

class Program
{
    static void Main()
    {
        string folder = System.AppDomain.CurrentDomain.BaseDirectory;

        var configuration = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json");
        var config = configuration.Build();

        int day = DateTime.Now.Day;
        try
        {
            day = int.Parse(config.GetRequiredSection("SelectedDay").Value ?? String.Empty);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        string filePath = $"{folder}/Inputs/input{day:00}.txt";
        var data = File.ReadAllText(filePath);
        Console.WriteLine(data);
    }
}