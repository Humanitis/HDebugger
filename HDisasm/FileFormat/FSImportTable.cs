#region description
///Import Table and Import Address Table (IAT)
///The Import Table and the Import Address Table (IAT) are used to import the _CorExeMain (for a .exe) or
///_CorDllMain (for a .dll) entries of the runtime engine (mscoree.dll). The Import Table directory entry points to
///a one element zero terminated array of Import Directory entries (in a general PE file there is one entry for each
///imported DLL):
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat
{
    public sealed class FSImportTable:AFileStructure
    {
        private static readonly uint ALWAYS_DATETIMESTAMP = 0;
        private static readonly uint ALWAYS_FORWARDER_CHAIN = 0;
        private static readonly string ALWAYS_NAME = "mscoree.dll";

        private static readonly ulong OFFSET_IMPORT_LOOKUP_TABLE = 0UL;
        private static readonly ulong OFFSET_DATETIMESTAMP = 4UL;
        private static readonly ulong OFFSET_FORWARDER_CHAIN = 8UL;
        private static readonly ulong OFFSET_NAME = 12UL;
        private static readonly ulong OFFSET_IMPORT_ADDRESS_TABLE = 16UL;

        private uint _importLookupTableRVA;
        private uint _datetimestamp;
        private uint _forwarderChain;
        private uint _nameRVA;
        private uint _importAddressTable;
        private string _name;

        /// <summary>
        /// RVA of the Import Lookup Table
        /// </summary>
        public uint ImportLookupTableRVA
        {
            get { return _importLookupTableRVA; }
            private set { _importLookupTableRVA = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint Datetimestamp
        {
            get { return _datetimestamp; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_DATETIMESTAMP, "Datetimestamp");
                _datetimestamp = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public uint ForwarderChain
        {
            get { return _forwarderChain; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_FORWARDER_CHAIN, "ForwarderChain");
                _forwarderChain = value;
            }
        }
        /// <summary>
        /// RVA of null-terminated ASCII string “mscoree.dll”.
        /// </summary>
        public uint NameRVA
        {
            get { return _nameRVA; }
            private set { _nameRVA = value; }
        }
        /// <summary>
        ///  ASCII string “mscoree.dll”.
        /// </summary>
        public string Name
        {
            get { return _name; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_NAME, "Name");
                _name = value;
            }
        }
        /// <summary>
        /// RVA of Import Address Table (this is the same as the
        ///RVA of the IAT descriptor in the optional header).
        /// </summary>
        public uint ImportAddressTable
        {
            get { return _importAddressTable; }
            private set { _importAddressTable = value; }
        }


        private FSImportTable()
        { }

        public FSImportTable(byte[] reader, ulong beginOffset,AFileFormatMediator mediator)
            :base(reader,beginOffset,mediator)
        {
            ImportLookupTableRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_IMPORT_LOOKUP_TABLE);
            Datetimestamp = reader.getUInt(BEGIN_OFFSET + OFFSET_DATETIMESTAMP);
            ForwarderChain = reader.getUInt(BEGIN_OFFSET + OFFSET_FORWARDER_CHAIN);
            NameRVA = reader.getUInt(BEGIN_OFFSET + OFFSET_NAME);
            ImportAddressTable = reader.getUInt(BEGIN_OFFSET + OFFSET_IMPORT_ADDRESS_TABLE);
            END_OFFSET = BEGIN_OFFSET + OFFSET_IMPORT_ADDRESS_TABLE + 24;
            //TODO:End of Import Table. Shall be filled with zeros.
        }
    }
}
