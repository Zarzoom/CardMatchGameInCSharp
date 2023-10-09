using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Components;

public class Card_razor
{
    protected bool face = true;
    [Parameter]
    public int CardNumber { get; set; }

}