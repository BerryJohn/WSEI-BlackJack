using System;
using System.Collections.Generic;
using System.Threading;
public class Game
{
    private void PlayerMenu(int choice)
    {
        Console.WriteLine("What u wanna do?");
        switch (choice)
        {
            case 1:
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("1.Take card");
                Console.ResetColor();
                Console.WriteLine("2. Pass");
                break;
            case 2:
                Console.WriteLine("1.Take card");
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("2. Pass");
                Console.ResetColor();
                break;
            default:
                break;
        }
    }

    private bool CheckBJ(Player player)
    {
        if (player.Hand.Count == 2 && player.Points == 21)
            return true;
        return false;
    }
    private bool CheckBJ(Croupier croupier) // overload
    {
        if (croupier.Hand.Count == 2 && croupier.Points == 21)
            return true;
        return false;
    }
    private void PlayerRound(ref int menuOption, Player player, List<string> deck, ref bool guard)
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
            if (menuOption == 1)
            {
                if (player.Hand.Count == 2 && CheckBJ(player))
                    guard = false;
                player.TakeCard(deck);
            }
            else if (menuOption == 2)
                guard = false;

        }
    }

    private int CheckWinner(Croupier croupier, Player player)
    {
        // return 2 -> Draw
        // return 1 -> Player Wins
        // return 0 -> Croupier wins

        int CrPnt = croupier.Points; // Croupiter Points
        int PlPnt = player.Points; // Player Points

        if (PlPnt > 21 && CrPnt > 21)
            return 2;
        else if (PlPnt > 21 && CrPnt <= 21) // croupier wins
            return 0;
        else if (PlPnt <= 21 && CrPnt > 21) // player wins
            return 1;
        else if (PlPnt == CrPnt) // draw
            return 2;
        else if (PlPnt > CrPnt) // Player wins
            return 1;
        else    // Croupier wins
            return 0;
    }
    private void StartGame()
    {
        Cards deck = new Cards(); // Creating new deck
        Croupier croupier = new Croupier(); // initalizing croupier
        Player player = new Player(); //initializing player

        // Croupiter starting round
        croupier.TakeCard(deck.AllCards); // Croupier is taking one card

        //Player round
        for (int i = 1; i <= 2; i++)  // player starts with 2 cards
            player.TakeCard(deck.AllCards);

        int option = 1;
        bool guard = true;

        while (guard)
        {
            Console.Clear();
            Console.WriteLine("Croupier Hand:");
            croupier.DrawCroupierHand();
            croupier.WriteHandPoints();
            Console.WriteLine("Player Hand:");
            player.DrawHand();
            player.WriteHandPoints();
            PlayerRound(ref option, player, deck.AllCards, ref guard);
        }
        // croupiers ends his round
        Console.Clear();
        Console.WriteLine("----Croupier Round----");
        croupier.TakeCards(deck.AllCards);

        //summary
        Console.Clear();

        Console.WriteLine("---Croupier Hand---");
        croupier.DrawHand();
        croupier.WriteHandPoints();
        Console.WriteLine("Player Hand:");
        player.DrawHand();
        player.WriteHandPoints();

        Console.WriteLine("----------Summary----------");
        Console.WriteLine($"Croupier Points: {croupier.Points}");
        Console.WriteLine("------");
        Console.WriteLine($"Player Points: {player.Points}");
        Console.WriteLine("--------------------------");
        Console.Write("The winner is... ");

        Thread.Sleep(500);
        if (CheckWinner(croupier, player) == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Croupier!");
        }
        else if (CheckWinner(croupier, player) == 1)
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Player! You won!");
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("No one! Draw!");
        }

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.ForegroundColor = ConsoleColor.White;
        if (CheckBJ(croupier))
            Console.WriteLine("Croupier has Black Jack! Congratulations!");
        else if (CheckBJ(player))
            Console.WriteLine("Player has Black Jack! Congratulations!");
        Console.ResetColor();
        Console.WriteLine("Press any key to return to menu...");
    }
    public Game()
    {
        StartGame();
        Console.ReadKey();
    }
}