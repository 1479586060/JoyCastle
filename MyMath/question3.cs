using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyMath.Question3
{   
    public class TreasureHuntSystem
    {
        public static int MaxTreasureValue(int[] treasures)
        {
            int size = treasures.Length;
            if(size==0)
            {
                return 0;
            }
            if(size==1)
            {
                return treasures[0];
            }
            int sum_1 = treasures[0];
            int sum_2 = treasures[0] > treasures[1] ? treasures[0] : treasures[1];
            for(int i = 2; i < size; i++)
            {
                int sum_3 = (sum_1 + treasures[i]) > sum_2 ? (sum_1 + treasures[i]) : sum_2;
                sum_1 = sum_2;
                sum_2 = sum_3;
            }
            return sum_1>sum_2?sum_1:sum_2;
        }
    }
}