using Avans_DevOps.domain.Discussions;

namespace Avans_DevOps.domain.Notifications.Observer;

public interface IDiscussionObserver
{
    void OnPostAdded(ThreadPost newPost);
}