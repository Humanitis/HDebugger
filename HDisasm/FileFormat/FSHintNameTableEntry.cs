#region description
///The Hint/Name table contains the name of the dll-entry that is imported.
#endregion
namespace PEFileFormat
{
    using System;


    
    /// <summary>
    /// 
    /// </summary>
    public sealed class FSHintNameTableEntry:AFileStructure
    {
        #region Constants
        private const ushort ALWAYS_HINT = 0;
        private const string ALWAYS_NAME_EXE = "_CorExeMain";
        private const string ALWAYS_NAME_DLL = "_CorDllMain";

        private const long OFFSET_HINT = 0L;
        private const long OFFSET_NAME = 2L;
        #endregion







        #region Fields
        private readonly ushort _hint;
        private readonly string _name;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSHintNameTableEntry(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._hint = reader.getUShort(beginOffset + OFFSET_HINT);
            Helper.CheckAlways(this._hint, ALWAYS_HINT, "Hint");
            this._name = reader.getStringWithNullEnd(beginOffset + OFFSET_NAME);
            Helper.CheckAlways(this._name, ALWAYS_NAME_EXE, ALWAYS_NAME_DLL, "Name");
        }
        #endregion








        #region Properties
        /// <summary>
        /// Shall be 0.
        /// </summary>
        public ushort Hint
        {
            get { return _hint; }
        }
        /// <summary>
        /// Case sensitive, null-terminated ASCII string containing name to
        ///import. Shall be “_CorExeMain” for a .exe file and
        ///“_CorDllMain” for a .dll file.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        #endregion
    }
}
