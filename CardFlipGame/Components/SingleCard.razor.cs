using CardFlipGame.DataType;
using CardFlipGame.Logic;
using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Components;

public class Card_razor: ComponentBase
{
    [Inject] public FlipLogic flipLogic { get; set; }
    protected bool CardState = false;
    protected Card card;
    protected bool disabled;
    [Parameter] public Card CardValue { get; set; }
    public void flipCard()
    {
        flipLogic.OnChange += OnChangeHandler;
        var tempFace = CardState;
        CardState = !CardState;
        CardState = flipLogic.flipCard(CardValue);

    }
    
    private async void OnChangeHandler()
    {
        if (!card.enabled)
        {
            disabled = true;
        }
        await InvokeAsync(StateHasChanged);
        flipLogic.OnChange -= OnChangeHandler;
    }
    

}