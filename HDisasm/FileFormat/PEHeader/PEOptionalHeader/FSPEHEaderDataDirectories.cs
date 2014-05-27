#region description
///PE header data directories
///The optional header data directories give the address and size of several tables that appear in the sections of the
///PE file. Each data directory entry contains the RVA and Size of the structure it describes.
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.PEHeader
{
    public sealed class FSPEHEaderDataDirectories:AFileStructure
    {
        private static readonly PairRVASize ALWAYS_EXPORT_TABLE = PairRVASize.Zero;
        //private static readonly PairRVASize ALWAYS_IMPORT_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_RESOURCE_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_EXEPTION_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_CERTIFICATE_TABLE = PairRVASize.Zero;
        //private static readonly PairRVASize ALWAYS_BASE_RELOCATION_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_DEBUG = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_COPYRIGHT = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_GLOBAL_PTR = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_TLS_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_LOADCONFIG_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_BOUND_IMPORT = PairRVASize.Zero;
        //private static readonly PairRVASize ALWAYS_IAT = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_DELAY_IMPORT_DESCRIPTION = PairRVASize.Zero;
        //private static readonly PairRVASize ALWAYS_CLI_HEADER = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_RESERVED = PairRVASize.Zero;

        private static readonly ulong OFFSET_EXPORT_TABLE = 96UL;
        private static readonly ulong OFFSET_IMPORT_TABLE = 104UL;
        private static readonly ulong OFFSET_RESOURCE_TABLE = 112UL;
        private static readonly ulong OFFSET_EXEPTION_TABLE = 120UL;
        private static readonly ulong OFFSET_CERTIFICATE_TABLE = 128UL;
        private static readonly ulong OFFSET_BASE_RELOCATION_TABLE = 136UL;
        private static readonly ulong OFFSET_DEBUG = 144UL;
        private static readonly ulong OFFSET_COPYRIGHT = 152UL;
        private static readonly ulong OFFSET_GLOBAL_PTR = 160UL;
        private static readonly ulong OFFSET_TLS_TABLE = 168UL;
        private static readonly ulong OFFSET_LOADCONFIG_TABLE = 176UL;
        private static readonly ulong OFFSET_BOUND_IMPORT = 184UL;
        private static readonly ulong OFFSET_IAT = 192UL;
        private static readonly ulong OFFSET_DELAY_IMPORT_DESCRIPTION = 200UL;
        private static readonly ulong OFFSET_CLI_HEADER = 208UL;
        private static readonly ulong OFFSET_RESERVED = 216UL;

        private PairRVASize _exportTable;
        private PairRVASize _importTable;
        private PairRVASize _resourceTable;
        private PairRVASize _exeptionTable;
        private PairRVASize _certificateTable;
        private PairRVASize _baseRelocationTable;
        private PairRVASize _debug;
        private PairRVASize _copyright;
        private PairRVASize _globalPtr;
        private PairRVASize _tlsTable;
        private PairRVASize _loadconfigTable;
        private PairRVASize _boundImport;
        private PairRVASize _iat;
        private PairRVASize _delayImportDescription;
        private PairRVASize _cliHeader;
        private PairRVASize _reserved;

        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ExportTable
        {
            get { return _exportTable; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_EXPORT_TABLE,"ExportTable");
                _exportTable = value;
            }
        }
        /// <summary>
        /// RVA and Size of Import Table,
        /// </summary>
        public PairRVASize ImportTable
        {
            get { return _importTable; }
            private set { _importTable = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ResourceTable
        {
            get { return _resourceTable; }
            private set
            {
                //Helper.CheckAlways(value ,ALWAYS_RESOURCE_TABLE,"ResourceTable");
                _resourceTable = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ExeptionTable
        {
            get { return _exeptionTable; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_EXEPTION_TABLE,"ExeptionTable");
                _exeptionTable = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize CertificateTable
        {
            get { return _certificateTable; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_CERTIFICATE_TABLE,"CertificateTable");
                _certificateTable = value;
            }
        }
        /// <summary>
        /// Relocation Table; set to 0 if unused
        /// </summary>
        public PairRVASize BaseRelocationTable
        {
            get { return _baseRelocationTable; }
            private set { _baseRelocationTable = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize Debug
        {
            get { return _debug; }
            private set
            {
                //Helper.CheckAlways(value ,ALWAYS_DEBUG,"Debug");
                _debug = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize Copyright
        {
            get { return _copyright; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_COPYRIGHT,"Copyright");
                _copyright = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize GlobalPtr
        {
            get { return _globalPtr; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_GLOBAL_PTR,"GlobalPtr");
                _globalPtr = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize TLSTable
        {
            get { return _tlsTable; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_TLS_TABLE,"TLSTable");
                _tlsTable = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize LoadconfigTable
        {
            get { return _loadconfigTable; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_LOADCONFIG_TABLE,"LoadconfigTable");
                _loadconfigTable = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize BoundImport
        {
            get { return _boundImport; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_BOUND_IMPORT,"BoundImport");
                _boundImport = value;
            }
        }
        /// <summary>
        /// RVA and Size of Import Address Table,
        /// </summary>
        public PairRVASize IAT
        {
            get { return _iat; }
            private set { _iat = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize DelayImportDescription
        {
            get { return _delayImportDescription; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_DELAY_IMPORT_DESCRIPTION,"DelayImportDescription");
                _delayImportDescription = value;
            }
        }
        /// <summary>
        /// CLI Header with directories for runtime data,
        /// </summary>
        public PairRVASize CLIHeader
        {
            get { return _cliHeader; }
            private set { _cliHeader = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize Reserved
        {
            get { return _reserved; }
            private set
            {
                Helper.CheckAlways(value ,ALWAYS_RESERVED,"Reserved");
                _reserved = value;
            }
        }

        private FSPEHEaderDataDirectories()
        { }

        public FSPEHEaderDataDirectories(byte[] reader, ulong beginOffset,AFileFormatMediator mediator)
            :base(reader,beginOffset,mediator)
        {
            ExportTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_EXPORT_TABLE));
            ImportTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_IMPORT_TABLE));
            ResourceTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_RESOURCE_TABLE));
            ExeptionTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_EXEPTION_TABLE));
            CertificateTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_CERTIFICATE_TABLE));
            BaseRelocationTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_BASE_RELOCATION_TABLE));
            Debug = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_DEBUG));
            Copyright = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_COPYRIGHT));
            GlobalPtr = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_GLOBAL_PTR));
            TLSTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_TLS_TABLE));
            LoadconfigTable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_LOADCONFIG_TABLE));
            BoundImport = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_BOUND_IMPORT));
            IAT = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_IAT));
            DelayImportDescription = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_DELAY_IMPORT_DESCRIPTION));
            CLIHeader = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_CLI_HEADER));
            Reserved = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_RESERVED));
            END_OFFSET = BEGIN_OFFSET + OFFSET_RESERVED + 8;
        }
    }
}
