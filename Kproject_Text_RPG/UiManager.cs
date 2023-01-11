using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kproject_Text_RPG
{
    public  class UiManager
    {
        public void UISet(int UI_SIZE_Y, int UI_SIZE_X, int[,] ui_screen)
        {
            for (int y = 0; y < UI_SIZE_Y; y++)
            {
                for (int x = 0; x < UI_SIZE_X; x++)
                {
                    if (y == 0 || x == 0 || y == UI_SIZE_Y - 1 || x == UI_SIZE_X - 1)
                    {
                        if (y == 0 && x == 0 || y == UI_SIZE_Y - 1 && x == 0 || y == 0 && x == UI_SIZE_X - 1 || y == UI_SIZE_Y - 1 && x == UI_SIZE_X - 1)
                        {
                            ui_screen[y, x] = -3; // 코너로 세팅
                        }
                        else if (y == 0 || y == UI_SIZE_Y - 1)
                        {
                            ui_screen[y, x] = -2; // 벽으로 세팅
                        }
                        else
                        {
                            ui_screen[y, x] = -1; // 벽으로 세팅
                        }
                    }
                    else
                    {
                        ui_screen[y, x] = 0; // 빈공간
                    }
                }
            }
        }
        public  void DrawUI(int UI_SIZE_Y, int UI_SIZE_X, int[,] ui_screen)
        {


            for (int y = 0; y < UI_SIZE_Y; y++)
            {
                for (int x = 0; x < UI_SIZE_X; x++)
                {
                    switch (ui_screen[y, x])
                    {
                        case -3:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write("  ".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        case -2:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ".PadRight(2, ' '));
                            Console.ResetColor();
                            break;
                        case -1:
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.Write(" ".PadRight(2, ' '));
                            Console.ResetColor();
                            break;

                        default:
                            Console.Write("  ");
                            break;

                    }//swith

                }
                Console.WriteLine();
            }
            Console.WriteLine();

        Console.SetCursorPosition(0, 0);
        }
    }
}
