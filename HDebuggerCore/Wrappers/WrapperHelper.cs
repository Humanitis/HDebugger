namespace HDebuggerCore.Wrappers
{
    using HDebuggerCore.NativeAPI;
    using System;
    using System.Runtime.InteropServices;
    using System.Text;



    /// <summary>
    /// 
    /// </summary>
    public static class WrapperHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TType"></typeparam>
        /// <param name="clsid"></param>
        /// <param name="riid"></param>
        /// <returns></returns>
        public static TType CLRCreateInstance<TType>(Guid clsid, Guid riid)
        {
            IntPtr ptrToObject = NativeMethods.CLRCreateInstance(clsid, riid);
            return (TType)Marshal.GetTypedObjectForIUnknown(ptrToObject, typeof(TType));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="runtimes"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public static ICLRRuntimeInfo GetRuntime(IEnumUnknown runtimes, String version)
        {
            if (runtimes.Reset() == HRESULT.S_OK)
            {

                IntPtr[] runtimeBuffer = new IntPtr[3];
                uint fetchRuntimes;
                while (runtimes.Next((uint)runtimeBuffer.Length, runtimeBuffer, out fetchRuntimes) == HRESULT.S_OK || fetchRuntimes > 0)
                {
                    for (uint index = 0; index < fetchRuntimes; ++index)
                    {
                        ICLRRuntimeInfo runtimeInfo = (ICLRRuntimeInfo)Marshal.GetTypedObjectForIUnknown(runtimeBuffer[index], typeof(ICLRRuntimeInfo));

                        StringBuilder runtimeVersion = new StringBuilder(32);
                        uint fetchedChars = (uint)runtimeVersion.Capacity;
                        runtimeInfo.GetVersionString(runtimeVersion, ref fetchedChars);

                        if (String.IsNullOrWhiteSpace(version) || runtimeVersion.ToString().Equals(version, StringComparison.OrdinalIgnoreCase))
                        {
                            return runtimeInfo;
                        }
                    }
                }
            }

            return null;
        }
    }
}
