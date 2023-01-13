using System;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Tasks;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace Kproject_Text_RPG
{
    internal class Program
    {
        
            
        public static void Main(string[] args)
        {

        

            UiManager.UiInit();

            //UiManager.UiInit();
            UiManager.TitleDraw();

            UiManager.EnterAnyKey();

            Console.ReadKey(true);
            UiManager.TitleDrawClear();
            TableManager tableManager =  TableManager.getInstance();

            tableManager.GetEnhanceTable();

 
            
            //{ 캐릭터 닉네임 입력 부분
            Console.SetCursorPosition(45, 10);
                string[] inputChracterNmae = { "캐", "릭", "터", " ", "이", "름", "을", " ", "입", "력", "하", "세", "요." };

                for (int i = 0; i < inputChracterNmae.Length; i++)
                {
                    Task.Delay(100).Wait();
                    Console.Write("{0}", inputChracterNmae[i]);

                }

                Console.SetCursorPosition(45, 12);
                Console.Write($"[                       ]");
                Console.SetCursorPosition(47, 12);
                string name = Console.ReadLine();

                Player player = new Player(name);
            // } 캐릭터 닉네임 입력 부분
            
            Console.SetCursorPosition(2, 1);
            player.SetGold(1000);
            Lobby.ShowLobby(player);
            

        }

   

        public static bool Battle(Player player, int monsterId, int stageNum )
        {
            TableManager tableManager = TableManager.getInstance();
            Monster monster = new Monster(tableManager.FindMonsterDataByID(monsterId));
          
            int turnCount = 0;

            UiManager.UiInit();


            // 스테이지 타이틀 출력
            UiManager.StageTitleDraw(stageNum, tableManager.GetStageName(stageNum - 1));
            
            // 플레이어 스텟 출력
            PlayerStatUI(player);

            // 몬스터 조우 메시지 출력
            UiManager.MonsterAppearMessage(monster.name);


            // 인벤 체크
            player.SetIventory(tableManager.FindItemDataByID(300));

            while (true)
            {
                ConsoleKeyInfo inputKey;

                // 몬스터 hp bar 출력
                UiManager.MonsterStatDraw(monster.name, monster.hp, monster.maxHP);

               
                SlimeDote();


                if (turnCount % 2 == 0)
                {
                    PlayerStatUI(player);

                    // 플레이어 턴 안내 메시지 
                    UiManager.PlayerTurnGuideMessage();
     
                    // 플레이어 턴 행동 버튼 출력
                    UiManager.PlayerTurnActionButtonDraw();
                    //Console.SetCursorPosition(2, 27);
                    //Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    //Console.SetCursorPosition(2, 28);
                    //Console.WriteLine(String.Format("{0}", "             F1 : 공격          ||             F2 : 스킬            ||         F3 :  HP 물약             "));
                   
                    // 행동 입력 대기
                    inputKey = Console.ReadKey(true);

                    // 행동 입력 후 버튼 막기.
                    UiManager.PlayerTurnActionButtinBlock();

                    // 플레이어 턴 안내 메시지 삭제
                    UiManager.PlayerTurnGuideMessageClear();
          
                    if (inputKey.Key == ConsoleKey.F1)
                    {
                        // 플레이어 공격 메시지 출력
                         UiManager.PlayerAttackMessage(1);

                        // 데미지 계산
                        int demage = player.attackPower - monster.defense;
                        monster.hp = monster.hp - demage;

                        if (player.attackPower <= monster.defense)
                        {
                            demage = 1;
                        }
                        if (monster.hp < player.attackPower - monster.defense)
                        {
                            demage = monster.hp;
                        }

                        // 플레이어 공격 데미지 출력
                        UiManager.InflictDamageMessage(monster.name, demage);

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
                                  
                                    // 내구도 0으로 장착 아이템 효과 해제 메시지 출력
                                    UiManager.EquipItemBrokenMessage(player.GetEquipItemBySlotIndex(0).GetItemName());

                                }
                            }
                        }
                        turnCount++;
                    }
                    else if(inputKey.Key == ConsoleKey.F2)
                    {
                        // 플레이어 공격 메시지 출력
                        UiManager.PlayerAttackMessage(2);
                        
                        // 데미지 계산
                        int skillAttack = player.attackPower * 2;
                        int demage = skillAttack - monster.defense;
                        if(skillAttack <= monster.defense)
                        {
                            demage = 1;
                        }
                        if(monster.hp < skillAttack - monster.defense)
                        {
                            demage = monster.hp;
                        }
                        monster.hp = monster.hp - (skillAttack - monster.defense);

                        // 플레이어 공격 데미지 출력
                        UiManager.InflictDamageMessage(monster.name, demage);

                   
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

                                    // 내구도 0으로 장착 아이템 효과 해제 메시지 출력
                                    UiManager.EquipItemBrokenMessage(player.GetEquipItemBySlotIndex(0).GetItemName());

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
                                UiManager.DoNotUseItemHpFullMessage();
                            }
                            else
                            {
                                
                                player.UseItem(player.FindItemByID(300));
                                PlayerStatUI(player);
                                turnCount++;
                            }
                        }
                        else // 소모품(3번타입) 아이템을 가지고있지 않는 경우
                        {
                            UiManager.DoNotHaveHpPotion();
                        }
                    }
                    
                }
                else
                { //몬스터 턴
                    // 몬스터 턴 안내 메시지 
                    UiManager.MonsterTurnGuideMessage();
                    // 데미지 계산
                    int  demage = monster.attackPower - player.defense;
                    if(monster.attackPower <= player.defense)
                    {
                        demage = 1;
                    }
                    if (player.hp < demage)
                    {
                        demage = player.hp;
                    }
                    player.hp = player.hp - demage;

                    //입은 데미지 출력
                    UiManager.TakeDamageMessage(monster.name, demage);

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

                                // 내구도 0으로 장착 아이템 효과 해제 메시지 출력
                                UiManager.EquipItemBrokenMessage(player.GetEquipItemBySlotIndex(1).GetItemName());
                     

                            }
                        }
                    }
                    // 플레이어 스탯 갱신
                    PlayerStatUI(player);
                    // 몬스터 턴 안내 메시지 삭제
                    UiManager.MonsterTurnGuideMessageClear();
                    // 턴 넘기기
                    turnCount++;
                }
                if (player.hp <= 0)
                {
                    // 플레이어 사망 출력
                    UiManager.PlayerDieDraw();

                    // 플레이어 장착 무기 , 방어구 내구도 10 깍기
                    if (player.GetEquipItemBySlotIndex(0) != null)
                    {
                        player.GetEquipItemBySlotIndex(0).SetDurability(-10);
                    }
                    if (player.GetEquipItemBySlotIndex(1) != null)
                    {
                        player.GetEquipItemBySlotIndex(1).SetDurability(-10);
                    }

                    // 아무키 입력 안내 메시지 출력
                    UiManager.EnterAnyKeyMessage();
                    // 입력 받기
                    Console.ReadKey(true);
                    // 아무키 입력 안내 메시지 삭제
                    UiManager.EnterAnyKeyMessageClear();
                    // 플레이어 사망 출력 삭제
                    UiManager.PlayerDieDrawClear();

                    return false;
                }
                if (monster.hp <= 0)
                {
                    // 몬스터 처치 출력
                    UiManager.MonsterKillDraw(monster.name);
                   
                    return true;
                }
            }
        }
        
        public static void PlayerStatUI(Player player)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 3);
            Console.WriteLine(String.Format("{0}", $"  {player.name,-10}              ||   HP :  {player.hp,6} / {player.maxHP,6}  ||      Gold : {player.GetGold(),10}      "));
            Console.SetCursorPosition(2, 4);
            Console.WriteLine(String.Format("{0}", $"  {player.LevelDisplay(),-10}   ||   AttckPower : {player.attackPower,12}    ||      defence : {player.defense,10}    "));
            Console.SetCursorPosition(2, 5);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();
        }


        public static void SlimeDote()
        {
            //Slime Test 도트..?
            Console.SetCursorPosition(48, 9);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            
            Console.SetCursorPosition(48, 10);
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
            

            Console.SetCursorPosition(48,11);
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
           

            Console.SetCursorPosition(48, 12);
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
          

            Console.SetCursorPosition(48, 13);
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

           
            Console.SetCursorPosition(48, 14);
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

            Console.SetCursorPosition(48, 15);
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

            Console.SetCursorPosition(48, 16);
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


            Console.SetCursorPosition(48, 17);
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
           

            Console.SetCursorPosition(48, 18);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□□□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
           

            Console.SetCursorPosition(48, 19);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■■■■■■■■■■");
           
        }

        public static void WolfDote()
        {
            //Slime Test 도트..?
            Console.SetCursorPosition(48, 9);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");

            Console.SetCursorPosition(48, 10);
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


            Console.SetCursorPosition(48, 11);
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


            Console.SetCursorPosition(48, 12);
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


            Console.SetCursorPosition(48, 13);
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


            Console.SetCursorPosition(48, 14);
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

            Console.SetCursorPosition(48, 15);
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

            Console.SetCursorPosition(48, 16);
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


            Console.SetCursorPosition(48, 17);
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


            Console.SetCursorPosition(48, 18);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□□□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");


            Console.SetCursorPosition(48, 19);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■■■■■■■■■■");

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