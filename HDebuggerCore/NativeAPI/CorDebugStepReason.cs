namespace HDebuggerCore.NativeAPI
{
    /// <summary>
    /// 
    /// </summary>
    [System.Flags]
    public enum CorDebugStepReason : int
    {
        STEP_NORMAL = 0,
        STEP_RETURN = (STEP_NORMAL + 1),
        STEP_CALL = (STEP_RETURN + 1),
        STEP_EXCEPTION_FILTER = (STEP_CALL + 1),
        STEP_EXCEPTION_HANDLER = (STEP_EXCEPTION_FILTER + 1),
        STEP_INTERCEPT = (STEP_EXCEPTION_HANDLER + 1),
        STEP_EXIT = (STEP_INTERCEPT + 1)
    }
}
