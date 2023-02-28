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
            Random random = new Random();
            switch (typeOfShuffle) 
            {
                case 0: //Fisher-Yates shuffle
                    List<Card> tempPack = new List<Card>();
                    while (pack.Count() >0)
                    {
                        int num = random.Next(0, pack.Count());
                        tempPack.Add(pack.ElementAt(num));
                        pack.RemoveAt(num);
                    }
                    pack = tempPack;
                    break;


                case 1: //Riffle shuffle
                    int cut = (pack.Count() / 2) + random.Next(-2, 2);
                    
                    List<Card> tempPackLeft = new List<Card>();
                    List<Card> tempPackRight = new List<Card>();

                    for (int i = 0; i < cut; i++)
                    {
                        tempPackLeft.Add(pack.ElementAt(0));
                        pack.RemoveAt(0);
                    }
                    while (pack.Count() > 0)
                    {
                        tempPackRight.Add(pack.ElementAt(0));
                        pack.RemoveAt(0);
                    }
                    bool first = true;
                    int packToMerge = -1;
                    while ((tempPackRight.Count()>0)||(tempPackLeft.Count()>0))
                    {
                        if (first == true)
                        {
                            switch (random.Next(0, 2))
                            {
                                case 0:
                                    packToMerge = 0;
                                    break;
                                case 1:
                                    packToMerge = 1;
                                    break;
                            }
                        }
                        else
                        {
                            if(tempPackRight.Count() > tempPackLeft.Count())
                            {
                                packToMerge = 0;
                            }
                            else
                            {
                                packToMerge = 1;
                            }
                        }
                        int numOfCards = random.Next(1, 2); // randomises how many cards are merged at a time
                        switch (packToMerge) 
                        {
                            case 0:
                                for (int i = 0; i< numOfCards; i++) 
                                {
                                    if (tempPackRight.Count() > 0)
                                    {
                                        pack.Add(tempPackRight.ElementAt(0));
                                        tempPackRight.RemoveAt(0);
                                    }
                                }
                                break;
                            case 1:
                                for (int i = 0; i < numOfCards; i++)
                                {
                                    if(tempPackLeft.Count() > 0) 
                                    {
                                        pack.Add(tempPackLeft.ElementAt(0));
                                        tempPackLeft.RemoveAt(0);
                                    }
                                }
                                break;
                        }
                    }
                        break;


                case 2: //No shuffle
                    Console.WriteLine("No shuffle");
                    break;
            }
        }

        public static Card deal()
        {
            //Deals one card
            Card tempCard = pack.ElementAt(0);
            pack.RemoveAt(0);
            return tempCard;
        }

        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> deltCards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                deltCards.Add(pack.ElementAt(0));
                pack.RemoveAt(0);
            }
            return deltCards;
        }

        public static void printPack()
        {
            Console.WriteLine("\nPack");
            for (int i = 0; i < pack.Count(); i++)
            {
                Console.WriteLine(pack.ElementAt(i).Value.ToString() + " , " + pack.ElementAt(i).Suit.ToString());
            }
        }
    }
}
