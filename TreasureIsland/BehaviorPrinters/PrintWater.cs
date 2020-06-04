using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class PrintWater : Printer
    {
        public void Print(List<Point> coordinates)
        {
            for (int i = 0; i < coordinates.Count - 1; i++)
            {                
                int x1 = coordinates[i].X;
                int y1 = coordinates[i].Y;

                int x2 = coordinates[i + 1].X;
                int y2 = coordinates[i + 1].Y;

                int minX = x1 < x2 ? x1 : x2;
                int minY = y1 < y2 ? y1 : y2;
                int maxX = x1 > x2 ? x1 : x2;
                int maxY = y1 > y2 ? y1 : y2;

                for (int j = minX; j <= maxX; j++)
                {
                    if ((j >= x1 && j <= x2) || (j >= x2 && j <= x1))
                    {
                        for (int k = minY; k <= maxY; k++)
                        {
                            bool isCollinear = (j - x1) * (y2 - y1) - (k - y1) * (x2 - x1) == 0 ? true : false;
                            if (isCollinear)
                            {
                                Console.SetCursorPosition(j, k);
                                Console.Write('~');
                            }
                        }
                    }
                }
            }
        }
    }
}
