﻿using System;
using HidLibrary.NetCore;

namespace StreamDeckSharp.NetCore.Internals
{
    internal static class HidDeviceExtensions
    {
        public static IHardwareInternalInfos GetHardwareInformation(this HidDevice hid)
        {
            if (hid.Attributes.VendorId != Hardware.VendorIds.ElgatoSystemsGmbH)
                throw new NotSupportedException();

            var pid = hid.Attributes.ProductId;
            switch (pid)
            {
                case Hardware.ProductIds.StreamDeck: return Hardware.Internal_StreamDeck;
                case Hardware.ProductIds.StreamDeckMini: return Hardware.Internal_StreamDeckMini;

                default:
                    throw new NotSupportedException($"ProductId {pid} is not supported.");
            }
        }
    }
}
