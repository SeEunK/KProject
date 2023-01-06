using System;

namespace Kproject_Text_RPG
{
    internal class Program
    {
        
            
        public static void Main(string[] args)
        {


            // int left = 9; // x 좌표
            // int top = 5;  // y 좌표
            //Console.SetCursorPosition(left, top);
           
            const int UI_SIZE_X = 33;
            const int UI_SIZE_Y = 50;

            int[,] ui_screen = new int[UI_SIZE_Y, UI_SIZE_X];
            


            Lobby lobby = new Lobby();
            lobby.UISet(UI_SIZE_Y, UI_SIZE_X, ui_screen);
            lobby.DrawUI(UI_SIZE_Y, UI_SIZE_X, ui_screen);

            TableManager tableManager = new TableManager();

            bool isLevelUp = false;
            isLevelUp = tableManager.LevelUpCheck(1, 5, 10);
            Console.WriteLine("==================================================================================");
            Console.WriteLine("현재 레벨 1, 보유 경험치 5, 획득 경험치 10인 경우 레벨업인가요? {0} ", isLevelUp);
            Console.WriteLine("==================================================================================");

            isLevelUp = tableManager.LevelUpCheck(1, 15, 190);
            Console.WriteLine("==================================================================================");
            Console.WriteLine("현재 레벨 1, 보유 경험치 15, 획득 경험치 200인 경우 레벨업인가요? {0} ", isLevelUp);
            Console.WriteLine("==================================================================================");

        
        }
        


      




        public void SlimeDote()
        {
            //Slime Test 도트..?
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■");
            Console.WriteLine(); // 1

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■");
            Console.WriteLine(); // 2

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.WriteLine(); // 3

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.WriteLine(); // 4

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□");

            Console.WriteLine(); // 5

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 6

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 7

            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 8


            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("■■■■■■");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("■■");
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□");
            Console.WriteLine(); // 9


            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("□□□□□□□□□□□");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■");
            Console.WriteLine(); // 10

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("■■■■■■■■■■■■■");
            Console.WriteLine(); // 10
        }
    }
}