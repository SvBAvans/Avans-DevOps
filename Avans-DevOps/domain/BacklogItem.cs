using Avans_DevOps.domain.BacklogItemState;

namespace Avans_DevOps.domain;

public class BacklogItem
{
    public IBacklogItemState TodoState { get; } = new TodoState();
    public IBacklogItemState DoingState { get; } = new DoingState();
    public IBacklogItemState ReadyForTestingState { get; } = new ReadyForTestingState();
    public IBacklogItemState TestingState { get; } = new TestedState();
    public IBacklogItemState TestedState { get; } = new TestedState();
    public IBacklogItemState DoneState { get; } = new DoneState();

    public string Title { get; set; }
    public string Description { get; set; }
    private IBacklogItemState _state;
    
    
    //TODO: Create Activity Object
    public List<object> Activities { get; } = [];

    public BacklogItem(string title, string description)
    {
        Title = title;
        Description = description;
        _state = TodoState;
    }

    public void SetState(IBacklogItemState state)
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