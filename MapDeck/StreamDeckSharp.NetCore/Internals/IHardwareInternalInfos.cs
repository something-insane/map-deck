﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HidLibrary.NetCore;
using OpenMacroBoard.NetCore.SDK;

namespace StreamDeckSharp.NetCore.Internals
{
    internal interface IHardwareInternalInfos : IUsbHidHardware
    {
        int ReportSize { get; }
        int StartReportNumber { get; }
        byte[] GeneratePayload(KeyBitmap keyBitmap);

        /// <summary>
        /// This is used to convert between keyId conventions
        /// </summary>
        /// <param name="extKeyId"></param>
        /// <returns></returns>
        /// <remarks>
        /// The original stream deck has a pretty weird way of enumerating keys.
        /// Index 0 starts right top and they are enumerated right to left,
        /// and top to bottom. Most developers would expect it to be left-to-right
        /// instead of right-to-left, so we change that ;-)
        /// </remarks>
        int ExtKeyIdToHardwareKeyId(int extKeyId);

        /// <summary>
        /// This is used to convert between keyId conventions
        /// </summary>
        /// <param name="hardwareKeyId"></param>
        /// <returns></returns>
        int HardwareKeyIdToExtKeyId(int hardwareKeyId);
    }
}
