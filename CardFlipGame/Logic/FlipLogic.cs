using CardFlipGame.DataType;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
namespace CardFlipGame.Logic;

public class FlipLogic
{
    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    [Parameter] public bool disabled { get; set; }
    protected int numFlipped = 0;
    private List<Card> flippedCards = new List<Card>();
    public bool flipCard(Card cardForFlip)
    {
    Console.WriteLine(numFlipped);

        if (!cardForFlip.state && flippedCards.Count < 1)
        {
            flippedCards.Add(cardForFlip);
            cardForFlip.state = true;
            return cardForFlip.state;
        }

        if (!cardForFlip.state && flippedCards.Count == 1)
        {
            flippedCards.Add(cardForFlip);
            if (flippedCards[0].value == flippedCards[1].value)
            {
                flippedCards[0].enabled = false;
                flippedCards[1].enabled = false;
                NotifyStateChanged();
                flippedCards.Clear();
                
                return cardForFlip.state;
            }
            else
            {
              
                cardForFlip.state = true;
                return cardForFlip.state;
            }
        }
        else if (!cardForFlip.state && flippedCards.Count >= 2)
        {
                cardForFlip.state = false;
                return cardForFlip.state;
        }
        else
        {
            flippedCards.Remove(cardForFlip);
            cardForFlip.state = false;
            return cardForFlip.state;
        }
       
    }
}