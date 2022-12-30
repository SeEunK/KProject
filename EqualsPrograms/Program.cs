using System;
using System.Reflection.PortableExecutable;

namespace EqualsPrograms
{
    internal class Program
    {
        static void Main(string[] args)
        {

            /*==============================================================================================
             * Q - 1) 사용자로 부터 2개의 문자열을 읽어서 같은지 다른지 화면에 출력하는 프로그램 작성
             *  ex) 첫번째 문자열 : Hello
             *      두번째 문자열 : World
             *      ====================
             *      결과 : 두개의 문자열은 다릅니다.
             *      
             *   * 조건 : equals 메서드를 사용하지 않을것.
             *   * hint : length를 비교한다던지?
             *==============================================================================================
             */

            if (false)
            {
                Console.WriteLine("첫번째 문자열을 입력하세요.");
                string strFirstInput = Console.ReadLine();

                Console.WriteLine("두번째 문자열을 입력하세요.");
                string strSecondInput = Console.ReadLine();

                bool isEquals = false;

                if (strFirstInput.Length != strSecondInput.Length)
                { // 길이가 다르면 걍 비교없이 틀림 처리.
                    isEquals = false;
                }
                else
                {  // 길이가 같으면 한글자씩 같은지 보자.
                    string[] firstStringArray = new string[strFirstInput.Length];
                    string[] secondStringArray = new string[strSecondInput.Length];

                    for (int index = 0; index < strFirstInput.Length; index++)
                    {
                        firstStringArray[index] = strFirstInput.Substring(index, 1);

                        Console.WriteLine("firstStringArray [{0}] 값 : {1}", index, firstStringArray[index]);
                    }
                    for (int index = 0; index < strSecondInput.Length; index++)
                    {
                        secondStringArray[index] = strSecondInput.Substring(index, 1);

                        Console.WriteLine("secondStringArray [{0}] 값 : {1}", index, secondStringArray[index]);
                    }

                    for (int index = 0; index < firstStringArray.Length; index++)
                    {

                        if (firstStringArray[index] != secondStringArray[index])
                        {  // 틀린 문자 나오는 순간 틀림 처리 후 반복문종료.
                            isEquals = false;
                            break;
                        }
                        else // firstStringArray[index] == secondStringArray[index] 문자 같은데, 
                        {    // 마지막 인덱스까지 같을 경우, 같음 처리 후 반복문종료.
                            if (index == firstStringArray.Length - 1)
                            {
                                isEquals = true;
                                break;
                            }
                        }
                    }
                }
                //  결과 출력 =================================================================
                Console.WriteLine("========================");
                Console.WriteLine(" 첫 번째 문자열 : {0} ", strFirstInput);
                Console.WriteLine(" 두 번째 문자열 : {0} ", strSecondInput);
                Console.WriteLine("========================");
                if (isEquals == true) // 값음 결과 출력
                {
                    Console.WriteLine("입력한 2개 문자열은 동일합니다.");
                }
                else
                {
                    Console.WriteLine("입력한 2개 문자열은 다릅니다.");
                }
                Console.WriteLine("========================");
            }


            /*====================================================================================================
             * Q - 2) 5개의 음료 (콜라, 물, 스프라이트, 주스, 커피를 판매하는 자판기 머신을 구현해 보기
             * 사용자가 1부터 5사이의 숫자를 입력함.
             * 선택한 음료를 출력함
             * 1~ 5 이외의 숫자를 선택하면 오류 메시지 출력함
             * 
             *  ex) 콜라, 물, 스프라이트, 주스, 커피 중에 하나를 선택하세요: 1
             *      콜라를 선택하였습니다.
             *      = 프로그램 종료 =
             *      
             *      * hint ) swith 문이나 if/else 문 사용.
             *      
             *====================================================================================================
             */
            if (false)
            {
                int[] vendingMachine = new int[5] { 1, 2, 3, 4, 5 };

                Console.WriteLine("======================================");
                Console.WriteLine("| 콜라 |  물  | 스프라이트 | 주스 | 커피 |");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("|  (1) | (2)  |  (3)      | (4)  | (5) |");
                Console.WriteLine("=======================================");

                Console.WriteLine("원하는 음료의 숫자를 입력하세요.");
                while (true)
                {

                    string strFirstInput = Console.ReadLine();
                    int intInput = 0;
                    int.TryParse(strFirstInput, out intInput);

                    if (intInput > 0 && intInput < 6)
                    {
                        switch (intInput)
                        {
                            case 1:
                                Console.WriteLine("콜라를 선택하였습니다.");
                                break;
                            case 2:
                                Console.WriteLine("물을 선택하였습니다.");
                                break;
                            case 3:
                                Console.WriteLine("스프라이트를 선택하였습니다.");
                                break;
                            case 4:
                                Console.WriteLine("주스를 선택하였습니다.");
                                break;
                            case 5:
                                Console.WriteLine("커피를 선택하였습니다.");
                                break;
                            default:
                                //Console.WriteLine("입력이 잘못되었습니다.");
                                break;
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                    }
                }
            }




            /*===============================================================================
             * Q - 3) 배열 days[]를 아래와 값이 초기화 하고 배열요소의 값을 다음과 같이 출력하는 프로그램 작성
             * 배열 days[]는 -> 31,29,31,30,31,30,31,31,30,31,30,31
             * ex) 1월은 31 일 까지입니다.
             * 2월은 29일 까지 입니다.
             * 
             * hint) 배열의 초기화는 중괄호를 사용한다.
             *================================================================================
             */
            if (true)
            {
                int[] days = { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                Console.WriteLine("1월 ~ 12월 중에, 마지막을 날짜를 알고싶은 달을 숫자로 입력하세요.");
                while (true)
                {
                    string strFirstInput = Console.ReadLine();
                    int intInput = 0;
                    int.TryParse(strFirstInput, out intInput);

                    if (intInput > 0 && intInput < 13)
                    {
                        Console.WriteLine("{0}월의 마지막 날짜는 {1}입니다.", intInput, days[intInput-1]);

                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못입력하셨습니다. 다시 입력해주세요.");
                    }
                }
            }
        }
    }
}
