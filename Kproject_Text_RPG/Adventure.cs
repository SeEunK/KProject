using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class Adventure
    {
        public static void ShowStageList(Player player)
        {
            
            TableManager tableManager = TableManager.getInstance();
            int stageCount = tableManager.GetStageTable().Count;
            int sellectStageNum = 0;




            Console.Clear();
            Program.Ui();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}", "                                                   Adventure                                                       "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();
            Console.SetCursorPosition(2, 3);
            Console.WriteLine(String.Format("{0}", $"  {player.name,-10}              ||   HP :  {player.hp,6} / {player.maxHP,6}  ||      Gold : {player.GetGold(),10}      "));
            Console.SetCursorPosition(2, 4);
            Console.WriteLine(String.Format("{0}", $"  {player.LevelDisplay(),-10}   ||   AttckPower : {player.attackPower,12}    ||      defence : {player.defense,10}    "));
            Console.SetCursorPosition(2, 5);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();

         


            if (stageCount != 0)
            {
                Console.SetCursorPosition(45, 7);
                Console.WriteLine("모험 할 stage를 선택하세요. ");
                Console.SetCursorPosition(45, 9);
                Console.WriteLine("====== Stage List ======");
                for (int i = 0; i < stageCount; i++)
                {
                    Console.SetCursorPosition(45, 10+i);
                    Console.WriteLine("[STAGE {0}] {1}", i + 1, tableManager.GetStageName(i));

                }
                Console.SetCursorPosition(2, 27);
                Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                Console.SetCursorPosition(2, 28);
                Console.WriteLine(String.Format("{0}", $"             NumPad 1 ~ {stageCount} : 스테이지 선택            ||            Esc : \"Go To Lobby\"     "));


                sellectStageNum = StageSellect(stageCount, player);
                if (sellectStageNum == -1)
                {
                    ShowStageList(player);
                }
                else if(sellectStageNum == 0)
                {
                    Lobby.ShowLobby(player);
                }
                else
                {
                    GoToStage(sellectStageNum, player);
                }
            }
        }
        public static void GoToStage(int sellectStage, Player player)
        {
            if (sellectStage == 0)
            {
                ShowStageList(player);
            }
            else
            {
                TableManager tableManager = TableManager.getInstance();

                List<StageStepData> stageStepList = tableManager.GetStageStepByID(sellectStage);

                for (int i = 0; i < stageStepList.Count; i++)
                {
                   if( Program.Battle(player, stageStepList[i].monsterID, sellectStage) == false)
                    {
                        break;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(40, 7);
                        Console.WriteLine("                                                   ");
                        Console.ResetColor();

                        if (tableManager.LevelUpCheck(player.GetExp(), stageStepList[i].rewardExp) == true)
                        {
                            Console.SetCursorPosition(40, 8);
                            Console.WriteLine("=========== LEVEL UP ===========");
                        }

                        Task.Delay(2000).Wait();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.SetCursorPosition(40, 7);
                        Console.WriteLine("                                                   ");
                        Console.ResetColor();

                        // {몬스터 이미지 지우기
                        for (int index = 0; index < 11; index++)
                        {
                            Console.SetCursorPosition(48, 9+ index);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.WriteLine("                                                       ");
                        }
                        Console.ResetColor();
                        // } 몬스터 이미지 지우기

                        Console.SetCursorPosition(40, 10);
                        Console.WriteLine("=========== Reward ===========");
                        // 경험치 추가
                        Console.SetCursorPosition(40, 11);
                        Console.WriteLine("EXP : {0}", stageStepList[i].rewardExp);
                        player.SetExp(stageStepList[i].rewardExp);
                        // 골드 추가
                        Console.SetCursorPosition(40, 12);
                        Console.WriteLine("GOLD : {0}", stageStepList[i].rewardGold);
                        player.SetGold(stageStepList[i].rewardGold);
                        //획득 아이템 추가


                        if (stageStepList[i].monsterDropItemID != 0)
                        {
                            ItemData rewardItem = new ItemData();
                            rewardItem = tableManager.FindItemDataByID(stageStepList[i].monsterDropItemID);
                            Console.SetCursorPosition(40, 13);
                            Console.WriteLine("Drop : {0}", rewardItem.name);
                            player.SetIventory(tableManager.FindItemDataByID(stageStepList[i].monsterDropItemID));
                        }
                        
                        Program.PlayerStatUI(player);
                    }

                    Console.SetCursorPosition(45, 22);
                    Console.WriteLine("아무키나 입력하면 결과창이 종료됩니다.");

                    // 다음 스텝 진행 여부 대기
                    Console.ReadLine();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(45, 22);
                    Console.WriteLine("                                                   ");
                    Console.ResetColor();
                    
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(30, 10);
                    Console.WriteLine("                                                               ");
                    Console.SetCursorPosition(30, 11);
                    Console.WriteLine("                                                               ");
                    Console.SetCursorPosition(30, 12);
                    Console.WriteLine("                                                               ");
                    Console.SetCursorPosition(30, 13);
                    Console.WriteLine("                                                               ");
                    Console.ResetColor();

                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(45, 22);
                    Console.WriteLine("                                                               ");

                    

                    Console.SetCursorPosition(40, 7);
                    Console.WriteLine("====== NEXT STEP ======");

                }

                Console.SetCursorPosition(40, 7);
                Console.WriteLine("====== Stage Clear ======");

                // stage clear reward;
                StageData stage = tableManager.GetStageByID(sellectStage);
                Console.SetCursorPosition(40, 7);
                Console.WriteLine("====== Stage Clear Reward ======");
                Console.SetCursorPosition(40, 9);
                Console.WriteLine("스테이지 {0} 클리어 보상 : {1}", sellectStage, tableManager.FindItemDataByID(stage.clearRewardID).name);

                player.SetIventory(tableManager.FindItemDataByID(stage.clearRewardID));

                if (sellectStage < tableManager.GetStageCount())
                {
                    // !! 다음 스테이지 갈지? 모험 그만할지 묻기
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(2, 27);
                    Console.WriteLine("                                                                                                                   ");
                    Console.SetCursorPosition(2, 28);
                    Console.WriteLine("                                                                                                                   ");
                    Console.ResetColor();

                    Console.SetCursorPosition(2, 27);
                    Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    Console.SetCursorPosition(2, 28);
                    Console.WriteLine(String.Format("{0}", $"             Enter : 다음 스테이지 가기           ||            Esc : \"Go To Lobby\"     "));
                    
                    
                    while (true)
                    {
                        ConsoleKeyInfo inputKey = Console.ReadKey();
                        switch (inputKey.Key)
                        {
                            case ConsoleKey.Enter:
                                if (player.inventory.Count >= player.GetInvenMaxSize())
                                {
                                    Console.SetCursorPosition(30, 15);
                                    Console.WriteLine("가방이 가득차서 더 이상 아이템을 획득하지 못합니다.");
                                    Console.SetCursorPosition(30, 16);
                                    Console.WriteLine("정말로 모험을 계속하시겠습니까? Y/N");
                                  
                                    while (true)
                                    {
                                        ConsoleKeyInfo inputKey_1 = Console.ReadKey();
                                        if (inputKey_1.Key == ConsoleKey.Y)
                                        {
                                            break;
                                        }
                                        else if (inputKey_1.Key == ConsoleKey.N)
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            Console.SetCursorPosition(30, 17);
                                            Console.WriteLine("잘못입력하였습니다.");
                                            Task.Delay(1000).Wait();
                                            Console.SetCursorPosition(30, 16);
                                            Console.BackgroundColor = ConsoleColor.Black;
                                            Console.WriteLine("                                                                       ");
                                            Console.ResetColor();
                                        }
                                    }
                                }

                                Console.SetCursorPosition(30, 15);
                                Console.WriteLine("Next Stage !!");
                                Task.Delay(1000).Wait();
                                Console.SetCursorPosition(30, 15);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("                                                                  ");
                                Console.ResetColor();
                                GoToStage(sellectStage + 1, player);

                                break;

                            case ConsoleKey.Escape:
                                Console.SetCursorPosition(30, 15);
                                Console.WriteLine("Go to Lobby");
                                Task.Delay(1000).Wait();
                                Console.SetCursorPosition(30, 15);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("                                                                  ");
                                Console.ResetColor();

                                Lobby.ShowLobby(player);
                                break;
                            default :
                                Console.SetCursorPosition(30, 15);
                                Console.WriteLine("잘못된입력입니다.");
                                Task.Delay(1000).Wait();
                                Console.SetCursorPosition(30, 15);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("                                                                  ");
                                Console.ResetColor();
                                break;

                        }
                    }
                }
                else
                {  // !! 다음 스테이지 갈지? 모험 그만할지 묻기
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.SetCursorPosition(2, 27);
                    Console.WriteLine("                                                                                                                   ");
                    Console.SetCursorPosition(2, 28);
                    Console.WriteLine("                                                                                                                   ");
                    Console.ResetColor();

                    Console.SetCursorPosition(2, 27);
                    Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                    Console.SetCursorPosition(2, 28);
                    Console.WriteLine(String.Format("{0}", $"                                                      Esc : \"Go To Lobby\"     "));

              
                    while (true)
                    {
                        ConsoleKeyInfo inputKey = Console.ReadKey();
                        switch (inputKey.Key)
                        {
                             case ConsoleKey.Escape:
                                //Console.WriteLine(" Go to Lobby ");
                                Lobby.ShowLobby(player);
                                break;
                             default:
                                Console.SetCursorPosition(30, 15);
                                Console.WriteLine("잘못된입력입니다.");
                                Task.Delay(1000).Wait();
                                Console.SetCursorPosition(30, 15);
                                Console.BackgroundColor = ConsoleColor.Black;
                                Console.WriteLine("                                                                  ");
                                Console.ResetColor();
                                break;
                        }
                    }
                }
            }
        }


        public static int StageSellect(int stageCount, Player player)
        {
           
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                
                switch (inputKey.Key)
                {
                    case ConsoleKey.Escape:
                       // Console.WriteLine(" Go to Lobby ");
                        
                        return 0;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                       // Console.WriteLine("Stage 1 Sellect!!!");

                        if (player.inventory.Count >= player.GetInvenMaxSize())
                        {
                            Console.SetCursorPosition(30, 15);
                            Console.WriteLine("가방이 가득차서 더 이상 아이템을 획득하지 못합니다.");
                            Console.SetCursorPosition(30, 16);
                            Console.WriteLine("정말로 모험을 진행하시겠습니까? Y/N");
                            while (true)
                            {
                                ConsoleKeyInfo inputKey_1 = Console.ReadKey();
                                if (inputKey_1.Key == ConsoleKey.Y)
                                {
                                    Console.SetCursorPosition(30, 14);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                                                       ");
                                    Console.SetCursorPosition(30, 15);
                                    Console.WriteLine("                                                                       ");
                                    Console.ResetColor();
                                    return 1; 
                                }
                                else if (inputKey_1.Key == ConsoleKey.N)
                                {
                                    Console.SetCursorPosition(30, 14);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                                                       ");
                                    Console.SetCursorPosition(30, 15);
                                    Console.WriteLine("                                                                       ");
                                    Console.ResetColor();
                                    return -1;
                                }
                                else
                                {
                                    Console.SetCursorPosition(30, 17);
                                    Console.WriteLine("잘못입력하였습니다.");
                                    Task.Delay(1000).Wait();
                                    Console.SetCursorPosition(30, 16);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                                                       ");
                                    Console.ResetColor();
                                }
                            }
                        }
                        return 1;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                      //  Console.WriteLine("Stage 2 Sellect!!!");
                        if (player.inventory.Count >= player.GetInvenMaxSize())
                        {
                            Console.SetCursorPosition(30, 15);
                            Console.WriteLine("가방이 가득차서 더 이상 아이템을 획득하지 못합니다.");
                            Console.SetCursorPosition(30, 16);
                            Console.WriteLine("정말로 모험을 진행하시겠습니까? Y/N");

                            while (true)
                            {
                                ConsoleKeyInfo inputKey_1 = Console.ReadKey();
                                if (inputKey_1.Key == ConsoleKey.Y)
                                {
                                    Console.SetCursorPosition(30, 15);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                                                       ");
                                    Console.SetCursorPosition(30, 16);
                                    Console.WriteLine("                                                                       ");
                                    Console.ResetColor();
                                    return 2;
                                }
                                else if (inputKey_1.Key == ConsoleKey.N)
                                {
                                    Console.SetCursorPosition(30, 15);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                                                       ");
                                    Console.SetCursorPosition(30, 16);
                                    Console.WriteLine("                                                                       ");
                                    Console.ResetColor();
                                    return -1;
                                }
                                else
                                {
                                    Console.SetCursorPosition(30, 17);
                                    Console.WriteLine("잘못입력하였습니다.");
                                    Task.Delay(1000).Wait();
                                    Console.SetCursorPosition(30, 17);
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.WriteLine("                                                                       ");
                                    Console.ResetColor();

                                }
                            }
                        }
                        return 2;

                    default:
                        Console.SetCursorPosition(30, 15);
                        Console.WriteLine("잘못된입력입니다. 1 ~ {0} 중 입장할 스테이지 번호를 입력하세요.", stageCount);
                        Task.Delay(1000).Wait();
                        Console.SetCursorPosition(30, 15);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("                                                                       ");
                        Console.ResetColor();
                        return -1;
                }

            }
        }
    }
}

