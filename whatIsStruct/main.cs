using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace whatIsClass
{

    internal class main
    {
        static int userInitPoint = 10000; //유저 최초 포인트
        static int winningPoint = 100000; // 승리 조건 포인트
        static int bettingPoint = 0; // 배팅되어있는 포인트 초기화 (최초 는 0)
        static int userPoint = 0; //유저가 가진 포인트
        

        public static void Main()
        {
            Console.WriteLine("카드 게임을 시작합니다.");
            userPoint = userInitPoint; // 유저 포인트 지급.
            Console.WriteLine("보유 {0} Point", userPoint);

                bool IsUserWin = false;
                TrumpCard trumpCard = new TrumpCard(); //trumpCard 인스턴스화 

                trumpCard.SetupTrumpCards(); //카드 셋업
                trumpCard.ShuffleCards(100); //카드 섞기
                
            while (true)
            {
               

                // 1) 컴퓨터 카드 2개 뽑아오기 ==
                Card comCard1 = trumpCard.RollCard();
                Card comCard2 = trumpCard.RollCard();

                // Card comCard1 = new Card("a", 1);
                // Card comCard2 = new Card("a", 1);

                while (true)
                {
                    if (comCard1.cardMark == comCard2.cardMark)
                    {
                        if (comCard1.cardNumber == comCard2.cardNumber)
                        {
                            comCard2 = trumpCard.RollCard();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

                //컴카드 그리기
                Console.WriteLine("2장의 카드를 오픈합니다.");
                Console.Write("[{0}{1}]", comCard1.cardMark, comCard1.cardNumber);
                Console.Write("[{0}{1}]", comCard2.cardMark, comCard2.cardNumber);
                Console.WriteLine();

                // 3) 유저 배팅 ==
                Console.Write("배팅할 POINT를 입력하세요. : ");
                Bet();
                Console.WriteLine();
                // 4) 유저 카드 1개 뽑기.==
                Card userCard = trumpCard.RollCard();
                //Card userCard = new Card("a", 1);
                while (true)
                {
                    if (comCard1.cardMark == userCard.cardMark)
                    {
                        if (comCard1.cardNumber == userCard.cardNumber)
                        {
                            userCard = trumpCard.RollCard();
                            continue;
                        }
                    }

                    if (comCard2.cardMark == userCard.cardMark)
                    {
                        if (comCard2.cardNumber == userCard.cardNumber)
                        {
                            userCard = trumpCard.RollCard();
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("당신이 뽑은 카드를 오픈합니다.");
                Console.Write("[{0}{1}]", userCard.cardMark, userCard.cardNumber);
                Console.WriteLine();

                // 5) 결과 판정
                IsUserWin = BeyondCards(comCard1, comCard2, userCard);

                // 6) 결과 반영 및 출력 ==
                ResultReflect(IsUserWin);
                

                if (winningPoint <= userPoint)
                {
                    Console.WriteLine("보유 point가 {0} point 를 넘어 우승했습니다!");
                    break;
                }
                else if (userPoint == 0)
                {
                    Console.WriteLine("보유 point가 없어 게임을 종료합니다.");
                    break;
                }
            }

            //for (int i = 0; i < 100; i++)
            //{
            //    trumpCard.ReRoll();
            //}

            //게임 출력 하는 함수
            //컴터가 뽑을 카드 index 추출 함수

            //유저가 뽑는 카드 index 받아서 컴터 인덱스랑 다른지 체크 함수 (뽑은 카드 중복 검증 함수)


        }
        public static bool BeyondCards(Card com1,Card com2, Card user)
        {
            Card bigNumCard = com1;
            Card smallNumCard = com2;
            if (com1.cardNumber < com2.cardNumber) {
                bigNumCard = com2;
                smallNumCard = com1;
                } 
            if (smallNumCard.cardNumber < user.cardNumber && user.cardNumber < bigNumCard.cardNumber )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static void Bet()
        {
            //배팅하는 함수.
            //유저가 가진돈 보다 더 큰 값을 배팅 하는 경우 체크해서 다시 배팅 시킴.
            //가진돈 이내에 배팅을 건경우 배팅 진행 함수(배팅금 차감 및 배팅금 변수에 담아둠)로 넘김.
            int betPoint = 0;
            while (true)
            {
                int.TryParse(Console.ReadLine(), out betPoint);
                if (betPoint<= userPoint)
                {
                    Console.WriteLine("[SYSTEM] {0} Point 배팅합니다.", betPoint);
                    BetPoint(betPoint);
                    break;
                }
                else
                {
                    Console.WriteLine("[SYSTEM] 보유 POINT 보다 큰값을 배팅할수 없습니다. 다시 배팅하세요.");
                }
            }

        }
        public static void BetPoint(int betPoint)
        {
            userPoint = userPoint - betPoint; // 유저 보유 포인트에서 배팅 포인트 만큼 차감
            bettingPoint = betPoint; // 배팅되어있는 포인트에 유저가 배팅한 포인트 넣음
            Console.WriteLine("보유 {0} Point", userPoint);
        }

        public static void ResultReflect(bool result) //결과 반영 함수.(포인트 적용)
        {
            //유저 승리인 경우.
            if(result == true)
            {
                int rewardPoint = bettingPoint * 2;
                Console.WriteLine("=*=*=*=*=*=*= [ WIN ] =*=*=*=*=*=*=*=*=");
                Console.WriteLine("|           Congratulations!           |");
                Console.WriteLine("=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=*=");
                Console.WriteLine("REWARD : + {0}POINT", rewardPoint);
                userPoint = userPoint + rewardPoint; //배팅금 2배 보상
                bettingPoint = 0; // 배팅금 초기화
                Console.WriteLine("보유 {0} Point", userPoint);
            }
            else // 유저 패배
            {
                Console.WriteLine("=.=.=.=.=.=.=.= [LOSS] =.=.=.=.=.=.=.=");
                Console.WriteLine("|        lost betting point          |");
                Console.WriteLine("=.=.=.=.=.=.=.=.=.=.=.=.=.=.=.==.=.=.=");
                bettingPoint = 0; // 배팅금 잃기.
                Console.WriteLine("보유 {0} Point", userPoint);
            }
                   
        }
    }
}
