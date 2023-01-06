using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{

    class Monster
    {
        public virtual void Move()
        {
            Console.WriteLine("이동한다 " );

        }
    }
    class Wolf : Monster
    {
        public override void Move()
        {
            Console.WriteLine( "늑대가 이동한다"  );

        }
    }
}
