using Xunit;
using FluentAssertions;
using GuideTest.Utils;

namespace GuiteTestUnitTests
{
    public class AbntFormatterTests
    {

        [Theory]
        [InlineData("andre torres", 2,"TORRES, Andre")]
        [InlineData("WARREN BUFFET", 2,"BUFFET, Warren")]
        [InlineData("Pedro de Alcântara João Carlos Leopoldo Salvador Bibiano Francisco Xavier de Paula Leocádio Miguel Gabriel Rafael Gonzaga", 15, "GONZAGA, Pedro de Alcântara João Carlos Leopoldo Salvador Bibiano Francisco Xavier de Paula Leocádio Miguel Gabriel Rafael")]
        public void GetAbntName_WhenCorrectParams_ShouldFormatCorrectly(string name, int lnCount, string expectation)
        {
            var formattedName = AbntFormatter.FormatName(name, lnCount);
            formattedName.Should().Be(expectation);
        }

        [Theory]
        [InlineData("josé carlos filho", 3, "CARLOS FILHO, José")]
        [InlineData("Maria manuela castro neta", 4, "CASTRO NETA, Maria Manuela")]
        public void GetAbntName_WhenThereIsAFamilyLevelName_ShouldFormatCorrectly(string name, int lnCount, string expectation)
        {
            var formattedName = AbntFormatter.FormatName(name, lnCount);
            formattedName.Should().Be(expectation);
        }

        [Theory]
        [InlineData("JoÃo NeTo", 2, "NETO, João")]
        public void GetAbntName_WhenThereIsAFamilyLevelNameButNoLastName_ShouldFormatCorrectly(string name, int lnCount, string expectation)
        {
            var formattedName = AbntFormatter.FormatName(name, lnCount);
            formattedName.Should().Be(expectation);
        }

        [Theory]
        [InlineData("GUIMARAES", 1, "GUIMARAES")]
        public void GetAbntName_WhenSingleNameOnly_ShouldFormatCorrectly(string name, int lnCount, string expectation)
        {
            var formattedName = AbntFormatter.FormatName(name, lnCount);
            formattedName.Should().Be(expectation);
        }

        [Fact]
        public void GetAbntName_WhenParamIsNull_ShouldReturnEmptyString()
        {
            var formattedName = AbntFormatter.FormatName(null, 0);
            formattedName.Should().Be(string.Empty);
        }
    } 
}
