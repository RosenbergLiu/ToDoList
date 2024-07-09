using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace ToDoList.Presentation.Services
{

    public class DialogService
    {
        private readonly IJSRuntime _jsRuntime;

        public DialogService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task ShowAsync(string modalId)
        {
            await _jsRuntime.InvokeVoidAsync("dialogService.show", modalId);
        }

        public async Task HideAsync(string modalId)
        {
            await _jsRuntime.InvokeVoidAsync("dialogService.hide", modalId);
        }

        public async Task ToggleAsync(string modalId)
        {
            await _jsRuntime.InvokeVoidAsync("dialogService.toggle", modalId);
        }
    }
}
