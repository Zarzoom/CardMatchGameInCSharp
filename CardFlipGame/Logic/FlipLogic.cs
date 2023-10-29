using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Logic;

public class FlipLogic
{
    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    [Parameter] public bool disabled { get; set; }
    protected int numFlipped = 0;
    private List<int> Compare = new List<int>();
    public bool flipCard(bool face, int value )
    {
    Console.WriteLine(numFlipped);

        if (face && numFlipped < 1)
        {
            Compare.Add(value);
            face = false;
            numFlipped++;
            return face;
        }

        if (face && numFlipped == 1)
        {
            Compare.Add(value);
            if (Compare[0] == Compare[1])
            {
                NotifyStateChanged();
                Compare.Clear();
                numFlipped = 0;
                return face;
            }
            else
            {
              
                face = false;
                numFlipped++;
                return face;
            }
        }
        else if (face && numFlipped >= 2)
        {
                face = true;
                return face;
        }
        else
        {
            Compare.RemoveAt(Compare.IndexOf(value));
            face = true;
            numFlipped--;
            return face;
        }
       
    }
}