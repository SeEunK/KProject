using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace whatIsClass
{
    internal class Program1
    {
        public static void Main()
        {
            /**
             *  C#의 모든 코드에 반드시 들어가는 클래스 (Class)알아보자.
             *  
             *  클래스 소개하기
             *  클래스는 지금까지 작성한 모든 예제에서 기본이 되는 C#의 핵심 코드이다.
             *  
             *      public class [class name]
             *      {
             *          - some thing 
             *      }
             *      
             *  같은 코드 블록을 사용하여 정의할수 있다.
             *  클래스를 정의하는 전반적인 내용과 클래스 내부 또는 외부에 올수 있는 구성요소는 다음장에서 살펴볼것.
             *  
             *  클래스의 구성요소는 많지만, 그중에서 속성과 메서드를 가장 많이 사용한다.
             *  속성은 데이터를 다루고, 메서드는 로직을 다룬다.
             *  
             *  - 클래스
             *      ㄴ 속성 : 데이터
             *      ㄴ 메서드 : 로직
             *  
             *  클래스는 그 의미에 따라, 이미 닷넷 프레임워크에서 만들어 놓은 내장 형식(built -in type)과 
             *  사용자가 직접 클레스 구조를 만드는 사용자 정의 형식 (User defined type)으로 구분할수있다.
             *  예를 들어,
             *      - 내장 형식 : Console, String, Math 등 클래스
             *      - 사용자 데이터 형식 : Class 키워드로 Product, Note,User,Group 처럼 새로운 형식 (기존에 제공되지 않는)을
             *                            정의할수 있는데, 이를 사용자 데이터 형식이라고 한다.
             *  
             *  클래스 만들기
             *  클래스를 정의하면 다음과 같다.
             *      - 클래스는 개체(instance) 를 생성하는 틀(템플릿)이다.
             *      - 클래스는 무엇인가를 만들어 내는 설계도이다.
             *   
             *  클래스는 C# 프로그래밍의 기본 단위로 새로운 개체(실체)를 생성하는 설계도 (청사진) 역할을 한다.
             *  예를 들어 자동자라는 개체(Object)를 만들려면 자동차 설계도가 필요하다.
             *  이와 마찬가지로 프로그래밍에서도 설계도가 필요한데, 이역할을 하는 것이 클래스(Class)이다.
             *  즉, 클래스는 개체를 생성하는 틀(템플릿)이며, 더 간단히 말하자면 "무엇인가를 만들어 내는 설계도"이다.
             *  
             *  
             *  클래스 선언하기
             *      - 클래스 이름은 반드시 대문자로 시작한다.
             *      
             *  piblic class [ClassName]
             *  {
             *      //클래스 내용
             *      - 속성   -> 변수
             *      - 메서드 -> 함수
             *  }
             * 
             */

            //ClassNote classNote = new ClassNote();
            // ClassNote.StaticMethod(); //ClassNote 의 StaticMethod()접근 하는 방법

            /**
             * 클래스를 여러개 사용할때는 public 키워드를 써야한다.
             * public 키워드가 붙은 클래스는 클래스 외부에서 해당 클래스를 바로 호출해서 사용할수있도록
             * 공개되었다는 의미이다.
             * 반대 의미는 private 키워드를 사용한다.
             * 
             * static과 정적 메서드
             * C#에서는 static을 정적으로 표현한다.
             * 의미가 같은 다른 말로 표현하면, 공유 (Shared) 이다.
             * static이 붙는 클래스의 모든 멤버는 해당 클래스 내에서 누구나 공유해서 접근할수있다.
             * 메서드에 static이 붙는 메서드를 정적 메서드라고 하는데, 이를 공유 메서드 (Shared Method)라고도 한다.
             * 
             * 정적 메서드와 인스턴스 메서드
             * 닷넷의 많은 API 처럼 우리가 새롭게 만드는 클래스는 메서드를 포함한 각 멤버에 static 키워드
             * 유무에 따라 정적 또는 인스턴스 멤버가 될수있다.
             * 
             */

            if (false)
            {
                ClassNote.StaticMethod();
                //ClassNote.InstanceMethod(); --> static 이 안붙은 instance method 는 접근 불가.

                ClassNote classNote = new ClassNote(); // 인스턴스 화 한것 (메모리에 할당)
                classNote.InstanceMethod(); // ClassNote를 인스턴스 화 한뒤에는 InstanceMethod에 접근가능!

            }



            /**
             * 클래스 시그니쳐
             * 클래스는 다음 시그니처를 가진다.
             *      public class Car {}
             *  
             *  public 액세스 한정자를 사용하면 기본값인 internal을 갖는데 internal은 해당 프로그램 내에서
             *  언제든지 접근 가능하다.
             *  
             *  하지만 학습 단계에서는 클래스에 public 만 사용해도 괜찮다.
             *  
             *  그리고 class 키워드 다음에 클래스 이름이 오는데 클래스 이름은 대문자로 시작하는 명사를 사용한다.
             *  
             *  class 본문 또는 몸통(Class Body)을 표현하는 중괄호 안에는 지금까지 배운 메서드와 앞으로 다룰
             *  필드, 속성, 생성자, 소멸자 등이 올수 있는데, 이모두를 가리켜 클래스 멤버라고 한다.
             *  
             *  클래스 이름 짓기
             *  클래스 이름은 의미있는 이름을 사용하면 좋다.
             *  이름은 명사를 사용하며, 첫 글자는 꼭 대문자여야 한다.
             *  또 클래스 이름을 지을때는 축약형이나 특정 접두사, 언더스코어(_) 같은 특수 문자는 쓰지않는다.
             *      - 클래스 이름은 누구나 알기 쉽게
             *      - 간단하고 명확하게
             *  
             *  클래스의 주요 구성요소
             *  클래스의 시작과 끝. 즉, 클래스 블록 내에는 다음 용어 (개념) 들이 포함될수있다.
             *  일반적으로 클래스 구성요소를 가리킬때 클래스 맴버라는 용어와 혼용해서 사용한다.
             *      
             *      - 필드(Field) : 클래스의 부품역할을 한다. 클래스 내에 선언된 변수나 데이터를 담는 그릇으로,
             *                      개체 상태를 저장한다.
             *                      
             *      - 메서드(Method) : 개체 동작이나 기능을 정의한다.
             *      
             *      - 생성자(Constructor) : 개체 필드를 초기화 한다. 즉, 개체를 생성할때 미리 수행해야 할 기능을 정의한다.
             *      
             *      - 소멸자(Destructor) : 개체를 모두 사용한 후 메모리에서 소멸될때 실행한다.
             *      
             *      - 속성(Property) : 개체의 색상, 크기, 형태 등을 정의한다.
             *      
             *  액세스 한정자
             *  클래스를 생성할때 public, private, internal, abstract, sealed 같은 키워드를 붙일수있다.
             *  이를 액세스 한정자라고 한다.
             *  액세스 한정자는 클래스에 접근할수 있는 범위를 결정하는데 도움이 된다.
             *  특별히 지정하지 않는 한 기본적인 public 액세스 한정자를 사용하면된다.
             *  
             */

            TrumpCard trumpCard = new TrumpCard();
            trumpCard.SetupTrumpCards();
            trumpCard.ShuffleCards(200);
            trumpCard.PrintCardSet();
            trumpCard.RollCard();

            if (false)
            {
                Random random = new Random(); // 랜덤 클래스 인스턴스 화 함.
                int randomNumber = random.Next(1, 100 + 1); //Next()는 인스턴스 메서드



                int roundCount = 1;
                LottoGenerate lottoFirst = new LottoGenerate();
                int[] lottoResult = lottoFirst.RandomNumber(roundCount);

                int resultNumCount = lottoResult.Length;

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=↓=↓=↓=↓=내가 짠 Lotto 결과=↓=↓=↓=↓=");
                Console.ResetColor();
                Console.WriteLine();

                for (int i = 0; i < resultNumCount; i++)
                {
                    Console.WriteLine("{2}회차 로또 {0}번째 숫자는 : {1}", (i + 1), lottoResult[i], roundCount);
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("=↓=↓=↓=↓=다른 방법으로 Lotto 결과=↓=↓=↓=↓=");
                Console.ResetColor();
                Console.WriteLine();

                LottoCreator lottoCreator = new LottoCreator();
                lottoCreator.PrintLottoNumber();
            }

            if (false)
            {
                //가위바위보~~~게임
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("=↓=↓=↓=↓=가위바위보게임=↓=↓=↓=↓=");
                Console.ResetColor();
                Console.WriteLine();
                int rpsRound = 0;
                string gameEnd = string.Empty;
                while (true)
                {

                    rpsRound++;
                    Console.WriteLine("가위: 1 / 바위: 2 / 보: 3 입력");
                    Console.WriteLine();


                    Console.WriteLine("========= 라운드 {0} ===========", rpsRound);
                    RockPaperScissorsCreate game = new RockPaperScissorsCreate();
                    int comChoice = game.ComputerHand();
                    int userInput;
                    int.TryParse(Console.ReadLine(), out userInput);
                    Console.WriteLine("========= [ 결과 ] ==========");
                    game.IsUserWinner(comChoice, userInput);
                    Console.WriteLine("=============================");


                    Console.WriteLine("게임 종료 : * 입력");
                    gameEnd = Console.ReadLine();

                    if (gameEnd == "*")
                    {
                        break;
                    }
                }
            }

        } //main()

    } //class Program1

    public class ClassNote
    {
        public static void StaticMethod()
        {
            Console.WriteLine("ClassNote Class  [StaticMethod()]");

        }
        public void InstanceMethod()
        {
            Console.WriteLine("ClassNote Class  [InstanceMethod()]");
        }
    }

    public class LottoGenerate
    {
        public int[] RandomNumber(int count)
        {
            Random ramdum = new Random();
            int[] lottoResult = new int[6];

            while (true)
            {
                for (int i = 0; i < lottoResult.Length; i++)
                {
                    int randumNum = ramdum.Next(1, 45 + 1);
                    for (int j = 0; j < i; j++)
                    {
                        if (lottoResult[i] == lottoResult[j])
                        {
                            break;
                        }
                        else { }
                    }
                    lottoResult[i] = randumNum;
                }
                break;
            }
            return lottoResult;
        }
}



    //다른 방법
    public class LottoCreator
    {
        int[] lottoNums;

        public void PrintLottoNumber()
        {
            lottoNums = new int[45];
            for(int i =0; i<45; i++)
            {
                lottoNums[i] = i+1;
            }
            
            for (int i = 0; i < 100; i++)
            {
                lottoNums = ShuffleOnce(lottoNums);
            }

            for (int i = 0; i <6; i++)
            {
                Console.WriteLine("{0}",lottoNums[i]);    
            }
            Console.WriteLine();
        }

        //!배열은 1번 섞는 함수
        public int[] ShuffleOnce(int[] lottoNum_)
        {
            Random ramdum = new Random();
            int sourIndex = ramdum.Next(0, lottoNum_.Length);
            int destIndex = ramdum.Next(0, lottoNum_.Length);

            int tempVarible = lottoNum_[sourIndex];
            lottoNum_[sourIndex] = lottoNum_[destIndex];
            lottoNum_[destIndex] = tempVarible;

            return lottoNum_;
        }
    }

    public class RockPaperScissorsCreate
    {
        int[] hand;

        public int ComputerHand()
        {
            hand = new int[3];

            for (int i = 0; i < 3; i++)
            {
                hand[i] = i + 1;
            }

            for (int i = 0; i < 10; i++)
            {
                hand = Choice(hand);
            }

            return hand[0];
        }

        public int[] Choice(int[] hand)
        {
            Random ramdum = new Random();
            int sourIndex = ramdum.Next(0, hand.Length);
            int destIndex = ramdum.Next(0, hand.Length);

            int tempVarible = hand[sourIndex];
            hand[sourIndex] = hand[destIndex];
            hand[destIndex] = tempVarible;

            return hand;
        }

        // 가위 1
        // 바위 2
        // 보  3

        public int IsUserWinner (int computerValue, int userValue)
        {
            int[] printValue = { computerValue, userValue };

            for (int i = 0; i < printValue.Length; i++)
            {
                switch (printValue[i])
                {
                    case 1:
                        if(i == 0) 
                             { Console.Write("컴퓨터 :");}
                        else { Console.Write(" VS 유  저 :"); }
                
                        Console.Write("X");
                        break;

                    case 2:
                        if (i == 0)
                        { Console.Write("컴퓨터 :"); }
                        else { Console.Write(" VS 유  저 :"); }
                        Console.Write("O");
                        break;
                    case 3:
                        if (i == 0)
                        { Console.Write("컴퓨터 :"); }
                        else { Console.Write(" VS 유  저 :"); }
                        Console.Write("ㅁ");

                        break;
                    default:
                       
                        Console.Write("잘못된 결과!!!");
                        break;
                }
            }
            Console.WriteLine();

            if (computerValue == 1 && userValue == 2 || 
                computerValue == 2 && userValue == 3 ||
                computerValue == 3 && userValue == 1)
            {// 유저 승리
                
                Console.WriteLine("이겼습니다! [승리자 : 유저]");
                return 0;
            }
            else if(computerValue == 1 && userValue == 3 ||
                    computerValue == 2 && userValue == 1 ||
                    computerValue == 3 && userValue == 2)
            {// 유저 패배 (컴퓨터 승리)
                Console.WriteLine("졌습니다! [승리자 : 컴퓨터]");
                return 1;
            }
            else
            {// 비김
                Console.WriteLine("비겼습니다. [승리자 : 없음]");
                return -1;
            }

        }

       
        
    }
}
