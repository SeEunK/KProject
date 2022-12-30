//System 이라는 어셈블리에서 이것저것 여러 기능을 가져와서 사용할거야.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 내 프로그램 이름이다. (내가 정한 이름)
namespace WhatIsArray
{
    // 클래스 라는것인데, c#에서는 모든 요소들이 클래스 안에있어야함.
    internal class Program
    {
        //무조건 1개는 있어야 함. --> C# 콘솔을 사용할때.
        static void Main(string[] args)
        {
            //// 프로그램은 여기서 부터 읽기 시작한다.
            //Console.WriteLine("Hello, World!");

            //int sumOfNum = 0;
            ////3의 배수를 제외한 수
            ////int variable_ = 100;
            ////(variable_ %3 == 0;)

            ////횟수가 정해진건 for가 편하고, 횟수가 정해지지 않은 경우 while 이 편함
            //for (int variable_ = 1; variable_ <= 100; variable_++)
            //{

            //    bool isRealMultipleOfThree = (variable_ % 3 == 0);
            //    Console.WriteLine("{0} -> isRealMultipleOfThree : {1}",
            //            variable_, isRealMultipleOfThree);


            //    // 1~100 숫자 중에서 3의 배수를 제외한 수의 합 구하기
            //    if (isRealMultipleOfThree == false)
            //    {
            //        //3의 배수가 아닌건 다 여기로 옴.
            //        // 여기서 값을 계속 더해주면되겠다.
            //        sumOfNum += variable_;
            //        Console.WriteLine("잘 더해지고있니? :{0}", sumOfNum);

            //    }
            //    else
            //    {
            //        // 3의 배수인것만 여기로 오고.
            //    }
            //} //loop: 100번 도는 루프

            ////루프가 끝나면 여기로 오니까, 다 끝날때 까지는 더해서 마지막 값을 눈으로 보고싶음
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("========================");
            //Console.WriteLine("sumOfNum : {0}", sumOfNum);
            //Console.WriteLine("========================");





            ////프로그램 사용자로 부터 양의 정수를 하나 입력 받아서,
            ////그 수만큼 "Hello world!"를 출력하는 프로그램 작성.

            //int someNumber = 100;
            //bool isPositiveInteger = (0 < someNumber);


            ///**
            // *프로그램 사용자로 부터 계속해서 정수를 입력받는다.
            // *그리고 그 값을 계속해서 더해 나간다.
            // *이러한 작업은 프로그램 사용자가 0을 입력할때 까지 계속되어야하며,
            // *0이 입력되면 입력된 모든 정수의 합을 출력하고 프로그램 종료.
            // */


            //bool isNumberZero = (someNumber == 0);

            ///**
            //* 프로그램 사용자로 부터 입력 받은 숫자에 해당하는 구구단을 출력하되, 
            //* 역순으로 출력하는 프로그램 작성.
            //*/

            //int userInputNum = 3;
            //for(int index = 9; 1<=index; index--)
            //{
            //    Console.WriteLine("{0} x {1} = {2}",userInputNum, index, userInputNum*index);
            //    //loop : 9번을 도는 루프
            //}



            ///**
            // *  복습. 
            // */

            //char scretCode = 'y';
            //char userInputAlphabet = 'c';
            //bool isSmallAlphabet = ('a' <= userInputAlphabet && userInputAlphabet <= 'z');

            //bool isAlphabetFore = (userInputAlphabet <= scretCode);
            //bool isAlphabetBack = (scretCode <= userInputAlphabet);

            //if (isSmallAlphabet)
            //{
            //    /*do nothing */                
            //}
            //else
            //{
            //    Console.WriteLine("{0}\n{1}","당신의 입력을 처리할수 없습니다.","알파벳 소문자만 입력하세요.");
            //}

            //if (isAlphabetFore)
            //{
            //    Console.WriteLine("당신의 알바벳은 시크릿 코드 보다 앞에있습니다.");
            //}
            //else 
            //{
            //    /*do nothing */
            //}

            //if (isAlphabetBack)
            //{
            //    Console.WriteLine("당신의 알바벳은 시크릿 코드 보다 뒤에있습니다.");
            //}
            //else
            //{
            //    /*do nothing */
            //}




            ///**
            // *  복습] 1~100 숫자 중에서 3의 배수이면서 4의 배수의 정수 합 구하기.
            // *  
            // *  
            // */
            //int sumNum = 0;
            //int somNum = 100;
            //bool isMultipleOfThree = (somNum % 3 == 0);
            //bool isMultipleOfFour = (somNum % 4 == 0);

            //bool isSatisfyCondition = isMultipleOfThree && isMultipleOfFour;

            //for (int i = 0; i <= somNum; i++) {
            //    if (isSatisfyCondition)
            //    {
            //        // if : 3 의 배수이면서 4의 배수인 값인 경우
            //        sumNum += someNumber;
            //        // 그 수의 합 
            //    }
            //}

            //Console.WriteLine("1~100 까지 3과 4의 배수 합은 {0} 이다.", sumNum);


            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //// 별을 100번 찍는 법

            //for (int index = 1; index <= 10; index++)
            //{
            //    for (int index2 = 1; index2 <= 10; index++)
            //    {
            //        Console.Write("{0}", "*");
            //    } //loop : 이건 밖의 루프가 1번 도는 동안 10번 도는 루프
            //    Console.WriteLine();
            //}//loop : 이건 10번 도는 루프


            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();


            //int hundredCount = 0;
            //for (int index = 1; index <= 10; index++)
            //{
            //    for (int index2 = 1; index2 <= 10; index2++)
            //    {
            //        for (int index3 = 1; index3 <= 10; index3++)
            //        {
            //            hundredCount++;
            //            if (100 <= hundredCount)
            //            {
            //                break;
            //            }
            //            else { }

            //            // 여기서 별을 찍는지점 
            //            Console.Write("{0}", "*");

            //            //여기서 10번 마다 한줄을 띄어준다.
            //            if(hundredCount %10 == 0)
            //            {
            //                Console.WriteLine();
            //            } //if: 별을 10번 찍을때 마다 한줄을 띄어주는 중.

            //        } //loop : 이건 밖의 루프가 1번 도는 동안 10번 도는 루프
            //    } //loop : 이건 밖의 루프가 1번 도는 동안 10번 도는 루프


            //}//loop : 이건 10번 도는 루프






            /**
             * 문제] =======================================================
             * 유저 입력 받아서 (1~20 줄 이내로 입력 받음)
             * 유저 입력은 줄, 단의 개수 임
             * 등차 수열로 한단이 내려 갈때 마다 별 1개씩 추가로 증가하는 프로그램 작성
             * 
             * ex) 유저 입력 : 5 인 경우
             *   *
             *   **
             *   ***
             *   ****
             *   *****
             *   
             */
            // 
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine();

            //int userInputNum = 0;
            //Console.Write("별을 찍을 단을 입력하세요: (1~20 이내 선택)");
            //int.TryParse(Console.ReadLine(), out userInputNum);


            //int upperTriangle = (userInputNum / 2) + 1;
            //int bottomTriangle = (userInputNum / 2);

            //for (int lineIndex = 1; lineIndex <= userInputNum; lineIndex++)
            //{ // 이건 유저가 입력한 줄 수만큼 도는 루프

            //    if (lineIndex <= upperTriangle)
            //    {
            //        //위에 삼각형
            //        for (int space = upperTriangle - lineIndex; space > 0; space--)
            //        { // 별 찍기 전에 띄어주기
            //            Console.Write(" ");
            //        }
            //        for (int point = 1; point < 2 * lineIndex; point++)
            //        {
            //            Console.Write("*");
            //        }// 여기서 별을 찍는지점
            //    }

            //    //위에 삼각형
            //    for (int space = 1; space <= userInputNum - lineIndex; space++)
            //    {
            //        // 별 찍기 전에 띄어주기
            //        Console.Write(" ");
            //    }
            //    for (int point = userInputNum - lineIndex + 1; point > 0; point--)
            //    {
            //        Console.Write("*");
            //    }// 여기서 별을 찍는지점


            //   


            //}





            // 문제 2.야구 ======================================================================
            if (true) {
                int[] computerNum = { 1, 2, 3 };

                int userNum1 = default;
                int userNum2 = default;
                int userNum3 = default;

                int maxCount = 9;

                Console.Write("0~9 숫자를 사용하여 3자리 숫자를 맞춰보세요. (기회는 {0}번 입니다)", maxCount);

                Console.WriteLine("/로 구분해서 입력하세요.");
                Console.WriteLine();

                for (int count = 1; count <= maxCount; count++) {
                    string userInputNumbers = Console.ReadLine();
                    string[] strUserInputNum = userInputNumbers.Split(new char[] { '/' });

                    int.TryParse(strUserInputNum[0], out userNum1);
                    int.TryParse(strUserInputNum[1], out userNum2);
                    int.TryParse(strUserInputNum[2], out userNum3);
                    int[] userNum = { userNum1, userNum2, userNum3 };


                    int strikeCount = 0;
                    int ballCount = 0;
                    int OutCount = 3 - strikeCount - ballCount;

                    for (int comNumIndex = 0; comNumIndex < userNum.Length; comNumIndex++)
                    {
                        for (int userNumIndex = 0; userNumIndex < userNum.Length; userNumIndex++)
                        {
                            if (comNumIndex == userNumIndex)
                            {
                                if (computerNum[comNumIndex] == userNum[userNumIndex])
                                {
                                    strikeCount++;
                                }
                            }
                            else if (computerNum[comNumIndex] == userNum[userNumIndex])
                            {
                                ballCount++;
                            }
                        }
                    }
                    if (strikeCount == 3)
                    {
                        Console.WriteLine("{0}/{1}/{2}는 {3}S 정답입니다.", userNum[0], userNum[1], userNum[2], strikeCount);
                        Console.WriteLine("=============종료=============");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("{0}/{1}/{2}는 {3}S| {4}B | {5}O 입니다.", userNum[0], userNum[1], userNum[2], strikeCount, ballCount, OutCount);
                        Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
                        Console.WriteLine("=============다시 입력하세요.=============");
                    }
                }

            }

            //if (isStrike[0] || isStrike[1] || isStrike[2])
            //{ //1개 이상 맞음.

            //if (isStrike[0] && isStrike[1] && isStrike[2])
            //{//0,1,2 번째 모두 맞았을때 (모두 스트라이크)

            //Console.WriteLine("{0}/{1}/{2}는 3S 정답입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("=============종료=============");
            //break;

            //}
            //else if (isStrike[0] && isStrike[1] || isStrike[1] && isStrike[2] || isStrike[0] && isStrike[2])
            //{//2개 스트라이크 상황

            //Console.WriteLine("{0}/{1}/{2}는 2S 입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");

            //}
            //else
            //{//1개 스트라이크 경우

            //if (computerNum[1] == userNum[2] && computerNum[2] == userNum[1]  //0번 자리 맞음
            //|| computerNum[0] == userNum[2] && computerNum[2] == userNum[0] //1번 자리 맞음
            //|| computerNum[0] == userNum[1] && computerNum[1] == userNum[0]) //2번 자리 맞음)
            //{//1개 스트라이크, 2개는 자리만 틀린경우

            //Console.WriteLine("{0}/{1}/{2}는 1S 2B입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}
            //else if (computerNum[0] == userNum[1] || computerNum[0] == userNum[2] 
            //|| computerNum[1] == userNum[2] || computerNum[1] == userNum[0] 
            //|| computerNum[2] == userNum[0] || computerNum[2] == userNum[1])
            //{//0번째 맞고, 1,2번 숫자는 맞지만 서로 자리만 틀린경우

            //Console.WriteLine("{0}/{1}/{2}는1S 1B입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}
            //else
            //{//0번째만 맞은경우 
            //Console.WriteLine("{0}/{1}/{2}는 1S 입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}
            //}

            //}
            //else //스트라이크 0개
            //{
            //if (maxCount - count ==0) // 기회 끝
            //{
            //Console.WriteLine("남은 기회가 없습니다.", maxCount - count);
            //Console.WriteLine("=============종료=============");
            //}
            ///*    else if (  computerNum[0] == userNum[1] && computerNum[1] == userNum[2] && computerNum[2] == use*/rNum[0]
            /*            || computerNum[0] == userNum[2] && computerNum[1] == userNum[0] && computerNum[2] == use*/
            // rNum[1]
            //)
            //{//3개 모두 자리만 틀린경우 

            //Console.WriteLine("{0}/{1}/{2}는 3B입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}
            //else if (   computerNum[2] == userNum[1] && computerNum[1] == userNum[0]                         
            //||  computerNum[2] == userNum[0] && computerNum[0] == userNum[1]
            //||  computerNum[1] == userNum[2] && computerNum[2] == userNum[1]
            //||  computerNum[1] == userNum[0] && computerNum[2] == userNum[1]
            //||  computerNum[0] == userNum[2] && computerNum[2] == userNum[0]  
            //||  computerNum[0] == userNum[1] && computerNum[1] == userNum[0]) 
            //{//2개는 자리만 틀린경우

            //Console.WriteLine("{0}/{1}/{2}는  2B입니다.", userNum[0], userNum[1], userNum[2]);                           
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}

            //else if(computerNum[1] == userNum[2] || computerNum[2] == userNum[1]
            //|| computerNum[0] == userNum[1] || computerNum[0] == userNum[2]
            //|| computerNum[1] == userNum[0])
            //{ // 1볼
            //Console.WriteLine("{0}/{1}/{2}는  1B입니다.", userNum[0], userNum[1], userNum[2]); 
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}
            //else
            //{// 숫자, 자리 모두 틀림.
            //Console.WriteLine("{0}/{1}/{2}는 3O 입니다.", userNum[0], userNum[1], userNum[2]);
            //Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //Console.WriteLine("=============다시 입력하세요.=============");
            //}
            //}


            /**-----------------------------------------------------------------------------------------------------
             * 컬렉션 
             * 이름 하나로 데이터 여러개를 담을수 있는 자료 구조를 컬렉션 (collection) 또는 컨테이너(containner)라고 한다.
             * C#애서 다루는 컬렉션은 배열 (array), 리스트 (list), 사전(Dictionary)등이 있다.
             * 
             * 배열
             * 배열 (array)은 같은 종류의 데이터들이 순차적을 메모리에 저장되는 자료 구조이다.
             * 각각의 데이터들은 인덱스(번호)를 사용하여 독립적으로 접근된다.
             * 배열을 사용하면 편리하게 데이터를 모아서 관리할수있다.
             * 
             * 배열의 특징들
             * 1. 배열 하나에는 데이터 형식 한 종류만 보관할수 있다.
             * 2. 배열은 메모리의 연속된 공간을 미리 할당하고, 이를 대괄호 ([])와 0부터 시작하는 정수형 인덱스를
             * 사용하여 접근할수있다.
             * 3. 배열을 선언할때는 new 키워드로 배열을 생성한 후 사용할수있다.
             * 4. 배열에서 값 하나는 요소(element) 또는 항목(Item)으로 표현한다.
             * 5. 필요한 데이터 개수를 정확히 정한다면 메모리를 적게 사용하여 프로그램 크기가 작아지고 성능이 향상된다.
             * 
             * 
             * 배열에는 3가지 종류가 있다.
             * - 1차원 배열 : 배열의 첨자를 하나만 사용하는 배열.
             * - 다 차원 배열 : 첨자 2개 이상을 사용하는 배열(2차원, 3차원, ....,n차원 배열)
             * - 가변 (Jagged) 배열: '배열의 배열'이라고도 하며, 이름 하나로 다양한 차원의 배열을 표현할때 사용된다.
             * 
             *
             *
             */

            // ---- 배열의 선언과 초기화 --------------------------------------------------
            //int[] numbers = new int[5] { 100, 200, 300, 400, 500 };
            ////Console.WriteLine(numbers[0]);
            ////Console.WriteLine(numbers[numbers.Length - 1]); // 총개수 모를때 마지막 값 가져오기



            ////for(int index = 0; index< numbers.Length; index++)
            ////{
            ////    Console.WriteLine("{0}",numbers[index]);

            ////}

            ////foreach(int element in numbers)
            ////{
            ////    Console.Write("{0}", element);

            ////}

            ////int number1 = 1;
            ////int number2 = 2;
            ////int number3 = 3;
            ////int number4 = 4;
            ////int number5 = 5;

            //Console.WriteLine(numbers);

            //**22-12-22 -----------------------------------------------------------------------------

            //** 모드연산? ============================================================================

            //  int number = 1_8021;
            //  Console.WriteLine("64를 Mod 연상:{0}", number % 64);

            //** ======================================================================================

            /**
             * 다차원 배열 
             * 2차원 배열, 3차원 배열 처럼 차원이 2개 이상인 배열을 다차원 배열이라고 한다.
             * c# 에서 배열을 선언할때는 콤마를 기준으로 차원을 구분한다.
             * 
             */
        

         if (false)
            {
        
            int[] oneArray = new int[2] { 1, 2 }; //1차원 배열 (element 2개를 담을 수 있는 배열)
            int[,] twoArray = new int[2, 2] { { 1, 2 }, { 3, 4 } }; // 2차원 배열 (element 2개를 담을 수 있는 배열 2개 있다)
            int[,] twoArray1 = new int[2, 3] { { 1, 2, 3 }, { 3, 4, 5 } }; // 2차원 배열 (element 3개를 담을 수 있는 배열 2개 있다)
            int[,] twoArray2 = new int[3, 2] { { 1, 2 }, { 3, 4 }, { 5, 6 } }; // 2차원 배열 (element 2개를 담을 수 있는 배열 3개 있다)
            int[,,] threeArray = new int[2, 2, 2]
            {
                { { 1, 2 }, { 3, 4 } },
                { { 1, 2 }, { 3, 4 } }
            }; // 3차원 배열 

            // 3행 3열짜리 배열에서 행과 열이 같으면 1, 다르면 0을 출력

            int[,] twoArray3 = new int[3, 3];

           
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        if (x == y) { twoArray3[y, x] = 1; }
                        else { twoArray3[y, x] = 0; }
                        Console.Write("{0}", twoArray3[y, x]);
                    }
                    Console.WriteLine();
                }
            
                for (int y = 0; y <= twoArray3.GetUpperBound(0); y++)
                {
                    for (int x = 0; x <= twoArray3.GetUpperBound(1); x++)
                    {
                        if (x == y) { twoArray3[y, x] = 1; }
                        else { twoArray3[y, x] = 0; }
                        Console.Write("{0}", twoArray3[y, x]);
                    }
                    Console.WriteLine();
                }  // loop: 값을 출력하는 루프
            }


            /**
             * 가변 배열 ===================================================================================
             * 차원이 2개 이상인 배열은 다차원 배열이고, 배열 길이가 가변 길이인 배열은 가변 배열이라고 한다.
             * 
            */
            if (false)
            {
                int[][] zagArray = new int[2][];
                zagArray[0] = new int[2] { 1, 2 };
                zagArray[1] = new int[3] { 3, 4, 5 };

                for (int y = 0; y < 2; y++)
                {
                    for (int x = 0; x < zagArray[y].Length; x++)
                    {
                        Console.Write("{0} ", zagArray[y][x]);
                    }
                    Console.WriteLine();
                }
            }

            if (false)
            {
                int[] intArray;         //int형 데이터 타입의 intArray라는 배열을 선언
                intArray = new int[3];  //int형 데이터 타입의 변수를 3개 메모리에 할당.

                intArray[0] = 1;  //intArray 0번째 인덱스에 1이라는 정수값을 대입
                intArray[1] = 2;  //intArray 1번째 인덱스에 2라는정수값을 대입
                intArray[2] = 3;  //intArray 2번째 인덱스에 3라는정수값을 대입

                //배열 직접 출력해본다
                for (int index = 0; index < 3; index++)
                {
                    Console.WriteLine("{0} 번째 인덱스의 값 -> {1}", index, intArray[index]);
                } //loop :3번 도는 루프
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();


                //intArray 배열에서 int 형 데이터 타입의 값을 하나씩 뽑아서 index에 저장할거임.
                foreach (int index in intArray)
                {
                    Console.WriteLine("intArray배열에서 뽑아온 값 -->{0}", index);
                } //loop: intArray 배열의 길이만큼 도는 루프

            }

            //**실습 1) =====================================================================
            // 배열을 사용하여, 국어점수의 총점과 평균 구하기.
            // 학생 3명의 점수를 저장하는 배열 선언해서, 각 학생별로 점수를 할당하고 (범위 1~100점)
            // 모든 점수의 총점과 평균을 구해서 출력하는 프로그램.
            // --> user input 받아서 처리해볼것.
            // - 조건) 유저 input 은 3회 
            // - 점수 범위 : 1~100점
            // - 이상한 입력 예외처리

            if (false)
            {
                int[] intScoreArray;         //int형 데이터 타입의 intArray라는 배열을 선언
                intScoreArray = new int[3];  //int형 데이터 타입의 변수를 3개 메모리에 할당.

                int sumNum = 0;
                int average = sumNum / intScoreArray.Length;
                int isInputSuccess = 0;
                while (isInputSuccess != 3)
                { //성공적인 입력이 3번 일경우까지 돌면서 점수 인풋 받기.
                    Console.WriteLine("국어 점수를 입력하세요. (점수 1~100 숫자로 입력하세요):");

                    string strInputNum = Console.ReadLine();

                    if (!int.TryParse(strInputNum, out intScoreArray[isInputSuccess]))
                    {
                        Console.WriteLine("숫자가 아닙니다. 다시 입력하세요.");
                    }
                    else
                    {
                        sumNum += intScoreArray[isInputSuccess]; // 더하기
                        isInputSuccess++;
                    }
                }
                Console.WriteLine("점수의 총점 : {0} ", sumNum);
                Console.WriteLine("점수의 평균 : {0} ", sumNum / intScoreArray.Length);
            }

            /* [lab 1. 배열에서 최대값 찾기 ] ====================================================================
             * 크기가 100인 배열을 1부터 100 사이의 난수로 채우고 배열 요소 중에서 최대값을 찾는 프로그램 작성.
             *  - 보기 좋게 출력하라(가독성 높아야함)
             *
             */
            if (false)
            {
                int[] hundredArray; // 배열 선언
                hundredArray = new int[100]; //크기가 100인 배열 할당

                Random random = new Random();
                int maxNum = 0;
                for (int count = 0; count < 100; count++)
                {
                    hundredArray[count] = random.Next(1, 100 + 1); //램덤 1~100 사이 값 생성 해서 배열 0 번째 부터 입력
                    if (hundredArray[count] > maxNum) // maxNum 과 비교 해서 큰지 체크
                    {
                        maxNum = hundredArray[count];   //maxNum 보다 크니까, maxNum 갱신.
                    }

                } //100번 랜덤 값 뽑고 배열에 넣는 루프

                //출력하기.
                Console.Write("hundredArray [100]:{");
                for (int index = 0; index < 100; index++)
                {
                    if (index == 99)
                    {
                        Console.Write("{0}", hundredArray[index]);
                    }
                    else
                    {
                        Console.Write("{0},", hundredArray[index]);
                    }

                } //loop: hundredArray 배열의 길이만큼 도는 루프

                Console.WriteLine("}");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("hundredArray 의 최대값은 {0} 입니다.", maxNum);
                Console.WriteLine("-------------------------------------------------------------------------");
            }

            /* [lab 2. 사과를 제일 좋아하는 사람찾기 ] =============================================================
             * 사람들 5명(사람1, 사람2,..., 사람 5)에게 아침에 먹는 사과 개수를 입력하도록 요총하는 프로그램 작성
             *  데이터 입력이 마무리 되면, 누가 가장 많은 사과를 아침으로 먹었는지 출력한다. (기본형)
             *  - 이상한 입력 예외처리
             *  - 제일 적게 먹은 사람도 찾도록 수정해보기. (변형1.)
             *  - 먹은 사과의 개수 순으로 정렬 : 정렬 알고리즘사용 
             *     : 정렬 할때는 유저 입력 x .
             *     : 데이터는 난수로 100~1000개 정도의 값.
             *     : 중복 제거.
             *     : 시간초는 전혀 상관없음.
             *     ->  알고리즘 잘모른다면 버블 정렬을 도전 해볼것. (변형2.)
             *     ->  알고리즘 잘 알겠다면 Merge sort 도전 해볼것. (어려움)
             *  
             *
             */

            // Q2 -1 ) 기본형 + 입력 예외처리, 변형 1 까지 ==================================================================
            if (false)
            {
                int[] intAppleArray;
                intAppleArray = new int[5];

                int maxCountNum = 0;
                int minCountNum = 0;
                int appleLikePersonIndex = 0; //사과 가장 좋아하는 사람 index 저장용 변수
                int appleHatePersonIndex = 0; //사과 가장 싫어하는 사람 index 저장용 변수

                int isInputSuccess = 0;
                while (isInputSuccess != 5)
                { //성공적인 입력이 5번 일경우까지 돌면서 점수 인풋 받기.
                    Console.WriteLine("사람 {0} 님,아침에 먹은 사과의 개수를 입력하세요. (개수만 숫자로 입력하세요)", isInputSuccess+1);

                    string strInputCount = Console.ReadLine();

                    if (!int.TryParse(strInputCount, out intAppleArray[isInputSuccess]))
                    {
                        Console.WriteLine("숫자가 아닙니다. 다시 입력하세요.");
                    }
                    else
                    {
                        
                        if (intAppleArray[isInputSuccess] > maxCountNum) // maxCountNum 과 비교 해서 큰지 체크
                        {
                            maxCountNum = intAppleArray[isInputSuccess];   //maxCountNum 보다 크니까, maxCountNum 갱신.
                            appleLikePersonIndex = isInputSuccess; // 몇번째 사람인지 index 저장.
                            if(isInputSuccess == 0) 
                            {
                                minCountNum = maxCountNum; 
                            }
                        }
                        else if(intAppleArray[isInputSuccess] < minCountNum)
                        {
                            minCountNum = intAppleArray[isInputSuccess];   //minCountNum 보다 적으면, minCountNum 갱신.
                            appleHatePersonIndex = isInputSuccess; // 몇번째 사람인지 index 저장.
                        }
                            
                        isInputSuccess++;
                    }
                }
                Console.WriteLine("제일 사과를 가장 많이 먹은 사람은 [{0}개를 먹은 {1} 번째 사람] 입니다. ", intAppleArray[appleLikePersonIndex], appleLikePersonIndex +1);
                Console.WriteLine("제일 사과를 가장 적게 먹은 사람은 [{0}개를 먹은 {1}번째 사람] 입니다. ", intAppleArray[appleHatePersonIndex], appleHatePersonIndex +1);
            }


            // Q2 - 2 )  ==================================================================
            /*     -먹은 사과의 개수 순으로 정렬 : 정렬 알고리즘사용
             *     : 정렬 할때는 유저 입력 x.
             *     : 데이터는 난수로 100~1000개 정도의 값.
             *     : 중복 제거.
             *     : 시간초는 전혀 상관없음.
             *     ->알고리즘 잘모른다면 버블 정렬을 도전 해볼것. (변형2.)
             *     ->알고리즘 잘 알겠다면 Merge sort 도전 해볼것. (어려움 > 변형 3.)
             *
             **/

            // (변형2.) 버블 정렬 ==============================================================
            if (false)
            {
                int[] intAppleRandomArray;
                intAppleRandomArray = new int[100];

                int[] intAppleSortArray;
                intAppleSortArray = new int[100];
                int tempNum = 0;
                int seedNum = 0;

                int arraySize = intAppleRandomArray.Length;
                Random random = new Random(Seed: seedNum);
              
                for (int arrayIndex = 0; arrayIndex < arraySize; arrayIndex++)
                {

                    seedNum = random.Next(1, 100 + 1);
                    bool isDuplication = false;
                    if(arrayIndex>0 && arrayIndex< arraySize)
                    {
                        for (int tempIndex = 0; tempIndex <= arrayIndex; tempIndex++)
                        {
                            if(intAppleRandomArray[tempIndex] == seedNum)
                            {
                                isDuplication = true; //
                            }

                        }
                    }
                    if (isDuplication) // 중복인 경우
                    {
                        --arrayIndex; // 현재인덱스 다시 뽑기.
                    }
                    else
                    { //중복아니면 넣기!
                        intAppleRandomArray[arrayIndex] = seedNum;
                    }
                    //intAppleRandomArray[arrayIndex] = random.Next(1, 100+1); //램덤 1~100 사이 값 생성 해서 배열 0 번째 부터 입력
                    
                } // 랜덤 생성해서 우선 배열에 넣기.


                //출력하기 
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("정렬 전 | intAppleRandomArray [100]: ");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("{");
                for (int index = 0; index < 100; index++)
                {
                    if (index == 99)
                    {
                        Console.Write("{0}", intAppleRandomArray[index]);
                    }
                    else
                    {
                        Console.Write("{0},", intAppleRandomArray[index]);
                    }
                    if (index > 8 && (index + 1) % 10 == 0)
                    {
                        Console.WriteLine(); //10개 마다 줄바꿈.
                    }


                } //loop: intAppleRandomArray 배열의 길이만큼 도는 루프

                Console.WriteLine("}");
                Console.WriteLine("-------------------------------------------------------------------------");
                               

                // 배열 인덱스 n 과 n+1 값을 비교해서 큰수을 앞으로 변경.
                for (int compareCount = 1; compareCount < arraySize;  compareCount++)
                {
                    for (int sortCount = 0; sortCount < arraySize; sortCount++)
                    {
                        if (intAppleRandomArray[compareCount] < intAppleRandomArray[sortCount]) // 정렬이 안된 배열의 n번째와 n+1번째와 값 비교
                        {
                            tempNum = intAppleRandomArray[compareCount];   //임시에 n 번재 값 넣어두고.
                            intAppleRandomArray[compareCount] = intAppleRandomArray[sortCount]; //n 번째에 n+1 번째 값 넣어두고.
                            intAppleRandomArray[sortCount] = tempNum; //n+1 번째에 임시에 넣어둔 값 넣기.
                        }
                    }
                }
                //출력하기 
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("정렬 후 | intAppleRandomArray [100]: ");
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("{");
                for (int index = 0; index < arraySize; index++)
                {
                    if (index == arraySize -1)
                    {
                        Console.Write("{0}", intAppleRandomArray[index]);
                    }
                    else
                    {
                        Console.Write("{0},", intAppleRandomArray[index]);
                    }
                    if(index > 8 && (index+1)% 10 == 0)
                    {
                        Console.WriteLine(); //10개 마다 줄바꿈.
                    }

                } //loop: intAppleRandomArray 배열의 길이만큼 도는 루프

                Console.WriteLine("}");
                Console.WriteLine("-------------------------------------------------------------------------");
            }

            // (어려움 > 변형 3.) Merge sort ========================================================================

            if (false)
            {

                int mergeSortArraySeed = 0;

                int[] intUnSortArray;
                intUnSortArray = new int[100];

                int[] intSortArray;

                int arraySize = intUnSortArray.Length;
                Random random = new Random(Seed: mergeSortArraySeed);

                for (int arrayIndex = 0; arrayIndex < arraySize; arrayIndex++)
                {
                    mergeSortArraySeed = random.Next(1, 100 + 1);
                    bool isDuplication = false;
                    if (arrayIndex > 0 && arrayIndex < arraySize)
                    {
                        for (int tempIndex = 0; tempIndex <= arrayIndex; tempIndex++)
                        {
                            if (intUnSortArray[tempIndex] == mergeSortArraySeed)
                            {
                                isDuplication = true; //
                            }

                        }
                    }
                    if (isDuplication) // 중복인 경우
                    {
                        --arrayIndex; // 현재인덱스 다시 뽑기.
                    }
                    else
                    { //중복아니면 넣기!
                        intUnSortArray[arrayIndex] = mergeSortArraySeed;
                    }

                } // 랜덤 생성해서 우선 배열에 넣기.

                printArray("정렬전", nameof(intUnSortArray), intUnSortArray);

                if (false)  // 출력문 함수로 빼고 이건 안타게 함.
                {
                    //출력하기(정렬 전)   =====================================================================
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("정렬 전 | intUnSortArray [100]: ");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("{");
                    for (int index = 0; index < 100; index++)
                    {
                        if (index == 99)
                        {
                            Console.Write("{0}", intUnSortArray[index]);
                        }
                        else
                        {
                            Console.Write("{0},", intUnSortArray[index]);
                        }
                        if (index > 8 && (index + 1) % 10 == 0)
                        {
                            Console.WriteLine(); //10개 마다 줄바꿈.
                        }
                    } //loop: intUnSortArray 배열의 길이만큼 도는 루프

                    Console.WriteLine("}");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    //============================================================================================

                }

                // mergeSort 함수에 정렬전의 배열(intUnSortArray) 넘기고, intSortArray에 담기.
                intSortArray = mergeSort(intUnSortArray);

                printArray("정렬후",nameof(intSortArray), intSortArray);

                if (false) // 출력문 함수로 빼고 이건 안타게 함.
                {
                    //출력하기 (mergeSort 정렬 후) ==================================================================
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("정렬 후 | intSortArray [100]: ");
                    Console.WriteLine("-------------------------------------------------------------------------");
                    Console.WriteLine("{");
                    for (int index = 0; index < arraySize; index++)
                    {
                        if (index == arraySize - 1)
                        {
                            Console.Write("{0}", intSortArray[index]);
                        }
                        else
                        {
                            Console.Write("{0},", intSortArray[index]);
                        }
                        if (index > 8 && (index + 1) % 10 == 0)
                        {
                            Console.WriteLine(); //10개 마다 줄바꿈.
                        }

                    } //loop: intSortArray 배열의 길이만큼 도는 루프

                    Console.WriteLine("}");
                    Console.WriteLine("-------------------------------------------------------------------------");
                }
            }
            //============================================================================================
        }
        public static int[] mergeSort(int[] unsortArray)
        {
            int[] leftArray;
            int[] rightArray;
            int[] resultArray = new int[unsortArray.Length];

            if (unsortArray.Length <= 1)
            {
                return unsortArray; 
            }
            
            int midIndex = unsortArray.Length / 2;
            leftArray = new int[midIndex];
            
            if (unsortArray.Length%2 == 0)
            {
                rightArray = new int[midIndex];
            }
            else
            {
                rightArray = new int[midIndex+1];
            }

            for (int leftArrayIndex = 0; leftArrayIndex < midIndex; leftArrayIndex++)
            {
                leftArray[leftArrayIndex] = unsortArray[leftArrayIndex];
            }
            
            int tempIndex = 0;
            for (int RightIndex = midIndex; RightIndex < unsortArray.Length; RightIndex++)
            {
                rightArray[tempIndex] = unsortArray[RightIndex];
                tempIndex++;
            }
            leftArray = mergeSort(leftArray);
            rightArray = mergeSort(rightArray);
            resultArray = merge(leftArray, rightArray);
            return resultArray;
        }

        public static int[] merge(int[] left, int[] right)
        {
            int resultLength = right.Length + left.Length;
            int[] mergeResult = new int[resultLength];

            int leftIndex = 0;
            int rightIndex = 0;
            int resultIndex = 0;

            while(leftIndex<left.Length || rightIndex < right.Length)
            {
                if (leftIndex < left.Length && rightIndex < right.Length)
                {
                    if (left[leftIndex]<= right[rightIndex])
                    {
                        mergeResult[resultIndex] = left[leftIndex];
                        leftIndex++;
                        resultIndex++;
                    }
                    else
                    {
                        mergeResult[resultIndex] = right[rightIndex];
                        rightIndex++;
                        resultIndex++;
                    }
                }
                else if(leftIndex < left.Length)
                {
                    mergeResult[resultIndex] = left[leftIndex];
                    leftIndex++;
                    resultIndex++;
                }
                else if (rightIndex < right.Length)
                {
                    mergeResult[resultIndex] = right[rightIndex];
                    rightIndex++;
                    resultIndex++;
                }
            }
            return mergeResult;
        }


        public static void printArray(string result,string arrayName ,int[] array)
        {
            
            //출력하기 ===========================================================================================
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("{2} | {0} [{1}]: ", arrayName, array.Length, result) ;
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("{");
            for (int index = 0; index < array.Length; index++)
            {
                if (index == array.Length - 1)
                {
                    Console.Write("{0}", array[index]);
                }
                else
                {
                    Console.Write("{0},", array[index]);
                }
                if (index > 8 && (index + 1) % 10 == 0)
                {
                    Console.WriteLine(); //10개 마다 줄바꿈.
                }

            } //loop: Array 배열의 길이만큼 도는 루프

            Console.WriteLine("}");
            Console.WriteLine("-------------------------------------------------------------------------");
        }

    }
}