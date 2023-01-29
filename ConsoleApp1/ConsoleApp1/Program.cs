using System.Collections.Generic;
using System.Linq;
using System;

namespace Recognizer
{
    public static class ThresholdFilterTask
    {
        static void Main()
        {
            var arr = new double[,] { { 123 } };
            Console.WriteLine(ThresholdFilter(arr,0));
        }
        public static double[,] ThresholdFilter(double[,] original, double whitePixelsFraction)
        {
            var lines = original.GetLength(0);
            var colums = original.GetLength(1);
            var result = new double[lines, colums];
            var minWhitePixelsCount = (int)lines * colums * whitePixelsFraction;
            var pixelsColorsList = new List<double>();
            for (int x = 0; x < lines; x++)
            {
                for (var y = 0; y < colums; y++)
                {
                    pixelsColorsList.Add(original[x, y]);
                }
            }
            pixelsColorsList.Sort();
            pixelsColorsList.Reverse();
            var maxWhitePixel = pixelsColorsList.FindIndex(x => x == minWhitePixelsCount);
            if (original[0, 0].Equals(original[lines - 1, colums - 1])) result[0, 0] = original[0, 0] >= minWhitePixelsCount ? 1.0 : 0.0;
            else
            {
                for (int x = 0; x < lines; x++)
                {
                    for (var y = 0; y < colums; y++)
                    {
                        if (original[x, y] >= maxWhitePixel) result[x, y] = 0.0;
                        else result[x, y] = 1.0;
                    }
                }
            }

            return result;
        }
    }
}