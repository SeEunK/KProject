using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
           

            UiManager.UiInit();


            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}", "                                                     Smithy                                                        "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            Program.PlayerStatUI(player);

            UiManager.SmithyBottombutton();
           
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    Lobby.ShowLobby(player);
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
                    UiManager.ErrorInputKey();
                }
            }
        }
       


        public static void ShowInvenList(TableManager tableManager, Player player, int smithySubMenu)
        {
            Lobby.OpenInventory(player);

            while (true)
            {

                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    UiManager.InventoryDrawClear();
                    ShowSmithy(player);
                    break;
                }
                else
                {
                    if (player.inventory.Count == 0&& player.equipSlot.Length==0)
                    {
                        UiManager.EmptySlotSellectMessage();
                    }
                    else
                    {
                        int sellectEquipSlotNum = -1;
                        int sellectInvenSlotNum = -1;
                        switch (inputKey.Key)
                        {
                                //equip 
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                sellectEquipSlotNum = 0;
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                sellectEquipSlotNum = 1;
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                sellectEquipSlotNum = 2; 
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
                                UiManager.ErrorInputKey();
                                break;
                        }
                        
                        if (0 >= sellectInvenSlotNum || 0>=sellectEquipSlotNum) 
                        {
                            // enhance menu
                            if (smithySubMenu == 1)
                            {
                                if (sellectInvenSlotNum == -1)
                                {  // 장착 중인 아이템 선택 한 경우,
                                    
                                    if (player.equipSlot[sellectEquipSlotNum] == null)
                                    {
                                        UiManager.EmptySlotSellectMessage();
                                    }
                                    else if (player.equipSlot[sellectEquipSlotNum].GetEnhanceLevel() == 5)
                                    {
                                        UiManager.MaxEnhanceLevelItemSellect();
                                    }
                                    else
                                    { // 강화 진행 함수로 이동
                                        UiManager.InventoryDrawClear();
                                        ShowItemInfoINSmithy(sellectInvenSlotNum, sellectEquipSlotNum, player, tableManager, smithySubMenu); //
                                    }
                                }
                                else if (sellectEquipSlotNum == -1)
                                { // 미 장착 아이템 선택
                                    if (player.inventory[sellectInvenSlotNum] == null)
                                    {
                                         UiManager.EmptySlotSellectMessage();
                                    }
                                    else if (player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Weapon ||
                                            player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Armor)
                                    {
                                        if (player.inventory[sellectInvenSlotNum].GetEnhanceLevel() == 5)
                                        {
                                            UiManager.MaxEnhanceLevelItemSellect();
                                        }
                                        else
                                        {
                                            UiManager.InventoryDrawClear();
                                        ShowItemInfoINSmithy(sellectInvenSlotNum, sellectEquipSlotNum, player, tableManager, smithySubMenu);
                                        }
                                    }
                                    else
                                    { //무기 , 방어구가 아닌 아이템 선택시
                                        UiManager.DoNotEnhanceItemSellect();
                                    }
                                }
                            }
                            // repair menu
                            else if (smithySubMenu == 2)
                            {
                                if (sellectInvenSlotNum == -1)
                                {  // 장착 중인 아이템 선택 한 경우,

                                    if (player.equipSlot[sellectEquipSlotNum] == null)
                                    {
                                        UiManager.EmptySlotSellectMessage();
                                    }
                                    else if (player.equipSlot[sellectEquipSlotNum].GetDurability() == player.equipSlot[sellectEquipSlotNum].GetMaxDurability())
                                    {
                                        UiManager.DurabilityMaxItemSellect();
                                    }
                                    else
                                    {
                                        // 수리 진행 함수로 이동
                                        UiManager.InventoryDrawClear();
                                        ShowItemInfoINSmithy( sellectInvenSlotNum, sellectEquipSlotNum, player, tableManager, smithySubMenu);
                                    }
                                }
                                else if(sellectEquipSlotNum == -1)
                                {// 미 장착 아이템 선택 한 경우,
                                    if (player.inventory[sellectInvenSlotNum] == null)
                                    {
                                         UiManager.EmptySlotSellectMessage();
                                    }
                                    else if (player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Weapon ||
                                            player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Armor)
                                    {
                                        if (player.inventory[sellectInvenSlotNum].GetDurability() == player.inventory[sellectInvenSlotNum].GetMaxDurability())
                                        {
                                            UiManager.DurabilityMaxItemSellect();
                                        }
                                        else
                                        {// 수리 진행 함수로 이동
                                            UiManager.InventoryDrawClear();
                                        ShowItemInfoINSmithy(sellectInvenSlotNum,sellectEquipSlotNum, player, tableManager, smithySubMenu);
                                    }
                                    }
                                    else
                                    { //무기 , 방어구가 아닌 아이템 선택시
                                        UiManager.DoNotRepairItemSellect();
                                    }
                                }
                            }
                            else
                            {
                                UiManager.ErrorWrongApproach();
                            }
                       }
                       else
                       {
                           UiManager.ErrorWrongApproach();
                       }
                    }
                }
            }
        }


        // 이것도 수리랑 같이 쓸까?
        public static void ShowItemInfoINSmithy(int sellectNum, int sellectEquipNum, Player player, TableManager tableManager, int smithySubMenu)
        {
            if (smithySubMenu == 1)
            { //강화
                if (sellectNum == -1)
                {//장착중인 장비 
                   
                    UiManager.SmithyEquipItemInfoUIDraw(player, sellectEquipNum, smithySubMenu);
                    SmithSellectItemProgressInput(sellectNum, sellectEquipNum, player, tableManager, smithySubMenu);
                }
                else
                {// 미장착 장비
                    UiManager.SmithyInvenItemInfoUIDraw(player, sellectNum, smithySubMenu);
                    SmithSellectItemProgressInput(sellectNum, sellectEquipNum, player, tableManager, smithySubMenu);
                }
            }
            else if (smithySubMenu == 2)
            { //수리
                if (sellectNum == -1)
                { //장착중인 장비 
                   
                    UiManager.SmithyEquipItemInfoUIDraw(player, sellectEquipNum, smithySubMenu);
                    SmithSellectItemProgressInput(sellectNum, sellectEquipNum, player, tableManager, smithySubMenu);
                    // ~~~~~~~~~~~~?

                }
                else
                { // 미장착 장비
                    UiManager.SmithyInvenItemInfoUIDraw(player, sellectNum, smithySubMenu);
                    SmithSellectItemProgressInput(sellectNum, sellectEquipNum, player, tableManager, smithySubMenu);                                                   
                }
            }

            // 뜯자.
            
        }

        public static void SmithSellectItemProgressInput(int sellectNum, int equipNum, Player player, TableManager tableManager, int smithySubMenu)
        {
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    UiManager.SmithyEnhanceItemInfoClear();
                    ShowInvenList(tableManager, player, smithySubMenu);
                    break;
                }
                else if (inputKey.Key == ConsoleKey.Enter)
                {   // 선택한 아이템 강화 대기 
                    if (smithySubMenu == 1)
                    {
                        if (equipNum == -1)
                        { // 미장착 아이템 선택
                            if (player.inventory[sellectNum].GetEnhanceLevel() == 5) //~!!!!!!!!!!!
                            {
                                UiManager.MaxEnhanceLevelItemSellect();
                                UiManager.SmithyEnhanceItemInfoClear();
                                ShowInvenList(tableManager, player, smithySubMenu);
                                break;
                            }
                            else
                            {
                                SellectItemEnhance(sellectNum, equipNum, player, tableManager);
                            }
                        }
                        else if (sellectNum == -1)
                        {// 장착 아이템 선택
                            if (player.equipSlot[equipNum].GetEnhanceLevel() == 5) //~!!!!!!!!!!!
                            {
                                UiManager.MaxEnhanceLevelItemSellect();
                                UiManager.SmithyEnhanceItemInfoClear();
                                ShowInvenList(tableManager, player, smithySubMenu);
                                break;
                            }
                            else
                            {
                                SellectItemEnhance(sellectNum, equipNum, player, tableManager);
                            }
                        }
                        break;
                    }
                    // 수리 하러가기
                    else if (smithySubMenu == 2)
                    {
                        if (equipNum == -1)
                        {// 미장착 아이템 수리선택
                            if (player.inventory[sellectNum].GetDurability() == player.inventory[sellectNum].GetMaxDurability())
                            {
                                // 내구도 풀이라 안됨
                                UiManager.DurabilityMaxItemSellect();
                                UiManager.SmithyRepairItemInfoClear();
                                ShowInvenList(tableManager, player, smithySubMenu);
                                break;
                            }
                            else
                            {
                                ShowRepairItem(sellectNum, equipNum, player, tableManager);
                            }
                            break;
                        }
                        else if (sellectNum == -1)
                        {// 장착 아이템 수리선택
                            if (player.equipSlot[equipNum].GetDurability() == player.equipSlot[equipNum].GetMaxDurability())
                            {
                                // 내구도 풀이라 안됨
                                UiManager.DurabilityMaxItemSellect();
                                UiManager.SmithyRepairItemInfoClear();
                                ShowInvenList(tableManager, player, smithySubMenu);
                                break;
                            }
                            else
                            {
                                ShowRepairItem(sellectNum, equipNum, player, tableManager);
                            }
                            break;
                        }
                    }
                    else
                    {
                        UiManager.ErrorWrongApproach();
                    }
                }
                else
                {
                    UiManager.ErrorInputKey();
                }
            }
        }

        public static void ShowRepairItem(int sellectNum,int equipNum, Player player, TableManager tableManager )
        { // 수리 하기 진입
            int preDurability = 0;
            int maxDurability = 0;
            int repairValue = 0;
            int durabilityCost = 0; 
            string itemName = string.Empty;
            ItemData.ItemType type  = ItemType.None;
            int repairRate = 50;

            if (sellectNum == -1)
            { //장착중인 장비
              
                preDurability =  player.equipSlot[equipNum].GetDurability();
                maxDurability = player.equipSlot[equipNum].GetMaxDurability();
                itemName = player.equipSlot[equipNum].GetItemName();
                type = player.equipSlot[equipNum].GetItemType();
            }
            else
            {// 미장착 장비
               
                preDurability = player.inventory[sellectNum].GetDurability();
                maxDurability = player.inventory[sellectNum].GetMaxDurability();
                itemName = player.inventory[sellectNum].GetItemName();
                type = player.inventory[sellectNum].GetItemType();
            }

            repairValue = maxDurability - preDurability;
            durabilityCost = repairValue * 10;
           
            UiManager.SmithyRepairItemInfoDraw(itemName, type, preDurability, maxDurability, repairRate, durabilityCost);
   
            Random random = new Random();
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    // SmithyRepairItemInfoDraw 삭제
                    UiManager.SmithyRepairItemInfoClear();
                    ShowInvenList(tableManager, player, 2);
                    break;
                }
                else if (inputKey.Key == ConsoleKey.Enter)
                { // 선택한 아이템 수리 
                    if (durabilityCost <= player.GetGold())
                    { //진행
                        int randomRate = random.Next(1, 100 + 1);
                        player.SetGold(-durabilityCost);
                        // 플레이어 정보 갱신
                        Program.PlayerStatUI(player);
                        if (randomRate <= repairRate)
                        { //성공 처리 
                            if (sellectNum == -1)
                            { //장착중인 장비
                                //수리 성공 메시지 출력
                                UiManager.SuccessRepairItemMessage();

                                //장착 장비의 경우, 내구도 0으로 작착효과 해제된거 다시 복구 해줘야함.
                                if (player.equipSlot[equipNum].GetDurability() == 0)
                                { // 내구도 0 이였다가 수리된 경우, 
                                    if (type == ItemType.Weapon)
                                    {
                                        player.attackPower = player.attackPower + player.equipSlot[equipNum].GetItemPropertyValue();
                                    }
                                    else if (type == ItemType.Armor)
                                    {
                                        player.defense = player.defense + player.equipSlot[equipNum].GetItemPropertyValue();
                                    }
                                }
                                player.equipSlot[equipNum].SetDurability(repairValue);

                            }
                            else
                            { //미 장착 장비
                                //수리 성공 메시지 출력
                                UiManager.SuccessRepairItemMessage();

                                player.inventory[sellectNum].SetDurability(repairValue);
                            }
                            // 수리 대상 선택 직전으로 돌아감.
                            // SmithyRepairItemInfoDraw 삭제
                            UiManager.SmithyRepairItemInfoClear();
                            ShowItemInfoINSmithy(sellectNum, equipNum, player, tableManager, 2);
                            break;

                        }
                        else
                        {
                            //수리 실패 메시지 출력
                            UiManager.FailRepairItemMessage();
                           
                            // 강화 대상 선택 상태 유지.
                            ShowRepairItem(sellectNum, equipNum,player, tableManager);
                            break;
                        }
                    }
                    else
                    { // 비용 부족.
                        UiManager.CanNotRepaitInsufficientCost();
                        // SmithyRepairItemInfoDraw 삭제
                        UiManager.SmithyRepairItemInfoClear();
                        ShowItemInfoINSmithy(sellectNum, equipNum, player, tableManager, 2);
                        break;
                    }
                }
                else
                {
                    UiManager.ErrorInputKey();
                }
            }
        }


        public static void SellectItemEnhance(int sellectNum, int equipNum, Player player, TableManager tableManager)
        {
            int prevEnhanceLevel= 0; 
            int nextEnhanceLevel =0; 
            ItemData.ItemType type = ItemType.None;
            string itemName = string.Empty;
            int enhanceID = 0;
            int prevPropertyValue = 0;

            if (sellectNum == -1)
            { //장착중인 장비
             
                itemName = player.equipSlot[equipNum].GetItemName();
                type = player.equipSlot[equipNum].GetItemType();
                prevEnhanceLevel = player.equipSlot[equipNum].GetEnhanceLevel();
                nextEnhanceLevel = prevEnhanceLevel + 1;
                prevPropertyValue = player.equipSlot[equipNum].GetItemPropertyValue();
            }
            else
            {// 미장착 장비
               
                itemName = player.inventory[sellectNum].GetItemName();
                type = player.inventory[sellectNum].GetItemType();
                prevEnhanceLevel = player.inventory[sellectNum].GetEnhanceLevel();
                nextEnhanceLevel = prevEnhanceLevel + 1;
                prevPropertyValue = player.inventory[sellectNum].GetItemPropertyValue();
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

            // 강화 진행 팝업 출력
            UiManager.SmithyEnhancetemInfoDraw(itemName, type, prevEnhanceLevel, nextEnhanceLevel, prevPropertyValue, nextPropertyValue, successRate, cost);
       

            Random random = new Random();
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    UiManager.SmithyEnhanceItemInfoClear();
                    ShowInvenList(tableManager, player, 1);
                    break; 
                }
                else if (inputKey.Key == ConsoleKey.Enter)
                { // 선택한 아이템 강화 
                    if(cost <= player.GetGold())
                    { //진행
                        int randomRate = random.Next(1,100+1);
                        player.SetGold(-cost);
                        // 플레이어 정보 갱신
                        Program.PlayerStatUI(player);

                        if (randomRate <= successRate)
                        { //성공 처리 
                          //강화 성공 메시지 출력
                            UiManager.SuccessEnhanceItemMessage();
                            if (sellectNum == -1)
                            {//장착 장비
                                player.equipSlot[equipNum].SetEnhanceLevelUp(nextPropertyValue);

                                if (player.equipSlot[equipNum].GetEnhanceLevel() != 5)
                                { // 강화 대상 선택 상태 유지.
                                    SellectItemEnhance(sellectNum, equipNum, player, tableManager);
                                    break;
                                }
                                else
                                { // 강화 대상 선택 직전으로 돌아감.
                                  // 강화 진행 팝업 삭제
                                    UiManager.SmithyEnhanceItemInfoClear();
                                    ShowItemInfoINSmithy(sellectNum, equipNum, player, tableManager, 1);
                                    break;
                                }
                            }
                            else
                            { // 미 장착 장비
                                player.inventory[sellectNum].SetEnhanceLevelUp(nextPropertyValue);

                                if (player.inventory[sellectNum].GetEnhanceLevel() != 5)
                                { // 강화 대상 선택 상태 유지.
                                    SellectItemEnhance(sellectNum, equipNum, player, tableManager);
                                    break;
                                }
                                else
                                { // 강화 대상 선택 직전으로 돌아감.
                                  // 강화 진행 팝업 삭제
                                    UiManager.SmithyEnhanceItemInfoClear();
                                    ShowItemInfoINSmithy(sellectNum, equipNum, player, tableManager, 1);
                                    break;
                                }
                            }
                        }
                        else
                        {
                            //강화 실패 메시지 출력
                            UiManager.FailEnhanceItemMessage();
                            // 강화 대상 선택 상태 유지.

                            SellectItemEnhance(sellectNum, equipNum, player, tableManager);
                            break;
                        }
                    }
                    else
                    { // 비용 부족출력
                        UiManager.CanNotEnhanceInsufficientCost();
                        // 강화 진행 팝업 삭제
                        UiManager.SmithyEnhanceItemInfoClear();
                        ShowItemInfoINSmithy(sellectNum, equipNum, player, tableManager,1);
                        break;
                    }
                }
                else
                {
                    UiManager.ErrorInputKey();
                }
            }
        }

    }
}
