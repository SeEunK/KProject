using System;
using System.Security.Principal;
using System.Text;

namespace PorkerGame
{
    internal class Program
    {
        static int winPoint = 100000;
        static int initPoint = 1000;
        static int betPoint = 0;
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

            Player player = new Player(); // 플레이어 생성.
            player.point = initPoint; // 플레이어 초기 포인트 설정.

            List<Card> computerCardList = CardDraw(cardList, 5);

            Console.WriteLine("컴퓨터 카드");
            PrintDrawCard(computerCardList);

            List<Card> playerCardList = CardDraw(cardList, 5);

            Console.WriteLine("플레이어 카드");
            PrintDrawCard(playerCardList);



            // 배팅 
            Console.WriteLine("======= 베팅 =======");
            betPoint = player.Betting(); // 베팅 포인트 받아두고,
            Console.WriteLine(" [ 베팅 Point : {0} ] ", betPoint);


            // 컴 카드 추가 받기
            CardAdd(computerCardList, CardDraw(cardList, 2));
            Console.WriteLine("컴퓨터 카드 추가");
            PrintDrawCard(computerCardList);

            // // 플레이어 카드 추가 받기
            // CardAdd(playerCardList, CardDraw(cardList, 2));
            // Console.WriteLine("플레이어 카드 추가");

            // 플레이어 카드 추가 안받음!
            Console.WriteLine("플레이어 카드");
            PrintDrawCard(playerCardList);

            // 플레이어 카드 변경 여부 체크 

            Console.WriteLine("카드 2장을 바꿀수있습니다. 변경하실겠습니까(Y/N)");

            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                int changeCardCount = 0;

                if (inputKey.Key == ConsoleKey.Y)
                {
                    Console.WriteLine("카드 몇장을 바꾸시겠습니까? (최대 2장 선택가능)");
                    int.TryParse(Console.ReadLine(), out changeCardCount);
                  
                    ChangeCard(playerCardList, changeCardCount);  // 플레이어 카드 변경 (현재 카드랑, 바꾸려는 카드 개수)
                    CardAdd(playerCardList, CardDraw(cardList, changeCardCount)); 
                    break;
                }
                else if (inputKey.Key == ConsoleKey.N)
                {
                    // 플레이어 카드 변경 안함.
                    break;
                }
                else
                { // 재입력 요청
                    Console.WriteLine("Y/N 로 입력하세요.");
                }

            }

            Console.WriteLine("==== 남은 플레이어 카드 ===");
            PrintDrawCard(playerCardList);
           
            
            //
            
            CardListCheck(playerCardList);

            

            // 족보 판정 함수 보내기 ==============================================================






            // 결과 반영  =============================================================






        } //Main()




        public static void CardListCheck(List<Card> cardList)
        {
            List<Card> typeSortList = new List<Card>();
            List<Card> NumberSortList = new List<Card>();
            //type으로 정렬
            typeSortList = cardList.OrderBy(x => x.cardType).ToList();
            NumberSortList = typeSortList.OrderBy(x =>x.cardNumber).ToList();

           

            Console.WriteLine("//무늬로 정렬한 카드");
            PrintDrawCard(typeSortList);

            Console.WriteLine("//숫자로 정렬한 카드");
            PrintDrawCard(NumberSortList);
            IsSameNumCard(NumberSortList);


            //============================================================

            //로티플 : 무늬 같고, 1/ 10/11/12/13

            //백스트레이트 : 무늬 같고, 1/2/3/4/5

            //스티플 : 무늬 같고, 연속 수
            
            //플러쉬 : 무늬 같음



            //1) 무늬 체크
            if (IsSameTypeCard(typeSortList) == true)
            { //무늬 5개 이상 같음

                //로티플 : 무늬 같고, 10/11/12/13/1

                // if (NumberSortList[0].cardNumber == 1) //|| NumberSortList[1].cardNumber == 1|| NumberSortList[2].cardNumber == 1)
                // {
                //     for (int i = 4; i == 0; i--)
                //     {
                //         for (int j = i - 1; j == 0; j--)
                //         {
                //             if (NumberSortList[j].cardNumber + 1 != NumberSortList[i].cardNumber)
                //                 {
                //                 break;
                //             }
                //         }
                //     }
                // 
                //     Console.WriteLine("로티플 ");
                // }

                //백스트레이트 : 무늬 같고, 1/2/3/4/5
                //스티플 : 무늬 같고, 연속 수
                //플러쉬 : 무늬 같음
                Console.WriteLine("플러쉬");

            }
            else // 무늬  같지않음.
            {
                // 포카드 (같은 숫자 4장)
                // 풀하우스 (같은 숫자 3장)+ (같은 숫자 2장)
                // 마운틴   (10/J/Q/K/A) 10/11/12/13/1
                // 백스트레이트 (1,2,3,4,5)
                // 스트레이트 (5장 연속 수)
                // 트리플 (같은 숫자 3장)
                // 투페어 (같은 숫자 2장 + 같은 숫자 2장)
                // 원페어 (같은 숫자 2장)
                // 노페어 (아무것도 같은게없음)

            }

        }


        public static void IsSameNumCard(List<Card> list)
        {
            Card tempCard = list[0];
            int isSameCount = 0;
            string result = string.Empty;
            List <string> resultResult  = new List<string>();

            // 카드의 숫자만 뺴서 list 만들어
            List<int> intList = new List<int>();

            for (int i = 1; i < list.Count; i++)
            {
                intList.Add(list[i].cardNumber);
            }
               
            //result = intList.GroupBy(x => x).Where(g => g.Count() > 1).Select(x => new { Element = x.Key, Count = x.Count() }).ToList();


            for (int i = 1; i < list.Count; i++)
            {
                // isSameCount = intList.Where(x => x.Equals(intList[i])).Count();

            }
                switch (isSameCount)
                {
                    case 4:
                        resultResult.Add("포커");
                        return ;

                    case 3:
                        resultResult.Add("트리플");
                        return ;

                    case 2:
                        resultResult.Add("원페어");
                        return ;

                    default:
                        resultResult.Add("노페어");
                        return;

                }
                
            
            //resultResult = list.GroupBy(x => x.cardNumber).Where(g => g.Count() > 1).Select(x => x.Key).ToString();

            for(int i = 0; i< resultResult.Count; i++)
            {
                Console.WriteLine("{0}", resultResult[i]);
            }
        }  


        public static bool IsSameTypeCard (List<Card> list)
        {
            bool isSame = false;

            for (int i = 1; i < 5; i++)
            {
                if (list.Where(x => x.cardType.Equals(i)).Count() >= 5)
                {
                    isSame = true;
                    break;
                }
            }

            return isSame;
        }

        public static void ChangeCard(List<Card> playerCardList, int changeCardCount)
        {
            List<Card> changeCardList = new List<Card>();

            List<int> choiceIndexList = new List<int> { 0 };

            for (int i = 0; i < changeCardCount; i++)
            {
                Console.WriteLine("바꿀 카드를 선택하세요. 좌측 부터 바꿀 카드의 순서(N번째)를 숫자로 입력하세요. ");

                int choiceIndex = ChangeCardChoiceIndex(playerCardList);

                if (0 <= choiceIndex && choiceIndex < playerCardList.Count)
                {// 잘못 입력되지않았고, 인덱스를 넘기지 않았고,

                    changeCardList.Add(playerCardList[choiceIndex]);
                    
                    Console.WriteLine("{0}번째 카드를 선택.", choiceIndex + 1);
                    
                    choiceIndexList.Add(choiceIndex);

                }
                else
                {
                    i--;
                }
            }

            Console.WriteLine("=========선택 종료=========");
            Console.WriteLine();
            Console.WriteLine("==== 선택 한 카드 ===");
            PrintDrawCard(changeCardList);

            Console.WriteLine();

            for (int i = 0; i <  changeCardCount; i++) {
                playerCardList.Remove(changeCardList[i]);

            }
            
        }

        public static int ChangeCardChoiceIndex (List<Card> playerCardList )
        {
            List<Card> changeCardList = new List<Card>();

            ConsoleKeyInfo inputKey = Console.ReadKey();
            switch (inputKey.Key)
            {
                case ConsoleKey.NumPad1:
                    
                    return 0;
                case ConsoleKey.NumPad2:
        
                    return 1;
                case ConsoleKey.NumPad3:
                
                    return 2;
                case ConsoleKey.NumPad4:
                 
                    return 3;
                case ConsoleKey.NumPad5:
        
                    return 4;
                case ConsoleKey.NumPad6:
          
                    return 5;
                case ConsoleKey.NumPad7:
        
                    return 6;
                default:
                    Console.WriteLine("잘못 입력하셨습니다.");
                    return -1;
            }

          
        }



        public static void PrintDrawCard(List<Card> cardList)
        {
            for (int i = 0; i < cardList.Count; i++)
            {
                Console.Write("[{0} {1}]", cardList[i].PrintCardType().PadLeft(2), cardList[i].PrintCardNumber().PadRight(2));
               
                //Console.WriteLine("┌──────┐");
                //Console.WriteLine("│{0} {1}│", cardList[i].PrintCardType().PadLeft(2), cardList[i].PrintCardNumber().PadLeft(2));
                //Console.WriteLine("│      │");
                //Console.WriteLine("│{1} {0}│", cardList[i].PrintCardType().PadLeft(2), cardList[i].PrintCardNumber().PadLeft(2));
                //Console.WriteLine("└──────┘");
            }
            Console.WriteLine();
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

        public static List<Card> CardAdd(List<Card> cardList, List<Card> addList)
        {
            for (int i = 0; i < addList.Count; i++)
            {
                cardList.Add(addList[i]);
            }

            return cardList;
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