namespace ConcordyaPayee.CommandProcessor
{
    public interface ICommandResults
    {
        ICommandResult[] Results { get; }

        bool Success { get; }
    }
}

