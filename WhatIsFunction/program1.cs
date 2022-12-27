using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatIsFunction
{
    internal class program1
    {
        static void Main(string[] args)
        {
            /** [실습] ===================================================================================
            * Q1. 3개의 정수 중에서 최대값을 찾는 함수 Maximun(x,y,z)를 정의 할것
            * 
            * Q2. 화면에 "Hello"를 출력하는 SayHello()함수를 작성.
            *       - int 타입 매개 변수를 받아서 그 횟수 만큼 "Hello"를 반복해서 출력.
            *       
            * Q3. 다른 두 변이 주어졌을때, 직각 삼각형의 빗변을 계산하는 함수 Hypot()를 정의할것
            *       - 매개 변수는 2개 타입은 double 형
            *       - 리턴 타입도 double 형
            *       
            * Q4. 주어진 숫자가 소수인지 여부를 찾는 함수 Prime()을 작성
            *       - 판별할 값의 범위는 2~100 사이의 값 중에서 소수는 모두 출력
            * 
            * Q5. 사용자가 입력하는 전화 번호에서 소괄호를 삭제한 형태로 출력하는 프로그램을 함수사용하여 작성
            *       - 전화 번호를 입력 받는다. -> 소괄호 삭제한 형태로 출력.
            *       - quit 입력하면 프로그램을 종료한다.
            *       - 프로그램 종료 전까지 전화번호를 입력받는다.
            *
            */

            // Q1 ===================
            int num1 = 100;
            int num2 = 102;
            int num3 = 103;

            Console.WriteLine("3개의 정수 {0},{1},{2} 중에서 최대값은 {3} 입니다.", num1, num2, num3, Maximun(num1, num2, num3));

            // Q2 ===================
            SayHello(5);

            // Q3 ===================
            double firstValue = 3.5d;
            double secondValue = 4.8d;

            Console.WriteLine("두 변 길이가 {0}, {1}인 직각삼각형의 빗변의 길이는 {2:F4} 입니다.", firstValue, secondValue, Hypot(firstValue, secondValue));

            // Q4 ====================
            Prime(2,100);

            Console.WriteLine();

            bool isQuit = false;
            // Q5 ====================
            while (isQuit != true)
            {
                Console.WriteLine("숫자만 추출할 전화 번호를 입력하세요. [종료하려면, quit를 입력하세요.]");
                string UserInput = string.Empty;
                UserInput = Console.ReadLine();
                if (UserInput == "quit" || UserInput == "Quit"|| UserInput == "QUIT")
                {
                    isQuit = true;
                    Console.WriteLine("종료합니다.");
                    break;
                }
                else
                {
                    Console.WriteLine("입력하신 전화번호는 {0} 입니다. ", PhoneNumbers(UserInput));
                   
                }
            }

        }

        static int Maximun(int x, int y, int z)
        {
            int bigNum = 0;
            if (x == y || y == z || x == z)
            {
                if (x == y && y == z)
                {
                    bigNum = -1;
                }
                else
                { 

                }
            }
            else if(x > y)
            {
                if(x < z)
                {
                    bigNum = z;
                    
                }
                else
                {
                    bigNum = x;
                }
            }
            else if(y > x)
            {
                if (y < z)
                {
                    bigNum = z;

                }
                else
                {
                    bigNum = y;
                }
            }
      
            return bigNum;
        }

        static void SayHello(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Hello");
            }
        }

        // Q3.다른 두 변이 주어졌을때, 직각 삼각형의 빗변을 계산하는 함수 Hypot()를 정의할것
        // - 매개 변수는 2개 타입은 double 형
        // - 리턴 타입도 double 형

        static double Hypot(double x, double y)
        {
            double resultValue = 0;
            resultValue = Math.Sqrt((x * x) + (y * y));
            return resultValue;
        }


        // Q4. 주어진 숫자가 소수인지 여부를 찾는 함수 Prime()을 작성
        //      - 판별할 값의 범위는 2~100 사이의 값 중에서 소수는 모두 출력

        static void Prime(int number1, int number2)
        {
            bool isPrime = false;
            int[] array = Enumerable.Range(number1, number2 - 1).ToArray();
            
            int primeIndex = 0;
            

            Console.WriteLine("{0} ~ {1}사이 값 중에 소수 인 수 : ",number1,number2);
            for (int i = 0; i < array.Length; i++)
            {

                if (isPrimeValue(array[i]) == true)
                 { 
                   Console.Write("{0}, ", array[i]);
                }
            }
            Console.ReadLine();
        }

        static bool isPrimeValue(int value)
        {
            if (value == 2)
            {
                //2일 경우 소수 이니까 true 반환, 
                return true;
            }
            else
            {
                for (int j = 2; j <= value - 1; j++) // 2 ~ N-1 까지 반복
                {
                    if (value % j == 0)// 2 ~ N-1 로 나눈값이 0인경우 경우
                    {
                        return false;
                    }
                    else
                    {
                        

                    }
                }
                return true;
            }

        }
        //* Q5.사용자가 입력하는 전화 번호에서 소괄호를 삭제한 형태로 출력하는 프로그램을 함수사용하여 작성
        //- 전화 번호를 입력 받는다. -> 소괄호 삭제한 형태로 출력.
        //- quit 입력하면 프로그램을 종료한다.
        //- 프로그램 종료 전까지 전화번호를 입력받는다.

        static string PhoneNumbers(string phoneNumber)
        {
            string originStr = phoneNumber;
            string[] split_str = originStr.Split(")");
            string resultNumbers = string.Empty;



            for (int i =0; i < split_str.Length; i++)
            {
                resultNumbers = resultNumbers + split_str[i];
            }

            return resultNumbers;
                 
        }
    }
}
