using System;
namespace HDebuggerCore.NativeAPI
{
    /// <summary>
    /// 
    /// </summary>
    public static class Constants
    {
        #region Guids
        public readonly static Guid IID_ICLMetaHost = new Guid(0xD332DB9E, 0xB9B3, 0x4125, 0x82, 0x07, 0xA1, 0x48, 0x84, 0xF5, 0x32, 0x16);
        public readonly static Guid CLSID_CLRMetaHost = new Guid(0x9280188d, 0xe8e, 0x4867, 0xb3, 0xc, 0x7f, 0xa8, 0x38, 0x84, 0xe8, 0xde);

        public readonly static Guid CLSID_CLRDebuggingLegacy = new Guid(0xDF8395B5, 0xA4BA, 0x450b, 0xA7, 0x7C, 0xA9, 0xA4, 0x77, 0x62, 0xC5, 0x20);
        public readonly static Guid IID_ICorDebug = new Guid("3D6F5F61-7538-11D3-8D5B-00104B35E7EF");
        #endregion
    }
}
