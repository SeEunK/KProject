using System;

namespace WhatIsFunction
{
    internal class TicTacToe
    {
        /**
         * Tic-Tac-Toe 게임
         * 컴퓨터와 사람이 번갈아 가면서 o,x를 둔다.
         * 보드 크기는 3X3
         * 컴퓨터의 룰은 간단하게
         *  1. 중앙이 비었으면 중앙을 선점 하려함.
         *  2. 이후에 빈자리 아무곳이나 적당히 찾아서 둔다.
         *  
         */
        enum TicTacToePlayerType
        {
            None = 0, PLAYER, COMPUTER
        }

        public static void Main()
        {
            int[,] gameBord = new int[3, 3];
            int playerX, playerY = 0;
            bool isValidLocation = false;
            bool isPlayerTurn = false;
            bool isGameOver = false;

            string playerIcon = string.Empty;
            string playerType = string.Empty;

            while(isGameOver ==false)
            {
                //플레이어 턴 진행
                isPlayerTurn = true;
                playerType = "[플레이어]";
                //{ 플레이어에게서 좌표를 입력 받는다.
                playerX = 0;
                playerY = 0;
                isValidLocation = false;

                while(true)
                {
                    // 루프 탈출 조건. 제대로 된 입력을 받은 경우 탈출.
                    if(isValidLocation ==true)
                    {
                        break;
                    }

                    // 플레이어 턴 / 좌표 입력 받음
                    Console.WriteLine("[플레이어] (x)좌표 : ");
                    int.TryParse(Console.ReadLine(), out playerX);
                    Console.WriteLine("[플레이어] (y)좌표 : ");
                    int.TryParse(Console.ReadLine(), out playerY);

                    if (gameBord[playerY,playerX].Equals((int)TicTacToePlayerType.None))
                    {
                        gameBord[playerY, playerX] = (int)(TicTacToePlayerType.PLAYER);
                        isValidLocation = true; 
                    } // if: 보드가 빈곳인 경우
                    else
                    {
                        Console.WriteLine("[system] 해당 좌표는 비어있지 않습니다. / 다른 좌표를 입력하세요.");
                        isValidLocation = false;
                    } //else : 보드가 빈곳이 아닌경우 
                }// loop: 플레이어의 좌표 입력을 받는 루프
                //} 플레이어에게서 좌표를 입력 받는다.

                //{플레이어의 턴 진행을 보드에 출력한다.
                for (int y = 0; y <= gameBord.GetUpperBound(0); y++)
                {
                    Console.WriteLine("---|---|---");
                    for(int x = 0; x <=gameBord.GetUpperBound(1); x++)
                    {
                        switch(gameBord[y,x]) {
                            case (int)TicTacToePlayerType.PLAYER:
                                playerIcon = "O";
                                break;
                            case (int)TicTacToePlayerType.COMPUTER:
                                playerIcon = "X";
                                break;
                            default:
                                playerIcon = " ";
                                break;
                        }//switch
                        Console.Write(" {0} ", playerIcon);

                        //print separator
                        if (x == gameBord.GetUpperBound(1)) { /* Do nothing */ }                        
                        else { Console.Write("|"); }
                    } //loop : 한 줄에서 출력할 내용을 연산한다
                    Console.WriteLine();
                } //loop: 
                Console.WriteLine("---|---|---");
                //}플레이어의 턴 진행을 보드에 출력한다.

                // { 게임이 끝났는지 보드 검사
                Console.WriteLine();
                isGameOver= false;
                for (int y = 0; y <= gameBord.GetUpperBound(0); y++)
                {
                    if (gameBord[y, 0].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBord[y, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBord[y, 2].Equals((int)TicTacToePlayerType.PLAYER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                } // loop: 가로 방향으로 검사하는 루프
                for (int x = 0; x <= gameBord.GetUpperBound(1); x++)
                {
                    if (gameBord[0, x].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBord[1, x].Equals((int)TicTacToePlayerType.PLAYER) &&
                        gameBord[2, x].Equals((int)TicTacToePlayerType.PLAYER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                } // loop: 세로 방향으로 검사하는 루프

                // 대각선 방향으로 검사
                if (gameBord[0, 0].Equals((int)TicTacToePlayerType.PLAYER) &&
                    gameBord[1, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                    gameBord[2, 2].Equals((int)TicTacToePlayerType.PLAYER) )
                {
                    isGameOver = true;
                }
                if (gameBord[0, 2].Equals((int)TicTacToePlayerType.PLAYER) &&
                    gameBord[1, 1].Equals((int)TicTacToePlayerType.PLAYER) &&
                    gameBord[2, 0].Equals((int)TicTacToePlayerType.PLAYER))
                {
                    isGameOver = true;
                }
                // } 게임이 끝났는지 보드 검사
                // 게임이 끝난 경우 루프 탈출한다
                if (isGameOver) { break; }

                // 게임이 끝나지 않은 경우 턴을 교체 한다.
                isPlayerTurn = false;
                playerType = "[컴퓨터]";
                bool isComputerDoing = false;

                Console.WriteLine("{0}의 턴", playerType);
                // 컴퓨터는 간단한 룰
                //{ 1. 중앙이 비어있으면 선점
                if (isComputerDoing == false)
                {
                    if (gameBord[1, 1].Equals((int)TicTacToePlayerType.None))
                    {
                        gameBord[1, 1] = (int)TicTacToePlayerType.COMPUTER;
                        isComputerDoing = true;
                    }// if: 중앙이 비어있는 경우
                    else {  /* Do Nothing */  }
                }    // if: 컴퓨터가 아직 아무것도 하지않은 경우
                else {  /* Do Nothing */  }
                //} 1. 중앙이 비어있으면 선점

                //{2. 적당히 빈자리 찾아서 착수
                if (isComputerDoing == false)
                {
                    for(int y =0; y<=gameBord.GetUpperBound(0); y++)
                    {
                        for (int x = 0; x <= gameBord.GetUpperBound(1); x++)
                        {
                            if(isComputerDoing == false &&
                                gameBord[y, x].Equals((int)TicTacToePlayerType.None))
                            {
                                gameBord[x, y] = (int)TicTacToePlayerType.COMPUTER;
                                isComputerDoing = true;
                                break;
                            } //if : 서치한 자리가 비어있는 경우
                            else { continue; }
                        }// loop : search horizontal
                    } // loop : search vertical
                }// if: 컴퓨터가 아직 아무것도 하지않은 경우
                else {  /* Do Nothing */  }
                //}2. 적당히 빈자리 찾아서 착수

                // { 컴퓨터의 턴 진행을 보드에 출력한다.
                for (int y = 0; y <= gameBord.GetUpperBound(0); y++)
                {
                    Console.WriteLine("---|---|---");
                    for (int x = 0; x <= gameBord.GetUpperBound(1); x++)
                    {
                        switch (gameBord[y, x])
                        {
                            case (int)TicTacToePlayerType.PLAYER:
                                playerIcon = "O";
                                break;
                            case (int)TicTacToePlayerType.COMPUTER:
                                playerIcon = "X";
                                break;
                            default:
                                playerIcon = " ";
                                break;
                        }//switch
                        Console.Write(" {0} ", playerIcon);

                        //print separator
                        if (x == gameBord.GetUpperBound(1)) { /* Do nothing */ }
                        else { Console.Write("|"); }
                    } //loop : 한 줄에서 출력할 내용을 연산한다
                    Console.WriteLine();
                } //loop 
                Console.WriteLine("---|---|---");
                // } 컴퓨터의 턴 진행을 보드에 출력한다.

                // { 게임이 끝났는지 보드 검사
                Console.WriteLine();
                isGameOver = false;
                for (int y = 0; y <= gameBord.GetUpperBound(0); y++)
                {
                    if (gameBord[y, 0].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBord[y, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBord[y, 2].Equals((int)TicTacToePlayerType.COMPUTER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                } // loop: 가로 방향으로 검사하는 루프
                for (int x = 0; x <= gameBord.GetUpperBound(1); x++)
                {
                    if (gameBord[0, x].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBord[1, x].Equals((int)TicTacToePlayerType.COMPUTER) &&
                        gameBord[2, x].Equals((int)TicTacToePlayerType.COMPUTER))
                    {
                        isGameOver = true;
                    }
                    else { continue; }
                } // loop: 세로 방향으로 검사하는 루프

                // 대각선 방향으로 검사
                if (gameBord[0, 0].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBord[1, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBord[2, 2].Equals((int)TicTacToePlayerType.COMPUTER))
                {
                    isGameOver = true;
                }
                if (gameBord[0, 2].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBord[1, 1].Equals((int)TicTacToePlayerType.COMPUTER) &&
                    gameBord[2, 0].Equals((int)TicTacToePlayerType.COMPUTER))
                {
                    isGameOver = true;
                }
                // } 게임이 끝났는지 보드 검사

            } // loop: 틱택토 게임 루프
              // 누가 이겼는지 결과 출력
            Console.WriteLine("{0}의 승리!", playerType);
        } //main ()
    }
}
