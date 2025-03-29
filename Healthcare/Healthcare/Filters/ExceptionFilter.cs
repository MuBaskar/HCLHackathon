using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using System;

namespace Healthcare.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
       

        public async void OnException(ExceptionContext context)
        {
            if (context.Exception is ArgumentException)
            {
                context.Result = new BadRequestObjectResult("Invalid argument");
            }
            else if (context.Exception is Exception)
            {
                var path = @"C:\hcv2\Healthcare\Healthcare\Logs\log.txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    string createText = DateTime.Now.ToString()+" :- " +context.Exception.Message + " : and   " + context.Exception.StackTrace;
                    File.WriteAllText(path, createText);
                }
                string appendText = DateTime.Now.ToString() + " :- " + context.Exception.Message + " : and   " + context.Exception.StackTrace;
                File.AppendAllText(path, appendText);
                string readText = File.ReadAllText(path);
                Console.WriteLine(readText);
                context.Result = new BadRequestObjectResult(context.Exception.Message + " : above excption occuerd in " + context.Exception.InnerException);
            }
        }
    }
}
