using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class BaseEntity : MapEntity
    {
        public BaseEntity()
        {
            parser = new ParseBase();
            printer = new PrintBase();
        }

        public static List<Point> GetExits(List<Point> coordinates)
        {
            List<Point> exits = new List<Point>();

            int x1 = coordinates[0].X;
            int y1 = coordinates[0].Y;

            int x2 = coordinates[1].X;
            int y2 = coordinates[1].Y;

            Point exit1 = new Point((x1 + x2) / 2, y1);
            Point exit2 = new Point(x2, (y1 + y2) / 2);
            Point exit3 = new Point((x1 + x2) / 2, y2);
            Point exit4 = new Point(x1, (y1 + y2) / 2);
            exits.Add(exit1);
            exits.Add(exit2);
            exits.Add(exit3);
            exits.Add(exit4);

            return exits;
        }

        public static List<Point> GetBasePoints(List<Point> coordinates)
        {
            List<Point> points = new List<Point>();

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
                    points.Add(new Point(i, j));
                }
            }

            return points;
        }
    }
}
