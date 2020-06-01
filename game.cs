using System;
using System.Collections.Generic;
public class Game
{
    private void PlayerMenu(int choice)
    {
        Console.WriteLine("Co chcesz zrobić?");
        switch (choice)
        {
            case 1:
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("1.Dobierz kartę");
                Console.ResetColor();
                Console.WriteLine("2. Pas");
                break;
            case 2:
                Console.WriteLine("1.Dobierz kartę");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("2. Pas");
                Console.ResetColor();
                break;
            default:
                break;
        }
    }
    private void PlayerRound(ref int menuOption)
    {
        PlayerMenu(menuOption);
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.UpArrow)
        {
            if (menuOption >= 2)
                menuOption -= 1;
        }
        else if (key == ConsoleKey.DownArrow)
        {
            if (menuOption <= 1)
                menuOption += 1;
        }
        else if (key == ConsoleKey.Enter)
        {
            Console.WriteLine("słicz");
        }
    }
    private void StartGame()
    {
        Cards deck = new Cards(); // Creating new deck
        Croupier croupier = new Croupier(); // initalizing croupier
        Player player = new Player(); //initializing player

        // Croupiter starting round
        croupier.TakeCards(deck.AllCards); // Croupier taking cards

        //Player round
        int option = 1;
        while (true)
        {
            Console.Clear();
            croupier.DrawHand();
            PlayerRound(ref option);
        }
    }
    public Game()
    {

        // player.TakeCard(cards.AllCards);
        // player.TakeCard(cards.AllCards);
        // player.TakeCard(cards.AllCards);

        // Console.WriteLine($"reka gracza: {player.Hand.Count}");
        // Console.WriteLine($"ilosc cart: {cards.AllCards.Count}");
        // Console.WriteLine($"punkty: {player.Points}");
        // player.DrawHand();

        StartGame();
        Console.ReadKey();
    }
}