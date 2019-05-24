using OpenMacroBoard.NetCore.SDK;

namespace StreamDeckSharp.NetCore
{
    /// <inheritdoc />
    public interface IStreamDeckRefHandle : IDeviceReferenceHandle
    {
        /// <inheritdoc />
        new IStreamDeckBoard Open();
    }
}
