﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyMath.Question1
{
    public class LeaderboardSystem
    {   
        public static List<int> GetTopScores(int[] scores, int m)
        {
            // 检查 scores 是否为 null
            if (scores == null || m <= 0 || scores.Length < m)
            {
                return new List<int>();
            }
            
            QuickSelect(scores, 0, scores.Length - 1, m);
            
            //提取前m个最大的元素
            List<int> topMScores = new List<int>();
            int k = scores.Length - m;

            for (int i = 0; i < m; i++)
            {
                topMScores.Add(scores[i]);
            }

            topMScores.Sort((a, b) => b - a);

            return topMScores;
        }
        private static void QuickSelect(int[] array, int left, int right, int k)
        {
            if(left<=right)
            {
                int pivotIndex = Partition(array, left, right);
                if(pivotIndex == k)
                {
                    return;
                }
                else if (pivotIndex < k)
                {
                    QuickSelect(array, pivotIndex + 1, right, k);
                }
                else
                {
                    QuickSelect(array, left, pivotIndex - 1, k);
                }
            }
        }
        private static int Partition(int[] array, int left, int right)
        {
            int pivot = array[right];
            int i = left - 1;
            for(int j = left; j<right; j++)
            {
                if(array[j]>pivot)
                {
                    i++;
                    Swap(array, i, j);
                }
            }
            Swap(array, i+1, right);
            return i+1;
        }
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
