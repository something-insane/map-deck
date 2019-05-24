using HidLibrary.NetCore;
using OpenMacroBoard.NetCore.SDK;

namespace StreamDeckSharp.NetCore
{
    /// <summary>
    /// Device information about Stream Deck
    /// </summary>
    public class DeviceReferenceHandle : IStreamDeckRefHandle
    {
        internal DeviceReferenceHandle(string devicePath)
        {
            DevicePath = devicePath;
        }

        /// <summary>
        /// Unique identifier for human interface device
        /// </summary>
        public string DevicePath { get; }

        /// <summary>
        /// Opens the StreamDeck handle
        /// </summary>
        /// <returns>Returns an <see cref="IMacroBoard"/> reference</returns>
        public IStreamDeckBoard Open() => StreamDeck.OpenDevice(DevicePath);

        IMacroBoard IDeviceReferenceHandle.Open() => Open();
    }
}
