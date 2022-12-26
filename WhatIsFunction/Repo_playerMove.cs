using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatIsFunction
{
    internal class Repo_playerMove
    {
        static void Main(string[] args)
        {
            /* 
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

            const int BOARD_SIZE_X = 5; // 가로 길이
            const int BOARD_SIZE_Y = 5; // 세로 길이

            Random randomPosition = new Random();
            bool isMove = false;  // 움직일수 있는 지.

            int[,] gameBoard = new int[BOARD_SIZE_Y, BOARD_SIZE_X];
            int[,] playBoard = new int[BOARD_SIZE_Y-2, BOARD_SIZE_X-2];
            int playerPosY = randomPosition.Next(1, BOARD_SIZE_Y - 1); // 플레이어 최초 랜덤 위치 Y 좌표
            int playerPosX = randomPosition.Next(1, BOARD_SIZE_X - 1);   // 플레이어 최초 랜덤 위치 X 좌표

            // gameBoard 상태
            // - -2 : 벽
            // - -1 : 유저 
            // -  n : 빈 공간

            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == BOARD_SIZE_Y -1|| x == BOARD_SIZE_X-1)
                    {
                        gameBoard[y, x] = -2; // 벽으로 세팅
                    }// if : 벽이어야 하는 경우
                    else if(y == playerPosY && x == playerPosX) 
                    {
                        gameBoard[y, x] = -1; // 플레이어 세팅
                    }// else if : 플레이어 최초 랜덤 위치인 경우
                    else
                    {                        
                        gameBoard[y, x] = 0; // 빈공간
                    }// else : 벽도 플레이어 위치도 아닌 경우 
                }
            }// loop : 벽과 빈공간 초기화 하는 루프

            
            
            // { 현재 보드의 상태를 플레이 시점으로 보여준다. 
            for (int y = 0; y < BOARD_SIZE_Y; y++)
            {
                for (int x = 0; x < BOARD_SIZE_X; x++)
                {
                    switch (gameBoard[y, x])
                    {
                        case -2:
                            Console.Write("□".PadRight(2, ' '));
                            break;
                        case -1:
                            Console.Write("♀".PadRight(2, ' ')); 
                            break;
                        default:
                            Console.Write(" . ".PadRight(2, ' '));
                            break;
                    }//swith
                } //loop: 
                Console.WriteLine();
            } // loop : 현재 보드의 상태를 출력하는 루프
            Console.WriteLine();
            // } 현재 보드의 상태를 플레이 시점으로 보여준다.

            while (isMove == false)
            {
                Console.WriteLine("W/A/S/D 로 플레이어 ♀ 를 움직여보세요.");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "w":
                        if (playerPosY - 1 == 0)
                        {
                            Console.WriteLine("벽으로 가로막혀서 움직일수 없습니다.");
                            isMove = false;
                        }
                        else
                        {
                            gameBoard[playerPosY, playerPosX] = 0;
                            playerPosY = playerPosY - 1;
                            gameBoard[playerPosY, playerPosX] = -1;
                            isMove = true;
                        }
                        break;
                    case "s":
                        if (playerPosY + 1 >= BOARD_SIZE_Y-1)
                        {
                            Console.WriteLine("벽으로 가로막혀서 움직일수 없습니다.");
                            isMove = false;
                        }
                        else
                        {
                            gameBoard[playerPosY, playerPosX] = 0;
                            playerPosY = playerPosY + 1;
                            gameBoard[playerPosY, playerPosX] = -1;
                            isMove = true;
                        }
                        break;
                    case "a":
                        if (playerPosX - 1 == 0)
                        {
                            Console.WriteLine("벽으로 가로막혀서 움직일수 없습니다.");
                            isMove = false;
                        }
                        else
                        {
                            gameBoard[playerPosY, playerPosX] = 0; // 이전 위치 보드 상태 빈공간으로 바꿔주고
                            playerPosX = playerPosX - 1; // x좌표 값 -1 적용
                            gameBoard[playerPosY, playerPosX] = -1; // 보드 상태도 바뀐 좌표에 유저 표시
                            isMove = true;
                        }
                        break;
                    case "d":
                        if (playerPosX + 1 >= BOARD_SIZE_X-1)
                        {
                            Console.WriteLine("벽으로 가로막혀서 움직일수 없습니다.");
                            isMove = false;
                        }
                        else
                        {
                            gameBoard[playerPosY, playerPosX] = 0;
                            playerPosX = playerPosX + 1;
                            gameBoard[playerPosY, playerPosX] = -1;
                            isMove = true;
                        }
                        break;
                }//swith
                if (isMove == true)
                {
                    // { 현재 보드의 상태를 플레이 시점으로 보여준다. 
                    for (int y = 0; y < BOARD_SIZE_Y; y++)
                    {
                        for (int x = 0; x < BOARD_SIZE_X; x++)
                        {
                            switch (gameBoard[y, x])
                            {
                                case -2:
                                    Console.Write("□".PadRight(2, ' '));
                                    break;
                                case -1:
                                    Console.Write("♀".PadRight(2, ' '));
                                    break;
                                default:
                                    Console.Write(" . ".PadRight(2, ' '));
                                    break;
                            }//swith
                        } //loop: 
                        Console.WriteLine();
                    } // loop : 현재 보드의 상태를 출력하는 루프
                    Console.WriteLine();
                    // } 현재 보드의 상태를 플레이 시점으로 보여준다.
                    isMove = false;
                }
                else
                {
                    //nothing 
                }
            }
        }
    }
}
