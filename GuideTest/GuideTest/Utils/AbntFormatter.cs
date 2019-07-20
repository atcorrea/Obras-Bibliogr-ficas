using GuideTest.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuideTest.Utils
{
    public static class AbntFormatter
    {
        public static string FormatName(string nameString, int lnCount)
        {
            if (string.IsNullOrEmpty(nameString))
                return string.Empty;

            var sb = new StringBuilder();

            var names = nameString.ToLower()
                            .Split(" ")
                            .Select(x => x.IsInside(new string[] { "da", "de", "do", "das", "dos" }) ? x : x.ToTitleCase())
                            .ToList();

            var lastName = names.Last();
            if (lnCount > 2)
            {
                if (lastName.IsInside(new string[] { "Filho", "Filha", "Neto", "Neta", "Sobrinho", "Sobrinha", "Junior" }))
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
}
