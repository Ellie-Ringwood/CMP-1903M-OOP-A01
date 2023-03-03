using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        private static List<Card> _pack = new List<Card>();

        //Properties
        public static List<Card> pack
        {
            get { return _pack; }
            set {}
        }

        public Pack() // Constructor for pack class
        {
            for (int value = 1; value < 14; value ++) // creates 52 cards and adds them to the pack list
            {
                for (int suit = 1; suit < 5; suit ++)
                {
                    Card card = new Card();
                    card.Value = value;
                    card.Suit = suit;
                    _pack.Add(card);
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
                    while (_pack.Count() >0) // until the pack is empty, pick a random card and add to the temporary list, then remove it from the original pack
                    {
                        int num = random.Next(0, _pack.Count());
                        tempPack.Add(_pack.ElementAt(num));
                        _pack.RemoveAt(num);
                    }
                    _pack = tempPack;
                    printPack();
                    break;


                case 1: //Riffle shuffle
                    for (int shuffle = 0; shuffle<4; shuffle++) // do multiple shuffles to make it more randomised
                    {
                        int cut = (_pack.Count() / 2) + random.Next(-2, 2); //cut pack in half with possible uneven cut

                        List<Card> tempPackLeft = new List<Card>();
                        List<Card> tempPackRight = new List<Card>();

                        for (int i = 0; i < cut; i++)
                        {
                            tempPackLeft.Add(_pack.ElementAt(0));
                            _pack.RemoveAt(0);
                        }
                        while (_pack.Count() > 0)
                        {
                            tempPackRight.Add(_pack.ElementAt(0));
                            _pack.RemoveAt(0);
                        }
                        bool first = true;
                        int packToMerge = -1;
                        while ((tempPackRight.Count() > 0) || (tempPackLeft.Count() > 0))  // iterate until one pack is empty
                        {
                            if (first == true)
                            {
                                switch (random.Next(0, 2)) // randomly pick which half will be on top
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
                                if (tempPackRight.Count() > tempPackLeft.Count()) // use the pack with the most cards
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
                                case 0: // put in the amount of cards from the larger side
                                    for (int i = 0; i < numOfCards; i++)
                                    {
                                        if (tempPackRight.Count() > 0)
                                        {
                                            _pack.Add(tempPackRight.ElementAt(0));
                                            tempPackRight.RemoveAt(0);
                                        }
                                    }
                                    break;
                                case 1:
                                    for (int i = 0; i < numOfCards; i++)
                                    {
                                        if (tempPackLeft.Count() > 0)
                                        {
                                            _pack.Add(tempPackLeft.ElementAt(0));
                                            tempPackLeft.RemoveAt(0);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                    printPack();
                    break;


                case 2: //No shuffle
                    Console.WriteLine("No shuffle");
                    printPack();
                    break;
            }
        }

        public static Card deal()
        {
            //Deals one card
            Card tempCard = _pack.ElementAt(0);
            _pack.RemoveAt(0);
            return tempCard;
        }

        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> deltCards = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                deltCards.Add(_pack.ElementAt(0));
                _pack.RemoveAt(0);
            }
            return deltCards;
        }

        public static void printPack() // Prints out the values and suits of the cards in the deck
        {
            Console.WriteLine("\nPack");
            for (int i = 0; i < _pack.Count(); i++)
            {
                _pack.ElementAt(i).printCard();
            }
        }
    }
}
