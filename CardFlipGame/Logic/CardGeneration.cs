using System.Security.Cryptography;
using Microsoft.AspNetCore.Components;
using CardFlipGame.DataType;

namespace CardFlipGame.Logic;

public class CardGeneration
{
    public CardGeneration()
    {
    randomCardNumbers = new List<Card>();
    NumberGenorator(8);
}

    public List<Card> randomCardNumbers { get; set; }
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
                Card newCard = new Card();
                newCard.value = cardNumbers.ElementAt(index);
                newCard.ID = index;
                newCard.state = false;
                newCard.enabled = true;
                randomCardNumbers.Add(newCard);
                cardNumbers.RemoveAt(index);
            }

            NotifyStateChanged();

    }
    
}