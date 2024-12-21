// - ---------- ------------- ---------------------------- ----- -----------------
// <copyright file="ArrayExtensions.cs" company="Isis & Milann">
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
    using System.Linq;

    public static class ArrayExtensions
    {
        #region Extensions methods

        public static MatchSequenceResult IsSequenceValid<T>(this T[] originalSequence, IEnumerable<T> sequenceToCompare)
        {
            if (sequenceToCompare.Count() <= originalSequence.Length)
            {
                bool isSequenceMatch = true;
                int index = 0;

                foreach (T item in sequenceToCompare)
                {
                    isSequenceMatch = originalSequence[index].Equals(item);
                    if (!isSequenceMatch)
                    {
                        break;
                    }
                    index++;
                }
                if (isSequenceMatch)
                {
                    return originalSequence.Length == index ? MatchSequenceResult.FullyMatch : MatchSequenceResult.PartiallyMatch;
                }
            }

            return MatchSequenceResult.Unmatched;
        }

        #endregion Extensions methods
    }

    public enum MatchSequenceResult
    {
        Unmatched,
        PartiallyMatch,
        FullyMatch
    }
}