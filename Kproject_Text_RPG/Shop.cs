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

            UiManager.UiInit();

            Console.SetCursorPosition(2, 1);
            Console.WriteLine(String.Format("{0}", "                                                      Shop                                                         "));
            Console.SetCursorPosition(2, 2);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));

            Program.PlayerStatUI(player);


            Console.SetCursorPosition(2, 27);
            Console.WriteLine(String.Format("{0}", "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━"));
            Console.SetCursorPosition(2, 28);
            Console.WriteLine(String.Format("{0}", "         F1 : \"buy\"            ||          F2 : \"sell\"            ||        Esc : \"Go To Lobby\"     "));




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
                    UiManager.ErrorInputKey();
                   
                }
            }

        }

        public static void ShowInventoryList( Player player)
        {
            Lobby.OpenInventory(player);
           
            while (true)
            {
                
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    ShowShop(player);
                    break;
                }
                else
                {
                    if (player.inventory.Count == 0)
                    {
                        UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
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
                                     UiManager.EmptySlotSellectMessage();
                                }
                                else
                                {
                                    ShowSellItemInfo(sellectInvenSlotNum, player);
                                }
                                return;
                            default:
                                UiManager.ErrorInputKey();
                               
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
                UiManager.InventoryDrawClear();
                UiManager.ShopItemInfoDraw(player, sellectNum);
                
                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey(true);
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        UiManager.ShopItemInfoClear();
                        ShowInventoryList(player);
                        return ;
                    }
                    else if (inputKey.Key == ConsoleKey.Enter)
                    { // 선택한 아이템 판매진행.
                       int sellectSaleItemID = player.inventory[sellectNum].GetID();
                       string sellectSaleItemName = player.inventory[sellectNum].GetItemName();
                        int sellPrice = player.inventory[sellectNum].GetSellPrice();
                        // 선택한 아이템 판매가격을 유저한테 넣어주고
                        player.inventory.RemoveAt(sellectNum); // 인벤에서 아이템 삭제.
                        player.SetGold(sellPrice);
                        // 플레이어 정보 갱신
                        Program.PlayerStatUI(player);
                        // 판매 성공 출력.
                        UiManager.ShopItemSellComplete(sellectSaleItemName, player, sellectSaleItemID, sellPrice);

                        UiManager.ShopItemInfoClear();
                        ShowInventoryList(player);
                       return;
                    }
                    else
                    {
                        UiManager.ErrorInputKey();
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
            // 상품 리스트 출력
            UiManager.ShopProdutItemListDraw(itemTable, player);
           
            //유저 인풋 받기
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey(true);
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    // 상품 출력 삭제
                    UiManager.ShopProdutItemListClear();
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
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F2:
                            sellectProductNum = 1;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {

                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F3:
                            sellectProductNum = 2;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;

                        case ConsoleKey.F4:
                            sellectProductNum = 3;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F5:
                            sellectProductNum = 4;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F6:
                            sellectProductNum = 5;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F7:
                            sellectProductNum = 6;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F8:
                            sellectProductNum = 7;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F9:
                            sellectProductNum = 8;
                            if (itemTable[sellectProductNum] == null)
                            {
                                UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        case ConsoleKey.F10:
                            sellectProductNum = 9;
                            if (itemTable[sellectProductNum] == null)
                            {
                               UiManager.ErrorSellectProductMissing();
                            }
                            else
                            {
                                ShowProductInfo(sellectProductNum, player, itemTable);
                            }
                            break;
                        default:
                            UiManager.ErrorInputKey();
                            break;
                    }

                }
            }
        }

        public static void ShowProductInfo(int sellectNum, Player player, List<ItemData> productList)
        {
            // 상품 리스트 출력 삭제
            UiManager.ShopProdutItemListClear();

            if (sellectNum <= productList.Count)
            {
                // 상품 중 선택한 아이템 정보창 출력
                UiManager.ShopProdutItemSellectInfo(productList[sellectNum].name, productList[sellectNum].type, productList[sellectNum].property, 
                                                    productList[sellectNum].desc, productList[sellectNum].price);
                while (true)
                {
                    ConsoleKeyInfo inputKey = Console.ReadKey();
                    if (inputKey.Key == ConsoleKey.Escape)
                    {
                        // 상품 상세 정보창 삭제
                        UiManager.ShopProdutItemSellectInfoClear();
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
                            // 플레이어 정보 갱신
                            Program.PlayerStatUI(player);

                            // 구매 성공 메시지 출력
                            UiManager.ShopItemBuyComplete(productList[sellectNum].name);
                          
                            // 상품 상세 정보창 삭제
                            UiManager.ShopProdutItemSellectInfoClear();
                            ShowProductList(productList,player);
                            break;
                        }
                        else
                        {//골드 부족 안내 메시지 
                            UiManager.CanNotBuyItemInsufficientCost();
                            // 상품 상세 정보창 삭제
                            UiManager.ShopProdutItemSellectInfoClear();
                            ShowShop(player);
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

    }
}
