using System;

namespace OpenMacroBoard.NetCore.SDK
{
    /// <summary>
    /// KeyBitmap factory extensions based on System.Windows (WPF)
    /// </summary>
    public static class KeyBitmapFactoryExtensions
    {
        /// <summary>
        /// Convert 32bit color (4 channel) to 24bit bgr
        /// </summary>
        internal static byte[] ConvertPbgra32ToBgr24(byte[] pbgra32, int width, int height)
        {
            var data = new byte[width * height * 3];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    var pos = y * width + x;
                    var posSrc = pos * 4;
                    var posTar = pos * 3;

                    double alpha = pbgra32[posSrc + 3] / 255.0;

                    data[posTar + 0] = (byte)Math.Round(pbgra32[posSrc + 0] * alpha);
                    data[posTar + 1] = (byte)Math.Round(pbgra32[posSrc + 1] * alpha);
                    data[posTar + 2] = (byte)Math.Round(pbgra32[posSrc + 2] * alpha);
                }

            return data;
        }
    }
}
