namespace Avans_DevOps.domain;

public class Backlog
{
    public List<BacklogItem> BacklogItems { get; set; } = [];

    public void AddItem(BacklogItem item)
    {
        BacklogItems.Add(item);
    }
}