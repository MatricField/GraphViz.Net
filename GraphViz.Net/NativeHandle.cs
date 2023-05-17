using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphViz.Net
{
    public abstract class NativeHandle<T> :
        IDisposable
    {
        internal abstract T Handle { get; }

        protected abstract void FreeNativeResources();

        private bool _DisposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_DisposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }
                FreeNativeResources();
                _DisposedValue = true;
            }
        }

        ~NativeHandle()
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
    }
}
