using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{

    public class Monster : Character
    {
        
        MonsterData monsterData;
        int type = 0;
        int id = 0;
        public Monster(MonsterData data)
        {
            name = data.name;
            monsterData = data;
            id = data.id;
            type = data.type;
            hp = data.hp;
            maxHP = data.hp;
            attackPower= data.attackPower;
            defense = data.defense;

        }

        public override void Attack()
        {

        }
        public override void SpecialAttack()
        {

        }

    }
    
}
