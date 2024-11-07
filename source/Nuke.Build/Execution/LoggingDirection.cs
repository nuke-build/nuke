namespace Nuke.Build.Execution
{
    /// <summary>
    /// Will be used to decide where logs can be redirected (cosnosle/files/....)
    /// </summary>
    public enum LoggingDirection
    {
        Default,
        Enricher,
        Host,
        Console,
        InMemory,
        Files
    }
}
