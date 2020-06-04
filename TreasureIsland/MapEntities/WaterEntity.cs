using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class WaterEntity : MapEntity
    {
        public WaterEntity()
        {
            parser = new ParseWater();
            printer = new PrintWater();
        }

        public static List<Point> GetWaterPoints(List<Point> pathCoordinates)
        {
            List<Point> waterPoints = new List<Point>();
            for (int i = 0; i < pathCoordinates.Count - 1; i++)
            {
                int x1 = pathCoordinates[i].X;
                int y1 = pathCoordinates[i].Y;

                int x2 = pathCoordinates[i + 1].X;
                int y2 = pathCoordinates[i + 1].Y;

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
                                waterPoints.Add(new Point(j, k));
                            }
                        }
                    }
                }
            }
            return waterPoints;
        }
    }
}
