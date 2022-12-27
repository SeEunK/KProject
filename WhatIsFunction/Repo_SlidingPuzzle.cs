using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsFunction
{
    internal class Repo_SlidingPuzzle
    {
        static void Main(string[] args)
        {

            const int BOARD_X = 5; // 게임 판 가로 사이즈 
            const int BOARD_Y = 5; // 게임 판 세로 사이즈 

            int[,] board = new int[BOARD_Y, BOARD_X];

            
            Random random = new Random();
            int blankPosY = random.Next(1, BOARD_Y-1);
            int blankPosX = random.Next(1, BOARD_X-1);

                      
            
            int maxNum = (BOARD_Y - 2) * (BOARD_X - 2) - 1;

            int[] numbers = new int[maxNum];
            int randomNumber = 0;
            bool isSame = false;

            for (int i = 0; i < numbers.Length; i++ )
            {
                randomNumber = random.Next(1, maxNum); // 1 ~ maxnum 사이 랜덤 수 가져옴 

                Console.WriteLine("랜덤값 : {0}",randomNumber);

                for (int j = 0; j < i; j++)
                {
                    if (numbers[j] == randomNumber)
                    {
                        Console.WriteLine("{0} 번째 값이랑 랜덤값 {1} 비교중 ",j, randomNumber);
                        isSame = true;
                        Console.WriteLine("같아!!!!!");
                        
                        break;
                    }
                    else
                    {
                        //nothing 
                    }
                }
                if(isSame == false) // 같은 수가 아니면,
                {
                    numbers[i]= randomNumber; // index i번에 랜덤 수 넣는다.
                    Console.WriteLine("{0} 번째에 랜덤값 {1} 넣음", i, randomNumber);
                    
                }
                else
                {
                    --i;
                }
                Console.WriteLine("index {0} 번째 숫자 다시 뽑자!", i);
            }




            // board 상태
            // -2 : 보드판 테두리 
            // -1 : 빈곳
            //  n : 숫자가 있는 곳

            for (int y = 0; y < BOARD_Y; y++)
            {
                for (int x = 0; x < BOARD_X; x++)
                {
                    // 보드판 테두리
                    if (y == 0 || x == 0 || y == BOARD_Y - 1 || x == BOARD_X - 1)
                    {
                        board[y, x] = -2; 
                    }// if : 테두리인 경우
                    else if (y == blankPosY && x == blankPosX)
                    {
                        board[y, x] = -1; // 빈곳 세팅
                    }// else if : 빈 칸 최초 랜덤 위치인 경우
                    else
                    {
                        board[y, x] = 0; //  숫자들이 들어갈 곳
                    }// else : 나머지 경우 
                }
            }// loop : 보드의 y,x 사이즈 만큼 반복 하며 설정.

            int numbersCount = 0;
            for (int y = 0; y < BOARD_Y; y++)
            {
                for (int x = 0; x < BOARD_X; x++)
                {
                    
                    switch (board[y, x])
                    {
                        case -2:
                            Console.Write("▦".PadRight(1, ' '));
                            break;
                        case -1:
                            Console.Write("□".PadRight(1, ' '));
                            break;
                        default:
                            
                            Console.Write("{0}".PadRight(4, ' '), numbers[numbersCount]);
                            numbersCount++;
                            break;
                    }//swith
                } //loop: 
                Console.WriteLine();
            } // loop : 현재 보드의 상태를 출력하는 루프
            Console.WriteLine();
            // } 현재 보드의 상태를 플레이 시점으로 보여준다.


        }
    }

}
