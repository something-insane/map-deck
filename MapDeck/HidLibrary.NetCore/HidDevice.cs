using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace HidLibrary.NetCore
{
    public class HidDevice : IHidDevice
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public event InsertedEventHandler Inserted;
        public event RemovedEventHandler Removed;
        public IntPtr Handle { get; }
        public bool IsOpen { get; }
        public bool IsConnected { get; }
        public string Description { get; }
        ////public HidDeviceCapabilities Capabilities { get; }
        ////public HidDeviceAttributes Attributes { get; }
        public string DevicePath { get; }
        public bool MonitorDeviceEvents { get; set; }
        public void OpenDevice()
        {
            throw new NotImplementedException();
        }

        public void OpenDevice(DeviceMode readMode, DeviceMode writeMode, ShareMode shareMode)
        {
            throw new NotImplementedException();
        }

        public void CloseDevice()
        {
            throw new NotImplementedException();
        }

        ////public HidDeviceData Read()
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public void Read(ReadCallback callback)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public void Read(ReadCallback callback, int timeout)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public HidDeviceData Read(int timeout)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public void ReadReport(ReadReportCallback callback)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public void ReadReport(ReadReportCallback callback, int timeout)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public HidReport ReadReport(int timeout)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public HidReport ReadReport()
        ////{
        ////    throw new NotImplementedException();
        ////}

        public bool ReadFeatureData(out byte[] data, byte reportId = 0)
        {
            throw new NotImplementedException();
        }

        public bool ReadProduct(out byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool ReadManufacturer(out byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool ReadSerialNumber(out byte[] data)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] data, WriteCallback callback)
        {
            throw new NotImplementedException();
        }

        public bool Write(byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool Write(byte[] data, int timeout)
        {
            throw new NotImplementedException();
        }

        public void Write(byte[] data, WriteCallback callback, int timeout)
        {
            throw new NotImplementedException();
        }

        ////public void WriteReport(HidReport report, WriteCallback callback)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public bool WriteReport(HidReport report)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public bool WriteReport(HidReport report, int timeout)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public void WriteReport(HidReport report, WriteCallback callback, int timeout)
        ////{
        ////    throw new NotImplementedException();
        ////}

        ////public HidReport CreateReport()
        ////{
        ////    throw new NotImplementedException();
        ////}

        public bool WriteFeatureData(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
