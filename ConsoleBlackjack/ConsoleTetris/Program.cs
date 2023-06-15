using System;
using System.Collections.Generic;

namespace ConsoleBlackjack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Консольный Blackjack";
            Console.CursorVisible = false;

            BlackjackGame game = new BlackjackGame();
            game.Run();
        }
    }
}