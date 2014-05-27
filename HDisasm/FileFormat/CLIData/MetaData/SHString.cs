#region description
///The stream of bytes pointed to by a “#Strings” header is the physical representation of the logical string heap.
///The physical heap can contain garbage, that is, it can contain parts that are unreachable from any of the tables,
///but parts that are reachable from a table shall contain a valid null-terminated UTF8 string. When the #String
///heap is present, the first entry is always the empty string (i.e., \0).
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class SHString : AStreamHeap, IEnumerable<string>, IEnumerable
    {
        private List<string> _stringHeap;

        public int Count
        {
            get { return _stringHeap.Count; }
        }
        public string this[int index]
        {
            get { return _stringHeap[index]; }
        }

        private SHString()
        { }
        public SHString(byte[] reader, ulong beginOffset, ulong offsetFromMetaData, AFileFormatMediator mediator)
            : base(reader, beginOffset, offsetFromMetaData, mediator)
        {
            _stringHeap = new List<string>();
            int totalSize = 0;
            while (totalSize < Size)
            {
                _stringHeap.Add(reader.getStringWithNullEnd((ulong)totalSize + OffsetFromMetaData));
                totalSize += _stringHeap[_stringHeap.Count - 1].Length + 1;
            }
        }

        public IEnumerator<string> GetEnumerator()
        {
            return _stringHeap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _stringHeap.GetEnumerator();
        }
    }
}
