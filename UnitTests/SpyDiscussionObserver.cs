using Avans_DevOps.domain.Discussions;
using Avans_DevOps.domain.Notifications.Observer;

namespace UnitTests;

public class SpyDiscussionObserver : IDiscussionObserver
{
    public int CallCount { get; private set; }
    public ThreadPost? LastPost { get; private set; }

    public void OnPostAdded(ThreadPost newPost)
    {
        CallCount++;
        LastPost = newPost;
    }
}