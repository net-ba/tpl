using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERNI.Training.TPL.Exercise02
{
    /// <summary>
    /// Rewrite to use parallel computation.
    /// </summary>
    public class TravellingSalesmanParallel : ITravellingSalesman
    {
        public IEnumerable<int> FindRoute(int[,] distances)
        {
            if (distances == null)
            {
                throw new ArgumentNullException(nameof(distances));
            }
            if (distances.Length == 0)
            {
                throw new ArgumentException();
            }
            if (distances.GetLength(0) != distances.GetLength(1))
            {
                throw new ArgumentException();
            }

            if (distances.Length == 1)
            {
                return new int[0];
            }

            return FindRouteStarting(distances, new List<int>());
        }

        private static List<int> FindRouteStarting(int[,] distances, List<int> starting)
        {
            var count = distances.GetLength(0);
            if (starting.Count == count - 1)
            {
                return AppendRoute(starting, 0);
            }

            var routes = new List<List<int>>();
            for (int city = 1; city < count; city++)
            {
                if (!starting.Contains(city))
                {
                    var route = FindRouteStarting(distances, AppendRoute(starting, city));
                    routes.Add(route);
                }
            }

            return GetShortestRoute(distances, routes);
        }

        private static List<int> AppendRoute(List<int> route, int city)
        {
            var result = new List<int>(route);
            result.Add(city);
            return result;
        }

        private static List<int> GetShortestRoute(int[,] distances, IEnumerable<List<int>> routes)
        {
            List<int> result = null;
            int distance = 0;
            foreach (var route in routes)
            {
                if (result == null)
                {
                    result = route;
                    distance = GetDistance(distances, route);
                }
                else
                {
                    var newDistance = GetDistance(distances, route);
                    if (newDistance < distance)
                    {
                        result = route;
                        distance = newDistance;
                    }
                }
            }

            return result;
        }

        private static int GetDistance(int[,] distances, List<int> cities)
        {
            var result = 0;
            var prevCity = 0;
            for (int i = 0; i < cities.Count; i++)
            {
                var city = cities[i];
                result += distances[prevCity, city];
                prevCity = city;
            }

            return result;
        }
    }
}
