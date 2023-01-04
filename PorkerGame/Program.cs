using System;
using System.Net;
using System.Security.Principal;
using System.Text;

namespace PorkerGame
{
    
    internal class Program
    {
        static int winPoint = 100000;
        static int initPoint = 10000;
        static int betPoint = 0;
        public static void Main(string[] args)
        {
            List<Card> cardList = null;
            Player player = new Player(); // 플레이어 생성.
            player.point = initPoint; // 플레이어 초기 포인트 설정.

            while (true)
            {
                if (cardList == null)
                {
                    cardList = CardSetting();
                }
                else if (cardList.Count < 14)
                {
                    cardList = CardSetting();
                }
                CardShuffle(cardList, 100);

                // Console.WriteLine("섞은 카드");
                // PrintDrawCard(cardList);


                List<Card> computerCardList = CardDraw(cardList, 5);
                Console.WriteLine();
                Console.WriteLine("┌───────────────── 컴퓨터 카드 ───────────────────┐");
                Console.WriteLine();
                PrintDrawCard(computerCardList);
                Console.WriteLine();
                Console.WriteLine("└─────────────────────────────────────────────────┘");
                Console.WriteLine();


                List<Card> playerCardList = CardDraw(cardList, 5);

                Console.WriteLine();
                Console.WriteLine("┌───────────────── 플레이어 카드 ─────────────────┐");
                Console.WriteLine();
                PrintDrawCard(playerCardList);
                Console.WriteLine();
                Console.WriteLine("└─────────────────────────────────────────────────┘");
                Console.WriteLine();



                // 배팅 
                Console.WriteLine("================== 베팅 ==================");
                Console.WriteLine("[ 플레이어 보유 포인트 : {0}Point]", player.point);
                Console.WriteLine();
                Console.WriteLine(" 베팅할 point를 입력하세요.");
                Console.WriteLine();
                Console.WriteLine();
                betPoint = player.Betting(); // 베팅 포인트 받아두고,
                player.point -= betPoint;
                Console.WriteLine();
                Console.WriteLine("[ 베팅 Point : {0} ] ", betPoint);
                Console.WriteLine();
                Console.WriteLine("[ 플레이어 보유 Point : {0}Point]", player.point);
                Console.WriteLine();
                Console.WriteLine();

                // 컴 카드 추가 받기
                CardAdd(computerCardList, CardDraw(cardList, 2));
                Console.WriteLine("컴퓨터가 2장의 카드를 더 받았습니다.");
                Console.WriteLine();
                Console.WriteLine("┌───────────────────────── 컴퓨터 카드 ───────────────────────────────┐");
                Console.WriteLine();
                PrintDrawCard(computerCardList);
                Console.WriteLine();
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine();


                // 플레이어 카드 추가 안받음!
                Console.WriteLine();
                Console.WriteLine("┌───────────────── 플레이어 카드 ─────────────────┐");
                Console.WriteLine();
                PrintDrawCard(playerCardList);
                Console.WriteLine();
                Console.WriteLine("└─────────────────────────────────────────────────┘");
                Console.WriteLine();

                // 플레이어 카드 변경 여부 체크 
                Console.WriteLine("카드 2장을 바꿀수있습니다. 변경하실겠습니까(Y/N)");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    int changeCardCount = 0;


                    if (inputKey.Key == ConsoleKey.Y) // Yes 응답 인 경우
                    {
                        Console.WriteLine("카드 몇장을 바꾸시겠습니까? (최대 2장 선택가능)");
                        int.TryParse(Console.ReadLine(), out changeCardCount); //바꿀 카드 개수 받기.

                        ChangeCard(playerCardList, changeCardCount);  // 플레이어 카드 변경 함수 호출 (현재 카드랑, 바꾸려는 카드 개수)
                        CardAdd(playerCardList, CardDraw(cardList, changeCardCount)); // 바꿀 카드 만큼 새로 추가.
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.N) //No 인 경우, 반복문 나가기
                    {
                        // 플레이어 카드 변경 안함.
                        break;
                    }
                    else
                    { // 예외) Y/N 이 아닌 인풋인 경우, 재입력 요청
                        Console.WriteLine("Y/N 로 입력하세요.");
                    }

                }

                Console.WriteLine();
                Console.WriteLine("┌───────────────── 플레이어 카드 ─────────────────┐");
                Console.WriteLine();
                PrintDrawCard(playerCardList);
                Console.WriteLine();
                Console.WriteLine("└─────────────────────────────────────────────────┘");
                Console.WriteLine();

                int computerScore = 0;
                int playerScore = 0;

                // 족보 판정  ==============================================================
                computerScore = CardListCheck(computerCardList);
                playerScore = CardListCheck(playerCardList);
                Console.WriteLine();
                Console.WriteLine("[컴퓨터 : {0}]", PrintResult(computerScore));
                Console.WriteLine();
                Console.WriteLine("[플레이어 : {0}]", PrintResult(playerScore));
                Console.WriteLine();

                if (computerScore > playerScore)
                {
                    //컴퓨터 승리 
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("==========o(-`д´- .)======== 컴퓨터 승리 =======(. - `д´-)o===========");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    betPoint = 0;
                }
                else if (computerScore < playerScore)
                {
                    //플레이어 승리
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Write("========☆===＼(* ｀∇｀*)／===☆==== 플레이어 승리 ===☆=====＼(*｀∇｀ *)／==☆===");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                    player.point += (betPoint*2) ;
                }
                else
                {
                    // 비김
                    Console.WriteLine();
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("========(ㆀ  = ロ= )==========     무승부    ========( =ロ = ㆀ )==========");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.WriteLine();
                }

                Console.WriteLine("[ 플레이어 보유 포인트 : {0}Point]", player.point);

                Console.WriteLine();
                Console.WriteLine();
                Task.Delay(500).Wait();
                Console.WriteLine("                      (샤샤샥.. 샤샥...)                           ");
                Task.Delay(500).Wait();
                Console.WriteLine();
                Console.WriteLine("딜러가 카드를 새로 나눠주었습니다.");
                Console.WriteLine();
                Console.WriteLine();
                Task.Delay(500).Wait();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("=========================NEW ROUND================================");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                // 결과 반영  =============================================================

                if (player.point >= winPoint)
                {
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("[플레이어가 {0}Point 획득하여 포커게임의 달인이 되었습니다!", player.point);
                    Console.ResetColor();
                    break;
                }
                else if (player.point == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("[플레이어가 Point 를 올인하여, 포커게임에서 퇴장 당했습니다...", player.point);
                    Console.ResetColor();
                    break;
                }

            }

            // 검증용 테스트 리스트 ====================================================
            if (false)
            {
                List<Card> testList = new List<Card>();
                testList.AddRange(new Card[] {  new Card { cardNumber = 7, cardType = 4 },
                                            new Card { cardNumber = 7, cardType = 3 },
                                            new Card { cardNumber = 11, cardType = 1 },
                                            new Card { cardNumber = 11, cardType = 3 },
                                            new Card { cardNumber = 1, cardType = 2 },
                                            new Card { cardNumber = 8, cardType = 1 },
                                            new Card { cardNumber = 11, cardType = 2 }});

                Console.WriteLine("==== 테스트 리스트 체크용  ===");
                PrintDrawCard(testList);

                //로티플 체크 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
                bool result = Checker.IsRoyalStraightFlush(testList);
                Console.WriteLine("{0}", result);
                //로티플 체크 ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

                // 백 스트레이트 플러쉬 체크 ============================================
                Console.WriteLine("==== 백 스트레이트 플러쉬 체크  ===");
                bool result_1 = Checker.IsBackStraightFlush(testList);
                Console.WriteLine("{0}", result_1);


                //스티플 체크 ======================================================
                Console.WriteLine("==== 스티플 체크  ===");
                bool result_2 = Checker.IsStraightFlush(testList);
                Console.WriteLine("{0}", result_2);

                //마운틴 체크
                Console.WriteLine("==== 마운틴 체크  ===");
                bool result_3 = Checker.IsMountain(testList);
                Console.WriteLine("{0}", result_3);

                //포카드 체크 -=======================================================
                Console.WriteLine("==== 포카드 체크  ===");
                bool result_4 = Checker.IsFourCard(testList);
                Console.WriteLine("{0}", result_4);

                //스트레이트 체크 ===================================================
                Console.WriteLine("==== 스트레이트 체크  ===");
                bool result_5 = Checker.IsStraight(testList);
                Console.WriteLine("{0}", result_5);

                //IsFlush =========================================================
                Console.WriteLine("==== IsFlush ===");
                bool result_6 = Checker.IsFlush(testList);
                Console.WriteLine("{0}", result_6);

                //TopNumber ======================================================
                Console.WriteLine("==== TopNumber ===");
                int result_7 = Checker.TopNumber(testList);
                Console.WriteLine("{0}", result_7);

                //IsTriple ======================================================
                Console.WriteLine("==== IsTriple ===");
                bool result_8 = Checker.IsTriple(testList);
                Console.WriteLine("{0}", result_8);


                //IsOnePair ======================================================
                Console.WriteLine("==== IsOnePair ===");
                bool result_9 = Checker.IsOnePair(testList);
                Console.WriteLine("{0}", result_9);


                //IsTwoPair ========================================================
                Console.WriteLine("==== IsTwoPair ===");
                bool result_10 = Checker.IsTwoPair(testList);
                Console.WriteLine("{0}", result_10);

                //IsFullHouse ===================================================
                Console.WriteLine("==== IsFullHouse ===");
                bool result_11 = Checker.IsFullHouse(testList);
                Console.WriteLine("{0}", result_11);

            }


        } //Main()




        public static int CardListCheck(List<Card> cardList)
        {

            if (Checker.IsRoyalStraightFlush(cardList) == true) { return 1013; }        // 로얄 스트레이트 플러쉬  [1013]
            else if (Checker.IsBackStraightFlush(cardList) == true) { return 1012; }    // 백 스트레이트 플러쉬    [1012]
            else if (Checker.IsStraightFlush(cardList) == true) { return 1011; }        //스트레이트 플러쉬        [1011]
            else if (Checker.IsFourCard(cardList) == true) { return 1010; }              //포카드                 [1010]
            else if (Checker.IsFullHouse(cardList) == true) { return 109; }                //풀하우스             [109]
            else if (Checker.IsFlush(cardList) == true) { return 108; }                 //플러쉬                  [108]
            else if (Checker.IsMountain(cardList) == true) { return 107; }                 //마운틴               [107]
            else if (Checker.IsBackStraight(cardList) == true) { return 106; }              //백 스트레이트        [106]
            else if (Checker.IsStraight(cardList) == true) { return 105; }                 //스트레이트            [105]
            else if (Checker.IsTriple(cardList) == true) { return 104; }                   //트리플                [104]
            else if (Checker.IsTwoPair(cardList) == true) { return 103; }                   //투페어               [103]
            else if (Checker.IsOnePair(cardList) == true) { return 102; }                   //원페어               [102]
            else
            {
                int topNum = Checker.TopNumber(cardList);
                return topNum;
            }                                                                     //노페어 . 탑 넘버        [n]

        }

        public static string PrintResult(int score)
        {
            switch (score)
            {
                case 1013: 
                    return " 로얄 스트레이트 플러쉬 ";
                case 1012: 
                    return " 백 스트레이트 플러쉬 ";
                case 1011:
                    return " 스트레이트 플러쉬 ";
                case 1010: 
                    return " 포카드 ";
                case 109: 
                    return " 풀하우스 ";
                case 108: 
                    return " 플러쉬 ";
                case 107: 
                    return " 마운틴 ";
                case 106: 
                    return " 백 스트레이트 ";
                case 105: 
                    return " 스트레이트 ";
                case 104: 
                    return " 트리플 ";
                case 103: 
                    return " 투페어 ";
                case 102:
                    return " 원페어 ";
                default: 
                    return "노페어";
            }
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
                Console.Write("  [{0} {1}]", cardList[i].PrintCardType().PadLeft(2), cardList[i].PrintCardNumber().PadRight(2));
               
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