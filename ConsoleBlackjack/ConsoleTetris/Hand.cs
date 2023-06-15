using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackjack
{
    class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetTotalValue()
        {
            int totalValue = 0;
            int numAces = 0;

            foreach (Card card in cards)
            {
                totalValue += card.GetValue();

                if (card.CardRank == Card.Rank.Ace)
                    numAces++;
            }

            while (totalValue > 21 && numAces > 0)
            {
                totalValue -= 10;
                numAces--;
            }

            return totalValue;
        }

        public override string ToString()
        {
            string handString = string.Empty;

            foreach (Card card in cards)
            {
                handString += card.ToString() + ", ";
            }

            return handString.TrimEnd(',', ' ');
        }
    }
}
