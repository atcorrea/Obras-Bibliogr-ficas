using System;
using Xunit;
using System.Linq;
using FluentAssertions;
using System.Threading;
using System.Collections.Generic;
using System.Text;

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

    public static class AbntFormatter
    {
        public static string FormatName(string nameString, int lnCount)
        {
            if (string.IsNullOrEmpty(nameString))
                return string.Empty;

            if (lnCount == 1)
                return nameString.ToUpper();
      
            var sb = new StringBuilder();

            var names = nameString.ToLower()
                            .Split(" ")
                            .Select(x => x.IsInside(new string[] { "da", "de", "do", "das", "dos" }) ? x : x.ToTitleCase())
                            .ToList();

            var lastName = names.Last();
            if (lnCount > 2)
            {
                if (lastName.IsInside(new string[] { "Filho", "Filha", "Neto", "Neta", "Sobrinho", "Sobrinha", "Junior" } ))
                {
                    lastName = $"{names[names.Count - 2]} {names.Last()}";
                    names.RemoveRange(names.Count - 2, 1);
                }
            }

            sb.Append($"{lastName.ToUpper()},");
            names.RemoveRange(names.Count - 1, 1);

            names.ForEach(x => sb.Append($" {x}"));
            return sb.ToString().TrimUnusedCharactersEnd();
        }
    }

    public static class StringExtensions
    {        
        public static string ToTitleCase(this string str)
        {
            var tInfo = Thread.CurrentThread.CurrentCulture.TextInfo;
            return tInfo.ToTitleCase(str);
        }

        public static string TrimUnusedCharactersEnd(this string str)
        {
            str = str.TrimEnd();
            var last = str.Last();

            if (last == ',')
                str = str.Substring(0, str.Length - 1);

            return str;
        }
    }

    public static class GeneralExtensions
    {
        public static bool IsInside<T>(this T str, IList<T> list)
        {
            return list.Contains(str);
        }
    }
}
