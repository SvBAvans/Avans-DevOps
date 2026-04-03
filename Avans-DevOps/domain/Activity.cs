using Avans_DevOps.domain.Notifications.Observable;
using Avans_DevOps.domain.Notifications.Observer;
using Avans_DevOps.domain.WorkableState;

namespace Avans_DevOps.domain;

public class Activity : IWorkable, IStateObservable
{
    public IWorkableState TodoState { get; } = new TodoState();
    public IWorkableState DoingState { get; } = new DoingState();
    public IWorkableState ReadyForTestingState { get; } = new ReadyForTestingState();
    public IWorkableState TestingState { get; } = new TestingState();
    public IWorkableState TestedState { get; } = new TestedState();
    public IWorkableState DoneState { get; } = new DoneState();
    
    public string Title { get; set; }
    public User Member {get; set;}
    public BacklogItem Parent { get; set; }
    
    private IWorkableState _state;
    private readonly List<IStateObserver> _observers = [];


    public Activity(string title, User member, BacklogItem parent)
    {
        Title = title;
        Member = member;
        Parent = parent;
        _state = TodoState;
    }

    public void SetState(IWorkableState state)
    {
        var oldState = _state;

        _state = state;

        NotifyStateChanged(this, oldState, _state);
    }

    public void StartWork()
    {
        ExecuteIfAllowed(() => _state.StartWork(this));
    }

    public void MarkReadyForTesting()
    {
        ExecuteIfAllowed(() => _state.MarkReadyForTesting(this));
    }
    
    public void MarkTesting()
    {
        ExecuteIfAllowed(() => _state.MarkTesting(this));
    }

    public void MarkTested()
    {
        ExecuteIfAllowed(() => _state.MarkTested(this));
    }

    public void ApproveDone()
    {
        ExecuteIfAllowed(() => _state.ApproveDone(this));
    }

    public void ReturnToTodo()
    {
        ExecuteIfAllowed(() => _state.ReturnToTodo(this));
    }

    public string GetStateName()
    {
        return _state.GetName();
    }

    public void Subscribe(IStateObserver observer)
    {
        if (!_observers.Contains(observer))
            _observers.Add(observer);
    }

    public void Unsubscribe(IStateObserver observer)
    {
        _observers.Remove(observer);
    }

    private void ExecuteIfAllowed(Action action)
    {
        if (Parent.IsClosed)
        {
            throw new InvalidOperationException("BacklogItem is closed");
        }

        action();
    }
    
    public void NotifyStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        foreach (var observer in _observers.ToList())
        {
            observer.OnStateChanged(workable, oldState, newState);
        }
    }
}