using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WhatIsClass
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConsoleKeyInfo inputKey;
            // ==============================================================================
            // 실습 
            // ==============================================================================

            UserCharacter user = new UserCharacter();
            Console.WriteLine("캐릭터 이름을 입력하세요.: ");
            user.name = Console.ReadLine();

            Thread.Sleep(200);
            Console.Clear();

            Slim monsterSlim = new Slim();
            Wolf mosterWolf = new Wolf();
            Rabbit monsterRabbit = new Rabbit();
            Goblin mosterGoblin = new Goblin();

            Monster[] monsters = new Monster[] { monsterSlim, monsterRabbit, mosterWolf, mosterGoblin };
            Battle pve = new Battle();
            Monster monster = new Monster();

            string[] gameItem = new string[] { "잡동산이", "골드", "제련석", "포션" };


            while (true)
            {
                string userInput = string.Empty;

                for (int i = 0; i < monsters.Length; i++)
                {
                    Console.WriteLine("=====================================");
                    Console.WriteLine("[{0}] HP:{1}", user.name, user.hp);
                    Console.WriteLine("=====================================");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine();

                    monster = monsters[i];
                    Console.WriteLine("!!!   WARRING !!!  ");
                    Console.WriteLine("{0}을/를 만났습니다.", monster.name);
                    Console.WriteLine();

                    while (true)
                    {
                        Console.WriteLine("=====================================");
                        Console.WriteLine("[공격] : 'A' 입력 OR [도망] :'B'입력");
                        Console.WriteLine("=====================================");
                        //userInput = Console.ReadLine();
                        inputKey = Console.ReadKey();

                        Console.Clear();

                        if (inputKey.Key == ConsoleKey.A)
                        {
                            Console.WriteLine("전투를 시작합니다.");

                            int dropItemID = 0;
                            pve.BattlePVE(user, monster);
                            dropItemID = monster.MonserDrop(monster);
                            user.GainItem(dropItemID);
                            
                            Console.WriteLine("=====================================");
                            Console.WriteLine("[가방 열기] : 'I' Key ");
                            Console.WriteLine("[계속 하기] : 'Enter' Key ");
                            Console.WriteLine("=====================================");

                            inputKey = Console.ReadKey();

                            if(inputKey.Key == ConsoleKey.I)
                            {
                                // user.InvenDraw(gameItem);
                                Console.WriteLine("//인벤출력");
                                break;
                            }
                            else if (inputKey.Key == ConsoleKey.Enter)
                            { Console.WriteLine("모험을 계속합니다.");
                                break;
                            }
                           
                        }
                        else if (inputKey.Key == ConsoleKey.B)
                        {
                            pve.Run(user);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다. 다시 입력하세요.");
                        }
                    }

                    if (user.hp == 0)
                    {
                        break;
                    }
                }
                break;
            }

        }


    }
}
