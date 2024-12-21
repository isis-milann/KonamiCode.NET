// - ---------- ------------- ---------------------------- ----- -----------------
// <copyright file="WindowExtensions.cs" company="Isis & Milann">
//  Copyright (c) Isis & Milann
//  Licensed under the MIT License. See LICENSE in the project root for license information.
// </copyright>
// <author>Vincent Menant (the_webartist)</author>
//
// Made with love in Naoned (Breizh)
// https://the-webartist.com
// - ---------- ------------- ---------------------------- ----- -----------------

namespace KonamiCode.Uwp
{
    using KonamiCode.Common;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using Windows.UI.Core;
    using Windows.UI.Xaml;

    /// <summary>
    /// Extension methods for the <see cref="Window"/> class to branch Konami code detection.
    /// </summary>
    public static class WindowExtensions
    {
        #region Constants and fields

        private static readonly List<KonamiCodeSequenceKey> currentKonamiCodeKeySequence = new List<KonamiCodeSequenceKey>(10);

        #endregion Constants and fields

        #region Extensions methods

        public static void AddKonamiCodeHandler(this Window window)
        {
            if (window == null || window.CoreWindow == null)
            {
                throw new ArgumentNullException(nameof(window), "Window cannot be null. Ensure that app is initialized before call Konami code detector.");
            }
            window.CoreWindow.KeyDown += OnCoreWindowKeyDown;
        }

        #endregion Extensions methods

        #region Private methods

        private static void OnCoreWindowKeyDown(CoreWindow sender, KeyEventArgs args)
        {
            var newKey = KonamiCodeMapper.MapSequenceKey(args.VirtualKey);
            currentKonamiCodeKeySequence.Add(newKey);
#if DEBUG
            Debug.WriteLine($"Konami code sequence: {currentKonamiCodeKeySequence.MapAsString()}");
#endif
            var matchResult = KonamiCodeDetector.TryKonamiCodeSequence(currentKonamiCodeKeySequence);
            if (matchResult == MatchSequenceResult.PartiallyMatch)
            {
                // TODO: maybe handle only GamepadB button that fire back event on XBOX
                args.Handled = true;
            }
            else
            {
                currentKonamiCodeKeySequence.Clear();
            }
        }

        #endregion Private methods
    }
}