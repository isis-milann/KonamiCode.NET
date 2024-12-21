// - ---------- ------------- ---------------------------- ----- -----------------
// <copyright file="KonamiCodeDetector.cs" company="Isis & Milann">
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
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Module that detects the Konami code sequence.
    /// </summary>
    public sealed class KonamiCodeDetector
    {
        #region Singleton

        public static readonly KonamiCodeDetector Instance = new KonamiCodeDetector();

        #endregion Singleton

        #region Constants and fields

        /// <summary>
        /// ⬆️⬆️⬇️⬇️⬅️➡️⬅️➡️BA
        /// What a legendary code.
        /// </summary>
        public static readonly KonamiCodeSequenceKey[] KonamiCode = new KonamiCodeSequenceKey[10]
        {
            KonamiCodeSequenceKey.Up,
            KonamiCodeSequenceKey.Up,
            KonamiCodeSequenceKey.Down,
            KonamiCodeSequenceKey.Down,
            KonamiCodeSequenceKey.Left,
            KonamiCodeSequenceKey.Right,
            KonamiCodeSequenceKey.Left,
            KonamiCodeSequenceKey.Right,
            KonamiCodeSequenceKey.B,
            KonamiCodeSequenceKey.A
        };

        #endregion Constants and fields

        #region Events

        public event EventHandler<KonamiCodeDetectedEventArgs> KonamiCodeDetected;

        #endregion Events

        #region Public methods

        public static MatchSequenceResult TryKonamiCodeSequence(IEnumerable<KonamiCodeSequenceKey> sequence)
        {
            var matchResult = KonamiCode.IsSequenceValid(sequence);
            if (matchResult == MatchSequenceResult.FullyMatch)
            {
                KonamiCodeDetector.Instance.OnKonamiCodeDetected(new KonamiCodeDetectedEventArgs());
            }
            return matchResult;
        }

        #endregion Public methods

        #region Private methods

        public void OnKonamiCodeDetected(KonamiCodeDetectedEventArgs e)
        {
            KonamiCodeDetected?.Invoke(this, e);
        }

        #endregion Private methods
    }
}