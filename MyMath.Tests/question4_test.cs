using System;
using Xunit;
using MyMath.Question4;
using System.Xml.Schema;

namespace MyMath.Tests.Question4
{
    public class TalentAssessmentSystemTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test4(int[] fireAbility, int[] iceAbility, double excepted)
        {
            var result = TalentAssessmentSystem.FindMedianTalentIndex(fireAbility, iceAbility);
            
            Assert.True(result==excepted, $"{fireAbility} Should be {string.Join(", ", excepted)}, but {string.Join(", ", result)}");
        }

        // 方法来生成测试数据
        public static IEnumerable<object[]> GetTestData()
        {
            // 根据不同条件生成测试数据
            yield return new object[] { new int[] {1,3,7,9,11}, new int[] {2,4,8,10,12,14}, 8f};
            yield return new object[] { new int[] {1,3,5,6}, new int[] {2,4,7,8}, 4.5f};
            yield return new object[] { new int[] {1,3,5,6}, new int[] {}, 4.0f};
            yield return new object[] { new int[] {}, new int[] {2,4,7,8}, 5.5f};
            yield return new object[] { new int[] {}, new int[] {}, 0};
        }
    }

}
