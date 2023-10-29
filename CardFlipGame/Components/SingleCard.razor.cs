using CardFlipGame.Logic;
using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Components;

public class Card_razor: ComponentBase
{
    [Inject] public FlipLogic flipLogic { get; set; }
    protected bool face = true;
    protected bool disabled;
    [Parameter] public int CardNumber { get; set; }
    public void flipCard()
    {
        flipLogic.OnChange += OnChangeHandler;
        var tempFace = face;
        face = !face;
        face = flipLogic.flipCard(tempFace, CardNumber);
            
    }
    
    private async void OnChangeHandler()
    {
        if (!face)
        {
            disabled = true;
        }
        await InvokeAsync(StateHasChanged);
        flipLogic.OnChange -= OnChangeHandler;
    }
    

}