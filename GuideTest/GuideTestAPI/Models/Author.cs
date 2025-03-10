﻿using GuideTest.Extensions;
using System.Linq;
using System.Text;

namespace GuideTest.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string NameString { get; set; }

        public string AuthorName { get; set; }

        public static string FormatName(string nameString, int lnCount)
        {
            if (string.IsNullOrEmpty(nameString))
                return string.Empty;

            var sb = new StringBuilder();

            var names = nameString.Trim().ToLower()
                            .Split(" ")
                            .Select(x => x.IsInside(new string[] { "da", "de", "do", "das", "dos" }) ? x : x.ToTitleCase())
                            .ToList();

            var lastName = names.Last();
            if (names.Count > 2)
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
