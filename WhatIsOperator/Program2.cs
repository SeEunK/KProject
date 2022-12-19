using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsOperator
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            ///*
            // * * [1. 최대 한도의 사탕 사기] ========================================
            // * 현재 1000원이 있고, 사탕의 가격이 300원일때, 최대 살수 있는 사탕의 개수와 나머지 돈은 얼마인지 출력하라.
            // * 
            // * 현재 가지고 있는 돈 : 1000 (유저 입력)
            // * 캔디 가격 300 (캔디의 가격은 상수)
            // * 최대 살수 있는 캔디 수 = ? 
            // * 캔디 구입 후 남은 돈 = ?
            // *  
            // * 
            //*/

            //Console.WriteLine("가지고있는 돈을 입력하세요 :  ");
            //string inputHaveMonney = Console.ReadLine();
            //int monney = default;
            //int.TryParse(inputHaveMonney, out monney);

            //const int candyCost = 300;
            //float countDivide = monney / candyCost;
            //int maxCount = (int)countDivide;
            //int change = monney - (candyCost * maxCount);

            //Console.WriteLine("사탕 하나의 가격은 {0}이고, 최대 {1}개 구매 가능하며, {2} 원이 남습니다.", candyCost, maxCount, change);


            ///**
            // * [2. 화씨온도를 섭씨온도로 바꾸기]========================================
            // * 우리나라는 섭씨 온도를 사용하지만, 미국에서는 화씨 온도를 사용한다.
            // * 화씨 온도를 섭씨 온도로 바꾸는 프로그램을 작성.
            // * 
            // * ex) 화씨 온도 60도는 섭씨온도 ???? 입니다.
            // * 
            // * (화씨 - 32)*5/9 = 섭씨
            // */
            //Console.WriteLine("섭씨로 변환할 화씨온도를 입력하세요. : ");
            //string InputFahrenheit = Console.ReadLine();
            //float fahrenheit = default;
            //float.TryParse(InputFahrenheit,out fahrenheit);

            //float celsius = (fahrenheit - 32) * 5/9;

            //Console.WriteLine("화씨 {0}는 섭씨 {1}이다.", fahrenheit, celsius);






            ///** 3. 주사위 게임
            // * 2개의 주사위를 던져서 주사위의 합을 표시하는 프로그램 작성.
            // * 주사위를 던지면 랜덤한 수가 나와야한다ㅓ.
            // * ex) 
            // * 첫번째 주사위 : {0}
            // * 두번째 주사위 : {0}
            // * 두 주사위의 합: {0}
            // * 
            // */

            //Console.WriteLine("주사위 두개를 굴리겠습니까? y/n");
            //string yOrN= Console.ReadLine();
           
            //if (yOrN == "y") 
            //{
            //    Random rand = new Random();



            //    int value1 = rand.Next(1, 7); //int diceValue = rand.Nect(1,6+1); 로 쓰기도함.
            //    int value2 = rand.Next(1, 7);

            //    int sumValue = value1 + value2;

            //    Console.WriteLine("첫번째 주사위 : {0}\n두번째 주사위:{1}\n\n두 주사위의 합:{2}", value1, value2, sumValue);
            //}
            //else
            //{
            //    Console.WriteLine("종료");
            //}





            //// 예제 1 구개의 정수 중 더 큰 수를 찾는 프로그램

            //int numberX, numberY;

            //Console.Write("x값을 입력하시오. : ");
            //int.TryParse(Console.ReadLine(), out numberX);

            //Console.Write("y값을 입력하시오. : ");
            //int.TryParse(Console.ReadLine(),out numberY);

            //if(numberY < numberX)
            //{
            //    Console.WriteLine("x가 y보다 큽니다.");

            //}
            //else
            //{
            //    Console.WriteLine("y가 x보다 큽니다.");
            //}



            //// 예제 2 컵의 사이즈를 받아서 100ml 미만은 small / 200ml 미만은 medium / 200ml 이상은 large 라고 출력하는 if-else 문 작성


            //int cupSize;


            //Console.Write("컵의 용량(ml)을 입력하시오. : ");
            //int.TryParse(Console.ReadLine(), out cupSize);

            
            //if (0 < cupSize && cupSize < 100)
            //{
            //    Console.WriteLine("컵사이즈는 samll 입니다.");

            //}            
            //else if(100<=cupSize && cupSize<200)
            //{
                
            //    Console.WriteLine("컵사이즈는 medium 입니다.");

            //}
            //else
            //{
            //    if (200 <= cupSize)
            //    {
            //        Console.WriteLine("컵사이즈는 large 입니다.");
            //    }
            //    else if(cupSize == 0)
            //    {          
            //        Console.WriteLine("용량을 알수없습니다.");

            //    }               
            //    else
            //    {
            //        Console.WriteLine("음수를 입력하셨습니다.");
            //    }
            //}


            /* lab 1. 비밀코드 맞추기
             * 컴퓨터가 숨기고 있는 비밀코드를 추측하는 게임을 작성
             * 비밀코드는 a - z 사이의 문자.
             * 컴퓨터는 사용자의 추측을 읽고서 앞에 있는지, 뒤에있는지 알려준다.(즉, 사용자에게 힌트를 준다.)
             * 
             *
             *
             *
             */

            //string computerPW;
            //Random rand = new Random();
            //int value1 = rand.Next(1, 26+1);

            //string[] PWcodeList = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y","Z" };
            //computerPW = PWcodeList[value1];

            ////Console.Write("비밀코드를 맞춰보세요 (a-z): ");
            ////string userInputPW= Console.ReadLine();

            ////int indexInputValue = Array.IndexOf(PWcodeList, userInputPW);
            

            //while (true)
            // {
            //    Console.Write("비밀코드를 맞춰보세요 (a-z): ");
            //    string userInputPW = Console.ReadLine();

            //    int indexInputValue = Array.IndexOf(PWcodeList, userInputPW);

            //    if (value1== indexInputValue) 
            //    {

            //        break;
            //    }
            //    else if (value1 < indexInputValue)
            //    {

            //        Console.WriteLine("{0}보다 앞에 있습니다.", userInputPW);

            //    }
            //    else  
            //    {
            //        Console.WriteLine("{0}보다 뒤에 있습니다.", userInputPW);
            //    }    

            //}
            //Console.WriteLine("정답입니다.");



            /* lab 2. 세 개의 정수 중에서 큰 수 찾기
             * 사용자로부터 받은 3개의 정수 중에서 가장 큰 수를 찾는 프로그램 작성
             * 
             * ex) 1.세 개의 정수를 입력하시오 20 10 30  (hard)    split메서드 사용?
             *     (2. 1번 정수 입력 x
             *         2번 정수 입력 y
             *         3번 정수 입력 z)
             *         ===
             *         가장 큰 정수는 :
             */

            Console.WriteLine("세개의 정수를 /로 구분하여 입력하세요. ");

            string userInputNumbers = Console.ReadLine();
            string[] splitValue = userInputNumbers.Split(new char[] { '/' });



            int InputNum1 = default;
            int.TryParse(splitValue[0], out InputNum1);


            int InputNum2 = default;
            int.TryParse(splitValue[1], out InputNum2);


            int InputNum3 = default;
            int.TryParse(splitValue[2], out InputNum3);


           
           
            if(InputNum1> InputNum2&& InputNum1> InputNum3)
            {
                Console.WriteLine("가장 큰 정수는 : {0}", InputNum1);

            }
            else if(InputNum2 > InputNum1 && InputNum2 > InputNum3)
            { 
            Console.WriteLine("가장 큰 정수는 : {0}", InputNum2);

            }
            else
            {
            Console.WriteLine("가장 큰 정수는 : {0}", InputNum3);
            }


        }
    }
}
