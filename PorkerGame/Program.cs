using System;

namespace PorkerGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Card> cardList = null;

            if (cardList == null)
            {
                cardList = CardSetting();
            }
            CardShuffle(cardList, 100);

           // Console.WriteLine("섞은 카드");
           // PrintDrawCard(cardList);
     

            List<Card> computerCardList = CardDraw(cardList, 5);

            Console.WriteLine("컴퓨터 카드");
            PrintDrawCard(computerCardList);
    
            List<Card> playerCardList = CardDraw(cardList, 5);

            Console.WriteLine("플레이어 카드");
            PrintDrawCard(playerCardList);

            // 배팅 

            // 컴 카드 추가 받기
            // 플레이어 카드 추가 받기
            // 플레이어 카드 변경 여부 체크 
            // 플레이어 카드 변경
            // 족보 판정.
            // 결과 반영 

     

        }

        public static void PrintDrawCard(List<Card> cardList)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                Console.WriteLine("[{0} {1}]", cardList[i].PrintCardType(), cardList[i].PrintCardNumber().PadLeft(2));
            }
        }
        public static List<Card> CardDraw(List<Card> cardList, int drawCount)
        {
            List<Card> drawCardList = new List<Card>();

            for (int i = 0; i < drawCount; i++)
            {
                drawCardList.Add (cardList[0]);
                cardList.RemoveAt(0);
            }
            return drawCardList;
        }

        public static List<Card> CardSetting()
        {
            List<Card> cardList = new List<Card>();

            for (int typeIndex = 1; typeIndex < 5; typeIndex++)
            {
                for (int numIndex = 1; numIndex < 14; numIndex++)
                {
                    Card card = new Card();
                    card.cardNumber = numIndex;
                    card.cardType = typeIndex;
                    cardList.Add(card);
                }
            }

            return cardList;
        }

        public static void CardShuffle(List<Card> cardList, int count)
        {    
            Random random = new Random();

            for (int shuffleCount = 0; shuffleCount < count; shuffleCount++)
            {
                int prevIndex = random.Next(0, cardList.Count);
                int currIndex = random.Next(0, cardList.Count);

                Card tempCard = cardList[prevIndex];
                cardList[prevIndex] = cardList[currIndex];
                cardList[currIndex] = tempCard;
            }
            
        }
    }
}