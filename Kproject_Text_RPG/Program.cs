using System;
using static System.Net.Mime.MediaTypeNames;

namespace Kproject_Text_RPG
{
    internal class Program
    {
        
            
        public static void Main(string[] args)
        {

            // int left = 9; // x 좌표
            // int top = 5;  // y 좌표
            //Console.SetCursorPosition(left, top);
           
            const int UI_SIZE_X = 33;
            const int UI_SIZE_Y = 50;

            int[,] ui_screen = new int[UI_SIZE_Y, UI_SIZE_X];
            
            UiManager uiManager = new UiManager();

           
            uiManager.UISet(UI_SIZE_Y, UI_SIZE_X, ui_screen);
            uiManager.DrawUI(UI_SIZE_Y, UI_SIZE_X, ui_screen);

            TableManager tableManager =  TableManager.getInstance();

            // 레벨 업 체크 잘되는지 확인용.
            if (false) { 
            bool isLevelUp = false;
            isLevelUp = tableManager.LevelUpCheck (5,10);
            Console.WriteLine("==================================================================================");
            Console.WriteLine("현재 레벨 1, 보유 경험치 5, 획득 경험치 10인 경우 레벨업인가요? {0} ", isLevelUp);
            Console.WriteLine("==================================================================================");

            isLevelUp = tableManager.LevelUpCheck(15, 190);
            Console.WriteLine("==================================================================================");
            Console.WriteLine("현재 레벨 1, 보유 경험치 15, 획득 경험치 190인 경우 레벨업인가요? {0} ", isLevelUp);
            Console.WriteLine("==================================================================================");

            }


            Console.WriteLine("캐릭터 이름을 입력하세요.");
            string name = Console.ReadLine();
            Player player= new Player(name);
            
            Battle(player, 1);

        }

        public static void Battle(Player player, int monsterId)
        {
            TableManager tableManager = TableManager.getInstance();
            Monster monster = new Monster(tableManager.FindMonsterDataByID(monsterId));
          
            int turnCount = 0;

            Console.WriteLine("{0}를 만났습니다.", monster.name);
            
            // 인벤 체크
          
            player.SetIventory(tableManager.FindItemDataByID(300));

            while (true)
            {
                ConsoleKeyInfo inputKey;

               
                Console.WriteLine("[ 플레이어 HP: {0} / {1} ]", player.hp, player.maxHP);
                Console.WriteLine("[ {0} HP: {1} / {2} ]", monster.name, monster.hp, monster.maxHP);
                Console.WriteLine();
               

                if (turnCount % 2 == 0)
                {
                    Console.WriteLine("공격 : F1 / 스킬 : F2 / 물약 : F3");

                    inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.F1)
                    {
                        Console.WriteLine("플레이어가 일반 공격을 시도합니다.");
                        int demage = player.attackPower - monster.defense;
                        monster.hp = monster.hp - demage;
                        Console.WriteLine("플레이어가 {0}에게 {1}의 데미지를 입혔습니다.", monster.name, demage);
                        turnCount++;
                    }
                    else if(inputKey.Key == ConsoleKey.F2)
                    {
                        Console.WriteLine("플레이어가 스킬을 사용합니다.");
                        int skillAttack = player.attackPower * 2;
                        int demage = skillAttack - monster.defense;
                        monster.hp = monster.hp - (skillAttack - monster.defense);
                        Console.WriteLine("플레이어가 {0}에게 {1}의 데미지를 입혔습니다.", monster.name, demage);
                        turnCount++;
                    }
                    else if (inputKey.Key == ConsoleKey.F3)
                    {
                        // 물약(id:300) 아이템을 가지고있는 경우
                        if (player.FindItemByID(300)!=null)
                        {

                            if (player.hp == player.maxHP)
                            {
                                Console.WriteLine("HP가 가득차 더이상 사용할수없습니다.");
                            }
                            else
                            {
                                player.UseItem(player.FindItemByID(300));
                           
                                turnCount++;
                            }
                        }
                        else // 소모품(3번타입) 아이템을 가지고있지 않는 경우
                        {
                            Console.WriteLine("보유한 HP물약이 없습니다.");
                        }
                    }
                   
                    Console.WriteLine();
                }
                else
                {
                    int demage = monster.attackPower - player.defense;
                    player.hp = player.hp - demage;
                    Console.WriteLine("{0}에게 {1}의 데미지를 입었습니다.", monster.name, demage);
                    turnCount++;
                    Console.WriteLine();
                }
               
                if (player.hp <= 0)
                {
                    Console.WriteLine("플레이어가 사망하였습니다.");
                    break;
                }
                if (monster.hp <= 0)
                {
                    Console.WriteLine("{0}를 처치하였습니다.", monster.name);
                    break;
                }

            }


        }
        


      




        public void SlimeDote()
        {
            //Slime Test 도트..?
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            Console.WriteLine(); // 1

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■");
            Console.WriteLine(); // 2

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.WriteLine(); // 3

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.WriteLine(); // 4

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");

            Console.WriteLine(); // 5

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 6

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 7

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 8


            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 9


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□□□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.WriteLine(); // 10

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■■■■■■■■■■");
            Console.WriteLine(); // 10
        }
    }
}