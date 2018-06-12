using System;
using System.Management.Automation;

namespace TesthostedPSJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ps = PowerShell.Create())
            {
                var results = ps.AddScript(@"Start-Job {Get-Date | Set-Content c:\temp\date.txt} | Receive-Job -Wait").Invoke();
                foreach (var error in ps.Streams.Error)
                {
                    System.Console.WriteLine($"Error: {error}");
                    System.Console.WriteLine($"Exception: {error.Exception}");
                    System.Console.WriteLine($"InnerException: {error.Exception.InnerException}");
                    System.Console.WriteLine($"InnerException: {error.Exception.InnerException.InnerException}");
                    System.Console.WriteLine("--------------------------------------------------------");
                }
                foreach (var result in results)
                {
                    System.Console.WriteLine($"Result: {result}");
                }
            }
        }
    }
}
