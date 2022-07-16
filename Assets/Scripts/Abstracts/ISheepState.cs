using SheepsWolf.Sheeps;


namespace SheepsWolf.Abstracts
{
    public interface ISheepState
    {
        StateBehavior StateBehavior { get; }
        void Execute();
    }
}