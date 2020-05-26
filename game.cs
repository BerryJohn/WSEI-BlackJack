using System;
using System.Collections.Generic;
public class Game
{
    private int ReadPoints(string card)
    {
        string[] cardTab = card.Split();
        return cardTab[2]; // returning card points
    }
    private string RandomCard(List<string> cards)
    {
        Random random = new Random();
        int ran = random.Next(0, cards.Count - 1);
        return cards[ran];  // returning randomized card
    }
    private void Croupier(List<string> cards)
    {
        Stack<string> croupierHand = new Stack<string>();
        int points = 0;
        var card = RandomCard(cards);
        cards.Remove(card); // deleting card from deck
        croupierHand.Push(card); // adding card to player hand 
        ReadPoints(card);
        card = RandomCard(cards); // rand second card
        cards.Remove(card); // deleting card from deck
        croupierHand.Push(card); // adding card second to player hand 

        // Console.WriteLine($"Ręka Krupiera: {croupierHand.Count}");
        // Console.WriteLine("_________________");

        // foreach (var el in croupierHand)
        //     Console.WriteLine(el);
    }
    private void Player(List<string> cards)
    {
        Stack<string> playerHand = new Stack<string>();

        var card = RandomCard(cards);
        cards.Remove(card); // deleting card from deck
        playerHand.Push(card); // adding card to player hand 

        card = RandomCard(cards); // rand second card
        cards.Remove(card); // deleting card from deck
        playerHand.Push(card); // adding card second to player hand 

        Console.WriteLine($"Ręka gracza: {playerHand.Count}");
        Console.WriteLine("_________________");

        foreach (var el in playerHand)
            Console.WriteLine(el);
    }
    public void StartGame()
    {
        //initalizing all cards deck
        Cards cards = new Cards();
        //initlaziling player deck hand
        Croupier(cards.AllCards);
        // Player(cards.AllCards);
        Console.ReadKey();
    }
    public Game()
    {
        StartGame();
    }
}