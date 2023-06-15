using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class BlackjackGame
    {
        private Deck deck;
        private Hand playerHand;
        private Hand dealerHand;
        private bool isGameOver;

        public void Run()
        {
            deck = new Deck();
            playerHand = new Hand();
            dealerHand = new Hand();
            isGameOver = false;

            deck.Shuffle();
            DealInitialCards();

            while (!isGameOver)
            {
                PrintHands();
                HandlePlayerTurn();
                if (!isGameOver)
                    HandleDealerTurn();
                PrintFinalResult();

                Console.WriteLine("Нажмите любую клавишу, чтобы начать новую игру или Esc, чтобы выйти.");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                    isGameOver = true;

                Console.Clear();
            }
        }

        private void DealInitialCards()
        {
            playerHand.AddCard(deck.DrawCard());
            dealerHand.AddCard(deck.DrawCard());
            playerHand.AddCard(deck.DrawCard());
            dealerHand.AddCard(deck.DrawCard());
        }

        private void PrintHands()
        {
            Console.WriteLine("Дилер: " + dealerHand.ToString());
            Console.WriteLine("Игрок: " + playerHand.ToString());
            Console.WriteLine();
        }

        private void HandlePlayerTurn()
        {
            while (true)
            {
                Console.WriteLine("Ваш ход. Нажмите H для получения карты или S для остановки.");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.H)
                {
                    playerHand.AddCard(deck.DrawCard());
                    Console.WriteLine("Вы получили карту: " + playerHand.ToString());
                    Console.WriteLine();

                    if (playerHand.GetTotalValue() > 21)
                    {
                        Console.WriteLine("Перебор! Вы проиграли.");
                        isGameOver = true;
                        break;
                    }
                }
                else if (key.Key == ConsoleKey.S)
                {
                    Console.WriteLine("Вы остановились.");
                    Console.WriteLine();
                    break;
                }
            }
        }

        private void HandleDealerTurn()
        {
            Console.WriteLine("Ход дилера.");

            while (dealerHand.GetTotalValue() < 17)
            {
                dealerHand.AddCard(deck.DrawCard());
                Console.WriteLine("Дилер получил карту: " + dealerHand.ToString());
                Console.WriteLine();

                if (dealerHand.GetTotalValue() > 21)
                {
                    Console.WriteLine("Перебор у дилера! Вы выиграли.");
                    isGameOver = true;
                    return;
                }

                if (dealerHand.GetTotalValue() >= 17 && dealerHand.GetTotalValue() <= 21)
                {
                    Console.WriteLine("Дилер остановился.");
                    Console.WriteLine();
                    break;
                }
            }
        }

        private void PrintFinalResult()
        {
            Console.WriteLine("Дилер: " + dealerHand.ToString() + " (Очки: " + dealerHand.GetTotalValue() + ")");
            Console.WriteLine("Игрок: " + playerHand.ToString() + " (Очки: " + playerHand.GetTotalValue() + ")");
            Console.WriteLine();

            if (playerHand.GetTotalValue() > dealerHand.GetTotalValue() && !isGameOver)
            {
                Console.WriteLine("Вы выиграли!");
            }
            else if (playerHand.GetTotalValue() < dealerHand.GetTotalValue() && !isGameOver)
            {
                Console.WriteLine("Вы проиграли.");
            }
            else
            {
                Console.WriteLine("Ничья.");
            }

            Console.WriteLine();
        }
    }
}
