using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Radzen;

namespace NestedDialogs.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var b = WebAssemblyHostBuilder.CreateDefault(args);
            b.RootComponents.Add<App>("app");

            b.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(b.HostEnvironment.BaseAddress) });

            // add Radzen services 
            b.Services.AddScoped<DialogService>();
            b.Services.AddScoped<NotificationService>();
            b.Services.AddScoped<TooltipService>();

            await b.Build().RunAsync();
        }
    }
}
