using System;

namespace ConsoleGame
{
    internal class Program
    {


        static void Main(string[] args)
        {
            Console.WriteLine("=================================");  //  1
            Console.WriteLine("=================================");  //  2
            Console.WriteLine("=================================");  //  3
            Console.WriteLine("=========모험가 이야기===========");   //  4
            Console.WriteLine("===O========================o====");  //  5
            Console.WriteLine("======o=========o================");  //  6
            Console.WriteLine("===========O==========o==========");  //  7
            Console.WriteLine("===o===============O======o======");  //  8 
            Console.WriteLine("=======*=======O=====o===========");  //  9
            Console.WriteLine("==O====***==================O====");  // 10
            Console.WriteLine("=======***======~~~~~~~~=========");  // 11
            Console.WriteLine("=====******===~~~~~~~~~~~~~~~~===");  // 12
            Console.WriteLine("=====******=~~~~~~~~~~~~~~~~~~~==");  // 13
            Console.WriteLine("====********=====================");  // 14
            Console.WriteLine("=====********===========/=/======");  // 15
            Console.WriteLine("===***********========/===/======");  // 16
            Console.WriteLine("===*************=====/====/======");  // 17
            Console.WriteLine("===***********=====/======/======");  // 18
            Console.WriteLine("=====|==|==|=====/========/======");  // 19
            Console.WriteLine("===============/=========/=======");  // 20
            Console.WriteLine("=============/===================");  // 21
            Console.WriteLine("=================================");  // 22
            Console.WriteLine("=================================");  // 23
            Console.WriteLine("=================================");  // 24
            Console.WriteLine("==========[TAB TO START]=========");  // 25
            Console.WriteLine("=================================");  // 26
            Console.WriteLine("=================================");  // 27
            Console.WriteLine("=================================");  // 28


            string userChoice = string.Empty;

            int userGold = 1000; // 초기에 지급할 골드 설정
            int[] userStat = { 8, 8, 8, 8, 8, 8 };  // user stat 기본 세팅 : 6개 index 순에 따라 힘 / 민첩 / 지능 / 카리스마 / 건강 / 지혜 로 관리

            int userExp = 0; // 경험치 
            bool isSuccess = false; // 성공 확률에 따라 결과 설정을위해 

            int stepNum = 0;

            // 시작 인풋 받기.
            string tapToStart = string.Empty;
            tapToStart = Console.ReadLine();


            if (tapToStart != null) // 뭔가 입력되면 다음 으로 씬전환.
            {
                Console.WriteLine("=================================");  //  1
                Console.WriteLine("=================================");  //  2
                Console.WriteLine("=================================");  //  3
                Console.WriteLine("=========새로운 모험 시작========");   //  4
                Console.WriteLine("=================================");  //  5
                Console.WriteLine("=================================");  //  6
                Console.WriteLine("=================================");  //  7
                Console.WriteLine("========  무작위 모험가 =========");  //  8 
                Console.WriteLine("===== 또는 당신만의 모험가로 ====");  //  9
                Console.WriteLine("=== 새로운 모험을 시작하세요! ===");  // 10
                Console.WriteLine("=================================");  // 11
                Console.WriteLine("=================================");  // 12
                Console.WriteLine("=================================");  // 13
                Console.WriteLine("=================================");  // 14
                Console.WriteLine("=================================");  // 15
                Console.WriteLine("=================================");  // 16
                Console.WriteLine("=================================");  // 17
                Console.WriteLine("=================================");  // 18
                Console.WriteLine("==== [ 무작위 시작:'A'입력 ] ====");  // 19
                Console.WriteLine("=================================");  // 20
                Console.WriteLine("=== [ 모험가 커스텀:'B'입력 ] ===");  // 21
                Console.WriteLine("=================================");  // 22
                Console.WriteLine("=================================");  // 23
                Console.WriteLine("=================================");  // 24
                Console.WriteLine("=================================");  // 25
                Console.WriteLine("=================================");  // 26
                Console.WriteLine("=================================");  // 27
                Console.WriteLine("=================================");  // 28

                sellectMenu(stepNum);
                
                // ==========================================================================
                // * 커스텀 하는 부분 구현 필요
                // ==========================================================================
            }
        }
        // 선택지를 포함한 이벤트 =================================================================================


        public static void sellectMenu(int step)
        {
            string userChoice = Console.ReadLine();
            Console.WriteLine("log: : {0}", step);
            while (true) {
                if (userChoice == "A")
                {
                    Console.WriteLine("log: A 입력함. step : {0}", step);
                  
                    step++;
                    break;
                }
                else if (userChoice == "B")
                {
                                                            
                    Console.WriteLine("log: B 입력함. step : {0}", step);
               
                    step = 0;
                    break;
                }
                else if (userChoice == "c" || userChoice == "C")
                {
                    
                    
                    
                    Console.WriteLine("log: C 입력함. step : {0}", step);
                   
                    step++;

                    int monsterID = 1000;
                    monsterBattle(monsterID);
                    reward(monsterID);
                    break;
                }
                else
                {
                    // A,B 중 선택이 아닌값이므로 다시 입력 기다리기.
                }
                
            }
            storys(step);

        }

        public static void storys (int step)
        {
            
            switch (step)
            {
                case 0:
                    Console.WriteLine("=================================");  //  1
                    Console.WriteLine("=================================");  //  2
                    Console.WriteLine("====||||||||||||||||||||||||||===");  //  3
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");   //  4
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");  //  5
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");  //  6
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");  //  7
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");  //  8 
                    Console.WriteLine("====||||||||||||||||||||||||||===");  //  9
                    Console.WriteLine("=== ||||||||||||||||||||||||||===");  // 10
                    Console.WriteLine("=================================");  // 11
                    Console.WriteLine("=================================");  // 12
                    Console.WriteLine("== 의뢰가 붙어있는 게시판이다. ==");  // 13
                    Console.WriteLine("=================================");  // 14
                    Console.WriteLine("==== 흥미로운 의뢰를 발견함. ====");  // 15
                    Console.WriteLine("=================================");  // 16
                    Console.WriteLine("=================================");  // 17
                    Console.WriteLine("=================================");  // 18
                    Console.WriteLine("== [ 의뢰를 받으러 간다.:'A' ] ==");  // 19
                    Console.WriteLine("=================================");  // 20
                    Console.WriteLine("====== [ 무시한다. : 'B'  ] =====");  // 21
                    Console.WriteLine("=================================");  // 22
                    Console.WriteLine("=================================");  // 23
                    Console.WriteLine("=================================");  // 24
                    Console.WriteLine("=================================");  // 25
                    Console.WriteLine("=================================");  // 26
                    Console.WriteLine("=================================");  // 27
                    Console.WriteLine("=================================");  // 28

                    
                    break;

                case 1:
                    Console.WriteLine("=================================");  //  1
                    Console.WriteLine("=================================");  //  2
                    Console.WriteLine("====||||||||||||||||||||||||||===");  //  3
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");   //  4
                    Console.WriteLine("====|||     [ 의뢰 내용 ]  |||===");  //  5
                    Console.WriteLine("====|||  숲속에서 잃어버린 |||===");  //  6
                    Console.WriteLine("====|||   모자를 찾아줘!   |||===");  //  7
                    Console.WriteLine("====|||~~~~~~~~~~~~~~~~~~~~|||===");  //  8 
                    Console.WriteLine("====||||||||||||||||||||||||||===");  //  9
                    Console.WriteLine("=== ||||||||||||||||||||||||||===");  // 10
                    Console.WriteLine("=================================");  // 11
                    Console.WriteLine("=================================");  // 12
                    Console.WriteLine("=(숲에는 무서운 늑대가 있는데..)=");  // 13
                    Console.WriteLine("=================================");  // 14
                    Console.WriteLine("=================================");  // 15
                    Console.WriteLine("=================================");  // 16
                    Console.WriteLine("=================================");  // 17
                    Console.WriteLine("=================================");  // 18
                    Console.WriteLine("===== [ 숲으로 이동 :'A' ] =====");  // 19
                    Console.WriteLine("=================================");  // 20
                    Console.WriteLine("====== [ 포기한다. : 'B'  ] =====");  // 21
                    Console.WriteLine("=================================");  // 22
                    Console.WriteLine("=================================");  // 23
                    Console.WriteLine("=================================");  // 24
                    Console.WriteLine("=================================");  // 25
                    Console.WriteLine("=================================");  // 26
                    Console.WriteLine("=================================");  // 27
                    Console.WriteLine("=================================");  // 28
                    
                    break;

                case 2:
                    Console.WriteLine("=================================");  //  1
                    Console.WriteLine("=================================");  //  2
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^===========");  //  3
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^===========");   //  4
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^===========");  //  5
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^==^^^======");  //  6
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^==^^^^^====");  //  7
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^==^^^^^====");  //  8 
                    Console.WriteLine("====^^^^^^^^^^^^^^^^^^==^^^^^====");  //  9
                    Console.WriteLine("=== ^^^^^^^^^^^^^^^^^^==^^^^^====");  // 10
                    Console.WriteLine("=================================");  // 11
                    Console.WriteLine("=================================");  // 12
                    Console.WriteLine("=================================");  // 13
                    Console.WriteLine("== 이런, 늑대가 모자를 물고있어! =");  // 14
                    Console.WriteLine("=================================");  // 15
                    Console.WriteLine("=================================");  // 16
                    Console.WriteLine("=================================");  // 17
                    Console.WriteLine("=================================");  // 18
                    Console.WriteLine("===== [ 늑대와 싸움 :'C' ] ======");  // 19
                    Console.WriteLine("=================================");  // 20
                    Console.WriteLine("======= [   도망  : 'B'  ] ======");  // 21
                    Console.WriteLine("=================================");  // 22
                    Console.WriteLine("=================================");  // 23
                    Console.WriteLine("=================================");  // 24
                    Console.WriteLine("=================================");  // 25
                    Console.WriteLine("=================================");  // 26
                    Console.WriteLine("=================================");  // 27
                    Console.WriteLine("=================================");  // 28

                   
                    break;
            }

            sellectMenu(step);

        }

        public static void monsterBattle(int monsterID)
        {
            Console.WriteLine("=================================");  //  1
            Console.WriteLine("==!!!!!!!  BATTLE START  !!!!!!==");  //  2
            Console.WriteLine("=================================");  //  3

        }


        public static void reward(int monsterID)
        {

        }
    }
}