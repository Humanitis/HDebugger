#region description
/*
 * Event : 0x14
 * 
 * Events are treated within metadata much like Properties; that is, as a way to associate a collection of methods
defined on a given class. There are two required methods (add_ and remove_) plus an optional one (raise_);
others are permitted. All of the methods gathered together as an Event shall be defined on the class.
The association between a row in the TypeDef table and the collection of methods that make up a given Event
is held in three separate tables (exactly analogous to the approach used for Properties)
 * 
 * 
 * Event tables do a little more than group together existing rows from other tables. The Event table has columns
for EventFlags, Name (e.g., DocChanged and TimedOut in the example here), and EventType. In addition, the
MethodSemantics table has a column to record whether the method it indexes is an add_, a remove_, a raise_,
or other function.
The Event table has the following columns:
• EventFlags (a 2-byte bitmask of type EventAttributes, §23.1.4)
• Name (an index into the String heap)
• EventType (an index into a TypeDef, a TypeRef, or TypeSpec table; more precisely, a
TypeDefOrRef (§24.2.6) coded index) (This corresponds to the Type of the Event; it is not the
Type that owns this event.)
Note that Event information does not directly influence runtime behavior; what counts is the information stored
for each method that the event comprises.
The EventMap and Event tables result from putting the .event directive on a class
 * 
 * 
 * 
 * 1. The Event table can contain zero or more rows
2. Each row shall have one, and only one, owner row in the EventMap table [ERROR]
3. EventFlags shall have only those values set that are specified (all combinations valid) [ERROR]
4. Name shall index a non-empty string in the String heap [ERROR]
5. The Name string shall be a valid CLS identifier [CLS]
6. EventType can be null or non-null
7. If EventType is non-null, then it shall index a valid row in the TypeDef or TypeRef table
[ERROR]
116 Partition II
8. If EventType is non-null, then the row in the TypeDef, TypeRef, or TypeSpec table that it indexes
shall be a Class (not an Interface or a ValueType) [ERROR]
9. For each row, there shall be one add_ and one remove_ row in the MethodSemantics table
[ERROR]
10. For each row, there can be zero or one raise_ row, as well as zero or more other rows in the
MethodSemantics table [ERROR]
11. Within the rows owned by a given row in the TypeDef table, there shall be no duplicates based
upon Name [ERROR]
12. There shall be no duplicate rows based upon Name, where Name fields are compared using CLS
conflicting-identifier-rules [CLS]
 */
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PEFileFormat.Extensions;

namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    public sealed class STEventRow : AStreamTableRow
    {
        private static readonly ulong OFFSET_EVENT_FLAGS = 0UL;
        private static readonly ulong OFFSET_NAME = 2UL;
        private static readonly ulong OFFSET_EVENT_TYPE = 2UL;

        private EventAttributesFlag _eventFlags;
        private uint _name;
        private ushort _eventType;
        private TypeDefOrRefTag _eventTypeTable;

        public EventAttributesFlag EventFlags
        {
            get { return _eventFlags; }
            private set { _eventFlags = value; }
        }
        public uint Name
        {
            get { return _name; }
            private set { _name = value; }
        }
        public ushort EventType
        {
            get { return _eventType; }
            private set { _eventType = value; _eventTypeTable = (TypeDefOrRefTag)(_eventType >> 14); }
        }
        public TypeDefOrRefTag EventTypeTable
        {
            get { return _eventTypeTable; }
        }


        public static AStreamTableRow CreateStreamTableRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
        {
            return new STEventRow(reader, beginOffset, mediator, heapSizes);
        }

        private STEventRow()
        { }
        protected STEventRow(byte[] reader, ulong beginOffset, AFileFormatMediator mediator, HeapSizeFlag heapSizes)
            : base(reader, beginOffset, mediator, heapSizes)
        {
            _typeTable = TypeMetaData.EVENT;

            EventFlags = (EventAttributesFlag)reader.getUShort(BEGIN_OFFSET + OFFSET_EVENT_FLAGS);

            ulong stringSizeIndex = HeapSizes.WideOfStringHeap();
            Name = (uint)reader.getValue(BEGIN_OFFSET + OFFSET_NAME, stringSizeIndex, stringSizeIndex);
            EventType = reader.getUShort(BEGIN_OFFSET + OFFSET_EVENT_TYPE);

            END_OFFSET = BEGIN_OFFSET + OFFSET_EVENT_TYPE + stringSizeIndex + 2;
        }

    }
}
