#region description
///The CLI header contains all of the runtime-specific data entries and other information. The header should be
///placed in a read-only, sharable section of the image.
#endregion
using System;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIHeader
{
    public sealed class FSCLIHeader:AFileStructure
    {
        private static readonly PairRVASize ALWAYS_CODE_MANAGER_TABLE = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_EXPORT_ADDRESS_TABLE_JUMPS = PairRVASize.Zero;
        private static readonly PairRVASize ALWAYS_MANAGED_NATIVE_HEADER = PairRVASize.Zero;

        private static readonly ulong OFFSET_SIZE_CB = 0UL;
        private static readonly ulong OFFSET_MAJOR_RUNTIME_VERSION = 4UL;
        private static readonly ulong OFFSET_MINOR_RUNTIME_VERSION = 6UL;
        private static readonly ulong OFFSET_META_DATA = 8UL;
        private static readonly ulong OFFSET_FLAGS = 16UL;
        private static readonly ulong OFFSET_ENTRY_POINT_TOKEN = 20UL;
        private static readonly ulong OFFSET_RESOURCES = 24UL;
        private static readonly ulong OFFSET_STRONG_NAME_SiGNATURE = 32UL;
        private static readonly ulong OFFSET_CODE_MANAGER_TABLE = 40UL;
        private static readonly ulong OFFSET_VTABLE_FIXUPS = 48UL;
        private static readonly ulong OFFSET_EXPORT_ADDRESS_TABLE_JUMPS = 56UL;
        private static readonly ulong OFFSET_MANAGED_NATIVE_HEADER = 64UL;

        private uint _sizeCb;
        private ushort _majorRuntimeVersion;
        private ushort _minorRuntimeVersion;
        private PairRVASize _metaData;
        private RuntimeFlags _flags;
        private uint _entryPointToken;
        private PairRVASize _resources;
        private PairRVASize _strongNameSIgnature;
        private PairRVASize _codeManagertable;
        private PairRVASize _vtableFixups;
        private PairRVASize _exportAddressTableJumps;
        private PairRVASize _managedNativeHeader;

        private readonly ulong _end_offset;

        /// <summary>
        /// Size of the header in bytes
        /// </summary>
        public uint SizeCb
        {
            get { return _sizeCb; }
            private set { _sizeCb = value; }
        }
        /// <summary>
        /// The minimum version of the runtime required to run
        ///this program, currently 2.
        /// </summary>
        public ushort MajorRuntimeVersion
        {
            get { return _majorRuntimeVersion; }
            private set { _majorRuntimeVersion = value; }
        }
        /// <summary>
        /// The minor portion of the version, currently 0.
        /// </summary>
        public ushort MinorRuntimeVersion
        {
            get { return _minorRuntimeVersion; }
            private set { _minorRuntimeVersion = value; }
        }
        /// <summary>
        /// RVA and size of the physical metadata
        /// </summary>
        public PairRVASize MetaData
        {
            get { return _metaData; }
            private set { _metaData = value; }
        }
        /// <summary>
        /// Flags describing this runtime image.
        /// </summary>
        public RuntimeFlags Flags
        {
            get { return _flags; }
            private set { _flags = value; }
        }
        /// <summary>
        /// Token for the MethodDef or File of the entry point
        ///for the image
        /// </summary>
        public uint EntryPointToken
        {
            get { return _entryPointToken; }
            private set { _entryPointToken = value; }
        }
        /// <summary>
        /// RVA and size of implementation-specific resources.
        /// </summary>
        public PairRVASize Resources
        {
            get { return _resources; }
            private set { _resources = value; }
        }
        /// <summary>
        /// RVA of the hash data for this PE file used by the
        ///CLI loader for binding and versioning
        /// </summary>
        public PairRVASize StrongNameSIgnature
        {
            get { return _strongNameSIgnature; }
            private set { _strongNameSIgnature = value; }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize CodeManagertable
        {
            get { return _codeManagertable; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_CODE_MANAGER_TABLE, "CodeManagertable");
                _codeManagertable = value;
            }
        }
        /// <summary>
        /// RVA of an array of locations in the file that contain
        ///an array of function pointers (e.g., vtable slots), see
        ///below.
        /// </summary>
        public PairRVASize VtableFixups
        {
            get { return _vtableFixups; }
            private set { _vtableFixups = value; }
        }
        /// <summary>
        /// /Always 0
        /// </summary>
        public PairRVASize ExportAddressTableJumps
        {
            get { return _exportAddressTableJumps; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_EXPORT_ADDRESS_TABLE_JUMPS, "ExportAddressTableJumps");
                _exportAddressTableJumps = value;
            }
        }
        /// <summary>
        /// Always 0
        /// </summary>
        public PairRVASize ManagedNativeHeader
        {
            get { return _managedNativeHeader; }
            private set
            {
                Helper.CheckAlways(value, ALWAYS_MANAGED_NATIVE_HEADER, "ManagedNativeHeader");
                _managedNativeHeader = value;
            }
        }


        private FSCLIHeader()
        { }

        public FSCLIHeader(byte[] reader, ulong beginOffset,AFileFormatMediator mediator)
            :base(reader,beginOffset,mediator)
        {
            SizeCb = reader.getUInt(BEGIN_OFFSET + OFFSET_SIZE_CB);
            MajorRuntimeVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MAJOR_RUNTIME_VERSION);
            MinorRuntimeVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MINOR_RUNTIME_VERSION);
            MetaData = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_META_DATA));
            Flags = (RuntimeFlags)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);
            EntryPointToken = reader.getUInt(BEGIN_OFFSET + OFFSET_ENTRY_POINT_TOKEN);
            Resources = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_RESOURCES));
            StrongNameSIgnature = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_STRONG_NAME_SiGNATURE));
            CodeManagertable = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_CODE_MANAGER_TABLE));
            VtableFixups = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_VTABLE_FIXUPS));
            ExportAddressTableJumps = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_EXPORT_ADDRESS_TABLE_JUMPS));
            ManagedNativeHeader = new PairRVASize(reader.getULong(BEGIN_OFFSET + OFFSET_MANAGED_NATIVE_HEADER));
            END_OFFSET = BEGIN_OFFSET + OFFSET_MANAGED_NATIVE_HEADER + 8;
        }

        #region nested types
        [Flags()]
        public enum RuntimeFlags:uint
        {
            COMIMAGE_FLAGS_ILONLY = 0x00000001,//Always 1
            COMIMAGE_FLAGS_32BITREQUIRED = 0x00000002,/*Image can only be loaded into a 32-bit process,
                                                        for instance if there are 32-bit vtablefixups, or
                                                        casts from native integers to int32. CLI
                                                        implementations that have 64-bit native
                                                        integers shall refuse loading binaries with this
                                                        flag set.*/
            COMIMAGE_FLAGS_STRONGNAMESIGNED = 0x00000008,//Image has a strong name signature.
            COMIMAGE_FLAGS_TRACKDEBUGDATA = 0x00010000,//Always 0
        }
        #endregion
    }
}
