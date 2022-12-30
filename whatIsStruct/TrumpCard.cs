using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace whatIsClass
{
    public class TrumpCard
    {
        private int[] trumpCardSet;
        private string[] trumpCardMark;

         
        public void SetupTrumpCards()
        {
            trumpCardSet = new int[52];
            for(int i = 0; i < trumpCardSet.Length; i++)
            {
                trumpCardSet[i] = i + 1;
                // Console.Write("[ DEBUG LOG ] {0}", trumpCardSet[i]);
                 
            }//loop : 카드를 셋업 하는 루프

            // 트럼프 카드 마크를 셋업
            trumpCardMark = new string[4] { "♥", "♠", "◆", "♣" };
        }

        // 셔플을 N번 실행해서 다시 넣는 함수
        public void ShuffleCards(int howManyLoop)
        {
            for (int i = 0; i <  howManyLoop; i++) {
                trumpCardSet = ShuffleOnce(trumpCardSet);
            }
        }

        //카드를 뽑아서 보여주는 함수 (마크랑 넘버 )
        public Card RollCard()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 52 + 1);

            int card = trumpCardSet[randomNum];

            string cardMark = trumpCardMark[(card - 1) / 13];
            int cardNumber = (int)Math.Ceiling(card % 13.1);
            Card card1 = new Card(cardMark, cardNumber);
            //Console.WriteLine("[{0}{1}]", cardMark, cardNumber);
            return card1;

        }

        //섞고 뽑고
        public void ReRoll()
        {
            ShuffleCards(100);
            
        }

        public void PrintCardSet()
        {
            foreach(int card in trumpCardSet)
            {
                Console.Write("{0}  ", card);
            }
            Console.WriteLine();
        }


        public int[] ShuffleOnce(int[] intArray)
        {
            Random ramdum = new Random();
            int sourIndex = ramdum.Next(0, intArray.Length);
            int destIndex = ramdum.Next(0, intArray.Length);

            int tempVarible = intArray[sourIndex];
            intArray[sourIndex] = intArray[destIndex];
            intArray[destIndex] = tempVarible;

            return intArray;
        }
    }
}
