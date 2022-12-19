using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace WhatIsOperator
{
    internal class Program
    {
        //static void Main(string[] args)
        //{
        //    // Console.WriteLine("Hello, World!");

        //    //string stringBinary = Convert.ToString(10, 2);
        //    //Console.WriteLine(stringBinary);



        //    //int intBinary = Convert.ToInt32("0111", 2);
        //    //Console.WriteLine(intBinary);


        //    //const int PLUS_FIVE = +5;

        //    //string compareTen = (PLUS_FIVE > 10) ? "{0}은 10보다 크다" : "{0} 은 10보다 크지않다";
        //    //Console.WriteLine(compareTen, PLUS_FIVE);


        //    //변환 연산자
        //    // ()기호를 사용하여 특정 값을 원하는 데이터 형식으로 변환할수 있다.


        //    //const int PI_INT = (int)3.141592;
        //    //const float PI_FLOAT = (float)3.141592;

        //    //Console.WriteLine("PI_INT : {0}, PI_FLOAT: {1}", PI_INT, PI_FLOAT);


        //    //int number = 0;
        //    //number++;
        //    //Console.WriteLine(number);


        //    //관계형 연산자
        //    //bool isBigger = false;
        //    //isBigger = (5 != 10);
        //    //Console.WriteLine(isBigger);


        //    //isBigger = !isBigger;
        //    //Console.WriteLine(isBigger);



        //    //시프트 연산자.
        //    //int bitNumber = 10;
        //    //int bitResult = 0;
        //    //bitResult = bitNumber >>1;
        //    //Console.WriteLine(bitResult);



        //    //int intNumber1, intNumber2, intNumber3;

        //    //Console.WriteLine("int의 메모리 크기는 {0}바이트입니다.",sizeof(int));


        //    ////[실습 1] 사용자에게 주어,동사, 목적어를 각각 물어보고 이것을 합하여 (주어+동사+목적어)형태로 출력하는 프로그램을 작성해보자.

            

        //    //Console.WriteLine("주어를 입력하세요 : ");
        //    //string subject = string.Empty;
        //    //subject = Console.ReadLine();

        //    //Console.WriteLine("동사를 입력하세요 : ");
        //    //string verb = string.Empty;
        //    //verb = Console.ReadLine();

        //    //Console.WriteLine("목적어를 입력하세요 : ");
        //    //string objective = string.Empty;
        //    //objective = Console.ReadLine();


        //    //Console.WriteLine("{0} {1} a {2}",subject, verb , objective);





        //    ////[실습 2] 사용자의 나이를 물어보고 10년 후 몇살이 되는지 출력하는 프로그램을 작성 해보자.



        //    //Console.WriteLine("나이를 입력하세요 : ");
        //    //string inputAge = Console.ReadLine();
        //    //int yourAge = default;           
        //    //int.TryParse(inputAge, out yourAge);

            
        //    //Console.WriteLine("당신은 10년 후에 {0}살이 됩니다.", yourAge+10);




        //    ////[실습 3] 직각 삼각형의 양변의 길이 (양변은 빗변이 아님)를 읽어서 빗변의 길이를 계산하는 프록램 작성
            
        //    //Console.WriteLine("직각 삼각형의 밑면의 길이를 입력하세요 : ");

        //    //string inputX = Console.ReadLine();
        //    //int x= default;
        //    //int.TryParse(inputX, out x);

        //    //Console.WriteLine("직각 삼각형의 높이의 길이를 입력하세요 : ");

        //    //string inputY = Console.ReadLine();
        //    //int y = default;
        //    //int.TryParse(inputY, out y);


        //    //var result = Math.Sqrt((x * x) + (y * y));


        //    //Console.WriteLine("x = {0}, y = {1} 의 직각 삼각형의 빗변의 길이는 = {2}", x, y, result);




        //    //4. 상자의 길이 , 너비, 높이를 입력하라는 메시지 표시. 상자의 부피와 표면적을 계산해서 출력하는 프로그램

        //    Console.WriteLine("상자의 길이를 입력하세요 : ");
        //    string inputLength = Console.ReadLine();
        //    int length = default;
        //    int.TryParse(inputLength, out length);

        //    Console.WriteLine("상자의 너비를 입력하세요 : ");
        //    string inputWidth = Console.ReadLine();
        //    int width = default;
        //    int.TryParse(inputWidth, out width);


        //    Console.WriteLine("상자의 높이를 입력하세요 : ");
        //    string inputHeight = Console.ReadLine();
        //    int height = default;
        //    int.TryParse(inputHeight, out height);

        //    int volume = length * width * height;
        //    int surface = 2*((length * width) + (width * height) + (length * height));

        //    Console.WriteLine("길이 : {0} \n 너비 : {1} \n 높이 :{2} \n 상자의 부피: {3} \n 상자의 표면적: {4}", length, width, height, volume, surface);



        //    //5.우리나라에서 많이 사용되는 면적의 단위인 평을 평방미터로 환산하는 프로그램 작성.
        //    //여기서 1평은 3.3058 m^2

        //    Console.WriteLine("평방미터를 알고싶은 평을 입력하세요 : ");

        //    const float ONE_P = 3.3058f;

        //    string inputM = Console.ReadLine();
        //    int flat = default;
        //    int.TryParse(inputM, out flat);

        //    float squareMeter = flat * ONE_P;


        //    Console.WriteLine("평: {0}\n평방미터:{1}", flat, squareMeter);



        //    //6. 시,분,초로 표현되는 시간을 초단위의 시간으로 변환
        //    //
        //    // * 시 :1 분: 1초: 1
        //    // * 전체 초:


        //    Console.WriteLine("초단위로 변환할 시간을 입력하세요.\n 시간: ");

        //    const int hourToSeconds= 60*60;
        //    const int minuteToSeconds = 60;

        //    string inputTime = Console.ReadLine();
        //    int hour = default;
        //    int.TryParse(inputTime, out hour);

        //    Console.WriteLine(" 분: ");
        //    string inputMinute = Console.ReadLine();
        //    int minute = default;
        //    int.TryParse(inputMinute, out minute);

        //    Console.WriteLine("초: ");
        //    string inputSecond = Console.ReadLine();
        //    int second = default;
        //    int.TryParse(inputSecond, out second);

        //    Console.WriteLine("초 단위로 변환한 결과 :{0} ", hour* hourToSeconds + minute* minuteToSeconds + second);



        //    //===== 6-1) 한번에 받아서 split 로 분리해버리기.

        //    Console.WriteLine("초단위로 변환할 시간을 시:분:초로 입력하세요.");

        //    string inputValue = Console.ReadLine();
        //    string[] splitValue = inputValue.Split(new char[] { ':' });

            
            
        //    int splitHour = default;
        //    int.TryParse(splitValue[0], out splitHour);

           
        //    int splitMinute = default;
        //    int.TryParse(splitValue[1], out splitMinute);

            
        //    int splitSecond = default;
        //    int.TryParse(splitValue[2], out splitSecond);

        //    Console.WriteLine("초 단위로 변환한 결과 :{0} ", splitHour * hourToSeconds + splitMinute * minuteToSeconds + splitSecond);




        //    //=====

        //    /**
        //     * 8. 퀴즈 중간고사 기말고사 성적을 사용자로부터 입력받아 성적 총합 계산
        //     * 
        //     * 퀴즈 #1 성적 : 10
        //     * 퀴즈 #2 성적 : 20
        //     * 퀴즈 #3 성적 : 30
        //     * 
        //     * 중간고사 성적 : 80
        //     * 기말고사 성적 : 80
        //     * =================
        //     * 성적 총합 :  
        //     * =================
        //     * 
        //     */


        //    Console.WriteLine("퀴즈와 중각/기말고사 성적을 입력하세요. \n 퀴즈#1 성적 : ");


        //    string inputRecordQ1 = Console.ReadLine();
        //    int quize1 = default;
        //    int.TryParse(inputRecordQ1, out quize1);



        //    Console.WriteLine("퀴즈#2 성적 : ");


        //    string inputRecordQ2 = Console.ReadLine();
        //    int quize2 = default;
        //    int.TryParse(inputRecordQ2, out quize2);

        //    Console.WriteLine("퀴즈#3 성적 : ");


        //    string inputRecordQ3 = Console.ReadLine();
        //    int quize3 = default;
        //    int.TryParse(inputRecordQ3, out quize3);



        //    Console.WriteLine("중각고사 성적 : ");


        //    string inputRecordMidtermExam = Console.ReadLine();
        //    int midtermExam = default;
        //    int.TryParse(inputRecordMidtermExam, out midtermExam);

        //    Console.WriteLine("기말고사 성적 : ");


        //    string inputRecordFinalExam = Console.ReadLine();
        //    int finalExam = default;
        //    int.TryParse(inputRecordFinalExam, out finalExam);

        //    int total = quize1 + quize2 + quize3 + midtermExam + finalExam;

        //    Console.WriteLine("퀴즈 #1 성적 : {0} \n퀴즈 #2 성적 : {1} \n퀴즈 #3 성적 : {2} \n중간고사 성적 : {3} \n기말고사 성적 : {4}\n ==================== \n 성적 총합: {5}\n ====================", quize1, quize2, quize3, midtermExam, finalExam, total);



        //}
    }
}