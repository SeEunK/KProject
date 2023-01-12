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

            UiManager.UiInit();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}", "                                                   Adventure                                                       "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            Program.PlayerStatUI(player);

            

            if (stageCount != 0)
            {
                // 스테이지 리스트 출력
                UiManager.StageListDraw(stageCount, tableManager.GetStageNameList());
                // 스테이지 선택 버튼 노출
                UiManager.StageSellctButtonDraw(stageCount);

                sellectStageNum = StageSellect(stageCount, player);

                if (sellectStageNum == -1)
                {
                    //선택 잘못했거나, 선택했지만 가방이 full로 진행안하기로 선택한 경우, 
                    ShowStageList(player);
                }
                else if(sellectStageNum == 0)
                { 
                    // 스테이지 리스트 출력 삭제
                    UiManager.StageListDrawClear(stageCount);
                    // 스테이지 선택 버튼 삭제
                    UiManager.StageSellctButtonClear();
                    // 로비로 씬전환
                    Lobby.ShowLobby(player);
                }
                else
                {
                    // 스테이지 리스트 출력 삭제
                    UiManager.StageListDrawClear(stageCount);
                    // 스테이지 선택 버튼 삭제
                    UiManager.StageSellctButtonClear();
                    // 스테이지 입장 
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
                        // 플레이어 사망 으로 배틀 종료
                        break;
                    }
                    else
                    { // 몬스터 처치로 배틀 종료
                        UiManager.MonsterStatDrawClear();

                        // {몬스터 이미지 지우기
                        UiManager.MonsterImageClear();

                        if (tableManager.LevelUpCheck(player.GetExp(), stageStepList[i].rewardExp) == true)
                        {
                            // 레벨업 출력
                            //Console.SetCursorPosition(40, 8);
                            //Console.WriteLine("=========== LEVEL UP ===========");
                            UiManager.LevelUpDraw();
                        }
                        // 경험치 추가
                        player.SetExp(stageStepList[i].rewardExp);
                        // 골드 추가
                        player.SetGold(stageStepList[i].rewardGold);

                        //획득 아이템 추가
                        string rewardItemName = string.Empty;
                        if (stageStepList[i].monsterDropItemID != 0)
                        {
                            ItemData rewardItem = new ItemData();
                            rewardItem = tableManager.FindItemDataByID(stageStepList[i].monsterDropItemID);
                            rewardItemName = rewardItem.name;
                            player.SetIventory(tableManager.FindItemDataByID(stageStepList[i].monsterDropItemID));
                        }
                        // 결과창 출력
                        UiManager.AdventureRewadUIDraw(stageStepList[i].rewardExp, stageStepList[i].rewardGold, rewardItemName);

                        //유저정보 갱신
                        Program.PlayerStatUI(player);
                    }

                    // 결과창 닫기 안내 메시지 출력 (아무키나 입력하면 결과창이 종료됩니다.)
                    UiManager.EnterAnyKeyMessage();
                
                    // 결과창 닫기 여부 대기
                    Console.ReadKey();

                    // 메시지 삭제
                    UiManager.EnterAnyKeyMessageClear();

                    // 레벨업 출력 삭제
                    UiManager.LevelUpDrawClear();
                    // 결과창 삭제
                    UiManager.AdventureRewadUIDrawClear();

                    // 마지막 스텝이 아니면,
                    if (i != stageStepList.Count - 1)
                    {
                        // 다음 스텝 시작 알림 메시지
                        UiManager.NextStepMessageDraw();
                    }

                }
                               
                // stage clear reward;
                StageData stage = tableManager.GetStageByID(sellectStage);
                        
                // 스테이지 클리어 보상 창 출력
                UiManager.StageClearRewardDraw(sellectStage, stage.stageName, tableManager.FindItemDataByID(stage.clearRewardID).name);

                //스테이지 보상 캐릭터에게 넣어주기.
                player.SetIventory(tableManager.FindItemDataByID(stage.clearRewardID));

                UiManager.EnterAnyKeyMessage();
                // 결과창 닫기 여부 대기
                Console.ReadKey();

                // 결과장 닫기 여부 메시지 삭제
                UiManager.EnterAnyKeyMessageClear();
                // 결과창 삭제
                UiManager.StageClearRewardDrawClear();


                if (sellectStage < tableManager.GetStageCount())
                {
                    // !! 다음 스테이지 갈지? 모험 그만할지 묻기
                    BottomButtonAdventureContinue(false);

                    while (true)
                    {
                        // 다음 스테이지 갈지 인풋 받기
                        ConsoleKeyInfo inputKey = Console.ReadKey();
                        switch (inputKey.Key)
                        {
                            // 다음 스테이지 간다를 선택한 경우
                            case ConsoleKey.Enter:
                                // 가방 풀 체크
                                if (player.inventory.Count >= player.GetInvenMaxSize())
                                {
                                    //가방 full 안내 메시지 출력
                                    UiManager.ErrorInventoryFullMessage();

                                    while (true)
                                    {
                                        // 계속 진행 여부 인풋 받기
                                        ConsoleKeyInfo inputKey_1 = Console.ReadKey();

                                        // 가방 full 안내 메시지 삭제
                                        UiManager.ErrorInventoryFullMessageClear();
                                        if (inputKey_1.Key == ConsoleKey.Y)
                                        {
                                            break;
                                        }
                                        else if (inputKey_1.Key == ConsoleKey.N)
                                        {
                                            // 스테이지 리스트 출력화면으로 돌아가기.
                                            ShowStageList(player);
                                            break;
                                        }
                                        else
                                        {  // 잘못된 입력 안내 메시지 출력
                                            UiManager.ErrorInputKey();
                                        }
                                    }
                                }

                                // 다음 스테이지 시작 알림 메시지
                                UiManager.NextStageMessageDraw();
           
                                // 다음스테이지 진입
                                GoToStage(sellectStage + 1, player);
                                break;

                            case ConsoleKey.Escape:
                                // 로비 이동 알림 메시지
                                UiManager.GoToLobbyMessage();
                                Lobby.ShowLobby(player);
                                break;
                            default :
                                // 잘못된 입력 안내 메시지 출력
                                UiManager.ErrorInputKey();
                                break;

                        }
                    }
                }
                else
                {  // 마지막 스테이지 상태에서, 
                    // !! 다음 스테이지 갈지? 모험 그만할지 묻기
                    BottomButtonAdventureContinue(true);
              
                    while (true)
                    {
                        // 인풋 받기
                        ConsoleKeyInfo inputKey = Console.ReadKey();
                        switch (inputKey.Key)
                        {
                            // 나가기 (" Go to Lobby ")
                            case ConsoleKey.Escape:
                                // 로비 씬 전환.
                                Lobby.ShowLobby(player);
                                break;
                            case ConsoleKey.Enter:
                                // 마지막 스테이지라 더 진행 못함 안내 메시지 출력
                                UiManager.ErrorInputKey_NoNextStage();
                                // 스테이지 리스트 출력화면으로 돌아가기.
                                ShowStageList(player);
                                break;
                            default:
                                // 잘못된 입력 안내 메시지 출력
                                UiManager.ErrorInputKey();
                                break;
                        }
                    }
                }
            }
        }

        public static void BottomButtonAdventureContinue(bool flagLastStage)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine("                                                                                                                   ");
            Console.SetCursorPosition(2, 28);
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();

            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            if (flagLastStage == true)
            {
                Console.SetCursorPosition(2, 28);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("                     Enter : 다음 스테이지 가기             ");
                Console.ResetColor();
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write("||               Esc : \"Go To Lobby\"                  ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 28);
                Console.WriteLine(String.Format("                     Enter : 다음 스테이지 가기             ||               Esc : \"Go To Lobby\"                  "));
                Console.ResetColor();
            }
           
        }


        public static int StageSellect(int stageCount, Player player)
        {
           
            while (true)
            {
                //스테이지 선택 받기
                ConsoleKeyInfo inputKey = Console.ReadKey();
                
                switch (inputKey.Key)
                {
                       // " Go to Lobby "
                    case ConsoleKey.Escape:
                        return 0;

                       // "Stage 1 Sellect!!!"
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        // 가방이 가득찬 경우
                        if (player.inventory.Count >= player.GetInvenMaxSize())
                        {
                            //가방 full 안내 메시지 출력
                            UiManager.ErrorInventoryFullMessage();
           
                            while (true)
                            {   
                                // 계속 진행 여부 인풋 받기
                                ConsoleKeyInfo inputKey_1 = Console.ReadKey();

                                // 가방 full 안내 메시지 삭제
                                UiManager.ErrorInventoryFullMessageClear();

                                if (inputKey_1.Key == ConsoleKey.Y)
                                {
                                    // 선택한 스테이지 번호 넘기고
                                    return 1; 
                                }
                                else if (inputKey_1.Key == ConsoleKey.N)
                                {
                                    // No 선택했으니, 스테이지 입장안하게 -1 리턴.
                                    return -1;
                                }
                                else
                                {
                                    // 잘못된 입력 안내 메시지 출력
                                    UiManager.ErrorInputKey();
                                }
                            }
                        } // 스테이지 1 선택함 반환
                        return 1;
                        
                    //"Stage 2 Sellect!!!"
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        // 가방 가득찬 경우
                        if (player.inventory.Count >= player.GetInvenMaxSize())
                        { 
                            //가방 full 안내 메시지 출력
                            UiManager.ErrorInventoryFullMessage();
                         
                            while (true)
                            {   // 계속 진행 여부 인풋 받기
                                ConsoleKeyInfo inputKey_1 = Console.ReadKey();

                                //가방 full 안내 메시지 삭제
                                UiManager.ErrorInventoryFullMessageClear();

                                if (inputKey_1.Key == ConsoleKey.Y)
                                {   
                                    // 선택한 스테이지 번호 넘기고
                                    return 2;
                                }
                                else if (inputKey_1.Key == ConsoleKey.N)
                                {    // No 선택했으니, 스테이지 입장 진행 안하고, -1 리턴.
                                    return -1;
                                }
                                else
                                {
                                    // 잘못된 입력 안내 메시지 출력
                                    UiManager.ErrorInputKey();
                                }
                            }
                        }// 스테이지 2 선택함 반환
                        return 2;

                    default:
                        // 잘못된 입력 안내 메시지 출력
                        UiManager.ErrorInputKey();
            
                        return -1;
                }

            }
        }
    }
}

