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
    public static Task GenerateAllureReport()
    {
        var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
        var projectRoot = Directory.GetParent(AppContext.BaseDirectory)?.Parent?.Parent?.Parent?.FullName;
        var allureCommand = isWindows ? "allure.exe" : "allure";
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