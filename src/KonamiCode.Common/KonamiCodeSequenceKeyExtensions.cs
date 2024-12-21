// - ---------- ------------- ---------------------------- ----- -----------------
// <copyright file="KonamiCodeSequenceKeyExtensions.cs" company="Isis & Milann">
//  Copyright (c) Isis & Milann
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>
// <author>Vincent Menant (the_webartist)</author>
//
// Made with love in Naoned (Breizh)
// https://the-webartist.com
// - ---------- ------------- ---------------------------- ----- -----------------

namespace KonamiCode.Common
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Extension methods for the <see cref="KonamiCodeSequenceKey"/> enumeration.
    /// </summary>
    public static class KonamiCodeSequenceKeyExtensions
    {
        public static string MapAsString(this IEnumerable<KonamiCodeSequenceKey> codeSequence)
        {
            StringBuilder builder = new StringBuilder();
            foreach (KonamiCodeSequenceKey direction in codeSequence)
            {
                switch (direction)
                {
                    case KonamiCodeSequenceKey.Up:
                        builder.Append("↑");
                        break;

                    case KonamiCodeSequenceKey.Down:
                        builder.Append("↓");
                        break;

                    case KonamiCodeSequenceKey.Left:
                        builder.Append("←");
                        break;

                    case KonamiCodeSequenceKey.Right:
                        builder.Append("→");
                        break;

                    case KonamiCodeSequenceKey.B:
                        builder.Append("B");
                        break;

                    case KonamiCodeSequenceKey.A:
                        builder.Append("A");
                        break;
                }
            }
            return builder.ToString();
        }
    }
}