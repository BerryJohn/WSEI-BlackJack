using System;
using System.Collections.Generic;

public class Croupier : Player
{

    public void TakeCards(List<string> deck)  // croupier has to stay at easy 15
    {
        while (Points < 15)
            TakeCard(deck);
    }
}