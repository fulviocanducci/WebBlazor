using System.Net.Http;
using System.Threading.Tasks;

namespace WebBlazor.Models
{
    public interface IService<T>
    {
        HttpClient Client { get; }

        Task AddAsync(T value);
        Task EditAsync(T value);
        Task<T[]> ListAsync();
        Task<Todo> GetAsync(int? id);
    }
}
