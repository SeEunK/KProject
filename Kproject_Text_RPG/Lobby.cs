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
            Console.WriteLine(String.Format("{0}", "                                                      LOBBY                                                         "));
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
                ConsoleKeyInfo inputKey = Console.ReadKey();

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
            Console.SetCursorPosition(2, 20);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━ [ INVENTORY ]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 22);
            Console.WriteLine(String.Format("{0}", "━━━━ [ Equip Slot ]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));


            Console.SetCursorPosition(5, 23);
            for (int index = 0; index < player.equipSlot.Length; index++)
            {
                Console.Write(" [ {0} 번 :", index + 1);
                if (player.equipSlot[index] != null)
                {
                    Console.Write("{0} ]", player.equipSlot[index].GetItemName());
                }
                else
                {
                    Console.Write(" -- empty -- ]");
                }

            }

            Console.SetCursorPosition(2, 24);
            Console.WriteLine(String.Format("{0}", "━━━━━ [ Inven Slot ]━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            string[] strInventoryList = new string [10];
            
            for (int i = 0; i < player.GetInvenMaxSize(); i++)
            {
               
                if (player.inventory.Count() == 0 || i >= player.inventory.Count())
                {
                    strInventoryList[i] = string.Format("{0, -2}: {1, 10}", $"[{i + 1}]"," -- empty -- ");
                }
                else if (player.inventory[i] != null)
                {
                    strInventoryList[i] = string.Format("{0, -2}: {1, 10}", $"[{i + 1}]",  player.inventory[i].GetItemName());
               
                }
        
            }

            Console.SetCursorPosition(2, 25);
            Console.WriteLine(String.Format($"{strInventoryList[0],22}|{strInventoryList[1],22}|{strInventoryList[2],22}|{strInventoryList[3],22}|{strInventoryList[4],22}"));
            Console.SetCursorPosition(2, 26);
            Console.WriteLine(String.Format($"{strInventoryList[5],22}|{strInventoryList[6],22}|{strInventoryList[7],22}|{strInventoryList[8],22}|{strInventoryList[9],22}"));

           

            if (player.inventory.Count == 0) {

                Console.SetCursorPosition(2, 27);
                Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                Console.SetCursorPosition(2, 28);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(String.Format("{0}", "                                                                              Esc :        close inventory        "));
                Console.ResetColor();
          
            }
            else 
            {
                Console.SetCursorPosition(2, 27);
                Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                Console.SetCursorPosition(2, 28);
                Console.WriteLine(String.Format("{0}", " 1~ 3  : equip slot number select  ||  F1 ~ F10  :   inven slot number select    ||   Esc :   close inventory      "));

            }
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    ShowLobby(player);
                    break;
                }
                else
                {
                    //if(player.inventory.Count == 0)
                    //{
                    //    ErrorInvenSellectEmpty();
                    //}
                    //else { 
                    int sellectInvenSlotNum = 0;
                    switch (inputKey.Key)
                    {
                        case ConsoleKey.F1:
                            sellectInvenSlotNum = 0;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F2:
                            sellectInvenSlotNum = 1;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F3:
                            sellectInvenSlotNum = 2;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F4:
                            sellectInvenSlotNum = 3;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F5:
                            sellectInvenSlotNum = 4;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty(); ;
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F6:
                            sellectInvenSlotNum = 5;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F7:
                            sellectInvenSlotNum = 6;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F8:
                            sellectInvenSlotNum = 7;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F9:
                            sellectInvenSlotNum = 8;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        case ConsoleKey.F10:
                            sellectInvenSlotNum = 9;
                            if (player.inventory[sellectInvenSlotNum] == null)
                            {
                                UiManager.ErrorInvenSellectEmpty();
                            }
                            else
                            {
                                ShowItemInfo(sellectInvenSlotNum, player);
                            }
                            return;
                        default:
                            UiManager.ErrorInputKey();
                            return;
                       // }
                    }
                }
            }
        }


        public static void ShowItemInfo(int sellectNum, Player player)
        {
           
            if (sellectNum <= player.inventory.Count)
            {
                ItemInfoUIDraw(player, sellectNum);


                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        ItemInfoUIClear();
                        OpenInventory(player);
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    {

                        if (player.inventory[sellectNum].GetItemType() == ItemData.ItemType.Weapon || player.inventory[sellectNum].GetItemType() == ItemData.ItemType.Armor)
                        {
                            player.SetEquipSlot(player.inventory[sellectNum]);
                            ItemInfoUIClear();
                            OpenInventory(player);
                            break;
                        }
                        else
                        {
                            ItemInfoUIClear();
                            player.UseItem(player.inventory[sellectNum]);
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
        
        // 아이템 정보 창
        public static void ItemInfoUIDraw(Player player, int sellectNum)
        {
            Console.SetCursorPosition(32, 10);
            Console.WriteLine("==============[ Item Info ]==============");
            Console.SetCursorPosition(32, 11);
            Console.WriteLine("|| [{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
            Console.SetCursorPosition(32, 12);
            Console.WriteLine("|| property :{0}     ||", player.inventory[sellectNum].GetItemProperty());
            Console.SetCursorPosition(33, 13);
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

        public static void ItemInfoUIClear()
        {
            Console.SetCursorPosition(32, 10);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(32, 11);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(32, 12);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(33, 13);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(32, 14);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(32, 15);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(32, 16);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
            Console.SetCursorPosition(32, 17);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("                                          ");
            Console.ResetColor();
        }

    }
}

