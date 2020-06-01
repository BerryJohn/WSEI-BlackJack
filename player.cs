using System;
using System.Collections.Generic;

public class Player
{
    public int Points = 0;
    public List<string> Hand = new List<string>();

    public int ReadPoints(string card) // function to reading card value
    {
        string[] cardTab = card.Split();
        return int.Parse(cardTab[2]); // returning card points  
    }

    public int CountPoints(List<string> Hand)
    {
        Hand.Sort((x, y) => (-1) * x.CompareTo(y));  // sorting hand to check how value must be ace
        int handPoints = 0;
        foreach (string card in Hand)
        {
            string cardName = card.Split()[0];
            if (cardName == "Ace" && handPoints + 11 <= 21)  // if hand value is under 21 Ace value is equal 11
                handPoints += 11;
            else
                handPoints += ReadPoints(card);
        }
        return handPoints;
    }
    public void TakeCard(List<string> deck)
    {
        Random random = new Random();
        int ran = random.Next(0, deck.Count - 1);
        string card = deck[ran];

        Hand.Add(card); // adding card to player hand
        deck.Remove(card); // removing from deck
        Points = CountPoints(Hand);
    }

    private string DrawCard(string suit, string figure)
    {
        string card =
        $"*****\n" +
        $"*  {suit}*\n" +
        $"* {figure} *\n" +
        $"*{suit}  *\n" +
        $"*****";
        return card;
    }
    public void DrawHand()
    {
        foreach (string card in Hand)
        {
            string[] cardInfo = card.Split();
            var Suits = Cards.Suit;
            // switch (int.Parse(cardInfo[1]))
            // {
            //     case int.Parse(Cards.Suit.Heart):
            //         cardInfo[1] = '♥';
            //         break;
            //     case Cards.Suit.Diamond:
            //         cardInfo[1] = '♦';
            //         break;
            //     case Cards.Suit.Spade:
            //         cardInfo[1] = '♠';
            //         break;
            //     case Cards.Suit.Club:
            //         cardInfo[1] = '♣';
            //         break;

            // }

            Console.WriteLine(
                DrawCard(
                    cardInfo[1], // Card suit 
                    cardInfo[2] // card face
                    )
                );
        }
    }


}