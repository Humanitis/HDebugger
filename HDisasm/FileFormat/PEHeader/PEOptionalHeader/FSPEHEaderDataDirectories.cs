#region description
///PE header data directories
///The optional header data directories give the address and size of several tables that appear in the sections of the
///PE file. Each data directory entry contains the RVA and Size of the structure it describes.
#endregion
namespace PEFileFormat
{
    using System;






    /// <summary>
    /// 
    /// </summary>
    public sealed class FSPEHEaderDataDirectories:AFileStructure
    {
        #region Constants
        public const long OFFSET_EXPORT_TABLE = 96L;
        public const long OFFSET_IMPORT_TABLE = 104L;
        public const long OFFSET_RESOURCE_TABLE = 112L;
        public const long OFFSET_EXEPTION_TABLE = 120L;
        public const long OFFSET_CERTIFICATE_TABLE = 128L;
        public const long OFFSET_BASE_RELOCATION_TABLE = 136L;
        public const long OFFSET_DEBUG = 144L;
        public const long OFFSET_COPYRIGHT = 152L;
        public const long OFFSET_GLOBAL_PTR = 160L;
        public const long OFFSET_TLS_TABLE = 168L;
        public const long OFFSET_LOADCONFIG_TABLE = 176L;
        public const long OFFSET_BOUND_IMPORT = 184L;
        public const long OFFSET_IAT = 192L;
        public const long OFFSET_DELAY_IMPORT_DESCRIPTION = 200L;
        public const long OFFSET_CLI_HEADER = 208L;
        public const long OFFSET_RESERVED = 216L;
        #endregion




        #region Fields
        private readonly PairRVASize _exportTable;
        private readonly PairRVASize _importTable;
        private readonly PairRVASize _resourceTable;
        private readonly PairRVASize _exeptionTable;
        private readonly PairRVASize _certificateTable;
        private readonly PairRVASize _baseRelocationTable;
        private readonly PairRVASize _debug;
        private readonly PairRVASize _copyright;
        private readonly PairRVASize _globalPtr;
        private readonly PairRVASize _tlsTable;
        private readonly PairRVASize _loadconfigTable;
        private readonly PairRVASize _boundImport;
        private readonly PairRVASize _iat;
        private readonly PairRVASize _delayImportDescription;
        private readonly PairRVASize _cliHeader;
        private readonly PairRVASize _reserved;
        #endregion








        #region Constants
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="beginOffset"></param>
        public FSPEHEaderDataDirectories(byte[] reader, long beginOffset)
            : base(reader)
        {
            this._exportTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_EXPORT_TABLE));
            Helper.CheckAlways(this._exportTable, PairRVASize.Zero, "ExportTable");
            this._importTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_IMPORT_TABLE));
            this._resourceTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_RESOURCE_TABLE));
            Helper.CheckAlways(this._resourceTable, PairRVASize.Zero, "ResourceTable");
            this._exeptionTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_EXEPTION_TABLE));
            Helper.CheckAlways(this._exeptionTable, PairRVASize.Zero, "ExeptionTable");
            this._certificateTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_CERTIFICATE_TABLE));
            Helper.CheckAlways(this._certificateTable, PairRVASize.Zero, "CertificateTable");
            this._baseRelocationTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_BASE_RELOCATION_TABLE));
            this._debug = new PairRVASize(reader.getULong(beginOffset + OFFSET_DEBUG));
            Helper.CheckAlways(this._debug, PairRVASize.Zero, "Debug");
            this._copyright = new PairRVASize(reader.getULong(beginOffset + OFFSET_COPYRIGHT));
            Helper.CheckAlways(this._copyright, PairRVASize.Zero, "Copyright");
            this._globalPtr = new PairRVASize(reader.getULong(beginOffset + OFFSET_GLOBAL_PTR));
            Helper.CheckAlways(this._globalPtr, PairRVASize.Zero, "GlobalPtr");
            this._tlsTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_TLS_TABLE));
            Helper.CheckAlways(this._tlsTable, PairRVASize.Zero, "TLSTable");
            this._loadconfigTable = new PairRVASize(reader.getULong(beginOffset + OFFSET_LOADCONFIG_TABLE));
            Helper.CheckAlways(this._loadconfigTable, PairRVASize.Zero, "LoadconfigTable");
            this._boundImport = new PairRVASize(reader.getULong(beginOffset + OFFSET_BOUND_IMPORT));
            Helper.CheckAlways(this._boundImport, PairRVASize.Zero, "BoundImport");
            this._iat = new PairRVASize(reader.getULong(beginOffset + OFFSET_IAT));
            this._delayImportDescription = new PairRVASize(reader.getULong(beginOffset + OFFSET_DELAY_IMPORT_DESCRIPTION));
            Helper.CheckAlways(this._delayImportDescription, PairRVASize.Zero, "DelayImportDescription");
            this._cliHeader = new PairRVASize(reader.getULong(beginOffset + OFFSET_CLI_HEADER));
            this._reserved = new PairRVASize(reader.getULong(beginOffset + OFFSET_RESERVED));
            Helper.CheckAlways(this._reserved, PairRVASize.Zero, "Reserved");
            //END_OFFSET = BEGIN_OFFSET + OFFSET_RESERVED + 8;
        }
        #endregion







        #region Properties
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ExportTable
        {
            get { return _exportTable; }
        }
        /// <summary>
        /// RVA and Size of Import Table,
        /// </summary>
        public PairRVASize ImportTable
        {
            get { return _importTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ResourceTable
        {
            get { return _resourceTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ExeptionTable
        {
            get { return _exeptionTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize CertificateTable
        {
            get { return _certificateTable; }
        }
        /// <summary>
        /// Relocation Table; set to 0 if unused
        /// </summary>
        public PairRVASize BaseRelocationTable
        {
            get { return _baseRelocationTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize Debug
        {
            get { return _debug; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize Copyright
        {
            get { return _copyright; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize GlobalPtr
        {
            get { return _globalPtr; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize TLSTable
        {
            get { return _tlsTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize LoadconfigTable
        {
            get { return _loadconfigTable; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize BoundImport
        {
            get { return _boundImport; }
        }
        /// <summary>
        /// RVA and Size of Import Address Table,
        /// </summary>
        public PairRVASize IAT
        {
            get { return _iat; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize DelayImportDescription
        {
            get { return _delayImportDescription; }
        }
        /// <summary>
        /// CLI Header with directories for runtime data,
        /// </summary>
        public PairRVASize CLIHeader
        {
            get { return _cliHeader; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize Reserved
        {
            get { return _reserved; }
        }
        #endregion
    }
}
