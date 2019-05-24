﻿using OpenMacroBoard.NetCore.SDK;

namespace StreamDeckSharp.NetCore
{
    /// <summary>
    /// A compact collection of hardware specific information about a device.
    /// </summary>
    public interface IHardware
    {
        /// <summary>
        /// Key layout information
        /// </summary>
        GridKeyPositionCollection Keys { get; }
    }
}
