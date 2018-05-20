using System.Threading.Tasks;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;
using WebBlazor.Models;

namespace WebBlazor.Pages.TodoList
{
    public class EditModel : BlazorComponent
    {
        [Parameter]
        protected int? Id { get; set; }

        [Parameter]
        protected Todo Todo { get; set; }

        [Inject]
        public IServiceTodo Service { get; set; }

        [Inject]
        IUriHelper UriHelper { get; set; }

        protected override async Task OnInitAsync()
        {
            await InitTodoAsync();
        }

        protected override void OnAfterRender()
        {
            InputFocus("#input-title");
        }

        private async Task InitTodoAsync()
        {
            Todo = await Service.GetAsync(Id);
            StateHasChanged();
        }

        protected async Task SaveAsync()
        {
            if (Todo != null && !string.IsNullOrEmpty(Todo?.Title))
            {
                await Service.EditAsync(Todo);
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