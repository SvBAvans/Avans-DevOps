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

    public string GetStateName()
    {
        return _state.GetName();
    }
}