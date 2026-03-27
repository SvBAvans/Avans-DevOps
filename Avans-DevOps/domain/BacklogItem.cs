using Avans_DevOps.domain.WorkableState;

namespace Avans_DevOps.domain;

public class BacklogItem : IWorkable
{
    public IWorkableState TodoState { get; } = new TodoState();
    public IWorkableState DoingState { get; } = new DoingState();
    public IWorkableState ReadyForTestingState { get; } = new ReadyForTestingState();
    public IWorkableState TestingState { get; } = new TestedState();
    public IWorkableState TestedState { get; } = new TestedState();
    public IWorkableState DoneState { get; } = new DoneState();

    public string Title { get; set; }
    public string Description { get; set; }
    private IWorkableState _state;
    
    public List<Activity> Activities { get; } = [];

    public BacklogItem(string title, string description)
    {
        Title = title;
        Description = description;
        _state = TodoState;
    }

    public void SetState(IWorkableState state)
    {
        _state = state;
    }

    public void StartWork()
    {
        _state.StartWork(this);
    }

    public void MarkReadyForTesting()
    {
        _state.MarkReadyForTesting(this);
    }

    public void MarkTesting()
    {
        _state.MarkTesting(this);
    }

    public void MarkTested()
    {
        _state.MarkTested(this);
    }

    public void ApproveDone()
    {
        _state.ApproveDone(this);
    }

    public void ReturnToTodo()
    {
        _state.ReturnToTodo(this);
    }

    public string GetStateName()
    {
        return _state.GetName();
    }
}