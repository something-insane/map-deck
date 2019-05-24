﻿using System;

namespace StreamDeckSharp.NetCore.Exceptions
{
    /// <summary>
    /// Is thrown if no device could be found
    /// </summary>
    [Serializable]
    public class StreamDeckNotFoundException : StreamDeckException
    {
        internal StreamDeckNotFoundException()
            : base("Stream Deck not found.")
        {
        }
    }
}
