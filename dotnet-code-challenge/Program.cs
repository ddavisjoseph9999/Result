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
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FeedData");
            showResult.Init(folderPath);    
            Console.Read();
        }
    }
}
