using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class MapSetup
    {    
        public static void SetupConsoleWindow()
        {   
            Console.ForegroundColor = System.ConsoleColor.Red;
            Console.BackgroundColor = System.ConsoleColor.White;

            Console.Clear();
        }

        public static Point GetMaxMapPoint(List<Point> allMapCoordinates)
        {
            int maxX = allMapCoordinates[0].X;
            int maxY = allMapCoordinates[0].Y;

            for (int i = 0; i < allMapCoordinates.Count - 1; i++)
            {
                maxX = maxX > allMapCoordinates[i + 1].X ? maxX
                                                         : allMapCoordinates[i + 1].X;
                maxY = maxY > allMapCoordinates[i + 1].Y ? maxY
                                                         : allMapCoordinates[i + 1].Y;
            }
            
            Point maxPoint = new Point(maxX, maxY);
            return maxPoint;
        }
    }
}
