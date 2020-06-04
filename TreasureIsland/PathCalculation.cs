using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TreasureIsland
{
    public class PathCalculation
    {
        //Функция расстояния от X до Y
        private static int GetDistanceBetweenNeighbours()
        {
            return 1;
        }

        //Функция примерной оценки расстояния до цели
        private static int GetHeuristicPathLength(Point from, Point to)
        {
            return Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);
        }

        //Получение списка соседей для точки
        private static Collection<PathNode> GetNeighbours(PathNode pathNode, Point goal, Point boundaries)
        {
            var result = new Collection<PathNode>();

            // Соседними точками являются соседние по стороне клетки.
            Point[] neighbourPoints = new Point[4];
            neighbourPoints[0] = new Point(pathNode.Position.X + 1, pathNode.Position.Y);
            neighbourPoints[1] = new Point(pathNode.Position.X - 1, pathNode.Position.Y);
            neighbourPoints[2] = new Point(pathNode.Position.X, pathNode.Position.Y + 1);
            neighbourPoints[3] = new Point(pathNode.Position.X, pathNode.Position.Y - 1);

            foreach (var point in neighbourPoints)
            {
                if (point.X < 0 || point.Y < 0 || point.X > boundaries.X || point.Y > boundaries.Y)
                    continue;
                // Заполняем данные для точки маршрута.
                var neighbourNode = new PathNode()
                {
                    Position = point,
                    CameFrom = pathNode,
                    PathLengthFromStart = pathNode.PathLengthFromStart +
                    GetDistanceBetweenNeighbours(),
                    HeuristicEstimatePathLength = GetHeuristicPathLength(point, goal)
                };
                result.Add(neighbourNode);
            }
            return result;
        }

        //Получение маршрута, он представлен в виде списка координат точек
        private static List<Point> GetPathForNode(PathNode pathNode)
        {
            var result = new List<Point>();
            var currentNode = pathNode;
            while (currentNode != null)
            {
                result.Add(currentNode.Position);
                currentNode = currentNode.CameFrom;
            }
            result.Reverse();
            return result;
        }

        public static List<Point> FindPath
            (List<Point> start, Point goal, List<Point> forbidden, Point boundaries)
        {
            // Шаг 1. Создаем 2 списка вершин - ожидающие рассмотрения (openSet) и уже рассмотренные (closedSet).
            var closedSet = new Collection<PathNode>();
            var openSet = new Collection<PathNode>();
            // Шаг 2. Создание листа стартовых точек.
            foreach (var node in start)
            {
                PathNode startNode = new PathNode()
                {
                    Position = node,
                    CameFrom = null,
                    PathLengthFromStart = 0,
                    HeuristicEstimatePathLength = GetHeuristicPathLength(node, goal)
                };
                //точку старта добавляем в ожидающие рассмотрения точки
                openSet.Add(startNode);
            }

            foreach (var node in forbidden)
            {
                PathNode forbiddenNode = new PathNode()
                {
                    Position = node,
                    CameFrom = null,
                    PathLengthFromStart = 0,
                    HeuristicEstimatePathLength = GetHeuristicPathLength(node, goal)
                };
                //запрещенную точку добавляем в рассмотренные точки
                closedSet.Add(forbiddenNode);
            }

            while (openSet.Count > 0)
            {
                // Шаг 3. Для каждой ожидающей точки считаем расстояние от старта до точки + расстояние от точки до цели
                // упорядочиваем точки по возрастанию и берем первую из набора
                var currentNode = openSet.OrderBy(node =>
                  node.EstimateFullPathLength).First();
                // Шаг 4. Если точка совпадает с целью - маршрут построен.
                if (currentNode.Position == goal)
                    return GetPathForNode(currentNode);
                // Шаг 5. Точка рассмотрена, удаляется из ожидающих и добавляется в рассмотренные
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);
                // Шаг 6. Цикл с рассмотрением всех соседних точек
                foreach (var neighbourNode in GetNeighbours(currentNode, goal, boundaries))
                {
                    // Шаг 7. Если соседняя точка находится в рассмотренных, пропускаем ее
                    if (closedSet.Count(node => node.Position == neighbourNode.Position) > 0)
                        continue;
                    //Берет точку из списка ожидающих, которая совпадает с соседом
                    var openNode = openSet.FirstOrDefault(node =>
                      node.Position == neighbourNode.Position);
                    // Шаг 8. Если такого соседа нет в списке, добавляет его туда
                    if (openNode == null)
                        openSet.Add(neighbourNode);
                    else
                    //если расстояние от старта до openNode + расстояние от openNode до neighbourNode < расстояния от старта до neighbourNode,
                    //значит мы пришли в neighbourNode более коротким путем, 
                    //заменяем расстояние от старта до neighbourNode на расстояние от старта до openNode + расстояние от openNode до neighbourNode
                    //точку, из которой пришли в neighbourNode на openNode.
                      if (openNode.PathLengthFromStart > neighbourNode.PathLengthFromStart)
                    {
                        openNode.CameFrom = currentNode;
                        openNode.PathLengthFromStart = neighbourNode.PathLengthFromStart;
                    }
                }
            }
            // Шаг 10. Если список точек на рассмотрение пуст, а до цели мы так и не дошли — значит маршрут не существует.
            return null;
        } 
        
        public static void PrintPath
            (List<Point> start, Point goal, List<Point> forbidden, List<Point> nonRedraw, Point boundaries)
        {
            try
            {
                List<Point> path = FindPath(start, goal, forbidden, boundaries);
                foreach (var point in path)
                {
                    Console.SetCursorPosition(point.X, point.Y);
                    if (!nonRedraw.Contains(point))
                        Console.Write('%');
                }
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Path to treasure was not found, check your map!");
                Console.ReadLine();
                Environment.Exit(-1);
            }
        }

    }
}
