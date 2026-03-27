namespace Avans_DevOps.domain;

public interface IWorkableState
{
    void StartWork(IWorkable item);
    void MarkReadyForTesting(IWorkable item);
    void MarkTesting(IWorkable item);
    void MarkTested(IWorkable item);
    void ApproveDone(IWorkable item);
    void ReturnToTodo(IWorkable item);
    string GetName();
}