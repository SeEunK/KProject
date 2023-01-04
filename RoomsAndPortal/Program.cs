using System;
using System.Net;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace RoomsAndPortal
{
    public static class Program
    {
        public static void Main(string[] args)
        {

            /**************************************************************************************************************
              * 5x5 보드 (사이즈 줘도 ok)
              *   □  □  □  □ □
              *   □ .  .  .  □
              *   □ .  옷 .  □
              *   □ .  .  .  □
              *   □  □  □  □ □
              * 
              * .(닷)은 빈곳, □는 벽을 의미
              * 빈곳 중에 아무곳(or 정 중앙) 이나, 사람(이모티콘 또는 옷)을 초기화 해서
              * w/a/s/d 입력 받아서 빈 곳을 자유롭게 이동하는 프로그램 작성.
              * 이동 조건> 
              * - 1. 사람은 빈곳을 다닐수 있음
              * - 2. 사람은 벽을 넘어다닐수 없음.
              * 
              * - 예외) 벽인곳으로 이동하려하면, 벽으로 막혀있습니다. 출력
              */

            /**************************************************************************************************************
             * 230104 추가 규칙
             * 벽에 포털이 있고, 포털을 타고 가면 다음 방으로 연결.
             * 포털 문 방향과 입장한 플레이어 위치 잘맞추고 [중요 포인트 : 문방향 맞추고, 플레이어 방향도 맞춘다]
             * 다시 돌아가도 이전 방이 로드되어야하고
             * (기본형 : 문 방향 1개) / (어려움 : 문 4방향  & 어딘가 코인있음)
             */

            ConsoleKeyInfo inputKey;

            const int BOARD_SIZE_X = 15; // 가로 길이
            const int BOARD_SIZE_Y = 15; // 세로 길이





            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];  //게임 보드 배열 초기화 

            Player player = new Player();
            player.inItPosition(BOARD_SIZE_Y, BOARD_SIZE_X);



            // gameBoard 상태
            // 
            // - -3 : 모서리 (corner)
            // - -5 : 포탈
            // - -2 : 벽
            // - -1 : 유저 
            // -  n : 빈 공간

            // item Object 
            // -  1 : 코인
            // -  2 : 장애물?
            // -  3 : 물약?

            InitBoard(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, player);




            Console.WriteLine("====================================");
            Console.WriteLine("   !!!!!!!!  S T A R T  !!!!!!!!    ");
            Console.WriteLine("====================================");



            // gameBoard 상태
            // 
            // - -3 : 모서리 (corner)
            // - -5 : 포탈
            // - -2 : 벽
            // - -1 : 유저 
            // -  n : 빈 공간
            while (player.isMove == false)
           {

               inputKey = Console.ReadKey();

                int directionToGo_y = -1;
                int directionToGo_x = -1;

                switch (inputKey.Key)
                { // inputKey 에 따라 갈방향 x/y좌표 설정.

                    case ConsoleKey.UpArrow:
                        directionToGo_y = player.playerPosY + 1;
                        directionToGo_x = player.playerPosX;
                        break;

                    case ConsoleKey.DownArrow:
                        directionToGo_y = player.playerPosY - 1;
                        directionToGo_x = player.playerPosX;
                        break;

                    case ConsoleKey.LeftArrow:
                        directionToGo_y = player.playerPosY;
                        directionToGo_x = player.playerPosX - 1;
                        break;

                    case ConsoleKey.RightArrow:
                        directionToGo_y = player.playerPosY;
                        directionToGo_x = player.playerPosX + 1;

     //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
     // 여기서 포탈일경우 갈 좌표도 미리 계산해서 넘길까? !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        break;

                    default: // 예외처리 : WASD 가 아닌 입력이 들어온경우 
                        Console.WriteLine("[System] 잘못된 입력입니다.");
                        break;
                }//swith

                // 
                CheckMoveAvailability(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard,player,directionToGo_y,directionToGo_x);


                if (player.isAnothcrRoom == true)
                {
                    NewRoomInitPos();
                }

                if (player.isMove == true)
                {
                   DrawBoard(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, player.playerHeartCount);

                    player.isMove = false;

                   if (player.playerCoinCount == BOARD_SIZE_Y)
                   {
                       Console.WriteLine("====================================");
                       Console.BackgroundColor = ConsoleColor.Magenta;
                       Console.ForegroundColor = ConsoleColor.Yellow;
                       Console.WriteLine("   !!!!!!!!  C L E A R  !!!!!!!!    ");
                       Console.ResetColor();
                       Console.WriteLine("====================================");

                       break;
                   }
                   else if (player.playerHeartCount == 0)
                   {
                       Console.WriteLine("====================================");
                       Console.BackgroundColor = ConsoleColor.DarkRed;
                       Console.ForegroundColor = ConsoleColor.White;
                       Console.WriteLine("   !!!!!!!!  GAME OVER  !!!!!!!!    ");
                       Console.ResetColor();
                       Console.WriteLine("====================================");

                       break;
                   }
                   else
                   {
                       Console.WriteLine("====================================");
                       Console.WriteLine(" ☆ 획득 코인: {0}개", player.playerCoinCount);
                       Console.WriteLine("====================================");
                   }
               }
               else { /*nothing*/
        }
    }

        }


        public static void InitBoard(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard, Player player)
        {
            // [corner]  { 0, 0 }, { BOARD_SIZE_Y - 1, 0 }, { 0, BOARD_SIZE_X - 1 }, { BOARD_SIZE_Y - 1, BOARD_SIZE_X - 1 } 
            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == BOARD_SIZE_Y - 1 || x == BOARD_SIZE_X - 1)
                    { // 좌표 가장자리.

                        //corner check
                        if (y == 0 && x == 0 || y == BOARD_SIZE_Y - 1 && x == 0 || y == 0 && x == BOARD_SIZE_X - 1 || y == BOARD_SIZE_Y - 1 && x == BOARD_SIZE_X - 1)
                        {
                            gameBoard[y, x] = -3; // 코너로 세팅
                        }
                        else
                        {
                            gameBoard[y, x] = -2; // 벽으로 세팅
                        }
                    }// if : 벽이어야 하는 경우
                    else if (y == player.playerPosY && x == player.playerPosX)
                    {
                        gameBoard[y, x] = -1; // 플레이어 세팅
                    }// else if : 플레이어 최초 랜덤 위치 설정의 경우
                    else
                    {
                        gameBoard[y, x] = 0; // 빈공간

                    }// else : 벽도 플레이어 위치도 아닌 경우 
                }
            }// loop : 게임보드 (벽,빈공간,플레이어 위치) 초기 설정 하는 루프


            // DrawBoard(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, playerHeartCount); 
            // 
            // Console.WriteLine("====================================");
            // Console.WriteLine(" ---------  R E A D Y -------------");
            // Console.WriteLine("====================================");


            // 1 : 재화(코인) / 2 : 장애물 / 3 : 물약
            for (int i = 0; i < BOARD_SIZE_Y; i++)
            {
                Generator.ItemGenerator(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, 1); //코인 셋팅 Coin
                Generator.ItemGenerator(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, 2); //장애물 셋팅 
                Generator.ItemGenerator(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, 3); //힐 아이템 셋팅 type HealItem

                if (i == BOARD_SIZE_Y - 1)
                {
                    if (player.isAnothcrRoom == true)
                    {
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        gameBoard[player.prevPosY, player.prevPosX] = -5; // 이전 사람의 위치를 등을 진 좌표 상태 - > 포탈로 바꿔주고
                        player.playerPosY = directionToGo_y; // 유저 y 좌표 값 곳의 x좌표 값 으로 변경./
                        player.playerPosX = directionToGo_x; // 유저 x 좌표 값 이동할곳의 x좌표 값 으로 변경./

                        gameBoard[player.playerPosY, player.playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 상태 적용






                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

                    }
                    else
                    {
                        Generator.PortalGenerator(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, -5); // 마지막에 포털!
                    }
                }

                DrawBoard(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, player.heartMaxCount); // 보드 그리기
                Task.Delay(500).Wait();

            }
        }


        public static void DrawHeart(int heartCount)
        {
            int maxHP = 3;
            Console.WriteLine("====================================");
            Console.Write("| 생명력 | ");
            for (int i = 0; i < heartCount; i++)
            {
                Console.Write("♥");
            }
            if (maxHP != heartCount)
            {
                for (int i = 0; i < maxHP - heartCount; i++)
                {
                    Console.Write("♡");
                }
            }
            Console.Write(" | ");
            Console.WriteLine();
            Console.WriteLine("====================================");
        }


        public static void DrawBoard(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard, int heartCount)
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine(" 플레이어(♀) 이동: 방향키←↑↓→");
            Console.WriteLine("    코인(ⓒ)을 모두 획득 하세요.     ");
            Console.WriteLine("   [불(♨)를 밟으면 생명력 1잃음]");
            Console.WriteLine("   [풀(♣)를 먹으면 생명력 1회복]");
            Console.WriteLine("====================================");

            DrawHeart(heartCount);

            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    switch (gameBoard[y, x])
                    {
                        case -5:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("▣".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        case -3:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("■".PadRight(2, ' '));
                            Console.ResetColor();
                            break;
                        case -2:
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("□".PadRight(2, ' '));
                            Console.ResetColor();

                            break;
                        case -1:
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("♀".PadRight(2, ' '));
                            Console.ResetColor();

                            break;

                        case 1:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.Write("ⓒ".PadRight(2, ' '));
                            Console.ResetColor();

                            break;

                        case 2:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("♨".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        case 3:
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("♣".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        default:
                            Console.Write(" . ".PadRight(2, ' '));
                            break;
                    }//swith

                } //loop : 현재 보드의 상태를 출력하는 루프 (x 좌표)
                Console.WriteLine();
            } // loop : 현재 보드의 상태를 출력하는 루프 (y 좌표)
            Console.WriteLine();

        }





        public static void CheckMoveAvailability(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard, Player player, int directionToGo_y, int directionToGo_x)
        {
            
            //공통으로 가능하게 바꿨음
            switch(gameBoard[directionToGo_y, directionToGo_x])
            {
                case -2: //한칸 움직일 x좌표가 0으로 벽의 위치인 경우
                    Console.WriteLine("[System] 벽으로 가로막혀서 움직일수 없습니다.");

                    player.isMove = false;
                    break;
                case 1:   //움직이려는 곳에 코인이있는경우

                    player.playerCoinCount++;
                    break;
                case 2: //장애물이있는 경우
                    player.playerHeartCount--;
                    break;
                case 3: //힐 아이템이 있는 경우
                    if (player.playerHeartCount < player.heartMaxCount)
                    {
                        player.playerHeartCount++;
                    }
                    break;
                case -5: //포탈인 경우
                    player.isAnothcrRoom = true;
                   
                    Console.WriteLine("다음 맵 출력 함수 연결 필요");

                    break;
            }


                player.prevPosX = player.playerPosX;
                player.prevPosY = player.playerPosY;

                gameBoard[player.prevPosY, player.prevPosX] = 0; // 이전 위치 보드 상태 빈공간으로 바꿔주고
                player.playerPosY = directionToGo_y; // 유저 y 좌표 값 이동할곳의 x좌표 값 으로 변경./
                player.playerPosX = directionToGo_x; // 유저 x 좌표 값 이동할곳의 x좌표 값 으로 변경./

                gameBoard[player.playerPosY, player.playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 상태 적용
                player.isMove = true; //움직일수 있음 상태로 변경
            
        }

        public static void NewRoomInitPos()
        {

        }

    }
    
}