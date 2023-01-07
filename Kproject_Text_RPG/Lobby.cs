using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Kproject_Text_RPG
{
    internal class Lobby
    {

        
       





        public void BottomButtonInput()
        {
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
                        break;
                    default:
                        return;
                }

            }
        }
    }
}
