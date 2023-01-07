using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public  class Character
    {
        public string name;
        public int level;
        public int hp;
        public int maxHP;
        public int mp;
        public int attackPower;
        public int defense;

        public virtual void Attack()
        {

        }
        public virtual void SpecialAttack()
        {

        }
    }
}
