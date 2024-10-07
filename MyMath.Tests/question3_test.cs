using System;
using Xunit;
using MyMath.Question3;
using System.Xml.Schema;

namespace MyMath.Tests.Question3
{
    public class TreasureHuntSystemTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test3(int[] treasures, int excepted)
        {
            var result = TreasureHuntSystem.MaxTreasureValue(treasures);
            
            Assert.True(result==excepted, $"{treasures} Should be {string.Join(", ", excepted)}, but {string.Join(", ", result)}");
        }

        // 方法来生成测试数据
        public static IEnumerable<object[]> GetTestData()
        {
            // 根据不同条件生成测试数据
            yield return new object[] { new int[] {3, 1, 5, 2, 4}, 12};
        }
    }

}
