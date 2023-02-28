using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Program
    {
        public static Pack pack = new Pack();
        static void Main(string[] args)
        {
            Pack.shuffleCardPack(0);
            Pack.printPack();
            Pack.shuffleCardPack(1);
            Pack.printPack();
            Console.WriteLine("Value: " + Pack.deal().Value.ToString() + " , Suit: " + Pack.deal().Suit.ToString());
            int cardsToDeal = 3;
            List<Card> deltCards = new List<Card>();
            deltCards = Pack.dealCard(cardsToDeal);
            for (int i = 0; i < cardsToDeal; i++)
            {
                printCard(deltCards.ElementAt(i));
            }
        }

        public static void printCard (Card card)
        {
            Console.WriteLine("Value: "+card.Value.ToString() + " , Suit: " + card.Suit.ToString());
        }
    }
}
