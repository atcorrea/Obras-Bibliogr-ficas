using System.Linq;
using System.Threading;

namespace GuideTest.Extensions
{
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
}
