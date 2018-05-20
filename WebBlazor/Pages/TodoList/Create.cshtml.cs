using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using WebBlazor.Models;
namespace WebBlazor.Pages.TodoList
{
    public class CreateModel : BlazorComponent
    {
        [Parameter]
        protected Todo Todo { get; set; }

        [Inject]
        public IServiceTodo Service { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        protected override Task OnInitAsync()
        {
            Todo = new Todo();            
            return base.OnInitAsync();
        }

        protected override void OnAfterRender()
        {
            InputFocus("#input-title");
        }

        protected async Task SaveAsync()
        {
            if (Todo != null && !string.IsNullOrEmpty(Todo?.Title))
            {
                await Service.AddAsync(Todo);
                Cancel();
            }
            else
            {
                ShowModal(".bd-example-modal-sm", "#input-title");
            }
        }

        protected async Task SaveKeyUpEnterAsync(UIKeyboardEventArgs e)
        {
            if (e.Key.ToLower() == "enter")
            {
                await SaveAsync();
            }
        }

        protected void Cancel()
        {
            UriHelper.NavigateTo("/admin/todo");
        }

        protected void ShowModal(string element, string position = "")
        {
            RegisteredFunction.Invoke<bool>("showModal", element, position);
        }

        protected void InputFocus(string element)
        {
            RegisteredFunction.Invoke<bool>("inputFocus", element);
        }
    }
}