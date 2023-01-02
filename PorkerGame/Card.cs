using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerGame
{
    internal class Card
    {
        public int cardNumber = 0;
        public int cardType = 0;



        public string PrintCardType()
        {
            // ♠ >  ◆ > ♥ > ♣ 
            switch (cardType)
            {
                case 1:
                    return "♣";
                case 2:
                    return "♥";
                case 3:
                    return "◆";
                case 4:
                    return "♠";
                default:
                    return "없음";
            }
        }

        public string PrintCardNumber()
        {
            // ♠ >  ◆ > ♥ > ♣ 
            switch (cardNumber)
            {
                case 1:
                    return "A";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return cardNumber.ToString();
            }
        }
    }
}
