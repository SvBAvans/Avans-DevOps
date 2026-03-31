using Avans_DevOps.domain.Discussions;

namespace Avans_DevOps.domain.Notifications.Observer;

public class CommentNotificationObserver : IDiscussionObserver
{
    public void OnPostAdded(ThreadPost newPost)
    {
        var project = newPost.BacklogItem.Project;
        var message = newPost.ParentPost == null
            ? $"[Discussion Notify] {newPost.Author.Name} commented on BacklogItem \"{newPost.BacklogItem.Title}\": \"{newPost.Content}\""
            : $"[Discussion Notify] {newPost.Author.Name} commented a post: \"{newPost.Content}\"";
        
        if (!project.ProductOwner.IsSameUser(newPost.Author)) {
            project.ProductOwner.SendNotification(message);
        }
        
        foreach (var user in project.TeamMembers.Where(user => !user.IsSameUser(newPost.Author)))
        {
            user.SendNotification(message);
        }
    }
}