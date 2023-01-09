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


        public static void BottomButtonInput(Player player)
        {

            Console.WriteLine("================================");
            Console.WriteLine(" || NumPad1: \"Shop\" || NumPad2: \"Smithy\"  ||  NumPad3: \"Inventory\" || NumPad4: \"Adventure\" || ");
            Console.WriteLine("================================");


            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();

                switch (inputKey.Key)
                {
                    case ConsoleKey.NumPad1:
                        Console.WriteLine("Shop Scene !!!");

                        break;
                    case ConsoleKey.NumPad2:
                        Console.WriteLine("Smithy Scene !!!");
                        break;
                    case ConsoleKey.NumPad3:
                        Console.WriteLine("Inventory Open !!!");
                        OpenInventory(player);
                        break;
                    case ConsoleKey.NumPad4:
                        Console.WriteLine("Adventure Scene !!!");
                        Adventure.ShowStageList(player);
                        break;
                    default:
                        Console.WriteLine("잘못된입력입니다.");
                        return;
                }

            }
        }

        public static void OpenInventory(Player player)
        {

            for (int i = 0; i < player.GetInvenSize(); i++)
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
            Console.WriteLine();

            Console.WriteLine("==============================");
            Console.WriteLine("== [ close inventory : Esc ] ==");
            Console.WriteLine("==============================");
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    BottomButtonInput(player);
                    break;
                }
                else
                {
                    int sellectInvenSlotNum = 0;
                    switch (inputKey.Key)
                    {
                        case ConsoleKey.F1:
                            sellectInvenSlotNum = 0;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F2:
                            sellectInvenSlotNum = 1;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F3:
                            sellectInvenSlotNum = 2;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F4:
                            sellectInvenSlotNum = 3;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F5:
                            sellectInvenSlotNum = 4;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F6:
                            sellectInvenSlotNum = 5;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F7:
                            sellectInvenSlotNum = 6;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F8:
                            sellectInvenSlotNum = 7;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F9:
                            sellectInvenSlotNum = 8;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        case ConsoleKey.F10:
                            sellectInvenSlotNum = 9;
                            ShowItemInfo(sellectInvenSlotNum, player);
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            return;
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
                        BottomButtonInput(player);
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    {

                        if (player.inventory[sellectNum].GetItemType() == ItemData.ItemType.Weapon || player.inventory[sellectNum].GetItemType() == ItemData.ItemType.Armor)
                        {
                            player.SetEquipSlot(player.inventory[sellectNum]);
                            break;
                        }
                        else
                        {
                            player.UseItem(player.inventory[sellectNum]);
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

