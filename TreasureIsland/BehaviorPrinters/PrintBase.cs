using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class PrintBase : Printer
    {
        public void Print(List<Point> coordinates)
        {
            int x1 = coordinates[0].X;
            int y1 = coordinates[0].Y;

            int x2 = coordinates[1].X;
            int y2 = coordinates[1].Y;

            int minX = x1 < x2 ? x1 : x2;
            int minY = y1 < y2 ? y1 : y2;
            int maxX = x1 > x2 ? x1 : x2;
            int maxY = y1 > y2 ? y1 : y2;

            for (int i = minX; i <= maxX; i++)
            {
                for (int j = minY; j <= maxY; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write('@');
                }
            }
        }
    }
}
