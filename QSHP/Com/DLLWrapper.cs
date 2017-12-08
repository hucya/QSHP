using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace QSHP.Com
{
    public abstract class DLLWrapper : IDisposable
    {
        private FileVersionInfo mFileVersionInfo;
        protected IntPtr mHandle = IntPtr.Zero;
        private const string mKernel32DLL = "kernel32.dll";

        public DLLWrapper(string pathToDLL)
        {
            this.mHandle = NativeMethods.LoadLibrary(pathToDLL);
            if (this.mHandle == IntPtr.Zero)
            {
                throw new ArgumentException(string.Format("加载 {0} 文件失败!", Path.GetFileName(pathToDLL)));
            }
            try
            {
                StringBuilder filename = new StringBuilder(0x100);
                NativeMethods.GetModuleFileName(this.mHandle, filename, (uint)filename.Capacity);
                this.mFileVersionInfo = FileVersionInfo.GetVersionInfo(filename.ToString());
            }
            catch
            {
            }
        }

        public virtual void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool dispose)
        {
            if (this.mHandle != IntPtr.Zero)
            {
                NativeMethods.FreeLibrary(this.mHandle);
                this.mHandle = IntPtr.Zero;
            }
        }

        ~DLLWrapper()
        {
            this.Dispose(false);
        }

        public string FileVersion
        {
            get
            {
                if (this.mFileVersionInfo == null)
                {
                    return string.Empty;
                }
                return this.mFileVersionInfo.FileVersion;
            }
        }
    }
}
