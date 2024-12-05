namespace Nuke.Build.Execution
{
    /// <summary>
    /// Will be used to decide where logs can be redirected (cosnosle/files/....)
    /// </summary>
    public enum LoggingDirection
    {
        /// <summary>
        /// Will use normal default nuke way of logging configuration
        /// </summary>
        Default,

        /// <summary>
        /// No Logging at all
        /// </summary>
        None,

        /// <summary>
        /// Use Enricher feature
        /// </summary>
        Enricher,

        /// <summary>
        /// Use Host logging
        /// </summary>
        Host,

        /// <summary>
        /// Use Console logging
        /// </summary>
        Console,

        /// <summary>
        /// Use Memory Logging
        /// </summary>
        InMemory,

        /// <summary>
        /// Use Files Logging 
        /// <para/>
        /// (in some scenarios may hurt concurrent instances if they attempt to write on same file, otherwise you need manually create different temp directories)
        /// </summary>
        Files
    }
}
