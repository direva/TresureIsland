using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class ParseBase : LineParser 
    {
        public List<Point> Parse(string line)
        {
            try
            {
                List<Point> coordinates = new List<Point>();
                string coordStr = line.Split('(')[1].TrimEnd(')');
                string startCoord = coordStr.Split(':')[0];
                string endCoord = coordStr.Split(':')[1];

                int startX = Convert.ToInt32(startCoord.Split(',')[0]);
                int startY = Convert.ToInt32(startCoord.Split(',')[1]);
                int endX = Convert.ToInt32(endCoord.Split(',')[0]);
                int endY = Convert.ToInt32(endCoord.Split(',')[1]);

                coordinates.Add(new Point(startX, startY));
                coordinates.Add(new Point(endX, endY));
                return coordinates;
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Coordinates are in invalid format, check your map!");
                Console.ReadLine();
                Environment.Exit(-1);
                return null;
            }
        }
    }
}
