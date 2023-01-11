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
            Console.Clear();
            Program.Ui();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}", "                                                      LOBBY                                                        "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();
            Console.SetCursorPosition(2, 3);
            Console.WriteLine(String.Format("{0}", $"  {player.name,-10}              ||   HP :  {player.hp,6} / {player.maxHP,6}  ||      Gold : {player.GetGold(),10}      "));
            Console.SetCursorPosition(2, 4);
            Console.WriteLine(String.Format("{0}", $"  {player.LevelDisplay(), -10}   ||   AttckPower : {player.attackPower,12}    ||      defence : {player.defense,10}    "));
            Console.SetCursorPosition(2, 5);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.ResetColor();






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
                        Console.SetCursorPosition(50, 7);
                        Console.WriteLine("잘못된입력입니다.");

                        Task.Delay(1000).Wait();
                        Console.SetCursorPosition(40, 7);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.WriteLine("                                          ");
                        break;
                }

            }
        }

        // !!!!!!!!!!!!!!!!!!!!! 23-01-11 인벤 오픈 출력 고쳐야함!!!!
        public static void OpenInventory(Player player)
        {
            Console.SetCursorPosition(2, 20);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            string[] strInventoryList = null;
            
            for (int i = 0; i < player.GetInvenMaxSize(); i++)
            {
                
                // strSlotInfo = string.Format("[ {0} 번 슬롯: ", i + 1);
                // Console.Write("[ {0} 번 슬롯: ", i + 1);

                if (player.inventory.Count() == 0 || i >= player.inventory.Count())
                {
                    strInventoryList[i] = string.Format("[ {0} 번 슬롯:  empty  ]", i + 1);
                    
                }
                else if (player.inventory[i] != null)
                {
                    strInventoryList[i] = string.Format("[ {0} 번 슬롯:  {1}  ]", i + 1, player.inventory[i].GetItemName());
                    //Console.Write("{0}]", player.inventory[i].GetItemName());
                }
               
                // if (i == 4)
                // {
                //     Console.WriteLine();
                // }
            }

            Console.SetCursorPosition(2, 22);
            Console.WriteLine(String.Format($"{strInventoryList[0]}, {strInventoryList[1]} , {strInventoryList[2]}, {strInventoryList[3]} , {strInventoryList[4]}"));
            Console.SetCursorPosition(2, 23);
            Console.WriteLine(String.Format($"{strInventoryList[5]}, {strInventoryList[6]} , {strInventoryList[7]}, {strInventoryList[8]} , {strInventoryList[9]}"));



            Console.WriteLine();
            
            Console.SetCursorPosition(2, 26);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            Console.WriteLine();

            if (player.inventory.Count == 0) {

                Console.SetCursorPosition(2, 27);
                Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                Console.SetCursorPosition(2, 28);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine(String.Format("{0}", "                                                                        Esc :        close inventory              "));
                Console.ResetColor();
          
            }
            else 
            {
                Console.SetCursorPosition(2, 27);
                Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
                Console.SetCursorPosition(2, 28);
                Console.WriteLine(String.Format("{0}", "        F1 ~ F10  :   slot number select   ||          Esc :        close inventory                   "));

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
                    if(player.inventory.Count == 0)
                    {
                        Console.WriteLine("빈슬롯은 선택할수없습니다.");
                    }
                    else { 
                    int sellectInvenSlotNum = 0;
                        switch (inputKey.Key)
                        {
                            case ConsoleKey.F1:
                                sellectInvenSlotNum = 0;
                                if (player.inventory[sellectInvenSlotNum] == null)
                                {
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
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
                                    Console.WriteLine("빈슬롯입니다.");
                                }
                                else
                                {
                                    ShowItemInfo(sellectInvenSlotNum, player);
                                }
                                return;
                            default:
                                Console.WriteLine("잘못된 입력입니다.");
                                return;
                        }
                    }

                }

            }
        }

        public static void ShowItemInfo(int sellectNum, Player player)
        {
           
            if (sellectNum <= player.inventory.Count)
            {
                Console.WriteLine("===========[ Item Info ]==============");
                Console.WriteLine("||[{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
                Console.WriteLine("||property :{0}  ||", player.inventory[sellectNum].GetItemProperty());
                Console.WriteLine("|| desc : {0}  ||", player.inventory[sellectNum].GetDescription()); ;
                Console.WriteLine("==============================");

                Console.WriteLine("==============================");
                Console.WriteLine("== [use : enter || close  : Esc ] ==");
                Console.WriteLine("==============================");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        OpenInventory(player);
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    {

                        if (player.inventory[sellectNum].GetItemType() == ItemData.ItemType.Weapon || player.inventory[sellectNum].GetItemType() == ItemData.ItemType.Armor)
                        {
                            player.SetEquipSlot(player.inventory[sellectNum]);
                            OpenInventory(player);
                            break;
                        }
                        else
                        {
                            player.UseItem(player.inventory[sellectNum]);
                            OpenInventory(player);
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

    }
}

