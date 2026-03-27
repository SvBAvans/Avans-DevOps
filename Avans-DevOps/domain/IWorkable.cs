namespace Avans_DevOps.domain;

public interface IWorkable
{
    public IWorkableState TodoState { get; }
    public IWorkableState DoingState { get; }
    public IWorkableState ReadyForTestingState { get; }
    public IWorkableState TestingState { get; }
    public IWorkableState TestedState { get; }
    public IWorkableState DoneState { get; }
    
    void SetState(IWorkableState state);
    void StartWork();
    void MarkReadyForTesting();
    void MarkTesting();
    void MarkTested();
    void ApproveDone();
    void ReturnToTodo();
    string GetStateName();
}