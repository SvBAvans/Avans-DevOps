using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Observer;

namespace UnitTests;

public class SpyStateObserver : IStateObserver
{
    public int CallCount { get; private set; }

    public void OnStateChanged(IWorkable workable, IWorkableState oldState, IWorkableState newState)
    {
        CallCount++;
    }
}