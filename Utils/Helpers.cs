using System.Diagnostics;
using System.Runtime.InteropServices;

namespace PlaywrightTests.Utils;

public class Helpers
{
    public static int SequenceToIndexNumber(string sequence)
    {
        string[] possibleStrings = ["first", "second", "third", "fourth", "fifth", "sixth", "seventh", "eighth", "ninth", "tenth"];
        return Array.IndexOf(possibleStrings, sequence);
    }
    private static bool IsAllureInstalled(string allureCommand)
    {
        try
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = allureCommand,
                    Arguments = "--version",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };
            process.Start();
            process.WaitForExit();
            var error = process.StandardError.ReadToEnd();
            return process.ExitCode == 0 && string.IsNullOrEmpty(error);
        }
        catch
        {
            return false;
        }
    }
    public static Task GenerateAllureReport()
    {
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var allureCommand = isWindows ? "allure.exe" : "allure";
        var projectRoot = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        if (!IsAllureInstalled(allureCommand))
        {
            Console.WriteLine("Allure is not installed. Please install Allure CLI to generate the report.");
            return Task.CompletedTask;
        }
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = allureCommand,
                Arguments = $"generate {AppContext.BaseDirectory}allure-results --output {projectRoot}/allure-report --clean --single-file",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        process.WaitForExit();
        var output = process.StandardOutput.ReadToEnd();
        var error = process.StandardError.ReadToEnd();
        Console.WriteLine(output);
        if (!string.IsNullOrEmpty(error))
        {
            Console.WriteLine(error);
        }
        return Task.CompletedTask;
    }
}