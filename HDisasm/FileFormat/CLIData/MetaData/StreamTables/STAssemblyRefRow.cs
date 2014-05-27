#region description
/*The AssemblyRef table has the following columns:
• MajorVersion, MinorVersion, BuildNumber, RevisionNumber (each being 2-byte constants)
• Flags (a 4-byte bitmask of type AssemblyFlags, §23.1.2)
• PublicKeyOrToken (an index into the Blob heap, indicating the public key or token that identifies
the author of this Assembly)
• Name (an index into the String heap)
Partition II 107
• Culture (an index into the String heap)
• HashValue (an index into the Blob heap)
The table is defined by the .assembly extern directive (§6.3). Its columns are filled using directives
similar to those of the Assembly table except for the PublicKeyOrToken column, which is defined using the
.publickeytoken directive.
 
 
 The AssemblyRef table shall contain no duplicates (where duplicate rows are deemd to be those
having the same MajorVersion, MinorVersion, BuildNumber, RevisionNumber,
PublicKeyOrToken, Name, and Culture) [WARNING]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STAssemblyRefRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_MAJOR_VERSION = 0UL;
        private static readonly ulong OFFSET_MINOR_VERSION = 2UL;
        private static readonly ulong OFFSET_BUILD_NUMBER = 4UL;
        private static readonly ulong OFFSET_REVISION_NUMBER = 6UL;
        private static readonly ulong OFFSET_FLAGS = 8UL;
        private static readonly ulong OFFSET_PUBLIC_KEY_OR_TOKEN = 12UL;
        private static readonly ulong OFFSET_NAME = 12UL;
        private static readonly ulong OFFSET_CULTURE = 12UL;
        private static readonly ulong OFFSET_HASH_VALUE = 12UL;

        private ushort _majorVersion;
        private ushort _minorVersion;
        private ushort _buildNumber;
        private ushort _revisionNumber;
        private AssemblyFlag _flags;
        private uint _publicKeyOrToken;
        private uint _name;
        private uint _culture;
        private uint _hashValue;

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
        /// Flags shall have only one bit set, the PublicKey bit (§23.1.2). All other bits shall be zero.
        ///[ERROR]
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
        /// an index into the Blob heap, indicating the public key or token that identifies
        ///the author of this Assembly
        ///PublicKeyOrToken can be null, or non-null (note that the Flags.PublicKey bit specifies
        /// whether the 'blob' is a full public key, or the short hashed token
        /// If non-null, then PublicKeyOrToken shall index a valid offset in the Blob heap [ERROR]
        /// </summary>
        public uint PublicKeyOrToken
        {
            get { return _publicKeyOrToken; }
            set { _publicKeyOrToken = value; }
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
        /// <summary>
        /// an index into the Blob heap
        /// HashValue can be null or non-null
        /// If non-null, then HashValue shall index a non-empty 'blob' in the Blob heap [ERROR]
        /// </summary>
        public uint HashValue
        {
            get { return _hashValue; }
            set { _hashValue = value; }
        }

        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STAssemblyRefRow(reader, beginOffset, mediator, heapSizes);
        }

        private STAssemblyRefRow()
        { }
        protected STAssemblyRefRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.ASSEMBLY_REF;

            MajorVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MAJOR_VERSION);
            MinorVersion = reader.getUShort(BEGIN_OFFSET + OFFSET_MINOR_VERSION);
            BuildNumber = reader.getUShort(BEGIN_OFFSET + OFFSET_BUILD_NUMBER);
            RevisionNumber = reader.getUShort(BEGIN_OFFSET + OFFSET_REVISION_NUMBER);
            Flags = (AssemblyFlag)reader.getUInt(BEGIN_OFFSET + OFFSET_FLAGS);

            ulong blobSizeIndex = HeapSizes.WideOfBlobHeap();
            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();

            PublicKeyOrToken = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_PUBLIC_KEY_OR_TOKEN, blobSizeIndex, blobSizeIndex);
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME + blobSizeIndex, stringSizeIndex, stringSizeIndex);
            Culture = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_CULTURE + blobSizeIndex + stringSizeIndex, stringSizeIndex, stringSizeIndex);
            HashValue = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_CULTURE + blobSizeIndex + 2 * stringSizeIndex, blobSizeIndex, blobSizeIndex);

            END_OFFSET = BEGIN_OFFSET + OFFSET_CULTURE + 2 * blobSizeIndex + 2 * stringSizeIndex;
        }

    }
}
