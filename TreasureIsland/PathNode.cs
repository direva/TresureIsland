using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace TreasureIsland
{
    public class PathNode
    {
        // Координаты точки на карте.
        public Point Position { get; set; }
        // Длина пути от старта.
        public int PathLengthFromStart { get; set; }
        // Точка, из которой пришли в текущую точку.
        public PathNode CameFrom { get; set; }
        // Примерное расстояние до цели.
        public int HeuristicEstimatePathLength { get; set; }
        // Ожидаемое полное расстояние до цели.
        public int EstimateFullPathLength
        {
            get
            {
                return this.PathLengthFromStart + this.HeuristicEstimatePathLength;
            }
        }
    }
}
