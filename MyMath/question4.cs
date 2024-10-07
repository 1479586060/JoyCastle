using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace MyMath.Question4
{   
    public class TalentAssessmentSystem
    {
        public static double FindMedianTalentIndex(int[] fireAbility, int[] iceAbility)
        {
            int size_fire = fireAbility.Length;
            int size_ice = iceAbility.Length;
            int flag = (size_fire + size_ice) / 2; 
            // 传入空数组
            if(size_fire==0 & size_ice==0)
            {
                return 0;
            }
            
            //火焰天赋为空
            if(size_fire==0)
            {
                if(size_ice%2==0)
                {
                    return Convert.ToDouble((iceAbility[size_ice/2-1] + iceAbility[size_ice/2]))/2;
                }
                else
                {
                    return iceAbility[size_ice/2];
                }
            }
            
            //冰霜天赋为空
            if(size_ice==0)
            {
                if(size_fire%2==0)
                {
                    return Convert.ToDouble((fireAbility[size_fire/2-1] + fireAbility[size_fire/2]))/2;
                }
                else
                {
                    return fireAbility[size_fire/2];
                }
            }
            
            //正常情况下，如果两天赋元素个数为偶数，则中位数取中间两数之和除2，否则取中间值
            if((size_fire+size_ice)%2==0)
            {
                double middle = 0;
                int index_fire = 0;
                int index_ice = 0;
                for(int i=0;i<=flag;i++)
                {
                    if(fireAbility[index_fire] > iceAbility[index_ice])
                    {
                        index_ice++;
                        if(i>=flag-1)
                        {
                            middle += iceAbility[index_ice-1];
                        }
                    }
                    else
                    {
                        index_fire++;
                        if(i>=flag-1)
                        {
                            middle += fireAbility[index_fire-1];
                        }
                    }
                }
                return middle/2;
            }
            else{
                double middle = 0;
                int index_fire = 0;
                int index_ice = 0;
                for(int i=0;i<=flag;i++)
                {
                    if(fireAbility[index_fire] > iceAbility[index_ice])
                    {
                        index_ice++;
                        if(i==flag)
                        {
                            middle += iceAbility[index_ice-1];
                        }
                    }
                    else
                    {
                        index_fire++;
                        if(i==flag)
                        {
                            middle += fireAbility[index_fire-1];
                        }
                    }
                }
                return middle;
            }
        }
    }
}