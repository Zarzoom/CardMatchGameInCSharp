using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using CardFlipGame.Logic;
using Microsoft.AspNetCore.Components;
namespace CardFlipGame.Components;

public class CardDisplay_razor: ComponentBase
{
    
    [Inject] public CardGeneration CardGen { get; set; }
    protected List<int> numbers = new();
    protected override void OnInitialized()
    {
        CardGen.OnChange += OnChangeHandler;
    }

    public void Dispose()
    {
        CardGen.OnChange -= OnChangeHandler;
    }

    private async void OnChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
    }
}