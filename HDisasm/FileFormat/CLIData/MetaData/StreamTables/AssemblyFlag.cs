using System;


namespace PEFileFormat.FileFormat.CLIData.MetaData
{
    [Flags()]
    public enum AssemblyFlag : uint
    {
        /// <summary>
        /// The assembly reference holds the full (unhashed)
        ///public key.
        /// </summary>
        PUBLIC_KEY = 0x0001,
        /// <summary>
        /// The assembly is side-by-side compatible
        /// </summary>
        SIDE_BY_SIDE_COMPATIBLE = 0x0000,
        /// <summary>
        /// Reserved: both bits shall be zero
        /// </summary>
        RESERVED = 0x0030,
        /// <summary>
        /// The implementation of this assembly used at runtime is
        ///not expected to match the version seen at compile time.
        ///(See the text following this table.)
        /// </summary>
        RETARGETABLE = 0x0100,
        /// <summary>
        /// Reserved (a conforming implementation of the CLI
        /// can ignore this setting on read; some implementations
        /// might use this bit to indicate that a CIL-to-native-code
        /// compiler should generate CIL-to-native code map)
        /// </summary>
        ENABLE_JIT_COMPILE_TRACKING = 0x8000,
        /// <summary>
        /// Reserved (a conforming implementation of the CLI
        /// can ignore this setting on read; some implementations
        /// might use this bit to indicate that a CIL-to-native-code
        /// compiler should not generate optimized code)
        /// </summary>
        DISABLE_JIT_COMPILE_OPTIMIZER = 0x4000,
    }
}
