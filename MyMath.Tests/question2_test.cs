using System;
using Xunit;
using MyMath.Question2;
using System.Xml.Schema;

namespace MyMath.Tests.Question2
{
    public class EnergyFieldSystemTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test2(int[] heights, float excepted)
        {
            var result = EnergyFieldSystem.MaxEnergyField(heights);
            
            Assert.True(result==excepted, $"{heights} Should be {string.Join(", ", excepted)}, but {string.Join(", ", result)}");
        }

        // 方法来生成测试数据
        public static IEnumerable<object[]> GetTestData()
        {
            // 根据不同条件生成测试数据
            yield return new object[] { new int[] {10,1,8,6,2,5,4,8,3,7}, 76.5f};
        }
    }

}
