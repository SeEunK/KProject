using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kproject_Text_RPG
{
    public  class Lobby
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

        public void OpenInventory(Player player)
        {

        }
    }
}
