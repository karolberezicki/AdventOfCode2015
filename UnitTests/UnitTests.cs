using day05;
using Xunit;

namespace UnitTests
{
    public class UnitTests
    {
        [Fact]
        public void Day05PartOne()
        {
            Assert.True(Program_05.IsNiceString("ugknbfddgicrmopn"));
            Assert.True(Program_05.IsNiceString("aaa"));
            Assert.False(Program_05.IsNiceString("jchzalrnumimnmhp"));
            Assert.False(Program_05.IsNiceString("haegwjzuvuyypxyu"));
            Assert.False(Program_05.IsNiceString("dvszwmarrgswjxmb"));
        }

        [Fact]
        public void Day05PartTwo()
        {
            Assert.True(Program_05.IsRealyNiceString("qjhvhtzxzqqjkmpb"));
            Assert.True(Program_05.IsRealyNiceString("xxyxx"));
            Assert.False(Program_05.IsRealyNiceString("uurcxstgmygtbstg"));
            Assert.False(Program_05.IsRealyNiceString("ieodomkazucvgmuy"));
        }
    }
}