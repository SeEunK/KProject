using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kproject_Text_RPG
{
    public class Lobby
    {
        public static void ShowLobby (Player player)
        {
            //Console.Clear();
           
            UiManager.UiInit();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}","                                                     LOBBY                                                          "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            Program.PlayerStatUI(player);
 
            BottomButtonInput(player);
        }
        public static void BottomButtonInput(Player player)
        {
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
           
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", "     NumPad1: \"Shop\"     ||     NumPad2: \"Smithy\"   ||     NumPad3: \"Inventory\"     ||    NumPad4: \"Adventure\" "));


            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);

                switch (inputKey.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        //Console.WriteLine("Shop Scene !!!");
                        Shop.ShowShop(player);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        //Console.WriteLine("Smithy Scene !!!");
                        Smithy.ShowSmithy(player);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                       // Console.WriteLine("Inventory Open !!!");
                        OpenInventory(player);
                        InvenItemSellectInput(player);

                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        //Console.WriteLine("Adventure Scene !!!");
                        Adventure.ShowStageList(player);
                        break;
                    default:
                        UiManager.ErrorInputKey();
                        break;
                }
            }


        }

        
        public static void OpenInventory(Player player)
        {
            Console.SetCursorPosition(2, 14);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ [ INVENTORY ]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            Console.SetCursorPosition(2, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(String.Format("{0}", "                                                                                   [  Esc :    close inventory   ] "));


            Console.SetCursorPosition(2, 16);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━ [ Equip Slot ]━━━━━━━━━━━━━━━━━━ ||━━━━━━━━━━━━━━━━━━━━━━━━ [ Inven Slot ]━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();

            string equipItemName = string.Empty;
            // 장착 슬롯 찍고
            for (int index = 0; index < 3; index++)
            {
                if (index == 0)
                {
                    Console.SetCursorPosition(5, 17); 
                    Console.WriteLine(); // 한칸 띄고
                    Console.SetCursorPosition(5, 18);
                    Console.WriteLine(" 1 >  Weapon Slot    ");
                    if (player.equipSlot[index] != null)
                    {
                        equipItemName = player.equipSlot[index].GetItemName();
                        Console.SetCursorPosition(5, 19);
                        Console.Write(string.Format("{0}", equipItemName).PadLeft(20 - (10 - (equipItemName.Length / 2))));
                    }
                    else
                    {
                        Console.SetCursorPosition(5, 19);
                        Console.WriteLine("    --- empty ---    ");
                    }
                    Console.SetCursorPosition(5, 20);
                    Console.WriteLine(); //20번 째 줄 띄우고
                }
                else if (index == 1)
                {
                    Console.SetCursorPosition(5, 21);
                    Console.WriteLine(" 2 >   Armor Slot    ");
                    if (player.equipSlot[index] != null)
                    {
                        equipItemName = player.equipSlot[index].GetItemName();
                        Console.SetCursorPosition(5, 22);
                        Console.Write(string.Format("{0}", equipItemName).PadLeft(20 - (10 - (equipItemName.Length / 2))));
                    }
                    else
                    {
                        Console.SetCursorPosition(5, 22);
                        Console.WriteLine("    --- empty ---    ");
                    }
                    Console.SetCursorPosition(5, 23);
                    Console.WriteLine(); //23번 째 줄 띄우고
                }
                else
                {
                    Console.SetCursorPosition(5, 24);
                    Console.WriteLine(" 3 > Accessory Slot  ");
                    if (player.equipSlot[index] != null)
                    {
                        equipItemName = player.equipSlot[index].GetItemName();
                        Console.SetCursorPosition(5, 25);
                        Console.Write(string.Format("{0}", equipItemName).PadLeft(20 - (10 - (equipItemName.Length / 2))));
                    }
                    else
                    {
                        Console.SetCursorPosition(5, 25);
                        Console.WriteLine("    --- empty ---    ");
                    }
                    Console.SetCursorPosition(5, 26);
                    Console.WriteLine(); //26번 째 줄 띄우고
                }
            }

            // 인벤 슬롯 찍고  17~26
            string itemName = string.Empty;
            for (int i = 0; i < player.GetInvenMaxSize(); i++)
            {
                Console.SetCursorPosition(55, 17+i);
                if (player.inventory.Count() == 0 || i >= player.inventory.Count())
                {
                    Console.Write("|| F {0,2} >",i+1);
                    Console.Write(String.Format("{0}","-- empty --").PadLeft(53-(26-("-- empty --".Length/2))));
                }
                else if (player.inventory[i] != null)
                {
                    itemName = player.inventory[i].GetItemName();
                    Console.Write("|| F {0} >", i+1);
                    Console.WriteLine(String.Format("{0}", itemName).PadLeft(53 - (26 - (itemName.Length / 2))));
                }
        
            }

            // 하단 버튼 
            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 28);
            
            if (player.inventory.Count == 0) {

                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(String.Format("{0}", "                                                                                                                   "));
                Console.ResetColor();
            }
            else 
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(2, 28);
                Console.WriteLine(String.Format("{0}", "          1 ~ 3  : equip slot number select          ||          F1 ~ F10  :   inven slot number select            "));
                Console.ResetColor();
            }
        }

        public static void InvenItemSellectInput(Player player)
        { 
            // 인벤 하단 인풋 받기
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    // 인벤 출력 지우고,
                    UiManager.InventoryDrawClear();

                    ShowLobby(player);

                    break;
                }
                else
                {
                    if (player.inventory.Count == 0&&player.equipSlot.Length == 0)
                    {
                        UiManager.ErrorInvenSellectEmpty();
                    }
                    else
                    {
                        int sellectEquipSlotNum = -1;
                        int sellectInvenSlotNum = -1;
                        switch (inputKey.Key)
                        {
                            // 장착 슬롯 선택
                            case ConsoleKey.D1:
                            case ConsoleKey.NumPad1:
                                sellectEquipSlotNum = 0;
                                if (player.equipSlot[sellectEquipSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player); // 0, -1
                                }
                                break;
                            case ConsoleKey.D2:
                            case ConsoleKey.NumPad2:
                                sellectEquipSlotNum = 1;
                                if (player.equipSlot[sellectEquipSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.D3:
                            case ConsoleKey.NumPad3:
                                sellectEquipSlotNum = 2;
                                if (player.equipSlot[sellectEquipSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                                // 미장착 인벤 아이템 선택
                            case ConsoleKey.F1:
                                sellectInvenSlotNum = 0;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F2:
                                sellectInvenSlotNum = 1;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F3:
                                sellectInvenSlotNum = 2;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F4:
                                sellectInvenSlotNum = 3;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F5:
                                sellectInvenSlotNum = 4;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty(); ;
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F6:
                                sellectInvenSlotNum = 5;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F7:
                                sellectInvenSlotNum = 6;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F8:
                                sellectInvenSlotNum = 7;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F9:
                                sellectInvenSlotNum = 8;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            case ConsoleKey.F10:
                                sellectInvenSlotNum = 9;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    UiManager.ErrorInvenSellectEmpty();
                                }
                                else
                                {
                                    ShowItemInfo(sellectEquipSlotNum, sellectInvenSlotNum, player);
                                }
                                break;
                            default:
                                UiManager.ErrorInputKey();
                                break;
                        }
                    }
                }
            }
        }

        public static void ShowItemInfo(int sellectEquipSlotNum, int sellectInvenSlotNum, Player player)
        {
            Item tempItem = null;

            if (sellectInvenSlotNum == -1)
            { // 장착 아이템 선택
                if (sellectEquipSlotNum <= player.equipSlot.Length)
                {
                    // 인벤 지우고,
                    UiManager.InventoryDrawClear();
                    // 아이템 정보 창 출력
                    ItemInfoUIDraw(player, sellectInvenSlotNum, sellectEquipSlotNum);

                    while (true)
                    {
                        ConsoleKeyInfo inputKey = Console.ReadKey(true);
                        if (inputKey.Key == ConsoleKey.Escape)
                        {
                            // 아이템 정보창 닫고
                            ItemInfoUIClear();
                            // 인벤 출력
                            OpenInventory(player);
                            break;
                        }
                        else if (inputKey.Key == ConsoleKey.Enter)
                        {
                            if (player.equipSlot[sellectEquipSlotNum].GetItemType() == ItemData.ItemType.Weapon || player.equipSlot[sellectEquipSlotNum].GetItemType() == ItemData.ItemType.Armor)
                            {// 장착 해제
                                player.UnEquipItem(player.equipSlot[sellectEquipSlotNum]); // unEquipItem 에서는 빼주는 로직이없으니,
                                tempItem = player.equipSlot[sellectEquipSlotNum];
                                player.inventory.Add(tempItem);
                                player.equipSlot[sellectEquipSlotNum]=null;

                                ItemInfoUIClear();
                                OpenInventory(player);
                                break;
                            }
                            else
                            {
                               
                            }
                        }
                    }
                }
            }
            else if (sellectEquipSlotNum == -1)
            { // 인벤 아이템 선택
                if (sellectInvenSlotNum <= player.inventory.Count)
                {
                    // 인벤 지우고,
                    UiManager.InventoryDrawClear();
                    // 아이템 정보 창 출력
                    ItemInfoUIDraw(player, sellectInvenSlotNum, sellectEquipSlotNum);

                    while (true)
                    {
                        ConsoleKeyInfo inputKey = Console.ReadKey(true);
                        if (inputKey.Key == ConsoleKey.Escape)
                        {
                            // 아이템 정보창 닫고
                            ItemInfoUIClear();
                            // 인벤 출력
                            OpenInventory(player);
                            break;
                        }
                        else if (inputKey.Key == ConsoleKey.Enter)
                        {

                            if (player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Weapon || player.inventory[sellectInvenSlotNum].GetItemType() == ItemData.ItemType.Armor)
                            {
                                player.SetEquipSlot(player.inventory[sellectInvenSlotNum]);
                                ItemInfoUIClear();
                                OpenInventory(player);
                                break;
                            }
                            else
                            {
                                ItemInfoUIClear();
                                player.UseItem(player.inventory[sellectInvenSlotNum]);
                                OpenInventory(player);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    UiManager.ErrorInputKey();
                }
            }
            else
            {
                UiManager.ErrorWrongApproach();
            }
        }

        // 아이템 정보 창
        public static void ItemInfoUIDraw(Player player, int sellectNum, int sellectEquipNum)
        {
            if (sellectEquipNum == -1)
            { // 미장착 템
                Console.SetCursorPosition(32, 10);
                Console.WriteLine("==============[ Item Info ]==============");
                Console.SetCursorPosition(32, 11);
                Console.WriteLine("|| [{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
                Console.SetCursorPosition(32, 12);
                Console.WriteLine("|| property :{0}     ||", player.inventory[sellectNum].GetItemProperty());
                Console.SetCursorPosition(32, 13);
                Console.WriteLine("|| desc : {0}        ||", player.inventory[sellectNum].GetDescription()); ;
                Console.SetCursorPosition(32, 14);
                Console.WriteLine("=========================================");
                Console.SetCursorPosition(32, 15);
                Console.WriteLine("=========================================");
                Console.SetCursorPosition(32, 16);
                Console.WriteLine("||   use : enter   ||   close  : Esc   ||");
                Console.SetCursorPosition(32, 17);
                Console.WriteLine("=========================================");
            }
            else if (sellectNum == -1)
            { //장착 템
                Console.SetCursorPosition(32, 10);
                Console.WriteLine("==============[ Item Info ]==============");
                Console.SetCursorPosition(32, 11);
                Console.WriteLine("|| [{0}]   type:{1}  ||", player.equipSlot[sellectEquipNum].GetItemName(), player.equipSlot[sellectEquipNum].GetItemType());
                Console.SetCursorPosition(32, 12);
                Console.WriteLine("|| property :{0}     ||", player.equipSlot[sellectEquipNum].GetItemProperty());
                Console.SetCursorPosition(32, 13);
                Console.WriteLine("|| desc : {0}        ||", player.equipSlot[sellectEquipNum].GetDescription()); ;
                Console.SetCursorPosition(32, 14);
                Console.WriteLine("=========================================");
                Console.SetCursorPosition(32, 15);
                Console.WriteLine("=========================================");
                Console.SetCursorPosition(32, 16);
                Console.WriteLine("||   unequip : enter   ||   close  : Esc   ||");
                Console.SetCursorPosition(32, 17);
                Console.WriteLine("=========================================");
            }
        }

        public static void ItemInfoUIClear()
        {
            Console.SetCursorPosition(2, 10);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 11);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 12);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 14);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 16);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
            Console.SetCursorPosition(2, 17);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                                                                                                   ");
            Console.ResetColor();
        }

    }
}

