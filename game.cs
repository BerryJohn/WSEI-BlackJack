using System;
using System.Collections.Generic;
public class Game
{

    public Game()
    {
        Cards cards = new Cards();

        Player player = new Player();

        // player.TakeCard(cards.AllCards);
        // player.TakeCard(cards.AllCards);
        // player.TakeCard(cards.AllCards);

        // Console.WriteLine($"reka gracza: {player.Hand.Count}");
        // Console.WriteLine($"ilosc cart: {cards.AllCards.Count}");
        // Console.WriteLine($"punkty: {player.Points}");
        // player.DrawHand();

        Croupier croupier = new Croupier();

        croupier.TakeCards(cards.AllCards); // Croupier taking cards
        croupier.DrawHand();
        Console.WriteLine(croupier.Points);
        Console.ReadKey();
    }
}