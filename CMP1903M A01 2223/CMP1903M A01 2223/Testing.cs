using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class Testing
    {
        public static Pack pack = new Pack();
        public static void UserTesting()
        {
            bool running = true;
            while (running == true)
            {
                Console.WriteLine("\nENTER NUMBER\n1: Fisher-Yates shuffle\n2: Riffle shuffle\n3: No shuffle\n4: Deal a card\n5: Deal many cards\n6: Stop program\n");
                string shuffleInput = (string)Console.ReadLine();
                switch (shuffleInput)
                {
                    case "1":
                        Pack.shuffleCardPack(0); //Fisher-Yates shuffle
                        break;
                    case "2":
                        Pack.shuffleCardPack(1); //Riffle shuffle
                        break;
                    case "3":
                        Pack.shuffleCardPack(2); //No Shuffle
                        break;
                    case "4":
                        printCard(Pack.deal()); // deals one card from top
                        break;
                    case "5":
                        bool valid = false;
                        int cardsToDeal = 0;
                        while (valid == false) // repeats until valid number entered
                        {
                            Console.WriteLine("How many cards?\n");
                            try
                            {
                                int inputCardsToDeal = Convert.ToInt32(Console.ReadLine());
                                if (inputCardsToDeal <= Pack.pack.Count()) // checks if number entered is more than cards in the deck
                                {
                                    cardsToDeal = inputCardsToDeal;
                                    valid = true;
                                }
                                else
                                {
                                    Console.WriteLine("Incorrect Entry: Number of cards to deal more than cards in pack");
                                }
                            }
                            catch (FormatException) // handles if the user enters a different data type than int
                            {
                                Console.WriteLine("Incorrect Entry: Enter a number");
                            }
                        }
                        List<Card> deltCards = new List<Card>();
                        deltCards = Pack.dealCard(cardsToDeal);
                        for (int i = 0; i < cardsToDeal; i++)
                        {
                            printCard(deltCards.ElementAt(i)); // prints multiple cards
                        }
                        break;
                    case "6": // stop program
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Entry: Input not understood");
                        break;
                }
            }
        }
        public static void printCard(Card card) // prints a card in nice format
        {
            Console.WriteLine("Value: " + card.Value.ToString() + " , Suit: " + card.Suit.ToString());
        }
    }
}
