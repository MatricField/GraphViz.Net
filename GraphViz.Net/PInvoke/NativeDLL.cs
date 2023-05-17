using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net.PInvoke
{
    internal sealed class NativeDLL :
        IDisposable
    {
        private readonly IntPtr _handle;

        private NativeDLL(string name)
        {
            _handle = Kernel32.LoadLibrary(name);
        }

        public static NativeDLL Open(string name)
        {
            return new NativeDLL(name);
        }

        public ProcAddress GetSymbolAddress(string symbol)
        {
            return new ProcAddress(this, Kernel32.GetProcAddress(_handle, symbol));
        }

        #region IDisposable
        private bool _DisposedValue;

        private void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                if (_handle != IntPtr.Zero)
                {
                    Kernel32.FreeLibrary(_handle);
                }
                _DisposedValue = true;
            }
        }

        ~NativeDLL()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        } 
        #endregion
    }

    internal sealed class ProcAddress:
        IDisposable
    {
        private NativeDLL? _handle;
        public IntPtr Address { get; }

        public ProcAddress(NativeDLL moduleHandle, IntPtr procAddress)
        {
            _handle = moduleHandle;
            Address = procAddress;
        }

        public void Dispose()
        {
            _handle = null;
        }
    }
}
