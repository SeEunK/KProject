using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using WhatIsClass;

namespace WhatIsClass
{
    public class Description
    {
        private string stringField = "이것은 전역변수(필드)인데, 어디서 접근이 가능한가? ";
        
        public void valueTypeAndRefferenceType()
        {
            /**
             * 값 형식과 참조 형식
             * 클래스나 구조체 같은 데이터 형식을 말할때 값 형식(Value type)과 참조 형식(Reference Type)으로 구분짓기도한다.
             * 
             * 값 형식
             * 개체에 값 자체를 담고있는 구조이다.
             * 지금까지 다룬 int, double 등은 내부적으로 구조체로 된 전형적인 값 형식의 데이터 구조이다.
             * 
             * 참조 형식
             * 개체가 값을 담고있는 또다른 개체를 포인터로 바라보는 구조이다.
             * 여러 값이 동일한 개체를 가리킬 수 있다.
             * 
             * 
             */

            /**
             * 박싱과 언박싱
             * 프로그래밍을 하다 보면 데잍의 형식 변환이 필요하다.
             * 이러한 변환 과정에서 값 형식의 데이터를 참조 형식의 데이터로 변경하는 것을 박싱(Boxing)이라고 한다.
             * 반대로 참조 형식의 데이터를 값 형식의 데이터로 변경하는것을 언박싱(UnBoxing)이라고 한다.
             * 
             *    // 박싱 예시
             *    {
             *      int number = 1234;
             *      object objectValue = number;
             *    }
             *    
             *    좀 더 어렵게 말하면 스택 메모리 영역에 저장된 값 형식의 데이터를 힙메모리 영역에 
             *    저장하는 단계를 거치기 때문에 시간과 공간이 소비되는 비용이 발생한다.
             *    
             *    
             * 
             * 박싱
             * 박싱이란 말 그대로 박스에 포장을 하는것이다.
             * C#에서 박싱은 값 형식의 데이터를 참조 형식의 데이터로 변환하는 작업을 의미한다.
             * 예를 들어 다음 코드 처럼 정수 형식의 데이터를 오브젝트 형식의 데이터에 담는 형태를 박싱이라고 한다.
             * 
             * 
             * 언박싱
             * 다음 코드는 object 변수에 저장된 1234를 실제 정수 형식의 데이터로 변환하는 모습을 보여준다.
             * 참조 형식의 데이터를 값 형식의 데이터로 변환하는 과정이 포장을 푸는것과 비슷해 보여서 언박싱이라고한다.
             * 언박싱을 캐스트(Cast)또는 캐스팅 (Casting)으로 표현한다.
             * 
             *    {
             *        object objectValue = 1234;
             *        int number = (int)objectValue;
             *    }
             * 
             * object 형 변수에 들어있는 데이터 중에서 숫자 형식의 데이터는 바로 int 형 변수에 대입할수없다.
             * object형 변수 값을 int 형 변수에 대입하려면 형식 변환을 해야한다.
             * 형식 변환은 캐스팅이나 Convert 클래스 값은 변환 API 를 사용하면 된다.
             * 즉, (int)또는 Convert.ToInt32() 같은 형식 변환 관련 기능을 명시적으로 지정해 주어야 한다.
             * 
             * 
             * 
             */

            object objectValue;
            char charValue = 'a';
            int intValue = 97;
            char charValue2;

            objectValue = charValue; // 'a'
            charValue2 = (char)objectValue;

            Console.WriteLine("{0}", charValue2);

        }

        public void WhatIsField()
        {
            /**
             * 필드 (Field)는 클래스의 부품 역할을 하는 클래스의 내부 상태 값을 저장해 놓는 그릇을 의미한다.
             * 예를 들어 필드는 자동자 클래스에 선언된 변수로 자동차 부품에 해당한다고 할수있다.
             * 
             * 필드 
             * 클래스 내에서 선언된 변수 또는 배열 등을 C#에서는 필드라고 한다.
             * 필드는 일반적으로 클래스의 부품 역할을 하며, 대부분 private 액세스 한정자(Access modifier)가 붙고
             * 클래스 내에서 데이터를 담는 그릇 역할을 한다.
             * 이러한 필드는 개체 상태를 보관한다.
             * 
             * 필드는 선언한 후 초기화 하지 않아도 자동으로 초기화 한다. [*그래도 항상 초기화 하고 쓰자!!!*]
             * 예를 들어 int 형 필드는 0으로, string 형 필드는 String.Empty 즉,공백으로 초기화한다.
             * 
             * 
             * 지역 변수와 전역변수
             * C#에서 변수를 선언할때는 Main()메서드와 같은 메서드 내에서 선언하거나 메서드 밖에서,
             * 즉 메서드와 동등한 레벨에서 변수를 선언할수있다.
             * 
             * 메서드 내에서 선언된 변수 또는 배열을 지역 변수 (Local variable)라고 하며,
             * 메서드 밖에서 선언된 변수를 전역 변수(Global variable)라고 한다.
             * 다만 C#에서는 전역변수라는 용어를 사용하지않고 메서드와 동일하게 액세스 한정하는 붙여 필드라고 한다.
             * 
             * 지역 변수
             * 변수는 Main()메서드가 종료되면 자동으로 소멸된다.
             * 변수가 살아있는 영역은 Main()메서드의 중괄호 시작({)과 끝(}) 사이이다.
             * 특정 지역을 범위로 하기때문에 변수를 일반적으로 지역 변수라고 표현한다.
             * 
             * 전역 변수
             * Main()메서드가 아닌 클래스내에 선언된 변수를 필드라고 한다.
             * C#에서 필드는 변수와 마찬가지로 주로 소문자 또는 언더스코어(_)로 시작한다.
             * 이러한 필드는 메서드 내에서 선언된 지역 변수와 달리 전역 변수라고도 한다.
             * 
             */
        }//WhatIsField()


        public void WhatIsConstructor()
        {
            /**
             * C#에서 생성자는 클래스에서 맨 먼저 호출되는 메서드로, 클래스 기본값 등을 설정한다.
             * 자동자 클래스를 예로 들면, 자동차의 시동 걸기에 해당하는 것이 바로 생성자이다.
             * 
             * 생성자
             * 클래스의 구성요소 중에는 생성자(Constructor)라는 메서드가 숨어있다.
             * 단어 그대로 개체를 생성하면서 무엇인가를 하고자 할때 사용되는 메서드이다.
             * 일반적으로 생성자를 개체를 초기화 (주로 클래스 내 필드를 초기화)하는데 사용된다.
             * 생성자는 생성자 메서드라고도 한다.
             * 이러한 생성자는 독특한 규칙이 있는데, 바로 생성자 이름이 클래스 이름과 동일하다는것이다.
             * 클래스 내에서 클래스 이름과 동일한 이름을 갖는 메서드는 모두 생성자이다.
             * 
             * 생성자는 매개변수가 없는 기본 (Default) 생성자가 있고, 매개변수를 원하는 만큼 정의해서 사용할 수 도있다.
             * 이때 리턴값은 가지지않는다.
             * 또 생성자도 static 생성자(정적 생성자)와 public 생성자 (인스턴스 생성자)로 구분된다.
             * 일반적으로 public 키워드를 사용하는 인스턴스 생성자를 많이 사용한다.
             *    
             *
             */
        }

        public void WhatIsDestructor()
        {
            /**
             * 소멸자는 생성자와 반대 개념으로 클래스에서 인스턴스화된 개체가 메모리상에서 없어질때 실행되는 메서드이다.
             * 자동차 클래스를 예로 들면 자동차 주차 대행, 시동 끄기 등으로 볼수있다.
             * 
             * 종료자
             * 종료자(Finalizer)라고도 하는 소멸자(Destructor)는 닷넷의 가비지 수집기(GarbageCollector, GC)에서
             * 클래스의 인스턴스를 사용한 후 최종 정리할때 실행되는 클래스에서 가장 늦게 호출하는 메서드이다.
             * C#에서는 닷넷 가비지 컬렉터가(GC)가 개체를 소멸할때 메모리를 해제하는 등 역할을 대신해주기 때문에
             * 이 책에서는 소멸자에 직접 접근할 일이 없다.
             * 
             *  - 자동차 시동을 끄는 것에 비유할수있으며, 운전수가 주차하고 시동을 끄는것이 아니라
             *      주차 요원(GC)이 대신 주차하고 시동을 끄는것과 의미가 비슷하다.
             *  
             *  - 소멸자는 클래스 이름과 동일한 메서드로 앞에 물결 기호인 "~" (틸드) 를 붙여 만든다.
             *  - 소멸자도 특별한 형태의 메서드이다. 소멸자 또는 소멸자 메서드라고도 한다.
             *  - 생성자와 달리 매개 변수를 받을수없다.
             *  - 소멸자는 오버로딩을 지원하지 않으며 직접 호출할수없다.
             *  
             *  
             * 
             * 
             */
        }//WhatIsDestructor()

        public void WhatIsInheritance()
        {
            /**
             * 클래스 간에는 부모와 자식 관계를 설정할수 있다.
             * 이러한 내용을 개제 관계 프로그래밍(Object relationship programming) 이라고도 한다.
             * 상속은 부모 클래스에 정의된 기능을 다시 사용하거나 확장 또는 수정하여 자식 클래스로 만드는 것이다.
             * 특정 클래스에서 만든 기능을 다른 클래스에 상속으로 물려주면 장점이 많이 있다.
             * 
             * 
             * 클래스 상속하기
             * 개체 지향 프로그래밍의 장점 중 하나는 이미 만든 클래스를 재사용하는것이다.
             * 이 재사용의 핵심 개념이 바로 상속이다.
             * 부모 재삭을 자식에게 상속하듯이 부모 클래스(기본 클래스)의 모든 멤버를 자식 클래스(파생 클래스)가 
             * 재사용하도록 허가하는 기능이다. 
             * 여러 클래스 간의 관계를 설정할때 수평 관계가 아닌 부모와 자식 간 관계처럼 계층적인 관계를 표현할때
             * 사용하는 개념을 상속이라고 한다.
             * 
             * 클래스 상속은 단일 상속(Single inheritance)과 다중 상속(Multiple inheritance)으로 구분할수있다.
             * 단, C#의 클래스 상속은 단일 상속만 지원한다.
             * 다중 상속은 나중에 배울 인터페이스로 지원받을수있다.
             * 
             * 클래스 상속 구문
             * C# 에서는 다음과 같이 클래스 이름 뒤에 콜론(:)기호와 부모가 되는 클래스 이름을 붙인다.
             * 
             *  예를 들자면,
             *  
             *      public class [기본 클래스 이름]
             *      {
             *          //기본 클래스 멤버를 정의
             *      }
             *      
             *      public class [파생 클래스 이름] : [기본 클래스 이름]
             *      {
             *          //기본 클래스 멤버를 포함한 자식 클래스의 멤버를 정의
             *      }
             *      
             *  - System.Object 클래스 : System.Object 클래스는 모든 클래스의 부모 클래스이다.
             *      닷넷에서 가장 높은 계층에 속하는 시조(조상)클래스라고 할수있다.
             *      새롭게 만드는 C#의 모든 클래스는 자동으로 Object 클래스에서 상속받기 때문에
             *      Object 클래스를 상속하는 코드는 생략 가능하다.
             *  
             *  - 기본 (Base) 클래스 : 다른 클래스의 부모 클래스가 되는 클래스로 기본 클래스라고 한다.
             *      기본 클래스를 다른 말로 Base 클래스, Super 클래스, 부모 클래스로 표현한다.
             *      
             *  - 파생 (Derived) 클래스 : 다른 클래스의 자식 클래스가 되는 클래스를 파생 클래스라고 한다.
             *      파생 클래스는 다른 클래스에서 멤버를 물려 받은 것으로, Dereved 클래스, Sub 클래스, 자식 클래스로 표현한다.
             *      
             *      
             *  부모 클래스와 자식 클래스 
             *  프로그래밍에서 상속을 표현할때 상속을 주는 클래스를 부모 클래스라고 하며,
             *  상속을 받는 클래스를 자식 클래스 라고 한다. 
             *  콜론(:) 기호로 상속 관계를 지정하면 부모 클래스의 publiec 멤버들은 자식클래스에서 그래도 물려 받아 사용할수있다.
             *  public , protected 로 선언된 멤버들도 자식 클래스에서 사용 가능하다. 
             *  (private로 선언된 멤버는 상속이 안됨!)
             *  
             * 
             */

        }//WhatIsInheritance()

    } //class

    class Parent
    {
        public string stringValue = "stringValue -> 부모 클래스의 멤버 변수";
        protected int intValue = 1234;
        private float floatValue = 3.14f;
        public void Print(){
            Console.WriteLine("부모 클래스의 멤버 호출");
        }
    }

    class Child : Parent
    {
        public void PrintChild()
        {
           
            Console.WriteLine("자식 클래스의 멤버 호출");
            Console.WriteLine("부모 클래스의 멤버 변수 호출 : {0},{1} ", base.stringValue, base.intValue);
            // Parent class의 private 변수인 floatValue는 접근 못함.

        }
    }

    // ========================================================================================



    //class Battle
    //{
    //    protected string startTarget = string.Empty;


    //    public void BattlePVE(BasePlayer attacker, BasePlayer targetPlayer)
    //    {
    //        //배틀을 시작할때 타겟의 이름을 체크
    //        startTarget = targetPlayer.name;

    //        while (true)
    //        {
    //            Attack(attacker, targetPlayer);
    //            Defence(attacker, targetPlayer);
    //            if (targetPlayer.hp <= 0)
    //            {
    //                if (targetPlayer.name == startTarget)
    //                {
    //                    Console.WriteLine("{0}를 처지했습니다.", targetPlayer.name);
    //                    Console.WriteLine();

    //                }
    //                else
    //                { // 유저 캐릭 사망
    //                    Console.WriteLine("{0}에게 죽었습니다.", attacker.name);
    //                    Console.WriteLine();
    //                }
    //                break;
    //            }
    //            else
    //            {//공 수 변경
    //                BasePlayer temp = attacker;
    //                attacker = targetPlayer;
    //                targetPlayer = temp;
    //            }
    //        }
    //    }

    //    public void Attack(BasePlayer attacker, BasePlayer targetPlayer)
    //    {
    //        Console.WriteLine("[{0}]이/가 [{1}]를 공격합니다.", attacker.name, targetPlayer.name);

    //    }

    //    public void Defence(BasePlayer attacker, BasePlayer targetPlayer)
    //    {
    //        int damage = 0;
    //        if (attacker.criticalRate > 0)
    //        {

    //            Random random = new Random();
    //            float randomRate = random.Next(1, 100 + 1);
    //            if (randomRate <= attacker.criticalRate)
    //            {
    //                damage = attacker.damage * 5;
    //                Console.WriteLine("[SYSTEM] !!! CRITICAL !!!");
    //            }
    //            else
    //            {
    //                damage = attacker.damage;
    //            }
    //        }
    //        else
    //        {
    //            damage = attacker.damage;
    //        }

    //        if (damage - targetPlayer.defence <= 0)
    //        {
    //            Console.WriteLine("[SYSTEM] MISS!");
    //            Console.WriteLine();
    //        }
    //        else
    //        {
    //            Console.WriteLine("[{0}]가 [{1}]만큼 데미지를 입었습니다.", targetPlayer.name, (damage - targetPlayer.defence));
    //            Console.WriteLine();
    //            targetPlayer.hp = targetPlayer.hp - damage;
    //        }
    //    }

    //    public void Run(BasePlayer runner)
    //    {
    //        Console.WriteLine("{0}는 도망쳤습니다.", runner.name);
    //        Console.WriteLine();
    //    }


    //}




    //class BasePlayer
    //{
    //    public string name;
    //    public int hp;
    //    public int damage;
    //    public int defence;
    //    public int speed;
    //    public float criticalRate;
    //    public void Move(string name, int speed)
    //    {
    //        Console.WriteLine("{0}가 [speed:{1}]움직인다.", name, speed);

    //    }
    //}

    //class Player : BasePlayer
    //{

    //    protected int[] inventory = new int[10];

    //}
    //class UserCharacter : Player
    //{
    //    //public float criticalRate = 30.0f;
    //    public UserCharacter()
    //    {
    //        this.name = string.Empty;
    //        this.hp = 10000;
    //        this.damage = 10;
    //        this.defence = 20;
    //        this.speed = 5;
    //        this.criticalRate = 30.0f;

    //        this.inventory = new int[10];

    //    }



    //    public void GainItem(int itemID)
    //    {

    //        Console.WriteLine("[SYSTEM] Item ID:{0} 을/를 획득했습니다. ", itemID);
    //        for (int i = 0; i < inventory.Length; i++)
    //        {
    //            if (inventory[i] != 0)
    //            {
    //                this.inventory[i] = itemID;
    //            }
    //        }
    //    }
    //}

    //class Monster : BasePlayer
    //{

    //    protected int dropItem;

    //    public int MonserDrop(Monster monster)
    //    {
    //        Console.WriteLine("{0}이/가 아이템을 Drop했습니다. ", monster.name);
    //        return monster.dropItem;
    //    }

    //}

    //class Slim : Monster
    //{
    //    public Slim() // Slim class 생성자
    //    {
    //        this.name = "푸른 슬라임";
    //        this.hp = 100;
    //        this.damage = 10;
    //        this.defence = 1;
    //        this.speed = 1;
    //        this.dropItem = 1;
    //        this.criticalRate = 0;
    //    }


    //}

    //class Wolf : Monster
    //{
    //    public Wolf()
    //    {
    //        this.name = "하얀 늑대";
    //        this.hp = 300;
    //        this.damage = 30;
    //        this.defence = 5;
    //        this.speed = 10;
    //        this.dropItem = 2;
    //        this.criticalRate = 10.0f;
    //    }

    //}

    //class Rabbit : Monster
    //{
    //    public Rabbit()
    //    {
    //        this.name = "회색 토끼";
    //        this.hp = 100;
    //        this.damage = 0;
    //        this.defence = 3;
    //        this.speed = 3;
    //        this.dropItem = 3;
    //        this.criticalRate = 0;
    //    }
    //}

    //class Goblin : Monster
    //{
    //    public Goblin()
    //    {
    //        this.name = "황금 고블린";
    //        this.hp = 100;
    //        this.damage = 10;
    //        this.defence = 20;
    //        this.speed = 10;
    //        this.dropItem = 4;
    //        this.criticalRate = 0;
    //    }
    //}

    //




    //public static void Main(string[] args)
    //{
    //    if (false)
    //    {
    //        Description description = new Description();
    //        description.valueTypeAndRefferenceType();
    //    }

    //    if (false)
    //    {
    //        Parent parent = new Parent();
    //        parent.Print();

    //        Child child = new Child();
    //        child.PrintChild(); //자식 클래스에 만든 멤버 호출.
    //        child.Print(); //부모 클래스에서 상속받은 멤버를 호출.
    //    }
    //}


}