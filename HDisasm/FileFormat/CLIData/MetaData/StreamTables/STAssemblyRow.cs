#region description
/*The Assembly table has the following columns:
• HashAlgId (a 4-byte constant of type AssemblyHashAlgorithm, §23.1.1)
• MajorVersion, MinorVersion, BuildNumber, RevisionNumber (each being 2-byte constants)
• Flags (a 4-byte bitmask of type AssemblyFlags, §23.1.2)
106 Partition II
• PublicKey (an index into the Blob heap)
• Name (an index into the String heap)
• Culture (an index into the String heap)
The Assembly table is defined using the .assembly directive (§6.2); its columns are obtained from the
respective .hash algorithm, .ver, .publickey, and .culture*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STAssemblyRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_HASH_ALGID = 0UL;
        private static readonly ulong OFFSET_MAJOR_VERSION = 4UL;
        private static readonly ulong OFFSET_MINOR_VERSION = 6UL;
        private static readonly ulong OFFSET_BUILD_NUMBER = 8UL;
        private static readonly ulong OFFSET_REVISION_NUMBER = 10UL;
        private static readonly ulong OFFSET_FLAGS = 12UL;
        private static readonly ulong OFFSET_PUBLIC_KEY = 16UL;
        private static readonly ulong OFFSET_NAME = 16UL;
        private static readonly ulong OFFSET_CULTURE = 16UL;

        private AssemblyHashAlgorithm _hashAlgId;
        private ushort _majorVersion;
        private ushort _minorVersion;
        private ushort _buildNumber;
        private ushort _revisionNumber;
        private AssemblyFlag _flags;
        private uint _publicKey;
        private uint _name;
        private uint _culture;

        /// <summary>
        /// a 4-byte constant of type AssemblyHashAlgorithm,
        /// HashAlgId shall be one of the specified values [ERROR]
        /// </summary>
        public AssemblyHashAlgorithm HashAlgId
        {
            get { return _hashAlgId; }
            private set
            {
                Helper.CheckAlways(value, typeof(AssemblyHashAlgorithm), "HashAlgId");
                _hashAlgId = value;
            }
        }
        public ushort MajorVersion
        {
            get { return _majorVersion; }
            private set { _majorVersion = value; }
        }
        public ushort MinorVersion
        {
            get { return _minorVersion; }
            private set { _minorVersion = value; }
        }
        public ushort BuildNumber
        {
            get { return _buildNumber; }
            private set { _buildNumber = value; }
        }
        public ushort RevisionNumber
        {
            get { return _revisionNumber; }
            private set { _revisionNumber = value; }
        }
        /// <summary>
        /// a 4-byte bitmask of type AssemblyFlags,
        /// Flags shall have only those values set that are specified [ERROR]
        /// </summary>
        public AssemblyFlag Flags
        {
            get { return _flags; }
            set
            {
                Helper.CheckAlways(value, typeof(AssemblyFlag), "Flags");
                _flags = value;
            }
        }
        /// <summary>
        /// an index into the Blob heap
        /// PublicKey can be null or non-null
        /// </summary>
        public uint PublicKey
        {
            get { return _publicKey; }
            set { _publicKey = value; }
        }
        /// <summary>
        /// an index into the String heap
        /// Name shall index a non-empty string in the String heap [ERROR]
        /// The string indexed by Name can be of unlimited length
        /// </summary>
        public uint Name
        {
            get { return _name; }
            set { _name = value; }
        }
        /// <summary>
        /// an index into the String heap
        /// Culture can be null or non-null
        /// If Culture is non-null, it shall index a single string from the list specified [ERROR]
        /// </summary>
        public uint Culture
        {
            get { return _culture; }
            set { _culture = value; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STAssemblyRow(reader, beginOffset, mediator, heapSizes);
        }

        private STAssemblyRow()
        { }
        protected STAssemblyRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.ASSEMBLY;

            HashAlgId = (AssemblyHashAlgorithm)reader.getUInt(BEGIN_OFFSET + OFFSET_HASH_ALGID);
            MajorVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MAJOR_VERSION);
            MinorVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MINOR_VERSION);
            BuildNumber = reader.getUShort(BEGIN_OFFSET + OFFSET_BUILD_NUMBER);
            RevisionNumber = reader.getUShort(BEGIN_OFFSET + OFFSET_REVISION_NUMBER);
            Flags = (AssemblyFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);

            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();

            PublicKey = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_PUBLIC_KEY, blobSizeIndex, blobSizeIndex);
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME + blobSizeIndex, stringSizeIndex, stringSizeIndex);
            Culture = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_CULTURE + blobSizeIndex + stringSizeIndex, stringSizeIndex, stringSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_CULTURE + blobSizeIndex + 2 * stringSizeIndex;
        }

    }
}
