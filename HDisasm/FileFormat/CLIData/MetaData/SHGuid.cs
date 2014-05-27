#region description
///The “#GUID” header points to a sequence of 128-bit GUIDs. There might be unreachable GUIDs stored in the
///stream.
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class SHGuid : AStreamHeap, IEnumerable<Guid>, IEnumerable
    {
        private List<Guid> _guidHeap;

        public int Count
        {
            get { return _guidHeap.Count; }
        }
        public Guid this[int index]
        {
            get { return _guidHeap[index]; }
        }

        private SHGuid()
        { }
        public SHGuid(byte[] reader, ulong beginOffset, ulong offsetFromMetaData, AFileFormatMediator mediator)
            : base(reader, beginOffset, offsetFromMetaData, mediator)
        {

            int count = (int)Size / 16;
            _guidHeap = new List<Guid>(count);
            for (int index = 0; index < count; ++index)
            {
                _guidHeap.Add(new Guid(reader.Skip((int)OffsetFromMetaData - 1 + index * 16).Take(16).ToArray()));
            }

        }

        public IEnumerator<Guid> GetEnumerator()
        {
            return _guidHeap.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _guidHeap.GetEnumerator();
        }
    }
}
