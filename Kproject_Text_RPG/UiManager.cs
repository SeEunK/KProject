using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Kproject_Text_RPG
{
    public class UiManager
    {
        // public int[,] ui_screen = new int[UI_SIZE_Y, UI_SIZE_X];
        public const int UI_SIZE_X = 60;
        public const int UI_SIZE_Y = 30;

        public static void UiInit()
        {
            int[,] _ui_screen = new int[UI_SIZE_Y, UI_SIZE_X];
            UISet(UI_SIZE_Y, UI_SIZE_X, _ui_screen);
            DrawUI(_ui_screen);
        }
        public static void UISet(int UI_SIZE_Y, int UI_SIZE_X, int[,] ui_screen)
        {
            for (int y = 0; y < UI_SIZE_Y; y++)
            {
                for (int x = 0; x < UI_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == UI_SIZE_Y - 1 || x == UI_SIZE_X - 1)
                    {
                        if (y == 0 && x == 0 || y == UI_SIZE_Y - 1 && x == 0 || y == 0 && x == UI_SIZE_X - 1 || y == UI_SIZE_Y - 1 && x == UI_SIZE_X - 1)
                        {
                            ui_screen[y, x] = -3; // 코너로 세팅
                        }
                        else if (y == 0 || y == UI_SIZE_Y - 1)
                        {
                            ui_screen[y, x] = -2; // 벽으로 세팅
                        }
                        else
                        {
                            ui_screen[y, x] = -1; // 벽으로 세팅
                        }
                    }
                    else
                    {
                        ui_screen[y, x] = 0; // 빈공간
                    }
                }
            }
        }
        public static void DrawUI(int[,] ui_screen)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < UI_SIZE_Y; y++)
            {
                for (int x = 0; x < UI_SIZE_X; x++)
                {
                    switch (ui_screen[y, x])
                    {
                        case -3:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        case -2:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ".PadRight(2, ' '));
                            Console.ResetColor();
                            break;
                        case -1:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        default:
                            Console.Write("  ");
                            break;

                    }//swith
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.SetCursorPosition(0, 0);
        }




        // 에러 메세지용

        public static void ErrorInvenSellectEmpty()
        {
            Console.SetCursorPosition(50, 7);
            UiManager.EmptySlotSellectMessage();
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void ErrorInputKey()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("잘못된 입력입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void ErrorWrongApproach()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("잘못된 접근입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void EmptySlotSellectMessage()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("빈 슬롯 입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void MaxEnhanceLevelItemSellect()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("최대 레벨로 강화된 아이템 입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void DoNotEnhanceItemSellect()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("강화할 수 없는 아이템 입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void DurabilityMaxItemSellect()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("내구도가 최대 상태입니다..");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void DoNotRepairItemSellect()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("수리할 수 없는 아이템 입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void ErrorSellectProductMissing()
        {
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("없는 상품 입니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void ErrorInputKey_NoNextStage()
        {
            Console.SetCursorPosition(50, 10);
            Console.WriteLine("마지막 스테이지입니다. ");
            Console.SetCursorPosition(50, 10);
            Task.Delay(200).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void ErrorInventoryFullMessage()
        {
            Console.SetCursorPosition(30, 15);
            Console.WriteLine("가방이 가득차서 더 이상 아이템을 획득하지 못합니다.");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("정말로 모험을 진행하시겠습니까? Y/N");
        }

        public static void ErrorInventoryFullMessageClear()
        {
            Console.SetCursorPosition(30, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                       ");
            Console.SetCursorPosition(30, 16);
            Console.WriteLine("                                                                       ");
            Console.ResetColor();
        }

        public static void EnterAnyKeyMessage()
        {
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("아무키나 입력하면 결과창이 종료됩니다.");
        }

        public static void EnterAnyKey()
        {
            Console.SetCursorPosition(50, 25);
            Console.WriteLine("아무키나 입력하세요.");
            Task.Delay(1000).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(50, 25);
            Console.WriteLine("                     ");
            Console.ResetColor();
        }
      
        public static void EnterAnyKeyMessageClear()
        {
            Console.SetCursorPosition(40, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void LevelUpDraw()
        {
            Console.SetCursorPosition(40, 8);
            Console.WriteLine("=========== LEVEL UP ===========");
        }
        public static void LevelUpDrawClear()
        {
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(40, 8);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void MonsterImageClear()
        {
            for (int index = 0; index < 11; index++)
            {
                Console.SetCursorPosition(48, 9 + index);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("                                                       ");
            }
            Console.ResetColor();
        }

        public static void AdventureRewadUIDraw(int rewardGold, int rewardExp, string dropItem)
        {
            Console.SetCursorPosition(40, 10);
            Console.WriteLine("=========== Reward ===========");
            // 경험치 추가
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("EXP : {0}", rewardExp);
            // 골드 추가
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("GOLD : {0}", rewardGold);

            //획득 아이템 추가

            if (dropItem != string.Empty)
            {
                Console.SetCursorPosition(40, 13);
                Console.WriteLine("Drop : {0}", dropItem);
            }
        }
        public static void AdventureRewadUIDrawClear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(30, 10);
            Console.WriteLine("                                                       ");
            Console.SetCursorPosition(30, 11);
            Console.WriteLine("                                                       ");
            Console.SetCursorPosition(30, 12);
            Console.WriteLine("                                                       ");
            Console.SetCursorPosition(30, 13);
            Console.WriteLine("                                                       ");
            Console.ResetColor();
        }

        public static void NextStepMessageDraw()
        {
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("=========== NEXT STEP ==========");
            Task.Delay(200).Wait();
            Console.SetCursorPosition(40, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void NextStageMessageDraw()
        {
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("=========== NEXT STAGE ==========");
            Task.Delay(200).Wait();
            Console.SetCursorPosition(40, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void GoToLobbyMessage()
        {
            Console.SetCursorPosition(40, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(40, 15);
            Console.WriteLine("Go to Lobby");
            Task.Delay(500).Wait();
            Console.SetCursorPosition(40, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                   ");
            Console.ResetColor();

        }

        public static void StageClearRewardDraw(int stageNum, string stageName, string clearRewardItemName)
        {

            Console.SetCursorPosition(40, 7);
            Console.WriteLine("========  Stage Clear ========");

            Console.SetCursorPosition(40, 9);
            Console.WriteLine("[ stage {0} - {1} ]", stageNum, stageName);


            // stage clear reward;

            Console.SetCursorPosition(40, 11);
            Console.WriteLine("======   Clear Reward    ======");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine(string.Format($"\"{clearRewardItemName}\"").PadLeft(30 - (15 - (clearRewardItemName.Length / 2))));
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("===============================");

        }
        public static void StageClearRewardDrawClear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 7);
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(40, 9);
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("                                                   ");
            Console.SetCursorPosition(40, 13);
            Console.WriteLine("                                                   ");
            Console.ResetColor();
        }
        public static void MonsterStatDraw(string monsterName, int monsterCurrHp, int monsterMaxHp)
        {
            Console.SetCursorPosition(47, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                    ");
            Console.ResetColor();

            Console.SetCursorPosition(47, 7);
            Console.WriteLine("[ {0} HP: {1} / {2} ]", monsterName, monsterCurrHp, monsterMaxHp);
        }
        public static void MonsterStatDrawClear()
        {
            Console.SetCursorPosition(47, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                    ");
            Console.ResetColor();
        }




        public static void MonsterAppearMessage(string monsterName)
        {
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("{0}를 만났습니다.", monsterName);

            Task.Delay(500).Wait();
            Console.SetCursorPosition(40, 7);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                       ");
            Console.ResetColor();
        }
        public static void StageTitleDraw(int stageNum, string StageName)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}", $"                                        STAGE {stageNum}. {StageName}                                      "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();
        }

        public static void DoNotUseItemHpFullMessage()
        {
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("HP가 가득차 더이상 사용할수없습니다.");
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(45, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                         ");
            Console.ResetColor();
        }

        public static void DoNotHaveHpPotion()
        {
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("보유한 HP물약이 없습니다.");
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(45, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                          ");
            Console.ResetColor();
        }

        public static void TakeDamageMessage(string monsterName, int demage)
        {
            Console.SetCursorPosition(2, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                     ");

            Console.SetCursorPosition(40, 22);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0}에게 {1}의 데미지를 입었습니다.", monsterName, demage);
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(40, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                         ");
            Console.ResetColor();
        }
        public static void InflictDamageMessage(string monsterName, int demage)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 22);
            Console.WriteLine("플레이어가 {0}에게 {1}의 데미지를 입혔습니다.", monsterName, demage);
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(40, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                         ");
            Console.ResetColor();

        }

        public static void EquipItemBrokenMessage(string itemName)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("{0}의 내구도가 0이 되어 장착 효과가 해제 되었습니다.", itemName);
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(45, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                       ");
            Console.ResetColor();

        }

        public static void PlayerAttackMessage(int attakType)
        {
            Console.SetCursorPosition(45, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                       ");

            if (attakType == 1)
            {
                Console.SetCursorPosition(45, 22);
                Console.WriteLine("플레이어가 일반 공격을 시도합니다.");
            }
            else if (attakType == 2)
            {
                Console.SetCursorPosition(45, 22);
                Console.WriteLine("플레이어가 공격 스킬을 사용했습니다.");
            }
            Task.Delay(1000).Wait();
            Console.SetCursorPosition(45, 22);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                       ");
            Console.ResetColor();

        }

        public static void PlayerTurnGuideMessage()
        {
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("플레이어 턴 입니다. 행동을 선택해주세요. ");
        }
        public static void PlayerTurnGuideMessageClear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("                                      ");
            Console.ResetColor();
        }

        public static void PlayerTurnActionButtonDraw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", "             F1 : 공격          ||             F2 : 스킬            ||         F3 :  HP 물약             "));
            Console.ResetColor();
        }
        public static void PlayerTurnActionButtonClear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "                                                                                                                   "));
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", "                                                                                                        "));
            Console.ResetColor();
        }

        public static void PlayerTurnActionButtinBlock()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 28);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(String.Format("{0}", "             F1 : 공격          ||             F2 : 스킬            ||         F3 :  HP 물약             "));
            Console.ResetColor();
        }

        public static void MonsterTurnGuideMessage()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("                                      ");
            Console.ResetColor();
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("몬스터 턴 입니다.");
            Task.Delay(500).Wait();

        }
        public static void MonsterTurnGuideMessageClear()
        {
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("                                      ");
            Console.ResetColor();
        }

        // 시간되면 플레이어 사망 UI 바꿔보장!
        public static void PlayerDieDraw()
        {
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("플레이어가 사망하였습니다.");
        }

        public static void PlayerDieDrawClear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("                                      ");
            Console.ResetColor();
        }

        public static void MonsterKillDraw(string monsterName)
        {
            Console.SetCursorPosition(45, 22);
            Console.WriteLine("{0}를 처치하였습니다.", monsterName);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(42, 22);
            Console.WriteLine("                                      ");
            Console.ResetColor();

        }

        public static void StageListDraw(int stageCount, string[] stageNameList)
        {
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("모험 할 stage를 선택하세요. ");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("====== Stage List ======");
            for (int i = 0; i < stageCount; i++)
            {
                Console.SetCursorPosition(45, 10 + i);
                Console.WriteLine("[STAGE {0}] {1}", i + 1, stageNameList[i]);
            }
        }

        public static void StageListDrawClear(int stageCount)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(45, 7);
            Console.WriteLine("                              ");
            Console.SetCursorPosition(45, 9);
            Console.WriteLine("                              ");

            for (int i = 0; i < stageCount; i++)
            {
                Console.SetCursorPosition(45, 10 + i);
                Console.WriteLine("                                     ");
            }
            Console.ResetColor();
        }

        public static void StageSellctButtonDraw(int stageCount)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", $"             NumPad 1 ~ {stageCount} : 스테이지 선택            ||            Esc : \"Go To Lobby\"     "));
            Console.ResetColor();
        }

        public static void StageSellctButtonClear()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "                                                                                                                   "));
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", "                                                                                                                   "));

            Console.ResetColor();
        }


        public static void SmithyBottombutton()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", "         F1 : \"Enhance\"            ||          F2 : \"Repair\"            ||        Esc : \"Go To Lobby\"     "));
            Console.ResetColor();
        }

        public static void InventoryDrawClear()
        {
            for (int i = 0; i < 13; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 14 + i);
                Console.WriteLine("                                                                                                                    ");

            }
            Console.ResetColor();
            Console.SetCursorPosition(0, 0);
        }

        public static void SmithyEquipItemInfoUIDraw(Player player, int index, int smithyMenuFlag)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("==============[ Item Info ]==============");

            // 강화 수리 - 장착 중 공통
            Console.SetCursorPosition(32, 11);
            Console.WriteLine("|| [{0}]   type:{1}  ||", player.equipSlot[index].GetItemName(), player.equipSlot[index].GetItemType());
            Console.SetCursorPosition(32, 12);
            Console.WriteLine("|| property :{0}  ||", player.equipSlot[index].GetItemProperty());
            Console.SetCursorPosition(33, 13);
            Console.WriteLine("|| desc : {0}  ||", player.equipSlot[index].GetDescription()); ;
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("===========================================");

            if (smithyMenuFlag == 1)
            {
                //강화 장착중
                Console.SetCursorPosition(32, 15);
                Console.WriteLine("|| enhance level : {0}  ||", player.equipSlot[index].GetEnhanceLevel());
            }
            else if (smithyMenuFlag == 2)
            {
                //수리 - 장착중
                Console.SetCursorPosition(32, 15);
                Console.WriteLine("|| durability : {0} / {1}  ||", player.equipSlot[index].GetDurability(), player.equipSlot[index].GetMaxDurability());
            }
            //공통
            Console.SetCursorPosition(32, 16);
            Console.WriteLine("===========================================");
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("|| [sellect : enter || close  : Esc ] ||");
            Console.SetCursorPosition(32, 18);
            Console.WriteLine("===========================================");
        }
        public static void SmithyInvenItemInfoUIDraw(Player player, int index, int smithyMenuFlag)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("==============[ Item Info ]==============");

            // 강화 수리 - 장착 중 공통
            Console.SetCursorPosition(32, 11);
            Console.WriteLine("||[{0}]   type:{1}  ||", player.inventory[index].GetItemName(), player.inventory[index].GetItemType());
            Console.SetCursorPosition(32, 12);
            Console.WriteLine("|| property :{0}  ||", player.inventory[index].GetItemProperty());
            Console.SetCursorPosition(33, 13);
            Console.WriteLine("|| desc : {0}  ||", player.inventory[index].GetDescription()); ;
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("===========================================");

            if (smithyMenuFlag == 1)
            {
                //강화 장착중
                Console.SetCursorPosition(32, 15);
                Console.WriteLine("|| enhance level : {0}  ||", player.inventory[index].GetEnhanceLevel());
            }
            else if (smithyMenuFlag == 2)
            {
                //수리 - 장착중
                Console.SetCursorPosition(32, 15);
                Console.WriteLine("|| durability : {0} / {1}  ||", player.inventory[index].GetDurability(), player.inventory[index].GetMaxDurability());
            }
            //공통
            Console.SetCursorPosition(32, 16);
            Console.WriteLine("===========================================");
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("|| [sellect : enter || close  : Esc ] ||");
            Console.SetCursorPosition(32, 18);
            Console.WriteLine("===========================================");
        }

        public static void SmithyRepairItemInfoDraw(string itemName, ItemData.ItemType type, int preDurability, int maxDurability, int repairRate, int durabilityCost)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("================[ Repair ]================");
            Console.SetCursorPosition(32, 11);
            Console.WriteLine("||[{0}] | type:{1}  ||", itemName, type);
            Console.SetCursorPosition(32, 12);
            Console.WriteLine("===========================================");
            Console.SetCursorPosition(32, 13);
            Console.WriteLine("||      Durability     ||");
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("||     {0} --> {1}   ||", preDurability, maxDurability);
            Console.SetCursorPosition(32, 15);
            Console.WriteLine("===========================================");
            Console.SetCursorPosition(32, 16);
            Console.WriteLine("||   Repair Rate : {0} %    || ", repairRate);
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("||   Repair Cost : {0} Gold    || ", durabilityCost);
            Console.SetCursorPosition(32, 18);
            Console.WriteLine("|| [Repair : enter ]|| [close  : Esc ] ||");
            Console.SetCursorPosition(32, 19);
            Console.WriteLine("===========================================");
        }

        public static void SmithyRepairItemInfoClear()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 10 + i);
                Console.WriteLine("                                                                                                                   ");
            }
            Console.ResetColor();
        }
        public static void SmithyEnhancetemInfoDraw(string itemName, ItemData.ItemType type, int prevEnhanceLevel, int nextEnhanceLevel, int prevPropertyValue, int nextPropertyValue, float successRate, int cost)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("===============[ Enhance ]===============");
            Console.SetCursorPosition(32, 11);
            Console.WriteLine("||[{0}] | type:{1}  ||", itemName, type);
            Console.SetCursorPosition(32, 12);
            Console.WriteLine("=========================================");
            Console.SetCursorPosition(32, 13);
            Console.WriteLine("||            enhance level           ||");
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("||       +{0}     -->     +{1}     ||", prevEnhanceLevel, nextEnhanceLevel);
            Console.SetCursorPosition(32, 15);
            Console.WriteLine("|| ------------- property ----------- ||");
            Console.SetCursorPosition(32, 16);
            Console.WriteLine("||        {0}     -->       {1}     ||", prevPropertyValue, prevPropertyValue + nextPropertyValue);
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("|| --------- success rate ---------   ||");
            Console.SetCursorPosition(32, 18);
            Console.WriteLine("||                 {0} %              ||", successRate);
            Console.SetCursorPosition(32, 19);
            Console.WriteLine("==========================================");
            Console.SetCursorPosition(32, 20);
            Console.WriteLine("||       Enhance Cost {0} Gold       || ", cost);
            Console.SetCursorPosition(32, 21);
            Console.WriteLine("== [Enhance : enter ]|| [close  : Esc ] ==");
            Console.SetCursorPosition(32, 22);
            Console.WriteLine("===========================================");
        }
        public static void SmithyEnhanceItemInfoClear()
        {
            for (int i = 0; i < 12; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 10 + i);
                Console.WriteLine("                                                                                                                   ");
            }
            Console.ResetColor();
        }

        public static void ShopItemInfoDraw(Player player , int sellectNum )
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("====================== [ Item Info ] =======================");
            Console.SetCursorPosition(32, 11);
            Console.Write(string.Format("|| [{0}]", player.inventory[sellectNum].GetItemName()));
            Console.SetCursorPosition(60, 11);
            Console.Write(string.Format("{0, -10}", " type :"));
            Console.Write(string.Format("{0,19} ||", player.inventory[sellectNum].GetItemType()));
            Console.SetCursorPosition(32, 12);
            Console.Write(string.Format("|| property :"));
            Console.SetCursorPosition(70, 12);
            Console.Write(string.Format("{0,19} ||", player.inventory[sellectNum].GetItemProperty()));
            Console.SetCursorPosition(32, 13);
            Console.Write(string.Format("|| desc :"));
            Console.Write(string.Format("{0,36} ||", player.inventory[sellectNum].GetDescription()));
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("||                      sell price :  {0,17}   ||", player.inventory[sellectNum].GetSellPrice());
            Console.SetCursorPosition(32, 15);
            Console.WriteLine("============================================================");
            Console.SetCursorPosition(32, 16);
            Console.WriteLine("============================================================");
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("== [      Sell   : enter     ||       close  : Esc      ] ==");
            Console.SetCursorPosition(32, 18);
            Console.WriteLine("============================================================");
        }

        public static void ShopItemInfoClear()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 10 + i);
                Console.WriteLine("                                                                                                                   ");
            }
            Console.ResetColor();
        }

        public static void ShopProdutItemListDraw(List<ItemData> itemTable, Player player)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("===================== [Product List] ========================");

            int produtLine = itemTable.Count +10;
            for (int i = 0; i < itemTable.Count; i++)
            {
                Console.SetCursorPosition(32, 11+i);
                Console.Write("[F{0} > {1}", i + 1, itemTable[i].name);
                Console.SetCursorPosition(60, 11 + i);
                Console.Write(String.Format("{0,-10}", "price : "));
                Console.Write(String.Format("{0,20}", itemTable[i].price));
            }
            Console.SetCursorPosition(32, produtLine);
            Console.WriteLine("============================================================");
            Console.SetCursorPosition(32, produtLine+1);
            Console.WriteLine("== [ select : product number F1 ~ F{0}  ||  close  : Esc ] ==", itemTable.Count-1);
            Console.SetCursorPosition(32, produtLine + 2);
            Console.WriteLine("============================================================");

        }
        public static void ShopProdutItemListClear()
        {
            for (int i = 0; i < 19; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 10 + i);
                Console.WriteLine("                                                                                                                   ");
            }
            Console.ResetColor();
        }

        public static void ShopProdutItemSellectInfo(string name, ItemData.ItemType type, string property, string desc , int price)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("====================== [ Item Info ] =======================");
            Console.SetCursorPosition(32, 11);
            Console.Write(string.Format("|| [{0}]", name));
            Console.SetCursorPosition(60, 11);
            Console.Write(string.Format("{0, -10}", " type :"));
            Console.Write(string.Format("{0,19} ||", type));
            Console.SetCursorPosition(32, 12);
            Console.Write(string.Format("|| property :"));
            Console.SetCursorPosition(70, 12);
            Console.Write(string.Format("{0,19} ||", property));
            Console.SetCursorPosition(32, 13);
            Console.Write(string.Format("|| desc :"));
            Console.Write(string.Format("{0,36} ||",desc));
            Console.SetCursorPosition(32, 14);
            Console.WriteLine("||                           price :  {0,17}   ||", price); 
            Console.SetCursorPosition(32, 15);
            Console.WriteLine("============================================================");
            Console.SetCursorPosition(32, 16);
            Console.WriteLine("============================================================");
            Console.SetCursorPosition(32, 17);
            Console.WriteLine("== [       Buy   : enter     ||       close  : Esc      ] ==");
            Console.SetCursorPosition(32, 18);
            Console.WriteLine("============================================================");
        }

        public static void ShopProdutItemSellectInfoClear()
        {
            for (int i = 0; i < 9; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 10 + i);
                Console.WriteLine("                                                                                                                   ");
            }
            Console.ResetColor();
        }
        public static void ShopItemSellComplete(string sellectSaleItemName , Player player, int itemID, int sellPrice)
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("  {0} 판매에 성공하였습니다. (+{1}Gold)  ", sellectSaleItemName, sellPrice);
            Console.SetCursorPosition(30, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                ");
            Console.ResetColor();
        }

        public static void ShopItemBuyComplete(string sellectSaleItemName)
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("  {0} 구매에 성공하였습니다. ", sellectSaleItemName);
            Console.SetCursorPosition(30, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                ");
            Console.ResetColor();
        }

        public static void CanNotBuyItemInsufficientCost()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("골드가 부족하여 구매할수없습니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                  ");
            Console.ResetColor();
        }
        public static void CanNotEnhanceInsufficientCost()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("비용이 부족하여 아이템 강화를 진행할수없습니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                  ");
            Console.ResetColor();
        }
        public static void CanNotRepaitInsufficientCost()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("비용이 부족하여 아이템 수리를 진행할 수 없습니다.");
            Console.SetCursorPosition(50, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                   ");
            Console.ResetColor();
        }

        public static void SuccessRepairItemMessage()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("=========== 수리 성공!!!! ===========");
            Console.SetCursorPosition(30, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void FailRepairItemMessage()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("=========== 수리 실패!!!! ===========");
            Console.SetCursorPosition(30, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void SuccessEnhanceItemMessage()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("=========== 강화 성공!!!! ===========");
            Console.SetCursorPosition(30, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }
        public static void FailEnhanceItemMessage()
        {
            Console.SetCursorPosition(30, 7);
            Console.WriteLine("=========== 강화 실패!!!! ===========");
            Console.SetCursorPosition(30, 7);
            Task.Delay(500).Wait();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

        public static void TitleDraw()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("■■■■■□■■■■□■□□□■□■■■■■□□■■■□□■■■□□□■■■□");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine("□□■□□□■□□□□□■□■□□□□■□□□□■□□■□■□□■□■□□□□");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("□□■□□□■■■□□□□■□□□□□■□□□□■■■□□■■■□□■□■■□");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("□□■□□□■□□□□□■□■□□□□■□□□□■□□■□■□□□□■□□■□");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("□□■□□□■■■■□■□□□■□□□■□□□□■□□■□■□□□□□■■■□");

        }
        public static void TitleDrawClear()
        {
            for (int i = 0; i < 19; i++)
            {
                Console.SetCursorPosition(20, 7+i);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("                                                                               ");
            } 
            Console.ResetColor();
        }
    }
}
