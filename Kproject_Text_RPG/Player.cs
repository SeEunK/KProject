using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    internal class Player : Character
    {
        public Player()
        {
            name = string.Empty;
            level = 1;

            hp = 100_000;
            mp = 20_000;
            attackPower = 10;
            defense = 1;
            int exp = 0;


        }

        public int hp { get; set; }
        public int mp { get; set; }

      
    }

}

