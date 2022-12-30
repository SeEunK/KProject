using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOverride
{

    internal class playMoveAndCoin
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo inputKey;

            const int BOARD_SIZE_X = 12; // 가로 길이
            const int BOARD_SIZE_Y = 12; // 세로 길이

            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];  //게임 보드 배열 초기화 

            Random randomPosition = new Random();
            int playerPosY = randomPosition.Next(1, BOARD_SIZE_Y - 1); // 플레이어 최초 랜덤 위치 Y 좌표
            int playerPosX = randomPosition.Next(1, BOARD_SIZE_X - 1);   // 플레이어 최초 랜덤 위치 X 좌표

            bool isMove = false;  // 움직일수 있는 지 체크용 bool 값

            int playerCoinCount = 0;
            int playerHeartCount = 3;
            int heartMaxCount = 3;
           

            // gameBoard 상태
            // - -2 : 벽
            // - -1 : 유저 
            // -  n : 빈 공간
            // -  1 : 코인
            // -  2 : 장애물?
            // -  3 : 물약?


            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == BOARD_SIZE_Y - 1 || x == BOARD_SIZE_X - 1)
                    {
                        gameBoard[y, x] = -2; // 벽으로 세팅
                    }// if : 벽이어야 하는 경우
                    else if (y == playerPosY && x == playerPosX)
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


            for (int i = 0; i < BOARD_SIZE_Y; i++)
            {
                CoinGenerator(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard); //코인이랑 장애물 셋팅
                
                HealItemGenerator(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard); //힐 아이템 셋팅
                
                DrawBoard(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, playerHeartCount); // 보드 그리기
                Task.Delay(500).Wait();
            }

            Console.WriteLine("====================================");
            Console.WriteLine("   !!!!!!!!  S T A R T  !!!!!!!!    ");
            Console.WriteLine("====================================");

            while (isMove == false)
            {
                inputKey = Console.ReadKey();

                switch (inputKey.Key)
                {
                    case ConsoleKey.UpArrow:

                        if (playerPosY - 1 == 0)
                        {
                            Console.WriteLine("[System] 벽으로 가로막혀서 위로 움직일수 없습니다.");
                            isMove = false;
                        } //if: 위로 한칸 움직일 y좌표가 0으로 벽의 위치인 경우
                        else
                        {
                            if (gameBoard[playerPosY - 1, playerPosX] == 1)
                            {
                                //움직이려는 곳에 코인이있는경우
                                playerCoinCount++;
                            }
                            else if (gameBoard[playerPosY - 1, playerPosX] == 2)
                            {
                                playerHeartCount--;
                            }
                            else if (gameBoard[playerPosY - 1, playerPosX] == 3)
                            {
                                if (playerHeartCount == heartMaxCount) { }
                                else
                                {
                                    playerHeartCount++;
                                }
                            }

                            gameBoard[playerPosY, playerPosX] = 0; // 이전 위치 보드 상태 빈공간으로 바꿔주고
                            playerPosY = playerPosY - 1; // 플리이어 y좌표 값 -1 적용한 값으로 바꿔주고
                            gameBoard[playerPosY, playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 상태 적용
                            isMove = true; //움직일수 있음 상태로 변경
                        } //else : 위로 한칸 움직일 y좌표가 0 이 아닌 경우
                        break;
                    case ConsoleKey.DownArrow:

                        if (playerPosY + 1 >= BOARD_SIZE_Y - 1)
                        {
                            Console.WriteLine("[System] 벽으로 가로막혀서 아래로 움직일수 없습니다.");
                            isMove = false;
                        } //if: 아래로 한칸 움직일 y좌표가 보드 세로 맨 아래 끝(벽의 위치)인 경우
                        else
                        {
                            if (gameBoard[playerPosY + 1, playerPosX] == 1)
                            {
                                //움직이려는 곳에 코인이있는경우
                                playerCoinCount++;
                            }
                            else if (gameBoard[playerPosY + 1, playerPosX] == 2)
                            {
                                playerHeartCount--;
                            }
                            else if (gameBoard[playerPosY + 1, playerPosX] == 3)
                            {
                                if (playerHeartCount == heartMaxCount) { }
                                else
                                {
                                    playerHeartCount++;
                                }
                            }
                            gameBoard[playerPosY, playerPosX] = 0; // 이전 위치 보드 상태 빈공간으로 바꿔주고
                            playerPosY = playerPosY + 1; // 플리이어 y좌표 값 +1 적용한 값으로 바꿔주고
                            gameBoard[playerPosY, playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 상태 적용
                            isMove = true;//움직일수 있음 상태로 변경
                        } //else: 아래로 한칸 움직일 y좌표가 보드 세로길이 맨 아래 끝(벽)이 아닌경우
                        break;
                    case ConsoleKey.LeftArrow:

                        if (playerPosX - 1 == 0)
                        {
                            Console.WriteLine("[System] 벽으로 가로막혀서 왼쪽으로 움직일수 없습니다.");

                            isMove = false;
                        }//if: 왼쪽으로 한칸 움직일 x좌표가 0으로 벽의 위치인 경우
                        else
                        {
                            if (gameBoard[playerPosY, playerPosX - 1] == 1)
                            {
                                //움직이려는 곳에 코인이있는경우
                                playerCoinCount++;
                            }
                            else if (gameBoard[playerPosY, playerPosX - 1] == 2)
                            {
                                playerHeartCount--;
                            }
                            else if (gameBoard[playerPosY, playerPosX - 1] == 3)
                            {
                                if (playerHeartCount == heartMaxCount) { }
                                else
                                {
                                    playerHeartCount++;
                                }
                            }
                            gameBoard[playerPosY, playerPosX] = 0; // 이전 위치 보드 상태 빈공간으로 바꿔주고
                            playerPosX = playerPosX - 1; // x좌표 값 -1 적용
                            gameBoard[playerPosY, playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 상태 적용
                            isMove = true; //움직일수 있음 상태로 변경
                        }//if: 왼쪽으로 한칸 움직일 x좌표가 0이 아닌경우
                        break;
                    case ConsoleKey.RightArrow:

                        if (playerPosX + 1 >= BOARD_SIZE_X - 1)
                        {
                            Console.WriteLine("[System] 벽으로 가로막혀서 오른쪽으로 움직일수 없습니다.");
                            isMove = false;
                        }//if: 오른족으로 한칸 움직일 x좌표가 보드 가로길이 맨 오른족 끝(벽)인 경우
                        else
                        {
                            if (gameBoard[playerPosY, playerPosX + 1] == 1)
                            {
                                //움직이려는 곳에 코인이있는경우
                                playerCoinCount++;
                            }
                            else if (gameBoard[playerPosY, playerPosX + 1] == 2) //불을 밟으면,
                            {// 하트 -1
                                playerHeartCount--;
                            }
                            else if (gameBoard[playerPosY, playerPosX + 1] == 3)
                            { // 약초 위치면 
                                if (playerHeartCount == heartMaxCount) { } // 하트 full 상태면 그대로.
                                else
                                {// 하트 +1 
                                    playerHeartCount++;
                                }
                            }
                            gameBoard[playerPosY, playerPosX] = 0; // 이전 위치 보드 상태 빈공간으로 바꿔주고
                            playerPosX = playerPosX + 1; // x좌표 값 +1 적용
                            gameBoard[playerPosY, playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 상태 적용
                            isMove = true;//움직일수 있음 상태로 변경
                        }//else: 오른족으로 한칸 움직일 x좌표가 보드 가로길이 맨 오른족 끝(벽)이 아닌 경우
                        break;
                    default: // 예외처리 : WASD 가 아닌 입력이 들어온경우 
                        Console.WriteLine("[System] 잘못된 입력입니다.");
                        break;

                }//swith
                if (isMove == true)
                {
                    DrawBoard(BOARD_SIZE_Y, BOARD_SIZE_X, gameBoard, playerHeartCount);

                    isMove = false;

                    if (playerCoinCount == BOARD_SIZE_Y)
                    {
                        Console.WriteLine("====================================");
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("   !!!!!!!!  C L E A R  !!!!!!!!    ");
                        Console.ResetColor();
                        Console.WriteLine("====================================");

                        break;
                    }
                    else if (playerHeartCount == 0)
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
                        Console.WriteLine(" ☆ 획득 코인: {0}개", playerCoinCount);
                        Console.WriteLine("====================================");
                    }
                }
                else { /*nothing*/ }
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

        public static void CoinGenerator(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard)
        {
            Random randomPosition = new Random();
            while (true)
            {
                int coinPosY = randomPosition.Next(1, BOARD_SIZE_Y - 1); // 코인 생성할 랜덤 위치 Y 좌표
                int coinPosX = randomPosition.Next(1, BOARD_SIZE_X - 1);   // 코인 생성할 랜덤 위치 X 좌표

                // 뽑은 랜덤 좌표가 빈 공간인 경우
                if (gameBoard[coinPosY, coinPosX] == 0)
                {
                    gameBoard[coinPosY, coinPosX] = 1;
                    // 해당 좌표에 코인상태로 설정.!!
                    break;
                }
                else
                {
                    //랜덤 좌표 다시 뽑으러가자!
                    /*nothing*/
                }
            }
            while (true)
            {
                int aPosY = randomPosition.Next(1, BOARD_SIZE_Y - 1); // 장애물 생성할 랜덤 위치 Y 좌표
                int aPosX = randomPosition.Next(1, BOARD_SIZE_X - 1);   // 장애물 생성할 랜덤 위치 X 좌표
                                                                        // 랜덤 y,x 뽑기!

                // 뽑은 랜덤 좌표가 빈 공간인 경우
                if (gameBoard[aPosY, aPosX] == 0)
                {
                    gameBoard[aPosY, aPosX] = 2;
                    // 해당 좌표에 장애물 설정.!!
                    break;
                }
                else
                {
                    //랜덤 좌표 다시 뽑으러가자!
                    /*nothing*/
                }
            }


        }
        public static void HealItemGenerator(int BOARD_SIZE_Y, int BOARD_SIZE_X, int[,] gameBoard)
        {

            while (true)
            {
                Random randomPosition = new Random();
                int healItemPosY = randomPosition.Next(1, BOARD_SIZE_Y - 1); // 물약 생성할 랜덤 위치 Y 좌표
                int healItemPosX = randomPosition.Next(1, BOARD_SIZE_X - 1);   // 물약 생성할 랜덤 위치 X 좌표



                // 뽑은 랜덤 좌표가 빈 공간인 경우
                if (gameBoard[healItemPosY, healItemPosX] == 0)
                {
                    gameBoard[healItemPosY, healItemPosX] = 3;
                    // 해당 좌표에 힐아이템 설정.
                    break;
                }
                else
                {
                    //랜덤 좌표 다시 뽑으러가자!
                    /*nothing*/
                }

            }
        }
    }
}
