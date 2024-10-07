# JoyCastle
## 三消校招⾯试题
### 1 休闲游戏排⾏榜
#### 你需要实现⼀个函数来处理排⾏榜数据。这个函数应该能从所有玩家的分数中筛选出前m名⾼分玩家的分数。
##### &emsp;&emsp; 只需要筛选出前m名⾼分玩家的分数，不需要对列表完全排序，因此选取快速排序。
##### &emsp;&emsp; 时间复杂度: O(N)
#### 进阶思考 如果我们的游戏变得⾮常受欢迎，玩家数量达到了数百万，你会如何优化这个算法以处理⼤规模数据？
##### &emsp;&emsp;维护一个最小堆，有新玩家可能进入前100名时，比较它和堆顶元素，如果高于堆顶元素，则移除堆顶元素，将新玩家加入堆中，如果不高于堆顶元素，则不需要更新排行榜。
##### 代码
```markdown
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
```
### 2 魔法能量场
#### 作为游戏开发团队的⼀员，你需要设计⼀个算法来帮助玩家找出最佳的能量塔建造位置。两座能量塔之间会形成⼀个梯形能量场，能量场的强度取决于两座塔的⾼度和它们之间的距离。
##### &emsp;&emsp; 按距离计算最大面积，比较它与当前最大面积，如果高于则替换，否则继续。
##### &emsp;&emsp; 空间复杂度：O(1), 时间复杂度: O(N^2)
#### 进阶思考1 如果我们允许玩家使⽤魔法道具来临时增加某个位置的塔的⾼度，你会如何修改你的算法？
##### &emsp;&emsp; 创建一个计算某位置与其他位置的面积的函数，当临时提高某个位置高度时，计算该位置与其他位置最大值。
#### 进阶思考2 在游戏的⾼级模式中，某些位置可能有建筑限制（⾼度为0）。你的算法如何处理这种情况？
##### &emsp;&emsp; 不需要特殊处理。
#### 创意思考 这个能量场机制如何影响玩家在游戏中的策略选择？你能想到如何将这个概念扩展到⼀个有趣的游戏玩法中吗？
##### &emsp;&emsp; 玩家建造能量塔时会倾向于覆盖更大的面积。例如，在一个有地形限制和作物适配度的背景下，玩家建造一个矩形面积的种植园时，需要考虑到种植园边界和作物适配度，乘积得到种植园效率，玩家需要根据场景选择合适的作物和合适的位置，以寻得最高的种植园效率。
#### 代码
```markdown
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
```
### 3 魔法宝箱探险
#### 你需要设计⼀个算法来帮助玩家在游戏中做出最优选择。然⽽，这些宝箱被施加了⼀个奇特的魔法诅咒：如果打开了相邻的两个宝箱，就会触发陷阱，导致玩家损失所有已收集的宝物！
##### &emsp;&emsp; 参考滚动数组思想，计算截止到第i个数的最大值时，其值只可能来自与截止到第i-2个数的最大值加第i个数以及截止到第i-1个数的最大值。
##### &emsp;&emsp; 空间复杂度：O(1)，时间复杂度: O(N)
#### 进阶挑战2 在游戏的⾼级关卡中，有些宝箱可能包含负值（表⽰陷阱会扣除玩家的分数）。你的算法如何处理这种情况？
##### 不需要特殊处理。
#### 代码
```markdown
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
```

### 4 魔法天赋评估系统
#### 作为游戏开发团队的⼀员，你需要设计⼀个算法来处理魔法天赋评估的结果。系统会提供两组已排序的能⼒值数据，你的任务是找出这两组数据合并后的中位数，作为学徒的综合天赋指数。
##### &emsp;&emsp; 维护一个总计数值，和两个元素计数值，遍历两有序数组，依次比较其元素大小，当总计数值到达中位时，根据两个元素计数值计回中位数。
##### &emsp;&emsp; 空间复杂度：O(1)，时间复杂度: O(N)
#### 进阶挑战1 如果我们需要实时更新⼤量学徒的天赋指数，你会如何优化你的算法或数据结构？
##### &emsp;&emsp; 如果天赋指数范围不大的话，为每个玩家建立一个哈希表，元素为天赋值出现次数，再维护一个中位数索引。动态更新时，更新哈希表和中位数索引，计算得出中位数。
#### 进阶挑战2 在游戏的⾼级模式中，可能会有更多的魔法属性（不仅仅是⽕和冰）。你的算法如何扩展到处理k个有序数组的中位数？
##### &emsp;&emsp;有几个元素就维护几个元素计数值，比较时候，需要对比所有元素当前元素计数值处对应的能力值大小，更新元素计数值。
#### 创意思考 这个天赋评估系统如何影响游戏的⻆⾊发展和技能学习机制？你能想到如何将这个概念融⼊到游戏的其他⽅⾯，⽐如任务系统或PVP对战中吗？
##### &emsp;&emsp; 玩家提升元素天赋能力值时，会以提高中位数为目标，避免过度依赖某一天赋，在构筑技能时，会专注于不同的天赋组合来形成独特的游戏风格。总体而言鼓励玩家发展多方面的魔法能力，增加游戏多样性与趣味性。游戏中会有不同元素间的协同效应，比如五行相生相克关系，元素间融合等等系统。
#### 代码
```markdown
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
```
