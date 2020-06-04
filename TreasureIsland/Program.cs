using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using TreasureIsland.BaseClassesAndInterfaces;

namespace TreasureIsland
{
	class Program
	{
		static void Main(string[] args)
		{
            #region Necessary variables
            MapEntity basement = new BaseEntity();
            MapEntity bridge = new BridgeEntity();
            MapEntity treasure = new TreasureEntity();
            MapEntity water = new WaterEntity();

            //Список точек, по которым нельзя прокладывать маршрут (река и точки базы)
            List<Point> forbidden = new List<Point>();
            //Список точек, которые нельзя перерисовывать (мост и клад)
            List<Point> notRedraw = new List<Point>();
            //Список выходов из базы
            List<Point> baseExits = new List<Point>();
            //Точки, где лежит клад
            List<Point> goals = new List<Point>();
            //Координаты всех сущностей карты
            List<Point> allCoordinates = new List<Point>();
            #endregion

            //Подготовка файла
            string filePath = Directory.GetCurrentDirectory() + "\\TestData\\Map5.txt";
            FileParser file = new FileParser(filePath);

            string[] allLines = file.PrepareFile();
            
            //Подготовка консоли
            MapSetup.SetupConsoleWindow();

            //Визуализация сущностей карты
            foreach (var line in allLines)
            {
                if (line.Split('(')[0].Equals(MapConsts.Base))
                {
                    List<Point> baseCoordinates = basement.Parse(line);
                    basement.Print(baseCoordinates);
                    baseExits = BaseEntity.GetExits(baseCoordinates);
                    foreach (var point in BaseEntity.GetBasePoints(baseCoordinates))
                    {
                        forbidden.Add(point);
                        allCoordinates.Add(point);
                    }
                    foreach (var point in baseExits)
                        notRedraw.Add(point);
                }
            }

            foreach (var line in allLines)
            {
                if (line.Split('(')[0].Equals(MapConsts.Treasure))
                {
                    List<Point> treasureCoordinates = treasure.Parse(line);
                    treasure.Print(treasureCoordinates);
                    goals.Add(new Point(treasureCoordinates[0].X, treasureCoordinates[0].Y));
                    notRedraw.Add(new Point(treasureCoordinates[0].X, treasureCoordinates[0].Y));
                    allCoordinates.Add(new Point(treasureCoordinates[0].X, treasureCoordinates[0].Y));
                }
            }

            foreach (var line in allLines)
            {
                if (line.Split('(')[0].Equals(MapConsts.Water))
                {
                    List<Point> waterCoordinates = water.Parse(line);
                    water.Print(waterCoordinates);
                    foreach (var point in WaterEntity.GetWaterPoints(waterCoordinates))
                    {
                        forbidden.Add(point);
                        allCoordinates.Add(point);
                    }
                }
            }

            foreach (var line in allLines)
            {
                if (line.Split('(')[0].Equals(MapConsts.Bridge))
                {
                    List<Point> bridgeCoordinates = bridge.Parse(line);
                    bridge.Print(bridgeCoordinates);
                    forbidden.Remove(bridgeCoordinates[0]);
                    notRedraw.Add(new Point(bridgeCoordinates[0].X, bridgeCoordinates[0].Y));
                    allCoordinates.Add(new Point(bridgeCoordinates[0].X, bridgeCoordinates[0].Y));
                }

            }

            //Поиск границ карты
            Point maxPoint = MapSetup.GetMaxMapPoint(allCoordinates);

            //Отрисовка пути
            foreach(var goal in goals)
                PathCalculation.PrintPath(baseExits, goal, forbidden, notRedraw, maxPoint);
            
            Console.ReadLine();
        }
	}
}
