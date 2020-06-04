using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class ParseWater : LineParser
    {
        public List<Point> Parse(string line)
        {
            try
            {
                List<Point> coordinates = new List<Point>();
                string coordStr = line.Split('(')[1].TrimEnd(')');

                string[] xyStr = coordStr.Split("->");
                foreach (var xy in xyStr)
                {
                    int x = Convert.ToInt32(xy.Split(',')[0]);
                    int y = Convert.ToInt32(xy.Split(',')[1]);
                    coordinates.Add(new Point(x, y));
                }

                return coordinates;
            }
            catch(System.FormatException e)
            {
                Console.WriteLine("Coordinates are in invalid format, check your map!");
                Console.ReadLine();
                Environment.Exit(-1);
                return null;
            }
        }
    }
}
