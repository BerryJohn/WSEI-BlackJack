using System;
using System.Collections.Generic;

public class Cards
{
    //  <string> <number> <number>
    //  ex: Two 1 2
    //  Card: Two, Type: Heart, Value: 2

    // 1 -> Heart
    // 2 -> Diamond
    // 3 -> Spade
    // 4 -> Clubs
    public enum Suit
    {
        Heart,
        Diamond,
        Spade,
        Clubs
    }
    public List<string> AllCards = new List<string>()
    {
        {"Two 1 2"},
        {"Two 2 2"},
        {"Two 3 2"},
        {"Two 4 2"},
        {"Three 1 3"},
        {"Three 2 3"},
        {"Three 3 3"},
        {"Three 4 3"},
        {"Four 1 4"},
        {"Four 2 4"},
        {"Four 3 4"},
        {"Four 4 4"},
        {"Five 1 5"},
        {"Five 2 5"},
        {"Five 3 5"},
        {"Five 4 5"},
        {"Six 1 6"},
        {"Six 2 6"},
        {"Six 3 6"},
        {"Six 4 6"},
        {"Seven 1 7"},
        {"Seven 2 7"},
        {"Seven 3 7"},
        {"Seven 4 7"},
        {"Eight 1 8"},
        {"Eight 2 8"},
        {"Eight 3 8"},
        {"Eight 4 8"},
        {"Nine 1 9"},
        {"Nine 2 9"},
        {"Nine 3 9"},
        {"Nine 4 9"},
        {"Ten 1 10"},
        {"Ten 2 10"},
        {"Ten 3 10"},
        {"Ten 4 10"},
        {"Jack 1 10"},
        {"Jack 2 10"},
        {"Jack 3 10"},
        {"Jack 4 10"},
        {"Queen 1 10"},
        {"Queen 2 10"},
        {"Queen 3 10"},
        {"Queen 4 10"},
        {"King 1 10"},
        {"King 2 10"},
        {"King 3 10"},
        {"King 4 10"},
        {"Ace 1 1"},
        {"Ace 2 1"},
        {"Ace 3 1"},
        {"Ace 4 1"},
    };
}