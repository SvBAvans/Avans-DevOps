namespace Avans_DevOps.domain;

public interface IBacklogItemState
{
    void StartWork(BacklogItem backlogItem);
    void MarkReadyForTesting(BacklogItem backlogItem);
    void MarkTested(BacklogItem backlogItem);
    void ApproveDone(BacklogItem backlogItem);
    void ReturnToTodo(BacklogItem backlogItem);
    string GetName();
}