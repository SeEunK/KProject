using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WhatIsClass
{
 

    class Battle
    {
        protected string startTarget = string.Empty;


        public void BattlePVE(BasePlayer attacker, BasePlayer targetPlayer)
        {
            //배틀을 시작할때 타겟의 이름을 체크
            startTarget = targetPlayer.name;

            while (true)
            {
                Attack(attacker, targetPlayer);
                Defence(attacker, targetPlayer);
                if (targetPlayer.hp <= 0)
                {
                    if (targetPlayer.name == startTarget)
                    {
                        Console.WriteLine("{0}를 처지했습니다.", targetPlayer.name);
                        Console.WriteLine();

                    }
                    else
                    { // 유저 캐릭 사망
                        Console.WriteLine("{0}에게 죽었습니다.", attacker.name);
                        Console.WriteLine();
                    }
                    break;
                }
                else
                {//공 수 변경
                    BasePlayer temp = attacker;
                    attacker = targetPlayer;
                    targetPlayer = temp;
                }
            }
        }

        public void Attack(BasePlayer attacker, BasePlayer targetPlayer)
        {
            Console.WriteLine("[{0}]이/가 [{1}]를 공격합니다.", attacker.name, targetPlayer.name);

        }

        public void Defence(BasePlayer attacker, BasePlayer targetPlayer)
        {
            int damage = 0;
            if (attacker.criticalRate > 0)
            {

                Random random = new Random();
                float randomRate = random.Next(1, 100 + 1);
                if (randomRate <= attacker.criticalRate)
                {
                    damage = attacker.damage * 5;
                    Console.WriteLine("[SYSTEM] !!! CRITICAL !!!");
                }
                else
                {
                    damage = attacker.damage;
                }
            }
            else
            {
                damage = attacker.damage;
            }

            if (damage - targetPlayer.defence <= 0)
            {
                Console.WriteLine("[SYSTEM] MISS!");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("[{0}]가 [{1}]만큼 데미지를 입었습니다.", targetPlayer.name, (damage - targetPlayer.defence));
                Console.WriteLine();
                targetPlayer.hp = targetPlayer.hp - damage;
            }
        }

        public void Run(BasePlayer runner)
        {
            Console.WriteLine("{0}는 도망쳤습니다.", runner.name);
            Console.WriteLine();
        }


    }




    class BasePlayer
    {
        public string name;
        public int hp;
        public int damage;
        public int defence;
        public int speed;
        public float criticalRate;
        public void Move(string name, int speed)
        {
            Console.WriteLine("{0}가 [speed:{1}]움직인다.", name, speed);

        }

        public virtual void initBasePlayer()
        {
            
        }
    }

    class Player : BasePlayer
    {
        public int[] Inven
        {
            get { return this.inventory; }
            set { this.inventory = value; }
        }
        public int[] inventory = new int[10];



    }
    class UserCharacter : Player
    {

        public UserCharacter()
        {
            this.name = string.Empty;
            this.hp = 10000;
            this.damage = 10;
            this.defence = 20;
            this.speed = 5;
            this.criticalRate = 30.0f;

            this.inventory = new int[10];

        }


        public void GainItem(int itemID)
        {

            Console.WriteLine("[SYSTEM] Item ID:{0} 을/를 획득했습니다. ", itemID);
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == 0)
                {
                    this.inventory[i] = itemID;
                    break;
                }
            }
        }

        public void InvenDraw(string[] items)
        {
            ConsoleKeyInfo inputKey;
            Console.WriteLine("-------------------------------------");

            for (int i = 0; i < this.inventory.Length; i++)
            {
                if (inventory[i] == 0)
                {
                    Console.Write("[  ]");
                }
                else
                {
                    Console.Write("[{0}]", items[this.inventory[i]]);
                }
            }
            Console.WriteLine();
            Console.WriteLine("-------------------------------------");

            Console.WriteLine("=====================================");
            Console.WriteLine("[가방 닫기] : 'X' Key ");
            Console.WriteLine("=====================================");

            while (true)
            {
                inputKey = Console.ReadKey();

                if (inputKey.Key == ConsoleKey.X)
                {
                    Console.WriteLine();
                    Console.WriteLine("모험을 계속합니다.");
                    break;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");

                }
            }
            Console.WriteLine();
        }
    }

    class Monster : BasePlayer
    {

        protected int dropItem;

        public int MonserDrop(Monster monster)
        {
            Console.WriteLine("{0}이/가 아이템을 Drop했습니다. ", monster.name);
            return monster.dropItem;
        }

     



    }

    class Slim : Monster
    {
        public Slim() // Slim class 생성자
        {
           initBasePlayer();
        }

        public override void initBasePlayer()
        {
            this.name = "푸른 슬라임";
            this.hp = 100;
            this.damage = 10;
            this.defence = 1;
            this.speed = 1;
            this.dropItem = 1;
            this.criticalRate = 0;
        }
    }

    class Wolf : Monster
    {
        public Wolf()
        {
            this.name = "하얀 늑대";
            this.hp = 300;
            this.damage = 30;
            this.defence = 5;
            this.speed = 10;
            this.dropItem = 2;
            this.criticalRate = 10.0f;
        }

    }

    class Rabbit : Monster
    {
        public Rabbit()
        {
            this.name = "회색 토끼";
            this.hp = 100;
            this.damage = 0;
            this.defence = 3;
            this.speed = 3;
            this.dropItem = 3;
            this.criticalRate = 0;
        }
    }

    class Goblin : Monster
    {
        public Goblin()
        {
            this.name = "황금 고블린";
            this.hp = 100;
            this.damage = 10;
            this.defence = 20;
            this.speed = 10;
            this.dropItem = 4;
            this.criticalRate = 0;
        }
    }

}
