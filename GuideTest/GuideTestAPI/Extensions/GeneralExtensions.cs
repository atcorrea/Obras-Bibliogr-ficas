using System.Collections.Generic;

namespace GuideTest.Extensions
{
    public static class GeneralExtensions
    {
        public static bool IsInside<T>(this T str, IList<T> list)
        {
            return list.Contains(str);
        }
    }
}
