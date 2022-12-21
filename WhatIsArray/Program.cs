//System 이라는 어셈블리에서 이것저것 여러 기능을 가져와서 사용할거야.
using System;
using System.Net.Sockets;

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





            //문제 2. 야구 ======================================================================

            //int[] computerNum = { 1, 2, 3 };


            //int userNum1 = default;
            //int userNum2 = default;
            //int userNum3 = default;

           
            


            //int maxCount = 9;

            //Console.Write("0~9 숫자를 사용하려 3자리 숫자를 맞춰보세요. (기회는 {0}번 입니다)", maxCount);

            //Console.WriteLine("/로 구분해서 입력하세요.");
            //Console.WriteLine();

            //for (int count = 1; count <= maxCount; count++) {
            //    string userInputNumbers = Console.ReadLine();
            //    string[] strUserInputNum = userInputNumbers.Split(new char[] { '/' });

            //    int.TryParse(strUserInputNum[0], out userNum1);
            //    int.TryParse(strUserInputNum[1], out userNum2);
            //    int.TryParse(strUserInputNum[2], out userNum3);
            //    int[] userNum = { userNum1, userNum2, userNum3 };

            //    if (computerNum[0] == userNum[0] || computerNum[1] == userNum[1] || computerNum[2] == userNum[2])
            //    { //1개 이상 맞음.


            //        if (computerNum[0] == userNum[0] && computerNum[1] == userNum[1] && computerNum[2] == userNum[2])
            //        {//0,1,2 번째 모두 맞았을때 (모두 스트라이크)


            //            Console.WriteLine("{0}/{1}/{2}는 3S 정답입니다.", userNum[0], userNum[1], userNum[2]);
            //            Console.WriteLine("=============종료=============");
            //            break;

            //        }
            //        else if (computerNum[0] == userNum[0] && computerNum[1] == userNum[1] 
            //            || computerNum[1] == userNum[1] && computerNum[2] == userNum[2] 
            //            || computerNum[0] == userNum[0] && computerNum[2] == userNum[2])
            //        {//2개 스트라이크 상황

            //            Console.WriteLine("{0}/{1}/{2}는 2S 입니다.", userNum[0], userNum[1], userNum[2]);
            //            Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //            Console.WriteLine("=============다시 입력하세요.=============");

            //        }
            //        else
            //        {//1개 스트라이크 경우

            //            if (computerNum[1] == userNum[2] && computerNum[2] == userNum[1]  //0번 자리 맞음
            //                    || computerNum[0] == userNum[2] && computerNum[2] == userNum[0] //1번 자리 맞음
            //                    || computerNum[0] == userNum[1] && computerNum[1] == userNum[0]) //2번 자리 맞음)
            //            {//1개 스트라이크, 2개는 자리만 틀린경우

            //                Console.WriteLine("{0}/{1}/{2}는 1S 2B입니다.", userNum[0], userNum[1], userNum[2]);
            //                Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //                Console.WriteLine("=============다시 입력하세요.=============");
            //            }
            //            else if (computerNum[0] == userNum[1] || computerNum[0] == userNum[2] 
            //                || computerNum[1] == userNum[2] || computerNum[1] == userNum[0] 
            //                || computerNum[2] == userNum[0] || computerNum[2] == userNum[1])
            //            {//0번째 맞고, 1,2번 숫자는 맞지만 서로 자리만 틀린경우

            //                Console.WriteLine("{0}/{1}/{2}는1S 1B입니다.", userNum[0], userNum[1], userNum[2]);
            //                Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //                Console.WriteLine("=============다시 입력하세요.=============");
            //            }
            //            else
            //            {//0번째만 맞은경우 
            //                Console.WriteLine("{0}/{1}/{2}는 1S 입니다.", userNum[0], userNum[1], userNum[2]);
            //                Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //                Console.WriteLine("=============다시 입력하세요.=============");
            //            }
            //        }

            //    }
            //    else //스트라이크 0개
            //    {
            //        if (maxCount - count ==0) // 기회 끝
            //        {
            //            Console.WriteLine("남은 기회가 없습니다.", maxCount - count);
            //            Console.WriteLine("=============종료=============");
            //        }
            //        else if (  computerNum[0] == userNum[1] && computerNum[1] == userNum[2] && computerNum[2] == userNum[0]
            //                || computerNum[0] == userNum[2] && computerNum[1] == userNum[0] && computerNum[2] == userNum[1]
            //                )
            //        {//3개 모두 자리만 틀린경우 

            //            Console.WriteLine("{0}/{1}/{2}는 3B입니다.", userNum[0], userNum[1], userNum[2]);
            //            Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //            Console.WriteLine("=============다시 입력하세요.=============");
            //        }
            //        else if (   computerNum[2] == userNum[1] && computerNum[1] == userNum[0]                         
            //                ||  computerNum[2] == userNum[0] && computerNum[0] == userNum[1]
            //                ||  computerNum[1] == userNum[2] && computerNum[2] == userNum[1]
            //                ||  computerNum[1] == userNum[0] && computerNum[2] == userNum[1]
            //                ||  computerNum[0] == userNum[2] && computerNum[2] == userNum[0]  
            //                ||  computerNum[0] == userNum[1] && computerNum[1] == userNum[0]) 
            //            {//2개는 자리만 틀린경우

            //             Console.WriteLine("{0}/{1}/{2}는  2B입니다.", userNum[0], userNum[1], userNum[2]);                           
            //            Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //                Console.WriteLine("=============다시 입력하세요.=============");
            //            }

            //        else if(computerNum[1] == userNum[2] || computerNum[2] == userNum[1]
            //                || computerNum[0] == userNum[1] || computerNum[0] == userNum[2]
            //                || computerNum[1] == userNum[0])
            //        { // 1볼
            //            Console.WriteLine("{0}/{1}/{2}는  1B입니다.", userNum[0], userNum[1], userNum[2]); 
            //            Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //            Console.WriteLine("=============다시 입력하세요.=============");
            //        }
            //        else
            //        {// 숫자, 자리 모두 틀림.
            //            Console.WriteLine("{0}/{1}/{2}는 3O 입니다.", userNum[0], userNum[1], userNum[2]);
            //            Console.WriteLine("남은 기회 {0}번 남았습니다.", maxCount - count);
            //            Console.WriteLine("=============다시 입력하세요.=============");
            //        }
                


                


            //    }

            //}


            /**
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

            //배열의 선언과 초기화
            int[] numbers = new int[5] { 100, 200, 300, 400, 500 };
            //Console.WriteLine(numbers[0]);
            //Console.WriteLine(numbers[numbers.Length - 1]); // 총개수 모를때 마지막 값 가져오기


            
            //for(int index = 0; index< numbers.Length; index++)
            //{
            //    Console.WriteLine("{0}",numbers[index]);

            //}

            //foreach(int element in numbers)
            //{
            //    Console.Write("{0}", element);

            //}

            //int number1 = 1;
            //int number2 = 2;
            //int number3 = 3;
            //int number4 = 4;
            //int number5 = 5;

            Console.WriteLine(numbers);

        }
    }
}