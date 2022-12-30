using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace whatIsClass
{
    
    public class Card
    {
        public string cardMark = string.Empty;
        public int cardNumber = 0;
        public Card(string mark, int value)
        {

            cardMark = mark;
            cardNumber = value;
        }
    }
}
