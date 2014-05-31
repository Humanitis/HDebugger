#region description
///Import Table and Import Address Table (IAT)
///The Import Table and the Import Address Table (IAT) are used to import the _CorExeMain (for a .exe) or
///_CorDllMain (for a .dll) entries of the runtime engine (mscoree.dll). The Import Table directory entry points to
///a one element zero terminated array of Import Directory entries (in a general PE file there is one entry for each
///imported DLL):
#endregion
namespace PEFileFormat
{
    using System;





    /// <summary>
    /// 
    /// </summary>
    public sealed class FSImportTableEntry : AFileStructure
    {
        #region Constants
        private const uint ALWAYS_DATETIMESTAMP = 0;
        private const uint ALWAYS_FORWARDER_CHAIN = 0;

        public const long OFFSET_IMPORT_LOOKUP_TABLE = 0L;
        public const long OFFSET_DATETIMESTAMP = 4L;
        public const long OFFSET_FORWARDER_CHAIN = 8L;
        public const long OFFSET_NAME = 12L;
        public const long OFFSET_IMPORT_ADDRESS_TABLE = 16L;
        #endregion





        #region Fields
        private readonly uint _importLookupTableRVA;
        private readonly uint _datetimestamp;
        private readonly uint _forwarderChain;
        private readonly uint _nameRVA;
        private readonly uint _importAddressTable;
        private readonly string _name;
        private readonly uint _hintNameTableRVA;
        private readonly FSHintNameTableEntry _hintNameTableEntry;
        #endregion







        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        /// <param name="mediator"></param>
        public FSImportTableEntry(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._importLookupTableRVA = reader.getUInt(beginOffset + OFFSET_IMPORT_LOOKUP_TABLE);
            this._datetimestamp = reader.getUInt(beginOffset + OFFSET_DATETIMESTAMP);
            Helper.CheckAlways(this._datetimestamp, ALWAYS_DATETIMESTAMP, "Datetimestamp");
            this._forwarderChain = reader.getUInt(beginOffset + OFFSET_FORWARDER_CHAIN);
            Helper.CheckAlways(this._forwarderChain, ALWAYS_FORWARDER_CHAIN, "ForwarderChain");
            this._nameRVA = reader.getUInt(beginOffset + OFFSET_NAME);
            this._importAddressTable = reader.getUInt(beginOffset + OFFSET_IMPORT_ADDRESS_TABLE);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="peHeader"></param>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSImportTableEntry(FSPEHeader peHeader,byte[] reader, long beginOffset)
            : base(reader)
        {
            this._importLookupTableRVA = reader.getUInt(beginOffset + OFFSET_IMPORT_LOOKUP_TABLE);
            this._datetimestamp = reader.getUInt(beginOffset + OFFSET_DATETIMESTAMP);
            Helper.CheckAlways(this._datetimestamp, ALWAYS_DATETIMESTAMP, "Datetimestamp");
            this._forwarderChain = reader.getUInt(beginOffset + OFFSET_FORWARDER_CHAIN);
            Helper.CheckAlways(this._forwarderChain, ALWAYS_FORWARDER_CHAIN, "ForwarderChain");
            this._nameRVA = reader.getUInt(beginOffset + OFFSET_NAME);
            this._importAddressTable = reader.getUInt(beginOffset + OFFSET_IMPORT_ADDRESS_TABLE);

            this._name = reader.getStringWithNullEnd(peHeader.TranslateRVA(this._nameRVA));
            this._hintNameTableRVA = reader.getUInt(peHeader.TranslateRVA(this._importAddressTable));
            this._hintNameTableEntry = new FSHintNameTableEntry(reader, peHeader.TranslateRVA(this._hintNameTableRVA));
        }
        #endregion









        #region Properties
        /// <summary>
        /// RVA of the Import Lookup Table
        /// </summary>
        public uint ImportLookupTableRVA
        {
            get { return _importLookupTableRVA; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint Datetimestamp
        {
            get { return _datetimestamp; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint ForwarderChain
        {
            get { return _forwarderChain; }
        }
        /// <summary>
        /// RVA of null-terminated ASCII string “mscoree.dll”.
        /// </summary>
        public uint NameRVA
        {
            get { return _nameRVA; }
        }
        /// <summary>
        ///  ASCII string “mscoree.dll”.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }
        /// <summary>
        /// RVA of Import Address Table (this is the same as the
        ///RVA of the IAT descriptor in the optional header).
        /// </summary>
        public uint ImportAddressTable
        {
            get { return _importAddressTable; }
        }
        /// <summary>
        /// 
        /// </summary>
        public uint HintNameTableRVA
        {
            get { return this._hintNameTableRVA; }
        }
        /// <summary>
        /// 
        /// </summary>
        public FSHintNameTableEntry HintNameTableEntry 
        {
            get { return this._hintNameTableEntry; }
        }
        #endregion
    }
}
