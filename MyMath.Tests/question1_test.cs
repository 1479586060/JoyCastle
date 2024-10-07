using System;
using Xunit;
using MyMath.Question1;
using System.Xml.Schema;

namespace MyMath.Tests.Question1
{
    public class LeaderboardSystemTests
    {
        [Theory]
        [MemberData(nameof(GetTestData))]
        public void Test1(int[] scores, int m, List<int> excepted)
        {
            var result = LeaderboardSystem.GetTopScores(scores, m);
            
            Assert.True(result.SequenceEqual(excepted), $"{scores} Should be {string.Join(", ", excepted)}, but {string.Join(", ", result)}");
        }

        // 方法来生成测试数据
        public static IEnumerable<object[]> GetTestData()
        {
            // 根据不同条件生成测试数据
            yield return new object[] { new int[] {100, 90, 80, 70, 60, 65, 75, 85, 95}, 3, new List<int> {100, 95, 90} };
            yield return new object[] { new int[] {100, 50, 30, 99, 75, 80, 65}, 3, new List<int> {100, 99, 80} };
            yield return new object[] { new int[] {90, 100, 95}, 1, new List<int> {100} };
            yield return new object[] { new int[] {}, 3, new List<int> {} };
            yield return new object[] { null, 3, new List<int> {} };
        }
    }

}
