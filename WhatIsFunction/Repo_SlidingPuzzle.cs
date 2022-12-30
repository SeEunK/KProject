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
            int blankPosY = random.Next(1, BOARD_Y - 1);
            int blankPosX = random.Next(1, BOARD_X - 1);


            int mixNumbersArraySize = (BOARD_X - 2) * (BOARD_Y - 2);
            int[] mixNumbersArray = new int[mixNumbersArraySize - 1];
            //int[] cheetNum = { 1, 2, 3, 4, 5, 6, 7, 8 }; // 보드판 검증 코드 테스트를 위해 임시로 만듦.

            int tryCount = 0; // 움직인 횟수 체크용 변수.
            // 0부터 numbersArray 배열의 사이즈 만큼 돈다.
            for (int i = 0; i < mixNumbersArraySize - 1; i++)
            {
                while (true)
                {
                    int randomNum = random.Next(1, mixNumbersArraySize); // 1~ 8 랜덤 인덱스를 뽑자. 
                    //int randomNum = cheetNum[i];  // 보드판 검증 코드 테스트를 위해 임시 코드
                    //Console.WriteLine("랜덤으로 뽑은 값: {0}", randomNum); //랜덤 값 확인용 .

                    bool isFindSameNum = false;
                    // 이미 뽑힌 수의 인덱스 0 부터 반복
                    for (int j = 0; j <= i; j++)
                    {

                        if (mixNumbersArray[j] == randomNum)
                        {
                            isFindSameNum = true;
                            //Console.WriteLine("같은 값이 있음!");
                            break;
                        }
                    }
                    // 랜덤으로 뽑은 수와 같은 수를 찾지 못한 경우.
                    if (isFindSameNum == false)
                    {
                        mixNumbersArray[i] = randomNum;
                        // Console.WriteLine("{0}번째 인덱스에 {1} 넣음", i, randomNum); //랜덤하게 배열에 들어갔나 확인용 
                        break;
                    }
                }
            }

            // board 상태
            // -2 : 보드판 테두리 
            // -1 : 빈곳
            //  n : 숫자가 있는 곳
            int numberCount = 0;
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
                        board[y, x] = mixNumbersArray[numberCount]; //  나머지 숫자들이 들어갈 곳에 mixNumbersArray을 0 부터 넣어준다.
                        numberCount++; //mixNumbersArray index 증가 
                    }// else : 나머지 경우 
                }
            }// loop : 보드의 y,x 사이즈 만큼 반복 하며 설정.

            BoardDraw(BOARD_Y, BOARD_X, board, tryCount); //보드 그리는 함수 호출.
            Console.WriteLine("[system] : WASD 키로 움직이세요"); //가이드 문구 출력.

            while (true)
            {
                bool isNotMove = false; // 움직일수없는 경우 체크 용 bool 타입 변수
                
                //string userInput = Console.ReadLine(); // 입력하고 엔터치고 반복하다보니 테스트가 힘들어서...
                ConsoleKeyInfo key = Console.ReadKey();  // Console.ReadKey()로 바꿈.
                BoardDraw(BOARD_Y, BOARD_X, board, tryCount);
                tryCount++;
                //switch (userInput)
                switch (key.Key)
                {
                    //case "A": case "a": //<-
                    case ConsoleKey.A:
                        if (blankPosX - 1 == 0)
                        { // if : 왼쪽으로 가려할때 X좌표가 0으로 벽이라 못움직임.
                            isNotMove = true;
                            tryCount--; // 이동 못했으니 ++한것 차감
                            //Console.WriteLine("[system] : 움직일 수 없습니다.");
                        }
                        else
                        {
                            // 빈 공간 좌표 자리에, 왼쪽에 있던 값을 넣어준다.
                            board[blankPosY, blankPosX] = board[blankPosY, blankPosX - 1];

                            blankPosX = blankPosX - 1; // 빈공간의 X좌표를 -1 해준다.
                            board[blankPosY, blankPosX] = -1; //바뀐 빈공간 좌표를 -1 상태로 바꿈.
                            isNotMove = false;
                        }
                        break;
                        //case "W": case "w": //^
                    case ConsoleKey.W:
                        if (blankPosY - 1 == 0)
                        { // if : 위로 가려할때 Y좌표가 0으로 벽이라 못움직임.
                            isNotMove = true;
                            tryCount--; // 이동 못했으니 ++한것 차감
                            //Console.WriteLine("[system] :움직일 수 없습니다.");
                        }
                        else
                        {
                            // 빈 공간 좌표 자리에, 위쪽에 있던 값을 넣어준다.
                            board[blankPosY, blankPosX] = board[blankPosY-1, blankPosX];

                            blankPosY = blankPosY - 1; // 빈공간의 Y좌표를 -1 해준다.
                            board[blankPosY, blankPosX] = -1; //바뀐 빈공간 좌표를 -1 상태로 바꿈.
                            isNotMove = false;
                        }
                        break;
                    //case "S": case "s": //v
                    case ConsoleKey.S:
                        if (blankPosY + 1 == BOARD_Y - 1)
                        { // if : 아래로 가려할때 Y좌표가 맨 아래(BOARD_Y-1) 벽이라 못움직임.
                            isNotMove = true;
                            tryCount--; // 이동 못했으니 ++한것 차감
                            //Console.WriteLine("[system] :움직일 수 없습니다.");
                        }
                        else
                        {
                            // 빈 공간 좌표 자리에, 아래쪽에 있던 값을 넣어준다.
                            board[blankPosY, blankPosX] = board[blankPosY + 1, blankPosX];

                            blankPosY = blankPosY + 1; // 빈공간의 Y좌표를 +1 해준다.
                            board[blankPosY, blankPosX] = -1; //바뀐 빈공간 좌표를 -1 상태로 바꿈.
                            isNotMove = false;
                        }
                        break;
                    //case "D": case "d": //-->
                    case ConsoleKey.D:
                        if (blankPosX + 1 == BOARD_X - 1)
                        { // if : 오른쪽으로 가려할때 X좌표가 맨 오른쪽(BOARD_X-1) 벽이라 못움직임.
                            isNotMove = true;
                            tryCount--; // 이동 못했으니 ++한것 차감
                            //Console.WriteLine("[system] :움직일 수 없습니다.");
                        }
                        else
                        {
                            // 빈 공간 좌표 자리에, 오른쪽에 있던 값을 넣어준다.
                            board[blankPosY, blankPosX] = board[blankPosY, blankPosX + 1];

                            blankPosX = blankPosX + 1; // 빈공간의 X좌표를 +1 해준다.
                            board[blankPosY, blankPosX] = -1; //바뀐 빈공간 좌표를 -1 상태로 바꿈.
                            isNotMove = false;
                        }
                        break;
                }
                if (isNotMove == true)
                {
                    Console.WriteLine("[system] : 움직일 수 없습니다.");
                    Console.WriteLine("[system] : WASD 키로 움직이세요");
                }
                else
                {
                    BoardDraw(BOARD_Y, BOARD_X, board, tryCount); // 새로 보드 그리기.
                    
                    if (BoadCheck(BOARD_Y, BOARD_X, board)) // 보드 완성(BoadCheck 함수에서 검증)이 true 면,
                    {
                        Console.WriteLine("[system] : COMPLETE!!!!!"); // 완성 결과 표시
                        break;  // while 문 나가기 (게임 종료)
                    }
                    else
                    {
                        Console.WriteLine("[system] : WASD 키로 움직이세요");
                    }
                }
            }
        }
        // 보드 그리는 함수.
        static void BoardDraw(int boardY, int boadX, int[,] board,int tryCount)
        {
            Console.Clear(); // 이전 내용 지우고,

            for (int y = 0; y < boardY; y++) //보드Y 사이즈만큼 반복
            {
                for (int x = 0; x < boadX; x++) //보드X 사이즈만큼 반복
                {
                    switch (board[y, x]) // swith (보드 y,x 의 값)
                    {
                        case -2: //벽
                            Console.Write("▦".PadRight(1, ' '));
                            break;
                        case -1: //빈공간 
                            Console.Write("□".PadRight(1, ' '));
                            break;
                        default: //나머지
                            int value = board[y, x]; //보드[y,x] 값 변수에 넣고 
                            Console.Write("{0}".PadRight(4, ' '), value); //그 변수 값 출력.

                            break;
                    }//swith
                } //loop: 
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("================================");
            Console.WriteLine("▶ 이동 횟수 : {0}", tryCount);
            Console.WriteLine("================================");
        }

        static bool BoadCheck(int boardY, int boardX, int[,] board)
        {
            int endPosY = boardY - 2; // 블랭크의 마지막 위치는 체크하지않기위해 end Y 좌표를 만듦.
            int endPosX = boardX - 2; // 블랭크의 마지막 위치는 체크하지않기위해 end X 좌표를 만듦.

            int tempNum = 0; // 비교할 숫자 담을 변수
            for (int y = 1; y < boardY-1; y++)
            {
                for(int x= 1; x < boardX - 1; x++)
                {
                    if(x == endPosX && y == endPosY)
                    {// x,y가 앤드 좌표와 동일할 경우 
                        return true;
                    }
                    else if (tempNum +1 == board[y, x])
                    {// 비교 값(이전값)에 1더한 값이 현재 좌표의 값이 같은 경우
                        tempNum = board[y, x]; // 비교값 현재 값으로 갱신해주고 
                    }
                    else
                    { // 비교 값(이전값)에 1더한 값이 현재 좌표의 값이 같지않은 경우 완성 검증 실패로 false 반환.
                        return false;
                    }
                }
            }
            return true;
        }

    }

}
