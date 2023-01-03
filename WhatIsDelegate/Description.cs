using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsDelegate
{
    public class Description
    {
        //┌ void 리턴 타입과, 매개 변수를 받지 않는 함수를 저장할 수 있는 데이터 타입을 선언 한 것.
        delegate void SayDelegate();  
        
        public void DelegateDesc()
        {
            /**
             * 대리자 (Delegate)는 매개변수 목록 및 반환 형식이 있는 메서드 참조(포인터)를 나타내는 형식이다.
             * 영어 단어 delegate는 '위임하다' 또는 '대신하다'의 의미가있다.
             * 
             * 대리자(위임/델리게이트) 
             * 대리자는 delegate 키워드를 사용하여 만든다.
             * 대리자는 함수 자체를 데이터하나로 보고 의미 그대로 다른 메서드를 대신 실행하는 기능이다.
             * 한 번에 하나 이상을 대신해서 호출할 수 있는 개념이다.
             * 
             *  - 자동자 개체를 예로 들면, 대리운전 처럼 대리자가 집까지 좌회전(), 우회전(), 직진(), 주차() 등 
             *      동작을 대신해서 할수있게 하는 개념과 비슷하다.
             *  - 메서드의 매개변수로 대리자를 넘길 수 있다. 대리자를 사용하여 함수의 매개 변수로 함수 자체를 전달할수있다.
             *  - 메서드의 매개변수로 또 다른 메서드 호출을 넘기는 기능이다.
             *  - 대리자는 동일한 메서드 시그니처를 갖는 메서드 참조를 담을수있는 그릇 역할을 한다.
             *  - 대리자는 람다(Lamda)와  개념이 같다고 보아도 된다.
             *  - 대리자를 사용하면 함수를 모아 놓았다가 나중에 실행하거나 실행을 취소할수있다.
             *  - 대리자는 내부적으로 MulticastDelegate 클래스에서 기능을 상속한다.
             *  - 대리자는 이벤트(Event)를 만들어 내는 중간 단계의 키워드로 존재한다.
             *  
             *      
             *
             */
            SayDelegate sayDelegate = Hi; //변수에 함수는 담음 [ sayDelegate 라는 변수에 Hi()메서드를 담고],
            sayDelegate.Invoke(); // 이렇게 호출..
        }

        public void Hi()
        {
            Console.WriteLine("안녕하세요.");
        }
    }
}
