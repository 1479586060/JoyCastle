using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyMath.Question2
{   
    public class EnergyFieldSystem
    {
        public static float MaxEnergyField(int[] heights)
        {
            float max = 0;
            max = SortByStep(heights);
            return max/2;
        }
        private static float SortByStep(int[] heights)
        {
            float max = 0;
            for(int i=heights.Length-1; i>0; i--)
            {
                max = SortStep(heights, i, max);
            }
            return max;
        }
        private static float SortStep(int[] heights, int step, float max)
        {
            for(int i=0; i+step<heights.Length; i++)
            {
                max = max>((heights[i]+heights[i+step])*step)?max:((heights[i]+heights[i+step])*step);
            }
            return max;
        }
    }

}