﻿using System;

namespace StreamDeckSharp.NetCore.Exceptions
{
    /// <summary>
    /// Base class for all StreamDeckSharp Exceptions
    /// </summary>
    [Serializable]
    public abstract class StreamDeckException : Exception
    {
        internal StreamDeckException(string Message)
            : base(Message)
        {
        }
    }
}
