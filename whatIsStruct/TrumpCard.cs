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

        public void ShuffleCards(int howManyLoop)
        {
            for (int i = 0; i <  howManyLoop; i++) {
                trumpCardSet = ShuffleOnce(trumpCardSet);
            }
        }

        //!한장의 카드를 뽑아서 보여주는 함수
        public void RollCard()
        {
            int card = trumpCardSet[0];
            string cardMark = trumpCardMark[(card-1) / 13];
            int cardNumber = card % 13;
            Console.WriteLine("내가 뽑은 카드는 [{0}{1}] 입니다.", cardMark, cardNumber);

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
