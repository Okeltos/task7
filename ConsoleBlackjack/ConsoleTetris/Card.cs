using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Card
    {
        public enum Rank
        {
            Ace = 1,
            Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
            Jack, Queen, King
        }

        public enum Suit
        {
            Clubs, Diamonds, Hearts, Spades
        }

        public Rank CardRank { get; }
        public Suit CardSuit { get; }

        public Card(Rank rank, Suit suit)
        {
            CardRank = rank;
            CardSuit = suit;
        }

        public int GetValue()
        {
            if (CardRank == Rank.Ace)
                return 11;

            if ((int)CardRank >= 10)
                return 10;

            return (int)CardRank;
        }

        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }

}
