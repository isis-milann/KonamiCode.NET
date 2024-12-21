// - ---------- ------------- ---------------------------- ----- -----------------
// <copyright file="KonamiCodeMapper.cs" company="Isis & Milann">
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
    using System.Collections.Generic;
    using System.Linq;
    using Windows.System;

    /// <summary>
    /// Konami code mapper for UWP.
    /// </summary>
    public static class KonamiCodeMapper
    {
        #region Public methods

        public static IEnumerable<KonamiCodeSequenceKey> Map(IEnumerable<VirtualKey> codeSequence)
            => codeSequence.Select(MapSequenceKey);

        public static KonamiCodeSequenceKey MapSequenceKey(VirtualKey virtualKey)
        {
            switch (virtualKey)
            {
                case VirtualKey.Up:
                case VirtualKey.GamepadDPadUp:
                    return KonamiCodeSequenceKey.Up;

                case VirtualKey.Down:
                case VirtualKey.GamepadDPadDown:
                    return KonamiCodeSequenceKey.Down;

                case VirtualKey.Left:
                case VirtualKey.GamepadDPadLeft:
                    return KonamiCodeSequenceKey.Left;

                case VirtualKey.Right:
                case VirtualKey.GamepadDPadRight:
                    return KonamiCodeSequenceKey.Right;

                case VirtualKey.B:
                case VirtualKey.GamepadB:
                    return KonamiCodeSequenceKey.B;

                case VirtualKey.A:
                case VirtualKey.GamepadA:
                    return KonamiCodeSequenceKey.A;

                default:
                    return KonamiCodeSequenceKey.None;
            }
        }

        #endregion Public methods
    }
}