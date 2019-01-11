using dotnet_code_challenge.Concrete;
using dotnet_code_challenge.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace dotnet_code_challenge
{
    class Program
    {
    
        static void Main(string[] args)
        {
           var serviceProvider = new ServiceCollection()             
             .AddSingleton<IFileHandler, FileHandler>()
             .AddSingleton<IOrderedResult, OrderedResult>()
             .BuildServiceProvider();
            ShowResult showResult = new ShowResult(serviceProvider);
            string folderPath=null;
            try
            {
                folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FeedData");
                var fileList = Directory.GetFiles(@folderPath);
                if (fileList.Length == 0)
                    Console.WriteLine($"ERROR: Location {@folderPath} does not contain data files");
                showResult.Init(fileList);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"ERROR: Location {@folderPath} cannot be accessed: {ex.Message}");
            }               
            Console.Read();
        }
    }
}
