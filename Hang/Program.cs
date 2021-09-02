using Hang.ViewModels;
using Hang.ViewModels.Interface;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hang
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddTransient<IIndexViewModel, IndexViewModel>();
            builder.Services.AddTransient<IClockViewModel, ClockViewModel>();

            await builder.Build().RunAsync();
        }
    }
}
