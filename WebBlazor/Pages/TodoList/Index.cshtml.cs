using Microsoft.AspNetCore.Blazor.Components;
using System.Threading.Tasks;
using WebBlazor.Models;

namespace WebBlazor.Pages.TodoList
{
    public class IndexModel: BlazorComponent
    {
        [Inject]
        public IServiceTodo Service { get; set; }        

        public Todo[] Todos { get; set; }

        protected override async Task OnInitAsync()
        {
            await InitListAsync();
        }

        private async Task InitListAsync()
        {
            Todos = await Service.ListAsync();
            StateHasChanged();
        }
    }
}