using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;

namespace CardFlipGame.Logic;

public class CardGeneration
{
    public CardGeneration()
    {
    randomCardNumbers = new List<int>();
    NumberGenorator(8);
}

    public List<int> randomCardNumbers { get; set; }
    public event Action OnChange;
    private void NotifyStateChanged() => OnChange?.Invoke();
    public void NumberGenorator(int numOfCards)
    {
        randomCardNumbers = new();
        var cardNumbers = new List<int>();
        

        var randomNum = new Random();
            for (int i = 0; i < numOfCards; i += 2)
            {
                int numForCard = randomNum.Next(0, 99);
                cardNumbers.Add(numForCard);
                cardNumbers.Add(numForCard);
            }

            while (cardNumbers.Count() >= 1)
            {
                int index = randomNum.Next(0, cardNumbers.Count());
                randomCardNumbers.Add(cardNumbers.ElementAt(index));
                cardNumbers.RemoveAt(index);
            }

            NotifyStateChanged();

    }
    
}