using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        public Card() 
        {
        }
        
        private int _value;
        private int _suit;

        //Properties
        public int Value 
        {
            get { return _value; }
            set { if (value < 14 && value > 0) { _value = value; }} //checks the value is valid
        }
        
        public int Suit 
        {
            get { return _suit; }
            set { if (value < 5 && value > 0) { _suit = value; }} //checks the suit is valid
        }
    }
}
