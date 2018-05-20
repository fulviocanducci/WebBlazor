using Microsoft.AspNetCore.Blazor.Browser.Rendering;
using Microsoft.AspNetCore.Blazor.Browser.Services;
using Microsoft.Extensions.DependencyInjection;
using WebBlazor.Models;

namespace WebBlazor
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new BrowserServiceProvider(services =>
            {
                services.AddScoped<IServiceTodo, ServiceTodo>();
            });

            new BrowserRenderer(serviceProvider).AddComponent<App>("app");
        }
    }
}
