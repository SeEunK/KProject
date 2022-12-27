using System;
using System.ComponentModel.Design.Serialization;

namespace WhatIsFunction
{
    internal class Program
    {
        // ** 22/12/27 전역 변수 지역변수 설명 중.. ===================//
        static int number1 = 1; //전역 변수 
        static int number2 = 3; //전역 변수

        // 지역 변수랑 전역변수가 이름이 같아도되지만 햇갈리기 때문에,
        // 전역 변수는 "m_" 접두사 또는 언더스코어 (_)를 붙여준다.
        // So, 로컬변수와 글로벌 변수는 구분해서 써주는게 좋다!

        static void Main(string[] args)
        {
            //**22/12/26 S====================================================//
            //string[,] starArray = new string[5, 5];

            //// 별찍기 직각 삼각형 했던거
            //// 별을 초기화 하는 코드
            //for (int y = 0; y < 5; y++)
            //{
            //    for (int x = 0; x < 5; x++)
            //    {
            //        starArray[y, x] = "*";
            //    }
            //} //loop : 별을 배열에 초기화 하는 루프

            ////별을 출력하는 코드
            //for (int y = 0; y < 5; y++)
            //{
            //    for (int x = 0; x < 5; x++)
            //    {
            //        if (starArray[y, x].Equals("*"))
            //        {
            //            Console.Write("{0}", starArray[y, x]);
            //        }
            //    }
            //    Console.WriteLine();
            //    //loop: 배열에 담긴 별 출력 하는 루프
            // }

            /*
             * 함수 (Function) 또는 메서드(Method)는 재사용을 목적으로 만든 특정 작업을 수행하는 코드 블록이다.
             * 함수를 부르는 다양한 명칭
             * - 함수 (Function)
             * - 메서드 (Method) // class 안에 있는 맴버
             * - 프로시저 (Procedure)
             * - 서브루틴 (Subroutine)
             * - 서브모듈 (Submodule)
             * 
             * 프로그래밍을 하다 보면 같은 유형의 코드를 반복할 때가 많다. 
             * 이 코드들을 매번 입력하면 불편하고 입력하다 실수도 할 수 있다. 이때 "함수"를 사용.
             * 
             * 프로그래밍 언어에서 함수는 어떤 동작 및 행위를 표현한다.
             * 함수의 사용 목적은 코드 재사용에있다.
             * 한번 만들어 놓은 함수는 프로그램에서 한번 이상 사용 할 수 있다.
             * 지금 까지 사용한 Main()메서드는 C#의 시작 지점을 나타내는 특수한 목적의 함수로 볼수있다.
             * 또, Console 클래스의 WhitLine()메서드도 함수로 볼수있다.
             * 
             * - 함수란, 어떤 값을 받아서 그값을 가지고 가공을 거쳐 어떤 결과값을 반환시켜 주는 코드이다.
             * - 함수는 프로그램 코드내에서 특정한 기능을 처리하는 독립적인 하나의 단위 또는 모듈을 가리킨다.
             * 
             * 함수의 실행 단계
             * - 입력 --> 처리 --> 출력
             *  
             *  
             *  함수의 종류 (내장 함수와 사용자 정의 함수)
             *  함수에는 내장함수와 사용자 정의 함수가 있다.
             *  
             *  내장 함수는 C#이 자주 사용하는 기능을 미리 만들어서 제공하는 함수로, 특정 클래스의 함수로 표현된다.
             *  내장 함수도 그 용도에 따라 문자열 관련 함수, 날짜 및 시간 관련 함수, 수학 관련 함수, 형식 변환 관련 함수 등으로 나눌수 있다.
             *  이러한 내장 함수를 API(Application Programming Interface)로 표현한다.
             *  
             *  사용자 정의 함수는 내장함수와 달리 프로그래머가 필요할 때 마다 새롭게 기능을 추가하여 사용하는 함수이다.
             *  
             *  함수 정의하고 사용하기
             *  함수 정의(Define)는 함수를 만드는 작업이다.
             *  함수 호출(Call)은 함수를 사용하는 작업이다.
             *  함수 생성 및 호출은 반드시 소괄호"(", ")"가 들어간다.
             *  함수를 정의하는 형태는 지금까지 사용한 Main() 메서드와 유사하다.
             *  
             *  다음 코드는 함수를 만드는 가장 기본적인 형태를 보여준다.
             *  
             *  // static void 함수이름 ()
             *  // {
             *  //       함수 내용 
             *  // }
             *  
             *  만든 함수를 호출하는 형태는 다음 세가지가 있다.
             *  - 함수 이름();
             *  - 함수 이름(매개변수);
             *  - 변수(결과값) = 함수이름(매개변수);
             *  
             */

            Show(); //Main() 메서드가 static 이니까, show() 함수도 static 이어야함, static이 없으면 에러가 남.

            int someNum = 100;
            Console.WriteLine(someNum);
            someNum = Hi();
            Console.WriteLine(someNum);
            someNum = Hi("Hello");
            Console.WriteLine(someNum);

            int num1 = 100;
            int num2 = 50;
            int num3 = -10;


            Console.WriteLine("{0} {1} 두 수의 합은: {2}", num1, num2, SumNumber(num1, num2));
            Console.WriteLine("{0} {1} 두 수 중 큰 값은: {2}", num1, num2, WhatIsMaxNum(num1, num2));
            Console.WriteLine("{0} {1} 두 수 중 작은 값은: {2}", num1, num2, WhatIsMinNum(num1, num2));
            Console.WriteLine("{0} {1} 두 수의 절대 값은 : {2}, {3}", num1, num3, Absolute(num1), Absolute(num3));


            Multi();
            Multi("반갑습니다.");
            Multi("또 만나요", 3);

            Factorial(10);


            int number1 = 10; // 지역 변수
            int number2 = 30; // 지역 변수
            // 전역 변수랑 지역 변수가 같이 존재할수있지만, 지역변수가 있으면 지역변수를 
            // 지역 변수가 없으면 전역 변수를 찾아온다.

            Swap(number1, number2); // number1 과 number2의 값만 넘겨준것!!
                        
            Console.WriteLine("Main 의 number 값은 : {0} , {1}", number1, number2);


        } //Main()

        // 클래스 내부, Main 밖에 함수 생성. 

        // ! Hello world 출력하는 사용자 정의 함수.
        static void Show()
        {
            Console.WriteLine("Hello world!");

            /*
             * 이 함수는 가장 간단한 형태의 함수로, 매개변수(Parameter)도 없고 반환값(Return value)도 없는 형태이다.
             * 
             */
        }

        //**22/12/26 E====================================================//

        static int Hi()
        {
            /*
             *  =====22/12/27 ======================================================================================
             *  함수를 만들고 반복해서 사용하기
             *  함수를 만드는 목적 중 하나는 반복 사용에 있다. 함수를 만들고 여러번 호출해서 사용하는 방법을 알아보자.
             */
            Console.WriteLine("안녕하세요.");

            return 0;
        }

        static int Hi(string text)
        {
            Console.WriteLine(text);
            return 50;
        }


        //! 매개 변수와 반환값 설명
        static void ParameterAndReturn()
        {
            /**
             * 함수를 만들어 놓고 기능이 동일한 함수만 사용하지는 않는다.
             * 호출할때 마다 조금씩 다른 기능을 적용 할 때는 함수의 매개변수를 달리하여 호출할수 있다.
             * 
             * 매개변수 (인자, 파라미터)는 함수에 어떤 정보를 넘겨주는 데이터를 나타낸다.
             * 이러한 매개변수는 콤마를 기준으로 여러개 설정할수있으며, 문자열과 숫자등 모든 데이터형식을 사용할수있다.
             * 
             * 매개변수 (인자, 파라미터) 가 없는 함수 : 매개변수도 없고 반환값도 없는 함수 형태는 가장 단순한 형태의 함수
             * 모든 변수에 있는 값을 문자열로 변환 시키는 ToString()메서드 처럼 빈 괄호만 있는 함수 형식을 나타낸다.
             * 
             * 매개 변수가 있는 함수 : 특정 함수에 인자 값을 1개 이상 전달하는 방식이다.
             * 정수형, 실수형, 문자형, 문자열형, 개체형 등 여러가지 데이터 형식을 인자 값으로 전달할 수 있다.
             * 
             * 반환값이 있는 함수(결과값이 있는 함수) : 함수의 처리 결과를 함수를 호출한쪽으로 반환할때는 
             * return 키워드를 사용하여 데이터를 돌려줄수 있다.
             * 
             * 매개변수가 가변(여러개)인 함수 : C#에서는 클래스 하나에 매개변수의 형식과 개수를 달리하여 
             * 이름이 동일한 함수를 여러개 만들수있다. 
             * 함수 중복 또는 함수 오버로드(Overload)라고 한다.
             * 
             */
        }

        static void ShowMessage(string message)
        {
            Console.WriteLine(message);

        }

        static int SquareFunction(int num)
        {
            num = num * num;
            return num;
        }

        // 두 수의 합을 구하는 함수 작성
        static int SumNumber(int num1, int num2)
        {
            int resultNum = num1 + num2;
            return resultNum;
        }

        // 함수를 사용하여 큰값과 작은값, 절댓값 구하기
        static int WhatIsMaxNum(int num1, int num2)
        {
            int returnNum = 0;
            if (num1 > num2) { returnNum = num1; }
            else if (num1 == num2) { returnNum = -1; }
            else { returnNum = num2; }

            return returnNum;
        }
        // 작은값
        static int WhatIsMinNum(int num1, int num2)
        {
            int returnNum = 0;
            if (num1 < num2) { returnNum = num1; }
            else if (num1 == num2) { returnNum = -1; }
            else { returnNum = num2; }

            return returnNum;
        }
        //절댓값 구하기
        static int Absolute(int num)
        {
            if (num < 0)
            {
                num = num * -1;
            }
            return num;
        }
        static void FunctionOverloading()
        {
            /**
             * 함수 오버로드 : 다중 정의
             * 클래스 하나에 매개변수를 달리해서 이름이 동일한 함수 여러개를 정의할수있는데, 
             * 이를 함수 오버로드라고 한다.
             * 우리말로는 여러번 정의한다는 의미.
             * 
             * 
             */
        }

        //! 숫자를 받아서 출력하는 함수
        /**
         * @param number int type number for print
         */
        static void GetNumber(int num)
        {
            Console.WriteLine($"Int32(4byte 정수): {num}");
        }
        /**
        * @param number long type number for print
        */
        static void GetNumber(long num)
        {
            Console.WriteLine($"Int64(8byte 정수): {num}");
        }

        static void Multi()
        {
            Console.WriteLine("안녕하세요.");
        }
        static void Multi(string message)
        {
            Console.WriteLine(message);
        }
        static void Multi(string message, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(message);
            }
        }

        static void RecursionFunction()
        {
            /**
             * 재귀 함수 
             * 함수에서 함수 자신을 호출하는것을 재귀(Recursion) 또는 재귀 함수라고 한다.
             * 
             */
        }

        static int Factorial(int n)
        {
            //탈출!
            if (n == 0 || n == 1)
            {
                return 1;
            }
            Console.WriteLine("n의 값은 :{0}", n);
            return n * Factorial(n - 1); //여기서 재귀 호출 
        }
        

        static void FunctionScope()
        {
            /**
             * 함수 범위 : 전역 변수와 지역 변수
             * 클래스와 같은 레벨에서 선언된 변수를 전역 변수 (Global Variable) 또는 필드 (Field)라고 하며,
             * 함수 레벨에서 선언된 변수를 지역변수 (Local Variable) 라고 한다. 
             * 이때 동일한 이름으로 변수를 전역변수와 함수내의 지역 변수로 선언할수있다.
             * 함수 내에서는 함수 범위에있는 지역 변수는 사용하고,
             * 함수 범위 내에 선언된 변수가 없으면 전역 변수내에 선언된 변수를 사용한다.
             * 단, C# 에서는 전역 변수가 아닌, 필드라는 단어를 주로 사용하며, 
             * 전역 변수는 언더스코어 (_) 또는 m_ 점두사를 붙이는 경향이있다.
             * 
             */
        }

        static void Swap(int intValue1, int intValue2)
        {
            Console.WriteLine("바뀌기 전의 값: {0} , {1}", intValue1, intValue2);

            int temp;
            temp = intValue1;
            intValue1 = intValue2;
            intValue2 = temp;

            Console.WriteLine("바뀐 후 값: {0} , {1}", intValue1, intValue2);
        } //이 스코프를 벗어나면, intValue1 과 intValue2 는 사라짐! //지역 변수임!


        static void ArrowFuntion()
        {
            /**
             * 화살표 함수
             * 화살표 모양의 연산자인 화살표 연산자 (=>)를 사용하여 매서드 코드를 줄일수 있다.
             * 이를 화살표 함수 (Arrow function)이라고 한다.
             * 프로그래밍에서 화살표 함수 또는 화살표 매서드는 람다식 (Lambda expression)의 또다른 이름이다.
             * 
             * 화살표 함수를 사용하면 함수를 줄여서 표현할수있다.
             * 함수 고유의 표현을 줄여서 사용하면 처음에는 어색할수있다.
             * 하지만 이 방식에 익숙해지면 차후에는 코드의 간결함을 유지할수있다.
             * 
             */
        }

        // ArrowFuntion 예시 
        static void Hello() => Console.WriteLine("안녕하세요.");
        static void Multiply(int a, int b) => Console.WriteLine(a * b);


    } //class 
}