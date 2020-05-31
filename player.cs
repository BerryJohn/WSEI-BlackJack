using System;
using System.Collections.Generic;

public class Player
{
    public int Points = 0;
    public Stack<string> Hand = new Stack<string>();

    public int ReadPoints(string card) // function to reading card value
    {
        string[] cardTab = card.Split();
        return int.Parse(cardTab[2]); // returning card points  
    }

    public int CountPoints(Stack<string> Hand)
    {
        int handPoints = 0;
        foreach (string card in Hand)
        {
            string cardName = card.Split()[0];
            if (cardName == "Ace" && handPoints + 11 <= 21)
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

        Hand.Push(card); // adding card to player hand
        deck.Remove(card); // removing from deck
        Points = CountPoints(Hand);
    }

    public void DrawHand()
    {
        Console.WriteLine($"Ręka gracza: {Hand.Count}");
        Console.WriteLine("_________________");

        foreach (var el in Hand)
            Console.WriteLine(el);
    }


}