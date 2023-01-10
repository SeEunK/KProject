using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public class Shop
    {
        public static void ShowShop(Player player)
        {

            TableManager tableManager = TableManager.getInstance();
            List<ItemData> itemTable = tableManager.GetItemTable();

            

            Console.WriteLine("================Shop =================");
            Console.WriteLine("======================================");
            Console.WriteLine("|| [  F1 : buy ] [ F2 : sell ] [ esc : Go To Lobby ]||");
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
                    ShowProductList(itemTable, player);
                    break;
                }
                else if (inputKey.Key == ConsoleKey.F2)
                {
                    ShowInventoryList( player);
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }

        }

        public static void ShowInventoryList( Player player)
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
                    ShowShop(player);
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
                                    ShowSellItemInfo( sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo( sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo( sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo (sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo( sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo( sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo( sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo(sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo(sellectInvenSlotNum, player);
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
                                    ShowSellItemInfo(sellectInvenSlotNum, player);
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

        public static void ShowSellItemInfo(int sellectNum, Player player)
        {

            if (sellectNum <= player.inventory.Count)
            {
                Console.WriteLine("===========[ Item Info ]==============");
                Console.WriteLine("||[{0}]   type:{1}  ||", player.inventory[sellectNum].GetItemName(), player.inventory[sellectNum].GetItemType());
                Console.WriteLine("||property :{0}  ||", player.inventory[sellectNum].GetItemProperty());
                Console.WriteLine("|| desc : {0}  ||", player.inventory[sellectNum].GetDescription()); ;
                Console.WriteLine("==============================");
                Console.WriteLine("|| sell price : {0}  ||", player.inventory[sellectNum].GetSellPrice()); ;
                Console.WriteLine("==============================");
                Console.WriteLine("== [sell : enter || close  : Esc ] ==");
                Console.WriteLine("==============================");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        ShowInventoryList(player);
                        return ;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    { // 선택한 아이템 판매진행.
                       int sellectSaleItemID = player.inventory[sellectNum].GetID();
                       string sellectSaleItemName = player.inventory[sellectNum].GetItemName();
                       player.inventory.Remove(player.inventory[sellectNum]); // 인벤에서 아이템 삭제.
                       player.SetGold( player.FindItemByID(sellectSaleItemID).GetSellPrice()); // 선택한 아이템 판매가격을 유저한테 넣어주고
                       Console.WriteLine("||  {0} 판매에 성공하였습니다. (+{1}Gold)  ||", sellectSaleItemName, player.FindItemByID(sellectSaleItemID).GetSellPrice());
                       ShowInventoryList(player);
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

        public static void ShowProductList(List<ItemData> itemTable , Player player)
        {
            Console.WriteLine("==============[Product List]=============");

            for (int i = 0; i < itemTable.Count; i++)
            {
                Console.WriteLine("[F{2} : {0}  price :{1}]", itemTable[i].name, itemTable[i].price, i + 1);

            }
            Console.WriteLine("======================================");


            Console.WriteLine("============================================================================");
            Console.WriteLine("== [ select : product number F1 ~ F{0}  /  close  : Esc ] ==", itemTable.Count);
            Console.WriteLine("============================================================================");
            Console.WriteLine("===[gold : {0} ]===============================", player.GetGold());
            Console.WriteLine("============================================================================");
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    ShowShop(player);
                    break;
                }
                else
                {
                    int sellectProductNum = 0;
                    switch (inputKey.Key)
                    {
                        case ConsoleKey.F1:
                            sellectProductNum = 0;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F2:
                            sellectProductNum = 1;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F3:
                            sellectProductNum = 2;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;

                        case ConsoleKey.F4:
                            sellectProductNum = 3;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F5:
                            sellectProductNum = 4;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F6:
                            sellectProductNum = 5;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F7:
                            sellectProductNum = 6;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F8:
                            sellectProductNum = 7;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F9:
                            sellectProductNum = 8;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        case ConsoleKey.F10:
                            sellectProductNum = 9;
                            if (itemTable[sellectProductNum] == null)
                            {
                                Console.WriteLine("없는 상품 입니다.");
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            return;
                        default:
                            Console.WriteLine("잘못된 입력입니다.");
                            return;
                    }

                }
            }
        }

        public static void ShowProductInfo(int sellectNum, Player player, List<ItemData> productList)
        {

            if (sellectNum <= productList.Count)
            {
                Console.WriteLine("===========[ Item Info ]==============");
                Console.WriteLine("||[{0}]   type:{1}  ||", productList[sellectNum].name, productList[sellectNum].type);
                Console.WriteLine("||property :{0}  ||", productList[sellectNum].property);
                Console.WriteLine("|| desc : {0}  ||", productList[sellectNum].desc); ;
                Console.WriteLine("|| price : {0}  ||", productList[sellectNum].price); ;
                Console.WriteLine("==============================");

                Console.WriteLine("==============================");
                Console.WriteLine("== [Buy : enter || close  : Esc ] ==");
                Console.WriteLine("==============================");

                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        ShowProductList(productList, player);
                        break;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    {
                        // 구매 진행
                        if (player.GetGold() >= productList[sellectNum].price)
                        {
                            player.SetGold(-productList[sellectNum].price);
                            player.SetIventory(productList[sellectNum]);
                            Console.WriteLine("{0} 구매에 성공하였습니다.", productList[sellectNum].name);
                            ShowProductList(productList,player);
                            break;
                        }
                        else
                        {//골드 부족
                            Console.WriteLine("골드가 부족하여 구매할수없습니다.");
                            ShowShop(player);
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
