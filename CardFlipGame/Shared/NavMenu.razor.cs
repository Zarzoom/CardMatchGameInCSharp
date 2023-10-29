using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Shared;

public class NavMenu_razor: ComponentBase
{
    protected bool collapseNavMenu = true;

    protected string? NavMenuCssClass => collapseNavMenu ? "collapse" : null;

    protected void ToggleNavMenu()
    {
        collapseNavMenu = !collapseNavMenu;
    }
}