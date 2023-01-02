using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsInterface
{
    public class TrumpCard
    {
        private int[] trumpCardNum;
        private string[] trumpCardMark;

        private Dictionary<int, string> trumpCardSet;

        public void SetupTrumpCards()
        {
            //trumpCardSet = new int[52];
            //for (int i = 0; i < trumpCardSet.Length; i++)
            //{
            //    trumpCardSet[i] = i + 1;
            //    // Console.Write("[ DEBUG LOG ] {0}", trumpCardSet[i]);
            //
            //}//loop : 카드를 셋업 하는 루프
            //
            //// 트럼프 카드 마크를 셋업
            //trumpCardMark = new string[4] { "♥", "♠", "◆", "♣" };

            trumpCardSet = new Dictionary<int, string>();
            trumpCardSet.Add(1, "101/♣  1");
            trumpCardSet.Add(2, "102/♣  2");
            trumpCardSet.Add(3, "103/♣  3");
            trumpCardSet.Add(4, "104/♣  4");
            trumpCardSet.Add(5, "105/♣  5");
            trumpCardSet.Add(6, "106/♣  6");
            trumpCardSet.Add(7, "107/♣  7");
            trumpCardSet.Add(8, "108/♣  8");
            trumpCardSet.Add(9, "109/♣  9");
            trumpCardSet.Add(10, "110/♣ 10");
            trumpCardSet.Add(11, "111/♣ 11");
            trumpCardSet.Add(12, "112/♣ 12");
            trumpCardSet.Add(13, "113/♣ 13");
            trumpCardSet.Add(14, "201/♥  1");
            trumpCardSet.Add(15, "202/♥  2");
            trumpCardSet.Add(16, "203/♥  3");
            trumpCardSet.Add(17, "204/♥  4");
            trumpCardSet.Add(18, "205/♥  5");
            trumpCardSet.Add(19, "206/♥  6");
            trumpCardSet.Add(20, "207/♥  7");
            trumpCardSet.Add(21, "208/♥  8");
            trumpCardSet.Add(22, "209/♥  9");
            trumpCardSet.Add(23, "210/♥ 10");
            trumpCardSet.Add(24, "211/♥ 11");
            trumpCardSet.Add(25, "212/♥ 12");
            trumpCardSet.Add(26, "213/♥ 13");
            trumpCardSet.Add(27, "301/◆  1");
            trumpCardSet.Add(28, "302/◆  2");
            trumpCardSet.Add(29, "303/◆  3");
            trumpCardSet.Add(30, "304/◆  4");
            trumpCardSet.Add(31, "305/◆  5");
            trumpCardSet.Add(32, "306/◆  6");
            trumpCardSet.Add(33, "307/◆  7");
            trumpCardSet.Add(34, "308/◆  8");
            trumpCardSet.Add(35, "309/◆  9");
            trumpCardSet.Add(36, "310/◆ 10");
            trumpCardSet.Add(37, "311/◆ 11");
            trumpCardSet.Add(38, "312/◆ 12");
            trumpCardSet.Add(39, "313/◆ 13");
            trumpCardSet.Add(40, "401/♠  1");
            trumpCardSet.Add(41, "402/♠  2");
            trumpCardSet.Add(42, "403/♠  3");
            trumpCardSet.Add(43, "404/♠  4");
            trumpCardSet.Add(44, "405/♠  5");
            trumpCardSet.Add(45, "406/♠  6");
            trumpCardSet.Add(46, "407/♠  7");
            trumpCardSet.Add(47, "408/♠  8");
            trumpCardSet.Add(48, "409/♠  9");
            trumpCardSet.Add(49, "410/♠ 10");
            trumpCardSet.Add(50, "411/♠ 11");
            trumpCardSet.Add(51, "412/♠ 12");
            trumpCardSet.Add(52, "413/♠ 13");

        }

        // // 셔플을 N번 실행해서 다시 넣는 함수
        // public void ShuffleCards(int howManyLoop)
        // {
        //     for (int i = 0; i < howManyLoop; i++)
        //     {
        //         trumpCardSet = ShuffleOnce(trumpCardSet);
        //     }
        // }

        
        
        //셔플 대신 랜덤 key 뽑아주는 함수
        public List<Card> RandomCards (int count)
        {
            List<Card> cards = new List<Card>();
            Random random = new Random();
            int randomNum = 0;
            int[] randomNumList = new int[count];

            for (int i = 0; i < count; i++)
            {
                randomNum = random.Next(1, 52 + 1);
                randomNumList[i] = randomNum;
                for (int j = 0; j < i; j++)
                {
                    if (i == 0)
                    {
                        break;
                    }
                    else if(randomNumList[j] != randomNumList[i])
                    {
                        if (j - 1 == i)
                        {
                            randomNumList[i] = randomNum;
                            break;
                        }
                    }
                    else
                    {
                        i--;
                        break;
                    }
                }
            }

            for (int i = 0; i < count; i++) {
               
                string pickCard = trumpCardSet[randomNumList[i]];
                string[] split_data = pickCard.Split('/');
                int.TryParse(split_data[0], out int num);
                Card card = new Card(num, split_data[1]);
                cards[i] = card;
                trumpCardSet.Remove(randomNumList[i]);
            }

            return cards;
        }

        //카드를 뽑아서 보여주는 함수 (마크랑 넘버 )
        public Card RollCard()
        {
            Random random = new Random();
            int randomNum = random.Next(1, 52 + 1);

            int card = trumpCardNum[randomNum];

            string cardMark = trumpCardMark[(card - 1) / 13];
            int cardNumber = (int)Math.Ceiling(card % 13.1);
            Card card1 = new Card(cardNumber, cardMark);
           
            return card1;

        }

        //섞고 뽑고
        //public void ReRoll()
        //{
        //    ShuffleCards(100);
        //
        //}

       // public void PrintCardSet()
       // {
       //     foreach (int card in trumpCardSet)
       //     {
       //         Console.Write("{0}  ", card);
       //     }
       //     Console.WriteLine();
       // }


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
