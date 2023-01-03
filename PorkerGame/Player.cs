using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PorkerGame
{
    public class Player
    {
        public int point;
         
       
        public int Betting()
        {
            int betPoint = 0;

            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out betPoint))
                {
                    if (betPoint > point)
                    {
                        Console.WriteLine("보유한 Point 보다 많이 베팅할수없습니다. 다시 입력하세요.");
                    }
                    else
                    {
                        point = point - betPoint; // 차감 
                        Console.WriteLine("플레이어가 {0}Point 를 베팅하였습니다.", betPoint);
                        return betPoint;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다. 숫자로 입력하세요.");
                }

            }
        }
    }
}
