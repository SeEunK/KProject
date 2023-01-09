using System;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("==============[Product List]=============");

            for (int i = 0; i < itemTable.Count; i++)
            {
                Console.WriteLine("[F{2} : {0}  price :{1}]", itemTable[i].name, itemTable[i].price, i+1);

            }
            Console.WriteLine("======================================");


            Console.WriteLine("============================================================================");
            Console.WriteLine("== [ select : product number F1 ~ F{0}  /  close  : Esc ] ==", itemTable.Count);
            Console.WriteLine("============================================================================");
            Console.WriteLine("===[gold : {0} ]===============================",player.GetGold());
            Console.WriteLine("============================================================================");
            while (true)
            {
                ConsoleKeyInfo inputKey = Console.ReadKey();
                if (inputKey.Key == ConsoleKey.Escape)
                {
                    Lobby.BottomButtonInput(player);
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
                                ShowProductInfo(sellectProductNum,  player, itemTable);
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
                        ShowShop(player);
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
                            ShowShop(player);
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
