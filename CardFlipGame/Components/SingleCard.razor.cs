using CardFlipGame.DataType;
using CardFlipGame.Logic;
using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Components;

public class Card_razor: ComponentBase
{
    [Inject] public FlipLogic flipLogic { get; set; }
   
    [Parameter] public Card CardValue { get; set; }
    public void flipCard()
    {
        if (!CardValue.enabled)
        {
            return;
        }
        flipLogic.OnChange += OnChangeHandler;
        flipLogic.flipCard(CardValue);

    }
    
    private async void OnChangeHandler()
    {
        await InvokeAsync(StateHasChanged);
        flipLogic.OnChange -= OnChangeHandler;
    }
    

}