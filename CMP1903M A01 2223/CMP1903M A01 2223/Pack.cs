using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static List<Card> pack = new List<Card>();

        public Pack()
        {
            for (int value = 1; value < 14; value ++)
            {
                for (int suit = 1; suit < 5; suit ++)
                {
                    Card card = new Card();
                    card.Value = value;
                    card.Suit = suit;
                    pack.Add(card);
                }
            }
        }

        public static void shuffleCardPack(int typeOfShuffle)
        {
            List<Card> tempPack = new List<Card>();
            switch (typeOfShuffle) 
            {
                case 0: //Fisher-Yates shuffle
                    Random random = new Random();
                    while (pack != null)
                    {
                        int num = random.Next(0, pack.Count());
                        tempPack.Add(pack.ElementAt(num));
                        pack.RemoveAt(num);
                    }
                    pack = tempPack;
                    break;
                case 1: //Riffle shuffle
                    break;
                case 2: //No shuffle
                    break;
            }
            for (int i = 0; i < pack.Count(); i++)
            {
                Console.WriteLine(pack.ElementAt(i));
            }
        }

        public static Card deal()
        {
            //Deals one card
            pack.RemoveAt(0);
            return pack.ElementAt(0);
        }
        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> deltCards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                pack.RemoveAt(0);
                deltCards.Add(pack.ElementAt(0));
            }
            return deltCards;
        }
    }
}
