#region description
/// <summary>
/// A stream header gives the names, and the position and length of a particular table or heap. Note that the length
///of a Stream header structure is not fixed, but depends on the length of its name field (a variable length nullterminated
///string).
/// </summary>
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public class FSStreamHeader : AFileStructure, IEnumerable<KeyValuePair<string, AStreamHeap>>, IEnumerable
    {
        private Dictionary<string, AStreamHeap> _streamHeaders;

        public int Count
        {
            get { return _streamHeaders.Count; }
        }
        public AStreamHeap this[string index]
        {
            get { return _streamHeaders[index]; }
            set { _streamHeaders[index] = value; }
        }

        private FSStreamHeader()
        { }
        internal FSStreamHeader(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, int countStreams, ulong offsetFromMetaData)
            : base(reader, beginOffset, mediator)
        {
            _streamHeaders = new Dictionary<string, AStreamHeap>();
            AStreamHeap temp;
            END_OFFSET = BEGIN_OFFSET;
            for (int index = 0; index < countStreams; ++index)
            {
                temp = AStreamHeap.BuidStreamHeap(reader, END_OFFSET, offsetFromMetaData, mediator, reader.getStringWithNullEnd(END_OFFSET + AStreamHeap.OFFSET_NAME));
                END_OFFSET = temp.END_OFFSET;
                _streamHeaders.Add(temp.Name, temp);
            }
        }

        public IEnumerator<KeyValuePair<string, AStreamHeap>> GetEnumerator()
        {
            return _streamHeaders.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _streamHeaders.GetEnumerator();
        }
    }
}