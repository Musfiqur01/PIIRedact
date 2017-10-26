namespace PIIRedact
{
    public interface IPIIMatchResult
    {
        int Start { get; }
        int End { get; }
        bool isWithinRange(int x);
    }
}
