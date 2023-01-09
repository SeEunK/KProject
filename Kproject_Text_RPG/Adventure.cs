using System;
using System.Collections.Generic;
using System.Linq;
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
            if (stageCount != 0)
            {
                Console.WriteLine("모험 할 stage를 선택하세요. ");
                Console.WriteLine("====== Stage List ======");
                for (int i = 0; i < stageCount; i++)
                {

                    Console.WriteLine("[STAGE {0}] ", i + 1);

                }
                Console.WriteLine("========================");
                GoToStage(StageSellect(stageCount),player);
               


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
                   if( Program.Battle(player, stageStepList[i].monsterID) == false)
                    {
                        break;
                    }
                    else
                    {
                        tableManager.LevelUpCheck(player.GetExp(), stageStepList[i].rewardExp);
                       
                        Console.WriteLine("====== Reward ======");
                        // 경험치 추가
                        Console.Write("EXP : {0},", stageStepList[i].rewardExp);
                        player.SetExp(stageStepList[i].rewardExp);
                        // 골드 추가
                        Console.Write("GOLD : {0},", stageStepList[i].rewardGold);
                        player.SetGold(stageStepList[i].rewardGold);
                        //획득 아이템 추가


                        if (stageStepList[i].monsterDropItemID != 0)
                        {
                            ItemData rewardItem = new ItemData();
                            rewardItem = tableManager.FindItemDataByID(stageStepList[i].monsterDropItemID);
                            Console.Write("Drop : {0},", rewardItem.name);
                            player.SetIventory(tableManager.FindItemDataByID(stageStepList[i].monsterDropItemID));
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("====== NEXT STEP ======");

                }
                Console.WriteLine("====== Stage Clear ======");
                
                // stage clear reward;
                StageData stage = tableManager.GetStageByID(sellectStage);
                Console.WriteLine("====== Reward ======");
                Console.WriteLine("스테이지 {0} 클리어 보상 : {1}", sellectStage, tableManager.FindItemDataByID(stage.clearRewardID).name);
                player.SetIventory(tableManager.FindItemDataByID(stage.clearRewardID));

                if (sellectStage < tableManager.GetStageCount())
                {
                    // !! 다음 스테이지 갈지? 모험 그만할지 묻기
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("|| 다음 스테이지 가기 : Enter || 모험 그만하기 (로비로 가기) : Esc ||");
                    Console.WriteLine("=====================================================");
                    
                    while (true)
                    {
                        ConsoleKeyInfo inputKey = Console.ReadKey();
                        switch (inputKey.Key)
                        {
                            case ConsoleKey.Enter:
                                Console.WriteLine("Next Stage !!");
                                GoToStage(sellectStage + 1, player);

                                break;

                            case ConsoleKey.Escape:
                                Console.WriteLine(" Go to Lobby");
                                Lobby.BottomButtonInput(player);
                                break;
                        }
                    }
                }
                else
                {  // !! 다음 스테이지 갈지? 모험 그만할지 묻기
                    Console.WriteLine("=====================================================");
                    Console.WriteLine("||  모험 그만하기 (로비로 가기) : Esc ||");
                    Console.WriteLine("=====================================================");
                    while (true)
                    {
                        ConsoleKeyInfo inputKey = Console.ReadKey();
                        switch (inputKey.Key)
                        {
                             case ConsoleKey.Escape:
                                Console.WriteLine(" Go to Lobby");
                                Lobby.BottomButtonInput(player);
                                break;
                        }
                    }
                }
            }
        }


        public static int StageSellect(int stageCount)
        {
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();

                switch (inputKey.Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Stage 1 Sellect!!!");

                        return 1;
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Stage 2 Sellect!!!");
                        return 2;

                    default:
                        Console.WriteLine("잘못된입력입니다. 1 ~ {0} 중 입장할 스테이지 번호를 입력하세요.", stageCount);
                        return 0;
                }

            }
        }
    }
}

