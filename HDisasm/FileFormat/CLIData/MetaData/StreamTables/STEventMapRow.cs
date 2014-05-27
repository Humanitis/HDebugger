#region description
/*
 * EventMap : 0x12
 * 
 * 
The EventMap table has the following columns:
• Parent (an index into the TypeDef table)
• EventList (an index into the Event table). It marks the first of a contiguous run of Events owned
by this Type. That run continues to the smaller of:
o the last row of the Event table
o the next run of Events, found by inspecting the EventList of the next row in the
EventMap table
Note that EventMap info does not directly influence runtime behavior; what counts is the information stored for
each method that the event comprises.
The EventMap and Event tables result from putting the .event directive on a class (§18).

 * 
 * 
1. EventMap table can contain zero or more rows
2. There shall be no duplicate rows, based upon Parent (a given class has only one ‘pointer’ to the
start of its event list) [ERROR]
3. There shall be no duplicate rows, based upon EventList (different classes cannot share rows in the
Event table) [ERROR]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STEventMapRow: AStreamTableRow
    {
        private static readonly ulong OFFSET_PARENT = 0UL;
        private static readonly ulong OFFSET_EVENT_LIST = 2UL;

        private ushort _parent;
        private ushort _eventList;

        public ushort Parent
        {
            get { return _parent; }
            private set { _parent = value; }
        }
        public ushort EventList
        {
            get { return _eventList; }
            private set { _eventList = value; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STEventMapRow(reader, beginOffset, mediator, heapSizes);
        }

        private STEventMapRow()
        { }
        protected STEventMapRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.EVENT_MAP;

            Parent = reader.getUShort(BEGIN_OFFSET + OFFSET_PARENT);
            EventList = reader.getUShort(BEGIN_OFFSET + OFFSET_EVENT_LIST);

            END_OFFSET = BEGIN_OFFSET + OFFSET_EVENT_LIST;
        }

    }
}
