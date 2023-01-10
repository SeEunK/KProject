using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class Smithy
    {
        public static void ShowSmithy(Player player)
        {

            TableManager tableManager = TableManager.getInstance();
            List<EnhanceData> enhanceTable = tableManager.GetEnhanceTable();

            Console.WriteLine("================Smithy =================");
            Console.WriteLine("======================================");
            Console.WriteLine("|| [  F1 : Enhance ]  [ esc : Go To Lobby ]||");
            Console.WriteLine("======================================");

            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    Lobby.BottomButtonInput(player);
                    break;
                }
                else if (inputKey.Key == ConsoleKey.F1)
                {
                    ShowInvenList(tableManager, player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
      
        public static void ShowInvenList(TableManager tableManager, Player player)
        {
            Console.WriteLine("==============[ Inventory ]=============");
            Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────────────────────────┐");
            for (int i = 0; i < player.GetInvenMaxSize(); i++)
            {
                Console.Write("[ {0} 번 슬롯: ", i + 1);

                if (player.inventory.Count() == 0 || i >= player.inventory.Count())
                {
                    Console.Write("empty ]");
                }
                else if (player.inventory[i] != null)
                {
                    Console.Write("{0}]", player.inventory[i].GetItemName());
                }

                if (i == 4)
                {
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine();

            if (player.inventory.Count == 0)
            {
                Console.WriteLine("============================================================================");
                Console.WriteLine("== [   close  : Esc ] ==");
                Console.WriteLine("============================================================================");
            }
            else
            {
                Console.WriteLine("============================================================================");
                Console.WriteLine("== [ select : slot number F1 ~ F10  /  close  : Esc ] ==");
                Console.WriteLine("============================================================================");
            }

            while (true)
            {

                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    ShowSmithy(player);
                    break;
                }
                else
                {
                    if (player.inventory.Count == 0)
                    {
                        Console.WriteLine("빈슬롯은 선택할수없습니다.");
                    }
                    else
                    {
                        int sellectInvenSlotNum = -1;
                        switch (inputKey.Key)
                        {
                            case ConsoleKey.F1:
                                sellectInvenSlotNum = 0;
                                
                                break;
                            case ConsoleKey.F2:
                                sellectInvenSlotNum = 1;

                                break;
                            case ConsoleKey.F3:
                                sellectInvenSlotNum = 2;

                                break;
                            case ConsoleKey.F4:
                                sellectInvenSlotNum = 3;

                                break;
                            case ConsoleKey.F5:
                                sellectInvenSlotNum = 4;

                                break;
                            case ConsoleKey.F6:
                                sellectInvenSlotNum = 5;

                                break;
                            case ConsoleKey.F7:
                                sellectInvenSlotNum = 6;

                                break;
                            case ConsoleKey.F8:
                                sellectInvenSlotNum = 7;

                                break;
                            case ConsoleKey.F9:
                                sellectInvenSlotNum = 8;

                                break;
                            case ConsoleKey.F10:
                                sellectInvenSlotNum = 9;
                                break;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                break;
                        }

                        if (player.inventory[sellectInvenSlotNum] == null)
                        {
                            Console.WriteLine("빈슬롯입니다.");
                        }
                        else if (player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Weapon || player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Armor)
                        {
                            if (player.inventory[sellectInvenSlotNum].GetEnhanceLevel() == 5)
                            {
                                Console.WriteLine("최대 레벨로 강화된 아이템 입니다.");
                            }
                            else 
                            {
                                ShowEnhanceItemInfo(sellectInvenSlotNum, player, tableManager);
                            }
                        }
                        else
                        { //무기 , 방어구가 아닌 아이템 선택시
                            Console.WriteLine("강화할수없는 아이템 입니다.");
                        }
                    }
                }
            }
        }

        public static void ShowEnhanceItemInfo(int sellectNum,  Player player, TableManager tableManager)
        {

            if (sellectNum <= player.inventory.Count)
            {
                Console.WriteLine("===========[ Item Info ]==============");
                Console.WriteLine("||[{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
                Console.WriteLine("|| property :{0}  ||", player.inventory[sellectNum].GetItemProperty());
                Console.WriteLine("|| desc : {0}  ||", player.inventory[sellectNum].GetDescription()); ;
                Console.WriteLine("==============================");
                Console.WriteLine("|| enhance level : {0}  ||", player.inventory[sellectNum].GetEnhanceLevel()); ;
                Console.WriteLine("==============================");
                Console.WriteLine("== [sellect : enter || close  : Esc ] ==");
                Console.WriteLine("==============================");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        ShowInvenList(tableManager, player);
                        return;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    { // 선택한 아이템 강화 대기 

                        SellectItemEnhance(sellectNum, player, tableManager);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
            }
            else
            {
                return;
            }

        }
        public static void SellectItemEnhance(int sellectNum, Player player, TableManager tableManager)
        {
            int prevEnhanceLevel = player.inventory[sellectNum].GetEnhanceLevel();
            int nextEnhanceLevel = prevEnhanceLevel + 1;
            ItemData.ItemType itemType = player.inventory[sellectNum].GetItemType();
            int enhanceID = 0;
            if(itemType == ItemData.ItemType.Weapon)
            {
                enhanceID = 1;
            }
            else
            {
                enhanceID = 2;
            }

            float successRate =  tableManager.GetEnhanceSuccessRate(enhanceID, nextEnhanceLevel);
            int prevPropertyValue = player.inventory[sellectNum].GetItemPropertyValue();
            int nextPropertyValue = tableManager.GetEnhanceValue(enhanceID,nextEnhanceLevel);
            int cost = tableManager.GetEnhanceCost(enhanceID, nextEnhanceLevel);

            Console.WriteLine("===========[ Enhance ]==============");
            Console.WriteLine("||[{0}] | type:{1}  ||", player.inventory[sellectNum].GetItemName(), itemType);
            Console.WriteLine("==============================");
            Console.WriteLine("||      enhance level       ||");
            Console.WriteLine("||    +{0}    -->     +{1}   ||", prevEnhanceLevel, nextEnhanceLevel) ;
            Console.WriteLine("|| ------- property -------- ||");
            Console.WriteLine("||     {0}   -->      {1}  ||", player.inventory[sellectNum].GetItemProperty(), prevPropertyValue+ nextPropertyValue);
            Console.WriteLine("|| ----- success rate ----   ||");
            Console.WriteLine("||            {0} %          || ",successRate);
            Console.WriteLine("==============================");
            Console.WriteLine("||   Enhance Cost {0} Gold    || ", cost);
            Console.WriteLine("== [Enhance : enter ]|| [close  : Esc ] ==");
            Console.WriteLine("==============================");

            Random random = new Random();
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    ShowInvenList(tableManager, player);
                    break; 
                }
                else if (inputKey.Key == ConsoleKey.Enter)
                { // 선택한 아이템 강화 
                    if(cost <= player.GetGold())
                    { //진행
                        int randomRate = random.Next(1,100+1);
                        player.SetGold(-cost);

                        if (randomRate <= successRate)
                        { //성공 처리 
                            Console.WriteLine("=========== 강화 성공!!!! ===========");
                            player.inventory[sellectNum].SetEnhanceLevelUp(nextPropertyValue);

                            if (player.inventory[sellectNum].GetEnhanceLevel() != 5)
                            { // 강화 대상 선택 상태 유지.
                                SellectItemEnhance(sellectNum, player, tableManager);
                                break;
                            }
                            else
                            { // 강화 대상 선택 직전으로 돌아감.
                                ShowEnhanceItemInfo(sellectNum, player, tableManager);
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("=========== 강화 실패!!!! ===========");
                            // 강화 대상 선택 상태 유지.
                            SellectItemEnhance(sellectNum, player, tableManager);
                            break;
                        }
                    }
                    else
                    { // 비용 부족.
                        Console.WriteLine("강화 비용이 부족하여 강화를 진행할수없습니다.");
                        ShowEnhanceItemInfo(sellectNum, player, tableManager);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }

    }
}
