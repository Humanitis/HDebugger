#region description
/*The stream of bytes pointed to by a “#US” or “#Blob” header are the physical representation of logical
Userstring and 'blob' heaps respectively. Both these heaps can contain garbage, as long as any part that is
reachable from any of the tables contains a valid 'blob'. Individual blobs are stored with their length encoded in
the first few bytes:
• If the first one byte of the 'blob' is 0bbbbbbb2, then the rest of the 'blob' contains the bbbbbbb2
bytes of actual data.
• If the first two bytes of the 'blob' are 10bbbbbb2 and x, then the rest of the 'blob' contains the
(bbbbbb2 << 8 + x) bytes of actual data.
• If the first four bytes of the 'blob' are 110bbbbb2, x, y, and z, then the rest of the 'blob' contains the
(bbbbb2 << 24 + x << 16 + y << 8 + z) bytes of actual data.
The first entry in both these heaps is the empty 'blob' that consists of the single byte 0x00.
Strings in the #US (user string) heap are encoded using 16-bit Unicode encodings. The count on each string is
the number of bytes (not characters) in the string. Furthermore, there is an additional terminal byte (so all byte
counts are odd, not even). This final byte holds the value 1 if and only if any UTF16 character within the string
has any bit set in its top byte, or its low byte is any of the following: 0x01–0x08, 0x0E–0x1F, 0x27, 0x2D,
0x7F. Otherwise, it holds 0. The 1 signifies Unicode characters that require handling beyond that normally
provided for 8-bit encoding sets.*/
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class SHUserString : AStreamHeap, IEnumerable<string>, IEnumerable
    {
        private List<string> _usHeap;

        public int Count
        {
            get { return _usHeap.Count; }
        }
        public string this[int index]
        {
            get { return _usHeap[index]; }
        }

        private SHUserString()
        { }
        public SHUserString(byte[] reader, ulong beginOffset, ulong offsetFromMetaData, AFileFormatMediator mediator)
            : base(reader, beginOffset, offsetFromMetaData, mediator)
        {
            _usHeap = new List<string>();
            int totalSize = 0;
            int countByte = 0;
            int offsetActualData = 0;
            while (totalSize < Size)
            {
                OffsetSizeSctualDataInBlobHeap(reader, totalSize + (int)OffsetFromMetaData, ref offsetActualData, ref countByte);
                if (countByte != 0)
                    _usHeap.Add(reader.getStringEx(OffsetFromMetaData + (ulong)totalSize + (ulong)offsetActualData, (ulong)(countByte - 1) / 2));
                else
                    _usHeap.Add(String.Empty);
                totalSize += countByte + offsetActualData;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _usHeap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _usHeap.GetEnumerator();
        }
    }
}
