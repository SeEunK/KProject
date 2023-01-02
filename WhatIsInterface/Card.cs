using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsInterface
{
    public class Card
    {
        public string cardMark = string.Empty;
        public int cardNumber = 0;
        public Card(int value, string mark)
        {

            cardMark = mark;
            cardNumber = value;
        }
    }
}
