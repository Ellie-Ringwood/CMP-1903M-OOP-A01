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
                Console.WriteLine("\nENTER NUMBER\n1: Fisher-Yates shuffle\n2: Riffle shuffle\n3: No shuffle\n4: Print deck\n5: Deal a card\n6: Deal many cards\n7: Stop program");
                Console.WriteLine("There are "+Pack.pack.Count()+" cards in the pack");
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
                        Pack.printPack(); //Print deck
                        break;
                    case "5":
                        Pack.deal().printCard(); // deals one card from top
                        break;
                    case "6":
                        bool valid = false;
                        int cardsToDeal = 0;
                        while (valid == false) // repeats until valid number entered
                        {
                            Console.WriteLine("How many cards?");
                            try
                            {
                                int inputCardsToDeal = Convert.ToInt32(Console.ReadLine());
                                if (inputCardsToDeal <= Pack.pack.Count()) // checks if number entered is more than cards in the deck
                                {
                                    if (inputCardsToDeal <= 0)
                                    {
                                        Console.WriteLine("Incorrect Entry: Number of cards to deal is negative or zero");
                                    }
                                    else
                                    {
                                        cardsToDeal = inputCardsToDeal;
                                        valid = true;
                                    }
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
                            deltCards.ElementAt(i).printCard(); // prints multiple cards
                        }
                        break;
                    case "7": // stop program
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Incorrect Entry: Input not understood");
                        break;
                }
            }
        }
    }
}
