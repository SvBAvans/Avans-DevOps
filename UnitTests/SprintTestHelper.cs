using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public static class SprintTestHelper
{
    public static Sprint CreateSprint(Sprint.SprintType type = Sprint.SprintType.DEVELOPMENT)
    {
        var strategy = new EmailNotificationStrategy();
        var scm = new GitScm();

        var productOwner = new User("PO", "po@test.com", false, strategy);
        var scrumMaster = new User("ScrumMaster", "sm@test.com", false, strategy);
        var member = new User("Alice", "alice@test.com", false, strategy);

        var project = new Project("Project X", "Description", "repo", scm)
        {
            ProductOwner = productOwner
        };

        project.AddTeamMember(member);

        return new Sprint(
            project,
            "Sprint 1",
            new DateTime(2025, 1, 1),
            new DateTime(2025, 1, 14),
            type)
        {
            ScrumMaster = scrumMaster
        };
    }

    public static User CreateMember()
    {
        return new User("Alice", "alice@test.com", false, new EmailNotificationStrategy());
    }

    public static Sprint CreateInExecutionSprint()
    {
        var sprint = CreateSprint();
        sprint.MarkInExecution();
        return sprint;
    }

    public static Sprint CreateInReviewSprint()
    {
        var sprint = CreateSprint();
        sprint.MarkInExecution();
        sprint.StartReview();
        return sprint;
    }

    public static Sprint CreateFinishedSprint()
    {
        var sprint = CreateSprint();
        sprint.MarkFinished();
        return sprint;
    }
}