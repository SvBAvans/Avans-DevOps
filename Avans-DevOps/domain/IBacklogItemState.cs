namespace Avans_DevOps.domain;

public interface IBacklogItemState
{
    void StartWork();
    void MarkReadyForTesting();
    void MarkTested();
    void ApproveDone();
    void ReturnToTodo();
    string GetName();
}