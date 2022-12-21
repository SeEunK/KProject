namespace Repo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            /**
             * [LAB. 1] ===================================================
             * 자음과 모음 개수 세기
             * 사용자로부터 영문자를 받아서 자음과 모음의 개수를 세는 프로그램을 작성
             * -대 소문자 모두 카운트
             * 
             */

            char alphabet = 'A'; 
            int vowel = 0; //모음 
            int consonant = 0; //자음

            while(alphabet!= 'Z')
            {
                Console.Write("알파벳을 입력하세요: ");
                char.TryParse(Console.ReadLine(), out alphabet);
                switch (alphabet)
                {
                    case 'A':
                        vowel++;
                        break;

                    case 'E':
                        vowel++;
                        break;

                    case 'I':
                        vowel++;
                        break;

                    case 'O':
                        vowel++;
                        break;

                    case 'U':
                        vowel++;
                        break;

                    default:
                        consonant++;
                        break;

                }
                Console.WriteLine("자음의 개수 :{0}",consonant);
                Console.WriteLine("모음의 개수 :{0}",vowel);
            }

            /**
            * [LAB.2] ========================================================
            * 숫자 맞추기 게임
            * 숫자 알아맞히기 게임이다 프로그램은 1~100사이의 정수를 저장하고 잇음
            * 사용자는 질문을 통해서 숫자를 알아 맞힌다. 사용자가 답을 제시하면 프로그램은 제시된 정수가 더 낮은 값인지
            * 높은 값인지 알려준다.
            * 사용자가 알아맞힐때까지 루프 한다.(기본형)
            * 
            * - Q2-1.프로그램을 수정하여 컴퓨터가 생성한 숫자를 사용자가 추측하는 대신에 사용자가 결정한 번호를 
            *   컴퓨터가 추측하도록 수정한다. 사용자는 컴퓨터가 추측한 숫자가 높거나 낮은지를 컴퓨터에 알려야 한다.
            *   컴퓨터가 맞힐때까지 반복(어려운 난이도)
            *   
            * - Q2-2사용자가 결정한 범위는 (1~100) 어떤 숫자를 생각하던 7번 이하의 추측으로 컴퓨터가 맞출 수 있도록 
            *   Q2-1프로그램을 수정  
            */


            /**
            * [LAB.3] ======================================================== 
            * 산수 문제 자동 출제
            * 산수 문제를 자동으로 출제하는 프로그램을 작성해보자. 덧셈 문제들을 자동으로 생성 하여야 한다.
            * 피연산자는 0~99사이의 숫자(난수) 한번이라도 맞으면 종료. 틀리면 리트라이
            * -추가) 뺄셈 곱셈 나눗셈 문제도 출제(나눗셈 예외처리:무한대값 주의)
            */
        }
    }
}