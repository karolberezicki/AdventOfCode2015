using day05;
using day06;
using day08;
using day10;
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

        [Fact]
        public void Day06ParseCommandTest()
        {
            string stringCommand = "toggle 14,9 through 29,16";
            Command command = Program_06.ParseCommand(stringCommand);

            Assert.Equal(command.Instruction, Instruction.Toggle);
            Assert.Equal(command.FromX, 14);
            Assert.Equal(command.FromY, 9);
            Assert.Equal(command.ToX, 29);
            Assert.Equal(command.ToY, 16);
        }

        [Fact]
        public void Day06PartOne()
        {
            bool[,] lightsArray = new bool[10, 10];
            string stringCommand = "turn on 0,0 through 2,2";
            Command command = Program_06.ParseCommand(stringCommand);
            Program_06.ExecuteCommand(command, ref lightsArray);

            Assert.Equal(lightsArray[0, 0], true);
            Assert.Equal(lightsArray[0, 1], true);
            Assert.Equal(lightsArray[0, 3], false);
            Assert.Equal(lightsArray[1, 0], true);
            Assert.Equal(lightsArray[1, 1], true);
            Assert.Equal(lightsArray[2, 2], true);
            Assert.Equal(lightsArray[3, 0], false);
            Assert.Equal(lightsArray[0, 3], false);
            Assert.Equal(lightsArray[2, 3], false);
            Assert.Equal(lightsArray[3, 2], false);

        }

        [Theory]
        [InlineData(2, @"""""")]
        [InlineData(2, @"""abc""")]
        [InlineData(3, @"""aaa\""aaa""")]
        [InlineData(5, @"""\x27""")]
        [InlineData(8, @"""\x27\x27""")]
        [InlineData(11, @"""\x27\x27\x27""")]
        [InlineData(8, @"""csgexlb\""zqdavlxxhtdbh\""\""\x0fkpvhiphm""")]
        [InlineData(13, @"""bvm\x28aa\\\\\""pywuhaniox\\z\\hbp\xd7mold""")]
        public void Day08PartOne(int count, string value)
        {
            Assert.Equal(count, Program_08.CountNonValueCharacters(value));
        }

        [Theory]
        [InlineData(4, @"""""")]
        [InlineData(4, @"""abc""")]
        [InlineData(6, @"""aaa\""aaa""")]
        [InlineData(5, @"""\x27""")]
        [InlineData(6, @"""\x27\x27""")]
        [InlineData(7, @"""\x27\x27\x27""")]
        [InlineData(11, @"""csgexlb\""zqdavlxxhtdbh\""\""\x0fkpvhiphm""")]
        [InlineData(16, @"""bvm\x28aa\\\\\""pywuhaniox\\z\\hbp\xd7mold""")]
        public void Day08PartTwo(int count, string value)
        {
            Assert.Equal(count, Program_08.EncodedStringLiteralLength(value));
        }

        [Theory]
        [InlineData("1", "11")]
        [InlineData("11", "21")]
        [InlineData("21", "1211")]
        [InlineData("1211", "111221")]
        [InlineData("111221", "312211")]
        [InlineData("312211", "13112221")]
        public void Day10_LookAndSayTest(string input, string output)
        {
            Assert.Equal(output, Program_10.LookAndSay(input));
        }


    }
}