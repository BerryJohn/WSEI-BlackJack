using System;
using System.Collections.Generic;
using System.Threading;

public class Croupier : Player
{
    private string DrawCard(string suit, string figure)
    {
        string card;
        if (figure != "10")
            card =
                $"*****\n" +
                $"*  {suit}*\n" +
                $"* {figure} *\n" +
                $"*{suit}  *\n" +
                $"*****\n" +
                $"*****\n" +
                $"*???*\n" +
                $"*???*\n" +
                $"*???*\n" +
                $"*****";
        else
            card =
                $"*****\n" +
                $"*  {suit}*\n" +
                $"* {figure}*\n" +
                $"*{suit}  *\n" +
                $"*****\n" +
                $"*****\n" +
                $"*???*\n" +
                $"*???*\n" +
                $"*???*\n" +
                $"*****";
        return card;
    }
    public void DrawCroupierHand()
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
                    )
                );
        }
    }


    public void TakeCards(List<string> deck)  // croupier has to stay at easy 15
    {
        while (Points < 15)
        {
            Console.Clear();
            TakeCard(deck);
            DrawHand();
            Console.WriteLine("Croupier is taking cards... its may take a while");
            Thread.Sleep(1000);
        }
    }
}