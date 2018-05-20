using Microsoft.AspNetCore.Blazor;
using System.Net.Http;
using System.Threading.Tasks;
using static WebBlazor.Models.UrlApi;
namespace WebBlazor.Models
{
    public class ServiceTodo : IServiceTodo
    {        
        public HttpClient Client { get; }

        public ServiceTodo(HttpClient client)
        {
            Client = client;
        }

        public async Task<Todo[]> ListAsync()
        {
            return await Client.GetJsonAsync<Todo[]>(Url("todos"));
        }
        
        public async Task AddAsync(Todo value)
        {
            await Client.SendJsonAsync(HttpMethod.Post, Url("todos"), value);
        }

        public async Task EditAsync(Todo value)
        {
            await Client.SendJsonAsync(HttpMethod.Put, Url($"todos/{value.Id}"), value);
        }

        public async Task<Todo> GetAsync(int? id)
        {
            if (id.HasValue)
            {
                return await Client.GetJsonAsync<Todo>(Url($"todos/{id.Value}"));
            }
            return null;
        }
    }
}
