using System;
using System.Collections.Generic;


public class Player
{
    // 1 -> Heart
    // 2 -> Diamond
    // 3 -> Spade
    // 4 -> Clubs
    public enum Suit
    {
        Heart = 1,
        Diamond,
        Spade,
        Club
    }
    public int Points = 0;
    public List<string> Hand = new List<string>();

    public int ReadPoints(string card) // function to reading card value
    {
        string[] cardTab = card.Split();
        return int.Parse(cardTab[2]); // returning card points  
    }

    public int CountPoints(List<string> Hand) // counting points from player hands
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

    public void WriteHandPoints() // Summary points
    {
        int i = 1;
        Console.WriteLine("----------------------");
        foreach (string card in Hand)
        {
            Console.WriteLine($"{i++} -> {card}");
        }
        Console.WriteLine($"Points: { CountPoints(Hand) }");
        Console.WriteLine("----------------------");
    }
    public void TakeCard(List<string> deck) // taking card from deck
    {
        if (Points < 21)
        {
            Random random = new Random();
            int ran = random.Next(0, deck.Count - 1);
            string card = deck[ran];

            Hand.Add(card); // adding card to player hand
            deck.Remove(card); // removing from deck
            Points = CountPoints(Hand);
        }
    }

    private string DrawCard(string suit, string figure)  // function to drawing cards
    {
        string card;
        if (figure != "10")
            card =
                $"*****\n" +
                $"*  {suit}*\n" +
                $"* {figure} *\n" +
                $"*{suit}  *\n" +
                $"*****";
        else
            card =
                $"*****\n" +
                $"*  {suit}*\n" +
                $"* {figure}*\n" +
                $"*{suit}  *\n" +
                $"*****";
        return card;
    }
    public void DrawHand()
    {
        foreach (string card in Hand)
        {
            string[] cardInfo = card.Split();
            switch (int.Parse(cardInfo[1]))
            {
                case (int)Suit.Heart:
                    cardInfo[1] = "H";
                    break;
                case (int)Suit.Diamond:
                    cardInfo[1] = "D";
                    break;
                case (int)Suit.Spade:
                    cardInfo[1] = "S";
                    break;
                case (int)Suit.Club:
                    cardInfo[1] = "C";
                    break;
            }
            Console.WriteLine(
                DrawCard(
                    cardInfo[1], // Card suit 
                    cardInfo[2] // card face
                    ));
        }
    }
}