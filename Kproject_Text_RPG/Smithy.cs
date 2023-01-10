using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Kproject_Text_RPG.ItemData;

namespace Kproject_Text_RPG
{
    public class Smithy
    {
        public static void ShowSmithy(Player player)
        {

            TableManager tableManager = TableManager.getInstance();
            List<EnhanceData> enhanceTable = tableManager.GetEnhanceTable();

            int smithySubMenu = 0;

            Console.WriteLine(String.Format("{0}","================Smithy =================").PadLeft(50 -(25-("================Smithy =================".Length/2))));
            Console.WriteLine("======================================");
            Console.WriteLine("|| [ F1 : Enhance ]  [ F2 : Repair ]  [ esc : Go To Lobby ]||");
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
                    smithySubMenu = 1;
                    ShowInvenList(tableManager, player, smithySubMenu);
                    break;
                }
                else if (inputKey.Key == ConsoleKey.F2)
                {
                    smithySubMenu = 2;
                    ShowInvenList(tableManager, player, smithySubMenu);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
       


        public static void ShowInvenList(TableManager tableManager, Player player, int smithySubMenu)
        {
            Console.WriteLine("==============[ Inventory ]=============");
            Console.WriteLine("┌────────────────────────────────────────Equip Slot─────────────────────────────────────────────────┐");
            for (int index = 0; index < player.equipSlot.Length; index++)
            {
                Console.Write(" [ {0} 번 :" , index + 1);
                if(player.equipSlot[index] != null)
                {
                    Console.Write("{0} ]", player.equipSlot[index].GetItemName());
                }
                else
                {
                    Console.Write(" empty ]");
                }

            }
            Console.WriteLine();
            Console.WriteLine("└────────────────────────────────────────────────────────────────────────────────────────────────┘");
            Console.WriteLine("┌────────────────────────────────────────inven Slot────────────────────────────────────────────────┐");
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
                Console.WriteLine("== [ select : equip slot number 1~ 3 || inven slot number F1 ~ F10   ||  close  : Esc ] ==");
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
                                //equip 
                            case ConsoleKey.NumPad1:
                                sellectInvenSlotNum = 100;
                                break;
                            case ConsoleKey.NumPad2:
                                sellectInvenSlotNum = 101;
                                break;
                            case ConsoleKey.NumPad3:
                                sellectInvenSlotNum = 102; 
                                break;

                                // inven
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
                        
                        if (0 <= sellectInvenSlotNum )
                        {
                            // enhance menu
                            if (smithySubMenu == 1)
                            {
                                if (sellectInvenSlotNum >= 100)
                                {  // 장착 중인 아이템 선택 한 경우,
                                    int slotNum = sellectInvenSlotNum - 100;
                                    if (player.equipSlot[slotNum] == null)
                                    {
                                        Console.WriteLine("빈슬롯입니다.");
                                    }
                                    else if (player.equipSlot[slotNum].GetEnhanceLevel() == 5)
                                    {
                                        Console.WriteLine("최대 레벨로 강화된 아이템 입니다.");
                                    }
                                    else
                                    { // 강화 진행 함수로 이동
                                        ShowItemInfoINSmithy(sellectInvenSlotNum, player, tableManager, smithySubMenu);
                                    }
                                }
                                else 
                                { // 미 장착 아이템 선택
                                    if (player.inventory[sellectInvenSlotNum] == null)
                                    {
                                        Console.WriteLine("빈슬롯입니다.");
                                    }
                                    else if (player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Weapon ||
                                            player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Armor)
                                    {
                                        if (player.inventory[sellectInvenSlotNum].GetEnhanceLevel() == 5)
                                        {
                                            Console.WriteLine("최대 레벨로 강화된 아이템 입니다.");
                                        }
                                        else
                                        {
                                            ShowItemInfoINSmithy(sellectInvenSlotNum, player, tableManager, smithySubMenu);
                                        }
                                    }
                                    else
                                    { //무기 , 방어구가 아닌 아이템 선택시
                                        Console.WriteLine("강화할 수 없는 아이템 입니다.");
                                    }
                                }
                            }
                            // repair menu
                            else if (smithySubMenu == 2)
                            {
                                if (sellectInvenSlotNum >= 100)
                                {  // 장착 중인 아이템 선택 한 경우,
                                    int slotNum = sellectInvenSlotNum - 100;
                                    if (player.equipSlot[slotNum] == null)
                                    {
                                        Console.WriteLine("빈슬롯입니다.");
                                    }
                                    else if (player.equipSlot[slotNum].GetDurability() == player.equipSlot[slotNum].GetMaxDurability())
                                    {
                                        Console.WriteLine("내구도가 최대 상태입니다..");
                                    }
                                    else
                                    {
                                        // 수리 진행 함수로 이동
                                        ShowItemInfoINSmithy(sellectInvenSlotNum, player, tableManager, smithySubMenu);
                                    }
                                }
                                else
                                {// 미 장착 아이템 선택 한 경우,
                                    if (player.inventory[sellectInvenSlotNum] == null)
                                    {
                                        Console.WriteLine("빈슬롯입니다.");
                                    }
                                    else if (player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Weapon ||
                                            player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Armor)
                                    {
                                        if (player.inventory[sellectInvenSlotNum].GetDurability() == player.inventory[sellectInvenSlotNum].GetMaxDurability())
                                        {
                                            Console.WriteLine("내구도가 최대 상태입니다..");
                                        }
                                        else
                                        {// 수리 진행 함수로 이동
                                            ShowItemInfoINSmithy(sellectInvenSlotNum, player, tableManager, smithySubMenu);
                                        }
                                    }
                                    else
                                    { //무기 , 방어구가 아닌 아이템 선택시
                                        Console.WriteLine("수리할 수 없는 아이템 입니다.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 접근입니다.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 접근입니다.");
                        }
                    }
                }
            }
        }





        // 이것도 수리랑 같이 쓸까?
        public static void ShowItemInfoINSmithy(int sellectNum,  Player player, TableManager tableManager, int smithySubMenu)
        {
            Console.WriteLine("===========[ Item Info ]==============");

            if (smithySubMenu == 1)
            { //강화
                if (sellectNum >= 100)
                {//장착중인 장비 
                    int equipIndex = sellectNum - 100;
                    Console.WriteLine("||[{0}]   type:{1}  ||", player.equipSlot[equipIndex].GetItemName(), player.equipSlot[equipIndex].GetItemType());
                    Console.WriteLine("|| property :{0}  ||", player.equipSlot[equipIndex].GetItemProperty());
                    Console.WriteLine("|| desc : {0}  ||", player.equipSlot[equipIndex].GetDescription()); ;
                    Console.WriteLine("==============================");
                    Console.WriteLine("|| enhance level : {0}  ||", player.equipSlot[equipIndex].GetEnhanceLevel());
                }
                else
                {// 미장착 장비
                    Console.WriteLine("||[{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
                    Console.WriteLine("|| property :{0}  ||", player.inventory[sellectNum].GetItemProperty());
                    Console.WriteLine("|| desc : {0}  ||", player.inventory[sellectNum].GetDescription()); ;
                    Console.WriteLine("==============================");
                    Console.WriteLine("|| enhance level : {0}  ||", player.inventory[sellectNum].GetEnhanceLevel());
                }
            }
            else if (smithySubMenu == 2)
            { //수리
                if (sellectNum >= 100)
                { //장착중인 장비 
                    int equipIndex = sellectNum - 100;
                    Console.WriteLine("||[{0}]   type:{1}  ||", player.equipSlot[equipIndex].GetItemName(), player.equipSlot[equipIndex].GetItemType());
                    Console.WriteLine("|| property :{0}  ||", player.equipSlot[equipIndex].GetItemProperty());
                    Console.WriteLine("|| desc : {0}  ||", player.equipSlot[equipIndex].GetDescription()); ;
                    Console.WriteLine("|| durability : {0} / {1}  ||", player.equipSlot[equipIndex].GetDurability(), player.equipSlot[equipIndex].GetMaxDurability());
                }
                else
                { // 미장착 장비
                    Console.WriteLine("||[{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
                    Console.WriteLine("|| property :{0}  ||", player.inventory[sellectNum].GetItemProperty());
                    Console.WriteLine("|| desc : {0}  ||", player.inventory[sellectNum].GetDescription()); ;
                    Console.WriteLine("|| durability : {0} / {1}  ||", player.inventory[sellectNum].GetDurability(), player.inventory[sellectNum].GetMaxDurability());
                }
            }
                Console.WriteLine("==============================");
                Console.WriteLine("|| [sellect : enter || close  : Esc ] ||");
                Console.WriteLine("==============================");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        ShowInvenList(tableManager, player, smithySubMenu);
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    {   // 선택한 아이템 강화 대기 
                        if (smithySubMenu == 1)
                        {
                            SellectItemEnhance(sellectNum, player, tableManager);
                            break;
                        }
                        // 수리 하러가기
                        else if (smithySubMenu == 2)
                        {
                            ShowRepairItem(sellectNum, player, tableManager);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 접근입니다.");
                       
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
        }


        public static void ShowRepairItem(int sellectNum, Player player, TableManager tableManager )
        { // 수리 하기 진입
            int index = 0;
            int preDurability = 0;
            int maxDurability = 0;
            int repairValue = 0;
            int durabilityCost = 0; 
            string itemName = string.Empty;
            ItemData.ItemType type  = ItemType.None;
            int repairRate = 50;

            if (sellectNum >= 100)
            { //장착중인 장비
                index = sellectNum - 100;
                preDurability =  player.equipSlot[index].GetDurability();
                maxDurability = player.equipSlot[index].GetMaxDurability();
                itemName = player.equipSlot[index].GetItemName();
                type = player.equipSlot[index].GetItemType();
            }
            else
            {// 미장착 장비
                index = sellectNum;
                preDurability = player.inventory[index].GetDurability();
                maxDurability = player.inventory[index].GetMaxDurability();
                itemName = player.inventory[index].GetItemName();
                type = player.inventory[index].GetItemType();
            }

            repairValue = maxDurability - preDurability;
            durabilityCost = repairValue * 10;

            Console.WriteLine("===========[ Repair ]==============");
            Console.WriteLine("||[{0}] | type:{1}  ||", itemName , type);
            Console.WriteLine("==============================");
            Console.WriteLine("||      Durability     ||");
            Console.WriteLine("||     {0} --> {1}   ||", preDurability, maxDurability);
            Console.WriteLine("==============================");
            Console.WriteLine("||   Repair Rate : {0} %    || ", repairRate);
            Console.WriteLine("||   Repair Cost : {0} Gold    || ", durabilityCost);
            Console.WriteLine("|| [Repair : enter ]|| [close  : Esc ] ||");
            Console.WriteLine("==============================");

   
            Random random = new Random();
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    ShowInvenList(tableManager, player, 2);
                    break;
                }
                else if (inputKey.Key == ConsoleKey.Enter)
                { // 선택한 아이템 수리 
                    if (durabilityCost <= player.GetGold())
                    { //진행
                        int randomRate = random.Next(1, 100 + 1);
                        player.SetGold(-durabilityCost);

                        if (randomRate <= repairRate)
                        { //성공 처리 
                            if (sellectNum >= 100)
                            { //장착중인 장비
                                Console.WriteLine("=========== 수리 성공!!!! ===========");
                                index = sellectNum - 100;
                                if (player.equipSlot[index].GetDurability() == 0)
                                { // 내구도 0 이였다가 수리된 경우, 
                                    if (type == ItemType.Weapon)
                                    {
                                        player.attackPower = player.attackPower + player.equipSlot[index].GetItemPropertyValue();
                                    }
                                    else if (type == ItemType.Armor)
                                    {
                                        player.defense = player.defense + player.equipSlot[index].GetItemPropertyValue();
                                    }
                                }
                                    player.equipSlot[index].SetDurability(repairValue);
                                
                            }
                            else
                            { //미 장착 장비
                                player.inventory[sellectNum].SetDurability(repairValue);
                            }
                             // 수리 대상 선택 직전으로 돌아감.
                            ShowItemInfoINSmithy(sellectNum, player, tableManager, 2);
                            break;
                           
                        }
                        else
                        {
                            Console.WriteLine("=========== 수리 실패!!!! ===========");
                            // 강화 대상 선택 상태 유지.
                            ShowRepairItem(sellectNum, player, tableManager);
                            break;
                        }
                    }
                    else
                    { // 비용 부족.
                        Console.WriteLine("수리 비용이 부족하여 수리를 진행할수없습니다.");
                        ShowItemInfoINSmithy(sellectNum, player, tableManager, 2);
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }


        public static void SellectItemEnhance(int sellectNum, Player player, TableManager tableManager)
        {
            int prevEnhanceLevel= 0; 
            int nextEnhanceLevel =0; 
            ItemData.ItemType type = ItemType.None;
            int index = 0;
            string itemName = string.Empty;
            int enhanceID = 0;
            int prevPropertyValue = 0;

            if (sellectNum >= 100)
            { //장착중인 장비
                index = sellectNum - 100;
               
                itemName = player.equipSlot[index].GetItemName();
                type = player.equipSlot[index].GetItemType();
                prevEnhanceLevel = player.equipSlot[index].GetEnhanceLevel();
                nextEnhanceLevel = prevEnhanceLevel + 1;
                prevPropertyValue = player.equipSlot[index].GetItemPropertyValue();
            }
            else
            {// 미장착 장비
                index = sellectNum;
                itemName = player.inventory[index].GetItemName();
                type = player.inventory[index].GetItemType();
                prevEnhanceLevel = player.inventory[index].GetEnhanceLevel();
                nextEnhanceLevel = prevEnhanceLevel + 1;
                prevPropertyValue = player.inventory[index].GetItemPropertyValue();
            }


            if (type == ItemData.ItemType.Weapon)
            {
                enhanceID = 1;
            }
            else
            {
                enhanceID = 2;
            }
            float successRate = tableManager.GetEnhanceSuccessRate(enhanceID, nextEnhanceLevel);
            int cost = tableManager.GetEnhanceCost(enhanceID, nextEnhanceLevel);
            int nextPropertyValue = tableManager.GetEnhanceValue(enhanceID, nextEnhanceLevel);

            Console.WriteLine("===========[ Enhance ]==============");
            Console.WriteLine("||[{0}] | type:{1}  ||", itemName, type);
            Console.WriteLine("==============================");
            Console.WriteLine("||      enhance level       ||");
            Console.WriteLine("||    +{0}    -->     +{1}   ||", prevEnhanceLevel, nextEnhanceLevel) ;
            Console.WriteLine("|| ------- property -------- ||");
            Console.WriteLine("||     {0}   -->      {1}  ||", prevPropertyValue, prevPropertyValue+ nextPropertyValue);
            Console.WriteLine("|| ----- success rate ----   ||");
            Console.WriteLine("||            {0} %          ||",successRate);
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
                    ShowInvenList(tableManager, player, 1);
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
                                ShowItemInfoINSmithy(sellectNum, player, tableManager, 1);
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
                        ShowItemInfoINSmithy(sellectNum, player, tableManager,1);
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
