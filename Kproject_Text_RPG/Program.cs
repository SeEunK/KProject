using System;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    internal class Program
    {
        
            
        public static void Main(string[] args)
        {

            // int left = 9; // x 좌표
            // int top = 5;  // y 좌표
            //Console.SetCursorPosition(left, top);

            //const int UI_SIZE_X = 60;
            //const int UI_SIZE_Y = 30;

            //int[,] ui_screen = new int[UI_SIZE_Y, UI_SIZE_X];

            //UiManager uiManager = new UiManager();

            //uiManager.UISet(UI_SIZE_Y, UI_SIZE_X, ui_screen);
            //uiManager.DrawUI(UI_SIZE_Y, UI_SIZE_X, ui_screen);
            Ui();

            TableManager tableManager =  TableManager.getInstance();

            if(false){
                Console.SetCursorPosition(0, 0);

                for (int i = 1; i < 10; i++)
                {

                    Console.Read();
                    BackGround(i);
                    Task.Delay(100).Wait();
                    // BackGround(0);

                }

                Console.Read();
            }
            
            //{ 캐릭터 닉네임 입력 부분
            Console.SetCursorPosition(45, 10);
                string[] inputChracterNmae = { "캐", "릭", "터", " ", "이", "름", "을", " ", "입", "력", "하", "세", "요." };

                for (int i = 0; i < inputChracterNmae.Length; i++)
                {
                    Task.Delay(100).Wait();
                    Console.Write("{0}", inputChracterNmae[i]);

                }
                Console.WriteLine();

                Console.SetCursorPosition(45, 12);
                Console.Write($"[                       ]");
                Console.SetCursorPosition(47, 12);
                string name = Console.ReadLine();

                Player player = new Player(name);
            // } 캐릭터 닉네임 입력 부분
            
            Console.SetCursorPosition(2, 1);
            Lobby.ShowLobby(player);

        }

        public static void Ui()
        {
            const int UI_SIZE_X = 60;
            const int UI_SIZE_Y = 30;

            int[,] ui_screen = new int[UI_SIZE_Y, UI_SIZE_X];

            UiManager uiManager = new UiManager();

            uiManager.UISet(UI_SIZE_Y, UI_SIZE_X, ui_screen);
            uiManager.DrawUI(UI_SIZE_Y, UI_SIZE_X, ui_screen);
        }

        public static bool Battle(Player player, int monsterId)
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
                        // 플레이어 장착 무기 내구도 1 깍기
                        if (player.GetEquipItemBySlotIndex(0) != null)
                        {
                            if (player.GetEquipItemBySlotIndex(0).GetDurability() > 0)
                            {
                                // 장착한 무기,  내구도가 0이상인 경우 내구도 1 차감
                                player.GetEquipItemBySlotIndex(0).SetDurability(-1);

                                if (player.GetEquipItemBySlotIndex(0).GetDurability() == 0)
                                {
                                    // 차감 후 내구도 0인경우, 무기로 적용되던 stat 해제.
                                    player.attackPower -= player.GetEquipItemBySlotIndex(0).GetItemPropertyValue();
                                    Console.WriteLine("{0}의 내구도가 0이 되어 장착 효과가 해제 되었습니다.", player.GetEquipItemBySlotIndex(0).GetItemName());

                                }
                            }
                        }
                        turnCount++;
                    }
                    else if(inputKey.Key == ConsoleKey.F2)
                    {
                        Console.WriteLine("플레이어가 스킬을 사용합니다.");
                        int skillAttack = player.attackPower * 2;
                        int demage = skillAttack - monster.defense;
                        monster.hp = monster.hp - (skillAttack - monster.defense);
                        Console.WriteLine("플레이어가 {0}에게 {1}의 데미지를 입혔습니다.", monster.name, demage);
                        // 플레이어 장착 무기 내구도 1 깍기
                        if (player.GetEquipItemBySlotIndex(0) != null)
                        {
                           
                            if (player.GetEquipItemBySlotIndex(0).GetDurability() > 0)
                            {
                                // 장착한 무기,  내구도가 0이상인 경우 내구도 1 차감
                                player.GetEquipItemBySlotIndex(0).SetDurability(-1);

                                if (player.GetEquipItemBySlotIndex(0).GetDurability() == 0)
                                {
                                    // 차감 후 내구도 0인경우, 무기로 적용되던 stat 해제.
                                    player.attackPower -= player.GetEquipItemBySlotIndex(0).GetItemPropertyValue();
                                    Console.WriteLine("{0}의 내구도가 0이 되어 장착 효과가 해제 되었습니다.", player.GetEquipItemBySlotIndex(0).GetItemName());

                                }
                            }
                        }
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
                    int  demage = monster.attackPower - player.defense;

                    player.hp = player.hp - demage;

                    Console.WriteLine("{0}에게 {1}의 데미지를 입었습니다.", monster.name, demage);

                    // 플레이어 장착 방어구 내구도 1 깍기
                    if (player.GetEquipItemBySlotIndex(1) != null)
                    {
                        if (player.GetEquipItemBySlotIndex(1).GetDurability() > 0)
                        {
                            // 장착한 방어구,  내구도가 0이상인 경우 내구도 1 차감
                            player.GetEquipItemBySlotIndex(1).SetDurability(-1);
                            if(player.GetEquipItemBySlotIndex(1).GetDurability() == 0)
                            {
                                // 차감 후 내구도 0인경우, 방어구로 적용되던 stat 해제.
                                player.defense -= player.GetEquipItemBySlotIndex(1).GetItemPropertyValue();
                                Console.WriteLine("{0}의 내구도가 0이 되어 장착 효과가 해제 되었습니다.", player.GetEquipItemBySlotIndex(1).GetItemName());

                            }
                        }
                    }

                    turnCount++;
                    Console.WriteLine();
                }

                if (player.hp <= 0)
                {
                    Console.WriteLine("플레이어가 사망하였습니다.");

                    // 플레이어 장착 무기 , 방어구 내구도 10 깍기
                    if (player.GetEquipItemBySlotIndex(0) != null)
                    {
                        player.GetEquipItemBySlotIndex(0).SetDurability(-10);
                    }
                    if (player.GetEquipItemBySlotIndex(1) != null)
                    {
                        player.GetEquipItemBySlotIndex(1).SetDurability(-10);
                    }
                    return false;
                }
                if (monster.hp <= 0)
                {
                    Console.WriteLine("{0}를 처치하였습니다.", monster.name);
                    return true;
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
        public static void BackGround(int value)
        {
            switch (value)
            {
                case 1:
                    Console.SetCursorPosition(6, 5);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("									                                                                   ");
                    Console.WriteLine("                                                                                                    ");
                    Console.WriteLine("      ..                                                                                            ");
                    Console.WriteLine("    .~^~~.                                                                                          ");
                    Console.WriteLine("    7:  :7                                                                                          ");
                    Console.WriteLine("    7^  ^7                                                                                          ");
                    Console.WriteLine("    .~77~.                                                                                          ");
                    Console.WriteLine("      ?!.                                                                                           ");
                    Console.WriteLine("     ^?:!                                                                                           ");
                    Console.WriteLine("     ~! 7                                                                                           ");
                    Console.WriteLine("     7^ 7.                                                                                          ");
                    Console.WriteLine("     ?: 7^                                                                                          ");
                    Console.WriteLine("     ?. ~!                                                                                          ");
                    Console.WriteLine("    .?  ^~                                                                                          ");
                    Console.WriteLine("     ?. ~:                                                                                          ");
                    Console.WriteLine("     7! !                                                                                           ");
                    Console.WriteLine("    ~7J!^~                                                                                          ");
                    Console.WriteLine("   :?J!^~7.                                                                                         ");
                    Console.WriteLine(" .!557  ~~!                                                                                         ");
                    Console.WriteLine("^?Y!.    ~~~:                                                                                       ");
                    Console.WriteLine("!J~       :~~                                                                                       ");
                    Console.WriteLine("^JY~~~~~~^!Y7                                                                                       ");
                    Console.ResetColor();
                    
                    break;

                case 2:
                    Console.SetCursorPosition(6, 5);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("									                                                                    ");
                    Console.WriteLine("                   .^~^                                                                              ");
                    Console.WriteLine("                  ^7..^!                                                                             ");
                    Console.WriteLine("                  !:   !.                                                                            ");
                    Console.WriteLine("                  .!^:^!                                                                             ");
                    Console.WriteLine("                   .~7^                                                                              ");
                    Console.WriteLine("                    ~^^                                                                              ");
                    Console.WriteLine("                    !.!                                                                              ");
                    Console.WriteLine("                   :^ !                                                                              ");
                    Console.WriteLine("                   ^: ~:                                                                             ");
                    Console.WriteLine("                   ^. ^^                                                                             ");
                    Console.WriteLine("                   ^  .^                                                                             ");
                    Console.WriteLine("                   ~   ~                                                                             ");
                    Console.WriteLine("                   7. .7                                                                             ");
                    Console.WriteLine("                   ~^ !^                                                                             ");
                    Console.WriteLine("                   :J.~:                                                                             ");
                    Console.WriteLine("                   ^YJ.~                                                                             ");
                    Console.WriteLine("                 .:75?^~.                                                                            ");
                    Console.WriteLine("                !JJ?~:!~:                                                                            ");
                    Console.WriteLine("               ~GJ   :!!.                                                                            ");
                    Console.WriteLine("               ?Y.   :?7:^!:                                                                         ");
                    Console.WriteLine("               !~^~~~~J!7J?~                                                                         ");
                    Console.ResetColor();
                   
                    break;

                case 3:
                    Console.SetCursorPosition(6, 5);
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("									                                                                   ");
                    Console.WriteLine("		    	                  :~~!~                                                                ");
                    Console.WriteLine("                             .7   !^                                                                ");
                    Console.WriteLine("                              7.  ~^                                                                ");
                    Console.WriteLine("                              :~~!!                                                                 ");
                    Console.WriteLine("                               .?^                                                                  ");
                    Console.WriteLine("                               ~~7                                                                  ");
                    Console.WriteLine("                               7.!:                                                                 ");
                    Console.WriteLine("                               ? ^~                                                                 ");
                    Console.WriteLine("                              .? .7                                                                 ");
                    Console.WriteLine("                              .!  7                                                                 ");
                    Console.WriteLine("                              :~  7:                                                                ");
                    Console.WriteLine("                              ^!  !^                                                                ");
                    Console.WriteLine("                              ^!  7:                                                                ");
                    Console.WriteLine("                              :!  J.                                                                ");
                    Console.WriteLine("                               7 .5.                                                                ");
                    Console.WriteLine("                               7 ^5^                                                                ");
                    Console.WriteLine("                             7JY.?5^                                                                ");
                    Console.WriteLine("                             5?~^Y:                                                                 ");
                    Console.WriteLine("                            ^5.:!J                                                                  ");
                    Console.WriteLine("                           ::.  !7:..                                                               ");
                    Console.WriteLine("                           ~^^^!Y?7?J7                                                              ");
                    Console.ResetColor();
                    
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(6, 5);
                   
                    Console.WriteLine("						                                                                               ");
                    Console.WriteLine("                                          :^~~.                                                     ");
                    Console.WriteLine("                                         ^^  .?.                                                    ");
                    Console.WriteLine("                                         ^^  .J.                                                    ");
                    Console.WriteLine("                                          ^^:::                                                     ");
                    Console.WriteLine("                                           !~.                                                      ");
                    Console.WriteLine("                                          ^~^^                                                      ");
                    Console.WriteLine("                                          !::~                                                      ");
                    Console.WriteLine("                                          ! .!                                                      ");
                    Console.WriteLine("                                         :~ .7                                                      ");
                    Console.WriteLine("                                         !^  7.                                                     ");
                    Console.WriteLine("                                         7:  !.                                                     ");
                    Console.WriteLine("                                         7:  7.                                                     ");
                    Console.WriteLine("                                         ~~ :Y:                                                     ");
                    Console.WriteLine("                                         :7 757                                                     ");
                    Console.WriteLine("                                         .7.JJJ~                                                    ");
                    Console.WriteLine("                                         ^^!::??:                                                   ");
                    Console.WriteLine("                                        ^~!^  .?!                                                   ");
                    Console.WriteLine("                                      .!!!:    77:                                                  ");
                    Console.WriteLine("                                      .!!:     !P5                                                  ");
                    Console.WriteLine("                                      ^!7??~^^^!?!                                                  ");
                    Console.WriteLine("									                                                                   ");
                    Console.ResetColor();
                    

                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(6, 5);
                    Console.WriteLine("									                                                                   ");
                    Console.SetCursorPosition(6, 6);
                    Console.WriteLine("									                                                                   ");
                    Console.SetCursorPosition(6, 7);
                    Console.WriteLine("                                                       ..                                           ");
                    Console.SetCursorPosition(6, 8);
                    Console.WriteLine("                                                      ~~^!:                                         ");
                    Console.SetCursorPosition(6, 9);
                    Console.WriteLine("                                                     ~^   7.                                        ");
                    Console.SetCursorPosition(6, 10);
                    Console.WriteLine("                                                     ~!  :?.                                        ");
                    Console.SetCursorPosition(6, 11);
                    Console.WriteLine("                                                      ^77!:                                         ");
                    Console.SetCursorPosition(6, 12);
                    Console.WriteLine("                                                       77^                                          ");
                    Console.SetCursorPosition(6, 13);
                    Console.WriteLine("                                                      .J.7                                          ");
                    Console.SetCursorPosition(6, 14);
                    Console.WriteLine("                                                      :? 7.                                         ");
                    Console.SetCursorPosition(6, 15);
                    Console.WriteLine("                                                      ^7 !^                                         ");
                    Console.SetCursorPosition(6, 16);
                    Console.WriteLine("                                                      ~~ ^7                                         ");
                    Console.SetCursorPosition(6, 17);
                    Console.WriteLine("                                                      !^ .?                                         ");
                    Console.SetCursorPosition(6, 18);
                    Console.WriteLine("                                                      7: .!                                         ");
                    Console.SetCursorPosition(6, 19);
                    Console.WriteLine("                                                      7: ^~                                         ");
                    Console.SetCursorPosition(6, 20);
                    Console.WriteLine("                                                      ~..J:                                         ");
                    Console.SetCursorPosition(6, 21);
                    Console.WriteLine("                                                     :!:J!7                                         ");
                    Console.SetCursorPosition(6, 22);
                    Console.WriteLine("                                                    .!^7^7?^                                        ");
                    Console.SetCursorPosition(6, 23);
                    Console.WriteLine("                                                   ^??7  ^?7.                                       ");
                    Console.SetCursorPosition(6, 24);
                    Console.WriteLine("                                                  Y5!:    ^!7.                                      ");
                    Console.SetCursorPosition(6, 25);
                    Console.WriteLine("                                                  57       ^??                                      ");
                    Console.SetCursorPosition(6, 26);
                    Console.WriteLine("                                                  7J!^^^^^^^J?                                      ");
                    Console.ResetColor();
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(6, 5);
                    Console.WriteLine("																		                               ");
                    Console.SetCursorPosition(6, 6); 
                    Console.WriteLine("					    							                   .::                             ");
                    Console.SetCursorPosition(6, 7);
                    Console.WriteLine("                                                                   ~..:7.                           ");
                    Console.SetCursorPosition(6, 8);
                    Console.WriteLine("                                                                  .!   ~~                           ");
                    Console.SetCursorPosition(6, 9);
                    Console.WriteLine("                                                                   ~~.:?.                           ");
                    Console.SetCursorPosition(6, 10);
                    Console.WriteLine("                                                                    :7~.                            ");
                    Console.SetCursorPosition(6, 11);
                    Console.WriteLine("                                                                    ^~^                             ");
                    Console.SetCursorPosition(6, 12);
                    Console.WriteLine("                                                                    ~ ~                             ");
                    Console.SetCursorPosition(6, 13);
                    Console.WriteLine("                                                                   .^ ~.                            ");
                    Console.SetCursorPosition(6, 14);
                    Console.WriteLine("                                                                   :^ ^^                            ");
                    Console.SetCursorPosition(6, 15);
                    Console.WriteLine("                                                                   ~: .~                            ");
                    Console.SetCursorPosition(6, 16);
                    Console.WriteLine("                                                                   !.  ^                            ");
                    Console.SetCursorPosition(6, 17);
                    Console.WriteLine("                                                                   7.  ^                            ");
                    Console.SetCursorPosition(6, 18);
                    Console.WriteLine("                                                                   ~:  7                            ");
                    Console.SetCursorPosition(6, 19);
                    Console.WriteLine("                                                                   .~ ^~                            ");
                    Console.SetCursorPosition(6, 20);
                    Console.WriteLine("                                                                   .! J^                            ");
                    Console.SetCursorPosition(6, 21);
                    Console.WriteLine("                                                                   ^~:57                            ");
                    Console.SetCursorPosition(6, 22);
                    Console.WriteLine("                                                                 .:!:75J:                           ");
                    Console.SetCursorPosition(6, 23);
                    Console.WriteLine("                                                                !!!!^:?7!                           ");
                    Console.SetCursorPosition(6, 24);
                    Console.WriteLine("                                                              ~J57.   ?J^                           ");
                    Console.SetCursorPosition(6, 25);
                    Console.WriteLine("                                                              ?~?:    7Y!~7                         ");
                    Console.SetCursorPosition(6, 26);
                    Console.WriteLine("                                                              ~^~^^^^^!JJ5Y                         ");
                    Console.ResetColor();
                  

                    break;
                case 7:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                   
                    Console.SetCursorPosition(6, 5);
                    Console.WriteLine("					   										                     ^~~!^                 ");
                    Console.SetCursorPosition(6, 6);
                    Console.WriteLine("                                                                             ^~  .7                 ");
                    Console.SetCursorPosition(6, 7);
                    Console.WriteLine("                                                                             ^!   7.                ");
                    Console.SetCursorPosition(6, 8);
                    Console.WriteLine("                                                                              ^~!7^                 ");
                    Console.SetCursorPosition(6, 9);
                    Console.WriteLine("                                                                               ^?.                  ");
                    Console.SetCursorPosition(6, 10);
                    Console.WriteLine("                                                                               7^!                  ");
                    Console.SetCursorPosition(6, 11);
                    Console.WriteLine("                                                                              .? ?                  ");
                    Console.SetCursorPosition(6, 12);
                    Console.WriteLine("                                                                              ^7 !:                 ");
                    Console.SetCursorPosition(6, 13);
                    Console.WriteLine("                                                                              ~~ ^~                 ");
                    Console.SetCursorPosition(6, 14);
                    Console.WriteLine("                                                                              ^^ :!                 ");
                    Console.SetCursorPosition(6, 15);
                    Console.WriteLine("                                                                              ~: .?                 ");
                    Console.SetCursorPosition(6, 16);
                    Console.WriteLine("                                                                              7:  ?                 ");
                    Console.SetCursorPosition(6, 17);
                    Console.WriteLine("                                                                              7: .7                 ");
                    Console.SetCursorPosition(6, 18);
                    Console.WriteLine("                                                                              !7 :?                 ");
                    Console.SetCursorPosition(6, 19);
                    Console.WriteLine("                                                                              ^5^ ?                 ");
                    Console.SetCursorPosition(6, 20);
                    Console.WriteLine("                                                                              :YY.7.                ");
                    Console.SetCursorPosition(6, 21);
                    Console.WriteLine("                                                                            .7?YJ??.                ");
                    Console.SetCursorPosition(6, 22);
                    Console.WriteLine("                                                                            ^J^??Y                  ");
                    Console.SetCursorPosition(6, 23);
                    Console.WriteLine("                                                                            ?7 ~Y7                  ");
                    Console.SetCursorPosition(6, 24);
                    Console.WriteLine("                                                                           :^  :Y7:.                ");
                    Console.SetCursorPosition(6, 26);
                    Console.WriteLine("                                                                           ~^^^75Y5YJ               ");
                    Console.ResetColor();
                    break;

                case 8:
                   
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(6, 5);
                    Console.WriteLine("																		                       .       ");
                    Console.SetCursorPosition(6, 6);
                    Console.WriteLine("                                                                                          :~^~^     ");
                    Console.SetCursorPosition(6, 7);
                    Console.WriteLine("                                                                                         :!   ~^    ");
                    Console.SetCursorPosition(6, 8);
                    Console.WriteLine("                                                                                         .!   ^~    ");
                    Console.SetCursorPosition(6, 9);
                    Console.WriteLine("                                                                                          ^~^~^     ");
                    Console.SetCursorPosition(6, 10);
                    Console.WriteLine("                                                                                           :~.      ");
                    Console.SetCursorPosition(6, 11);
                    Console.WriteLine("                                                                                          .~:~      ");
                    Console.SetCursorPosition(6, 12);
                    Console.WriteLine("                                                                                          ~^ !      ");
                    Console.SetCursorPosition(6, 13);
                    Console.WriteLine("                                                                                          7. !      ");
                    Console.SetCursorPosition(6, 14);
                    Console.WriteLine("                                                                                         .~  !:     ");
                    Console.SetCursorPosition(6, 15);
                    Console.WriteLine("                                                                                         ^^  ^^     ");
                    Console.SetCursorPosition(6, 16);
                    Console.WriteLine("                                                                                         ~:  ^^     ");
                    Console.SetCursorPosition(6, 17);
                    Console.WriteLine("                                                                                         ^^  ^.     ");
                    Console.SetCursorPosition(6, 18);
                    Console.WriteLine("                                                                                         .?. :^     ");
                    Console.SetCursorPosition(6, 19);
                    Console.WriteLine("                                                                                          J?: 7.    ");
                    Console.SetCursorPosition(6, 20);
                    Console.WriteLine("                                                                                          J!?^:7    ");
                    Console.SetCursorPosition(6, 21);
                    Console.WriteLine("                                                                                         :YJ^.^~~   ");
                    Console.SetCursorPosition(6, 22);
                    Console.WriteLine("                                                                                        :Y?~  .?!.  ");
                    Console.SetCursorPosition(6, 23);
                    Console.WriteLine("                                                                                      .7Y?~    J7:::");
                    Console.SetCursorPosition(6, 24);
                    Console.WriteLine("                                                                                       ?5^     7J?7:");
                    Console.SetCursorPosition(6, 25);
                    Console.WriteLine("                                                                                     ~^~JJ7:::.^!^  ");
                    Console.SetCursorPosition(6, 26);
                    Console.ResetColor();
                 
                    break;

                case 0:
                    
                    Console.BackgroundColor = ConsoleColor.Black;
                    for (int i = 0; i < 22; i++)
                    {
                        Console.SetCursorPosition(6, 5+i);
                        Console.WriteLine("                                                                                       ");
                    }
                    Console.ResetColor();
                    Task.Delay(50).Wait();
                    break;

            }
        }
    }
}