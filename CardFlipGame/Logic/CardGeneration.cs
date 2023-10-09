using System.Security.Cryptography;

namespace CardFlipGame.Logic;

public class CardGeneration
{
    public List<int> NumberGenorator(int numOfCards)
    {
        var cardNumbers = new List<int>();
        var randomCardNumbers = new List<int>();

        var randomNum = new Random();
            for (int i = numOfCards; i < numOfCards; i += 2)
            {
                int numForCard = randomNum.Next(0, 99);
                cardNumbers.Add(numForCard);
                cardNumbers.Add(numForCard);
            }

            while (cardNumbers.Count() >= 1)
            {
                int index = randomNum.Next(1, numOfCards);
                randomCardNumbers.Add(cardNumbers.ElementAt(index));
                cardNumbers.RemoveAt(index);
            }
        
    }
    
}