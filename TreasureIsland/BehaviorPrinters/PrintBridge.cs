using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class PrintBridge : Printer
    {
        public void Print(List<Point> coordinates)
        {
            foreach (var point in coordinates)
            {
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write('#');
            }
        }
    }
}
