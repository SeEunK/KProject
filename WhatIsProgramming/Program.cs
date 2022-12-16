using System;
using System.Globalization;
using System.Windows.Markup;
using System.Xml.Linq;

namespace WhatIsProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //  한줄 주석이다.
            /*
             *  여러줄 주석이다.
             *  주석은 메모하고 싶을때 쓰는 기능
             *  Comment 
             */

            /**
             * 컴퓨터는 하드웨어와 소프트웨어로 구성.
             * 하드웨어는 PC, 스마트폰과 같은 물리적으로 존재하는 장치를 의미함.
             * 소프트웨어는 이러한 하드웨어에 설치된 운영체제, 앱 등을 의마함.
             * 
             * 프로그램(program)이란?
             * 우리가 하고자 하는 작업을 컴퓨터에게 전달해주는 역할을 하는 소프트웨어를 의미함.
             * 
             * 프로그램 안에는 "무엇을 어떤식으로 해라" 와 같은 형태의 명령어(Instruction) 들이 들어있다.
             * 
             * 소프트웨어를 만드는 행위를 프로그래밍(programming) 또는 코딩(Coding)이라고 한다.
             * 
             * 컴퓨터가 알아듣는 언어는 한가지 뿐.
             * 0과 1의 형태로 되어있으며 기계어(Machine language)라고 부름
             * 과거 초기 형태의 컴퓨터는 이러한 기계어를 사용하여 프로그래밍 했음..
             * 
             * 기계어는 인간에게 상당히 불편(난해)한 언어이기 때문에 사람이 이해하기 쉬운 프로그래밍 언어가 만들어 지게 됨.
             * 프로그래밍 언어의 예약어(keyward)와 문법으로 소프트웨어를 만드는 사람을 프로그래머 (programmer) 또는 개발자(developer)라고 한다.
             * 
             * 프로그래밍 언어의 문법에 맞게 작성한, 텍스트로 된 명령 집합을 코드 (code)또는 소스(source)라고 함.
             * 소스코드를 기계어로 번역하는 작업을 컴파일(compile)이라 한다.
             * 이러한 작업을 하는 소프트웨어를 컴파일러(comoiler)라고 한다.
             * 
             * 프로그램밍을 하는 과정은 다음과 같다.
             * 1. 텍스트 에디터 소스를 작성하여 파일로 저장한다. ex) .cs 파일 
             * 2. 소스 파일을 컴파일하여 실행 프로그램을 생성한다. ex) .exe 파일 
             * 3. 프로그램을 실행한다.
             * 이 중 1,2 단계를 합쳐서 흔히 빌드(Build)라고 한다.
             * 
             * 프로그래밍 과정 중 발생한 오류를 버그(Bug)라고 한다.
             * 오류를 탐색하고 수정하는 과정을 디버그(Debug), 디버깅(Debugging) 또는 트러블슈팅(Trouble shooting)이라고 한다.
             * 
             * 
             * C#의 경우
             * C# 언어로 코딩 -> IL(Intermediate Langusge)코드로 변환 -> 기계어
             * 
             * C#의 특징
             * C#은 .Net을 위한 많은 언어 중 하나로, 마이크로소프트의 닷넷 플랫폼을 기반으로 한다.
             * 절차적 언어와 객체지향적 언어의 특징, 그리고 함수형 프로그래밍 스타일을 제공하는 다중 패러다임 프로그래밍 언어이다.
             * 
             * - C,C++,Java, Javascript와 기초 문법이 비슷하다.
             * - 자동으로 메모리를 관리한다. (Garbage collection 기능을 제공)
             * - 컴파일 기반 언어이다.
             * - 강렬한 형식(Strongly typed)의 언어이다.
             * - Generic과 LINQ 등 편리한 기능을 제공한다.
             * 
             * .Net(닷넷)
             * - 닷넷 프레임워크와 닷넷 코어를 합쳐서 편하게 닷넷이라 한다.
             * - 소프트웨어 프레임워크로, 응용 프로그램의 개발 속도를 높이는데 도움이 되는 
             *      API(Application Programming Interface) 및 서비스 모음이다.
             *      
             * 프레임워크 :  응용 프로그램의 개발 속도를 높이는데 도움이 되는 API 및 서비스 모음이다.
             * 
             * 함수, 라이브러리, API ??
             * - 함수 : 프로그램에서 사용하기 위한 기능의 단위를 의미함. 보통 하나의 함수는 하나의 기능을 함.
             * - 라이브러리 : 어떠한 기능을 구현할때 도움이 되는 기능,함수의 모음이다.
             * - API : 어떠한 기능을 구현할때 도움이 되도록 문서와 함께 제공되는 라이브러리, 함수의 모음이다.
             * 
             * 플랫폼 : 프로그램을 실행하기 위한 배경 환경 또는 운영체제를 의미한다.
             * 
             * 
             * C#의 기본 코드 구조
             * C# 프로그램은 class와 main()메서드가 반드시 있어야하고, 하나 이상의 문(statement)이 있어야한다.
             * C#의 기본 코드는 위쪽에 네임스페이스 선언부와 main()메서드가 오고, 중괄호 시작과 끝을 사용하여 
             * 프로그램 범위(Scope)를 구분한다.
             * 
             * 네임스페이스: 자주 사용하는 네임스페이스를 상단에 미리 선언해 둘수있다.
             * Main() 메서드 : 프로그램의 시작 지점이며, 반드시 있어야 한다.
             * 중괄호 ({}) : 프로그램 범위를 구분 짓는다.
             * 세미콜론(;) : 명령어(문, 문장)의 끝을 나타낸다.
             * 
             * Main() 메서드
             * - 메서드 (Method):클래스에서 제공하는 멤버 함수를 의미한다.
             * - Main() 앞에 static 키워드가 있어 개체를 생성하지 않고 바로 실행할수 있다.
             * - Main() 메서드가 2개이면 "프로그램 진입점이 2개 이상 정의되어있습니다." 라는 에러 메시지가 출력되어 프로그램이 컴파일되지않음.
             * 
             * 대, 소문자 구분하기
             * C#은 대,소문자를 구분하기 때문에 정확히 입력하지 않으면 에러가 발생.
             * 
             * 문법, 스타일, 패턴
             * - 문법(syntex) : 프로그래밍을 하기위해 반드시 지켜야 하는 규칙(Rule)이다.언어별로 차이가 있다
             * - 스타일(Style) : 프로그래밍 가이드라인(Guideline)이다.
             * - 패턴(Pattern) : 자주 사용하는 규칙과 스타일 모음이다.
             * 
             * 정규화된 이름
             * 정규화된 이름 (Fully qualified names)은 아래와 같이 네임스페이스 이름과 형식 이름까지 전체를 지정하는 방식.
             *   > System.Console.WriteLine("Hello, world!");
             * 
             * 
             * 출력문 : 명령 프롬프트에 출력하는 구문
             * 주석문 : 실행에 영향을 주지않는 코드 설명문
             * - 한 줄 주석.
             * - 여러줄 주석.
             * 
             * 
             * 
             */

            //Console.WriteLine("Hello, World!");
            //Console.Write("Hello, World!");

            //Console.WriteLine("Hello, World!"); 
            //Console.WriteLine("Hello, World!");


            /**
             * 들여 쓰기 : 프로그램 소스 코드의 가독성을 위해서 사용하는 일반적인 들여쓰기 규칙
             * - 보동 4칸의 공백(space)또는 Tab을 사용하지만 혼용하면 안된다.
             * 
             * 공백 처리 : C#에서 명령어 사이, 기호와 괄호 사이의 공백, Tab, 줄바꿈은 무시된다.
             *  
             * 1) Console  .   WriteLine("Hello, World!");
             * 2) Console.WriteLine    ("Hello, World!");
             * 3) Console.WriteLine(
             *      "Hello, World!"
             *      );
             */

            /**
             * 이스케이프 시퀀스
             * - C#은 WriteLine()메서드에서 사용할 확장 문자를 제공하는데, 이스케이프시퀸스(Escapesequence)라고 한다.
             * - 역슬래쉬(\) 기호와 특정 문자를 조합하면 특별한 기능을 사용할수 있다.
             * - 어떤 이스케이프 시퀸스가 있는지 검색하면 알수있다.
             *      ex) \n, \b, \f, \t등...
             * 
             * 
             * 
             */

            /**
             * 문자열 보간법
             * 문자열 보간법 (string interpolation) 또는 문자열 템플릿(string template)이라고도 한다.
             * 문자열을 묶어서 처리하기 위한 기능.
             * 기존에는 String.Format()메서드를 주로 사용했는데, C# 6.0 버전 부터는 $"{}" 형태로 간결하게 제공하고있다.
             * 
             */

            //string hello = "Hello";
            //string world = "world!";
            //Console.WriteLine("{0},{1}", hello, world);
            //Console.WriteLine($"{hello},{world}");


            //const int Num_Three = 3;
            //const string ODD_WORD = "홀수";
            //Console.WriteLine($"{Num_Three}은(는) {ODD_WORD}입니다.");


            //string stringFormat = string.Format("{0}은(는) {1}입니다.", Num_Three, ODD_WORD);
            //Console.WriteLine(stringFormat);

            //// 이렇게 문자열을 "+"연산하면 특히 느리다.
            //string stringPlus = Num_Three + "은(는)" + ODD_WORD + "입니다.";
            //Console.WriteLine(stringPlus);




            // 이름/ 과정명 / 학습교과 한줄씩 쓰기!

            //string name = "김세은";
            //string className = "(게임콘텐츠제작) 모바일 게임 개발자 양성과정C";
            //string studyName = "(전공)게임 프로그래밍 기초 기술";

            //Console.WriteLine($"이름: {name}\n과정명 :{className}\n학습교과:{studyName}");




            /**
             * 변수 
             * 프로그램에서 값을 다루려면 데이터를 메모리에 잠시 보관해 놓고 사용할수 있는 임시 저장공간이 필요하다
             * 이때 변수를 사용한다. 
             * 변수를 사용하는 순서는 선언(메모리에 공간을 확보)하고 정의(대입,할당)하여 사용하는 것이다.
             * 변수는 데이터 형식, 변수의 이름, 대입한 값으로 이루어져있다.
             * 
             * 
             * - 변수 선언 : 메모리에 데이터를 저장할 공간을 확보하는것.
             * - 변수 정의 : 확보한 공간에 값을 지정하는 것.
             * - 변수 초기화 : 변수를 선언한 직후, 초기값으로 정의하는것.
             * // 초기화는 변수의 초기값을 명확하게 정의하여 원치않는 논리적 오류를 방지하는 역할을 한다.
             *
             *
             */

            //int number; //선언
            //number = 100; //정의

            //int number2 = 1; //초기화

            //Console.WriteLine($"number :{number}\nnumber2:{number2}");

            /**
             *
             * Memory safety [과제]
             *
             *
             *
             *
             *
             */


            //Console.WriteLine("int는 얼마만큼의 메모리를 할당하나요? --> {0}byte", sizeof(int));

            /**
             * bit : 0 또는 1로 표현할 수 있는 최소 단위
             * [0][0]
             * [0][1]
             * [1][0]
             * [1][1]
             * 
             * byte 숫자를 세는 단위. 8bit = 1byte
             * 
             * 
             */




            /**
             * 변수 사용할때 주의사항(규칙)
             * 변수의 이름을 지을때 다음 규칙을 지켜야한다.
             * - 변수의 첫 글자는 반드시 문자로 지정한다. (숫자는 변수의 이름 첫글자로 사용 X)
             * - 길이는 255자 이하로 하고 공백을 포함할수 없다.
             * - 영문자와 숫자, 언더스코어(_)조합으로 사용하며, 기타 특수 기호는 사용할수없다.
             * - C#에서 사용하는 키워드는 사용할수 없다.
             * - 변수는 대,소문자를 구분하고, 일반적으로 소문자로 시작한다.
             * - 변수는 타인이 보더라도 이해할수 있는 이름으로 사용한다.
             *
             *
             *
             *
             *
             * 데이터 형식
             * 변수에 지정할 수 있는 데이터의 종류를 자료형 (Data type) 이라고 한다.
             * int,string, bool, double, object 등 C#에서 기본으로 제공하는 데이터 형식을 기본형식(primitive type)이라 한다.
             * 
             * - int : 정수형 데이터 타입 (음수,양수,0)
             * - float : 실수형 데이터 타입 (보동 소수점 형태 ex: 3.14) // 4byte
             * - double : 실수형 데이터 타입이지만 float 보다 크다 // 8 byte 
             * - bool : 논리값을 가지는 데이터 타입 (true, false)
             * - string : 문자열 가지는 데이터 타입 ("hello world")
             * - char : 한 문자를 가지는 데이터 타입 ('a')
             * - object :C#에서 모든자료형의 부모형 데이터 타입 (모든 데이터 저장 가능)
             * 
             * 
             */

            /**
             * 상수와 리터럴
             * 
             * 상수
             * - 변수를 선언할 때 앞에 const 키워드를 붙이면 상수(constant)가 된다.
             * - 한번 상수로 선언된 변수는 다시 값을 바꿀수 없고, 반드시 서넌과 동시에 초기화해야한다.
             * - 이러한 const 키워드를 붙인 변수를 상수 또는 지역(Local) 상수라고 한다.
             * - 상수는 주로 대문자로 표현한다.
             * 
             * 리터럴
             * - 변수에 저장하기 위해 직접 대입하는 값 자체를 리터럴(Literal)이라고 한다.
             * - 정수형 리터럴 : 숫자 그대로 표현한다.                           ex) 1234
             * - 실수형 리터럴 : 대문자 F or 소문자 f 를 접미사로 붙여 표현한다.     ex) 3.14F
             * - 문자형 리터럴 : 작은 따옴표로 묶어서 표현한다.                  ex) 'A'
             * - 문자열 리터럴 : 큰 따옴표로 묶어서 표현한다.                   ex) "Hello"
             * 
             * 숫자 구분자 사용
             * - C# 7.0 버전 부터는 언더스코어(_) 문자를 사용하는 숫자 구분자(Digit separator)를 제공한다.
             * - 숫자 형식을 표현할때 언더스코어 문자를 무시한다.
             * - 이를 이용하면 긴 숫자를 표시할때 가독성을 높일수 있다.
             * 
             */

            int number = 0;
            Console.WriteLine(number);
            number = 1;
            Console.WriteLine(number);
            // 이렇게 하면 number 0 이 1로 바뀜

            const int CONST_FIVE = 5; // 5 = 정수형 리터럴
            // CONST_FIVE = 3;  이미 5로 선언한 상수이기때문에 바꿀수없다.

            const float PI = 3.14f; // 실수형 리터럴
            int bigNumber = 110000 - 1000;// 숫자 구분자 사용 비교용 
            int bigNumberDigit = 110_000 - 1000;// 숫자 구분자 사용
            Console.WriteLine("bigNumber - 1000의 값이 변하지 않을까? {0}", bigNumber);
            Console.WriteLine("bigNumberDigit - 1000의 값이 변하지 않을까? {0}", bigNumberDigit);

            bool boolType;
            boolType = true;
            boolType = false;


            //[ 실습 ] 정수형으로 반지름을 선언하고, 상수형으로 원주율을 선언하고 그 원의 넓이를 구하라.


            int radius = 3;
            const float CONST_PI = 3.14f;
            float tempRaius = (float)radius;

            float value = tempRaius * tempRaius * CONST_PI;

            Console.WriteLine("원의 넓이는 : {0}", value);


            /*
             * null 키워드
             * C#에서 null 키워드는 아무것도 없는 값을 의미한다.
             * 
             * null 가능 형식 (nullable)
             * 숫자 형식의 변수를 선언할때 int?, float? 와 같이 물음표(?) 기호를 붙이면 null 가능 형식으로 변경된다.
             * 이러한 null 가능 형식에는 아무런 값도 없음을 의미하는 null을 대입할수 있다.
             * 
             *
             * 
             */

            int? nullNumber = null;
            Console.WriteLine("Null 을 눈으로 보고 싶다 -> {0}", nullNumber);
            int doNothingNumber = 0;

            string nullString = null;
            // string nullString = string.empty 로 도 됨.



            /**
             * 자동 타입 추론(Automatic type deduction)
             * 변수에 대입하는 값의 데이터 타입이 명시적이거나 명확할때, 데이터 타입을 명시하지 않고 생략할수 있다.
             * 자동 타입 추론이란 컴파일러가 대입하는 값 또는 변수의 데이터 타입으로 다른 한쪽의 데이터 타입을 추론하는 기능을 의미한다.
             * 
             * default 값
             * C# 6.0 버전 부터는 자동 타입 추론으로 기본 형식에 default 값을 대입할수 있다.
             * 기본 형식 마다 정해진 default 값이 존재한다.
             * 
             * 
             * 
             * 
             */

            int defaultNumber = default;
            string defaultString = default;
            char defaultCharValue = default;
            float defaultFloatValue = default;

            var autoVaribleInt = 10;
            var autoVaribleFloat = 3.14f;
            var autoVaribleDouble = 3.14;



            /**
             * 열거형 형식
             * C# 에서 열거형 (Enumeration) 형식은 기억하기 어려운 상수들을 기억하기 쉬운 이름 하나로 묶어 관리하는 표현 방식이다.
             * 일반적으로 열거형으로 줄여 말한다. 열거형은 enum 키워드를 사용하고 "이늄" 또는 "이넘"으로 읽는다.
             * 열거형 클래스 범위 내에 정의해야 하며, 메서드 범위 안에는 정의할수없다.
             * 
             */

            //Align align = Align.TOP;
            //align = Align.LEFT;

            //Console.WriteLine("Enumeration 데티어는 어떻게 보일까? --> {0}", align);




            /**
             * 입출력에 대해서
             * 프로그램을 실행할때마다 서로 다른 값을 입력받으려면 콘솔에서 입력한 값을 변수에 저장 할수 있어야한다.
             * 키보드로 입력받고 모니터로 출력하는 일반적인 내용을 표준 입출력 (standard input/output)이라고 한다.
             * 
             * System.console.ReadLine()    : 콘솔에서 한줄을 입력받는다.
             * System.console.Read()        : 콘솔에서 한 문자를 정수로 입력받는다.
             * System.console.ReadKey()     : 콘솔에서 다음 문자나 사용자가 누른 기능 키를 가져온다.
             * 
             * 
             */

            Console.WriteLine("이름을 입력하세요 :)");
            string yourName = string.Empty;
            yourName = Console.ReadLine();


            Console.WriteLine("안녕하세요. {0}님.", yourName);

            /**
             * 형식 변환
             * Console.ReadLine() 메서드를 사용하여 콘솔에서 입력받은 데이터는 문자열이다.
             * 문자열 대신 정수나 실수 데이터를 입력받고 싶다면 입력된 문자열을 원하는 데이터 형식으로 변환할수 있어야한다.
             * 
             * 키워드 : 캐스팅 연산자, 암시적(묵시적) 형변환, 명시적 형변환
             * 
             * 3가지 형변환 방법
             * 
             * 
             */

            //Console.Write("숫자를 입력하세요: ");
            //string stringNumber = Console.ReadLine();
            
            //int intNumber = Convert.ToInt32(stringNumber);  // convert 메서드를 사용한 형변환
            //int intNumber2 = int.Parse(stringNumber);       // Parse를 이용한 형변환
            //int intNumber3 = default;
            //int.TryParse(stringNumber, out intNumber3);     // TryParse를 이용한 형변환 *선생님 추천 스타일



            //Console.WriteLine("입력한 숫자 + 10은 {0}입니다.", intNumber + 10);
            //Console.WriteLine("입력한 숫자 + 10은 {0}입니다.", intNumber2 + 10);
            //Console.WriteLine("입력한 숫자 + 10은 {0}입니다.", intNumber3 + 10);


            // [ 실습 ]
            // 실수형 변수로 반지를 사용자에게 입력받고, 실수형 상수로 원주율을 선언한 다음, 구의 겉넓이, 구의 부피 를 출력하는 프로그램 


            Console.Write("계산할 구의 반지름을 실수형으로 입력하세요: ");
            string stringNumber = Console.ReadLine();

            
            float intNumber3 = default;
            float.TryParse(stringNumber, out intNumber3);     // TryParse를 이용한 형변환 *선생님 추천 스타일

            float powOfThree = intNumber3 * intNumber3 * intNumber3;
            float powOfTwo = intNumber3 * intNumber3;

            float value1 = 4 * PI * powOfTwo;
            float value2 = (PI * powOfThree)/3*4;

            Console.WriteLine("입력한 구의 넓이는 {0}이고 구의 부피는{1}입니다.", value1, value2);

        }
        //enum Align { TOP, BOTTOM, LEFT, RIGHT }; //열거형 형식.
    }
}