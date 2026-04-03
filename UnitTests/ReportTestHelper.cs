using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.domain.SCM;
using Avans_DevOps.Infrastructure;

namespace UnitTests;

public static class ReportTestHelper
{
    public static Sprint CreateSprintForReport()
    {
        var strategy = new EmailNotificationStrategy();
        var scm = new GitScm();

        var siem = new User("Siem", "siem@test.com", false, strategy);
        var alice = new User("Alice", "alice@test.com", false, strategy);
        var bob = new User("Bob", "bob@test.com", false, strategy);

        var project = new Project("Project X", "Description", "repo", scm)
        { ProductOwner = siem };

        project.TeamMembers.Add(alice);
        project.TeamMembers.Add(bob);

        var sprint = new Sprint(project, "Sprint 1", DateTime.Now, DateTime.Now.AddDays(7), Sprint.SprintType.DEVELOPMENT);

        return sprint;
    }

    public static Sprint CreateSprintForReportWithCompletedWork()
    {
        var sprint = CreateSprintForReport();

        var alice = sprint.Project.TeamMembers[0];
        var bob = sprint.Project.TeamMembers[1];

        var item1 = new BacklogItem("Login feature", "Implement login", alice, sprint.Project);
        item1.AddActivity("Create login form", alice);
        item1.AddActivity("Validate credentials", bob);

        foreach (var activity in item1.Activities)
        {
            if (activity.GetStateName() == "TodoState")
                activity.StartWork();

            if (activity.GetStateName() == "DoingState")
                activity.MarkReadyForTesting();

            if (activity.GetStateName() == "ReadyForTestingState")
                activity.MarkTesting();

            if (activity.GetStateName() == "TestingState")
                activity.MarkTested();

            if (activity.GetStateName() == "TestedState")
                activity.ApproveDone();
        }

        item1.StartWork();
        item1.MarkReadyForTesting();
        item1.MarkTesting();
        item1.MarkTested();
        item1.ApproveDone();

        var item2 = new BacklogItem("Register feature", "Implement registration", bob, sprint.Project);
        item2.AddActivity("Create registration form", bob);

        foreach (var activity in item2.Activities)
        {
            if (activity.GetStateName() == "TodoState")
                activity.StartWork();

            if (activity.GetStateName() == "DoingState")
                activity.MarkReadyForTesting();

            if (activity.GetStateName() == "ReadyForTestingState")
                activity.MarkTesting();

            if (activity.GetStateName() == "TestingState")
                activity.MarkTested();

            if (activity.GetStateName() == "TestedState")
                activity.ApproveDone();
        }

        item2.StartWork();
        item2.MarkReadyForTesting();
        item2.MarkTesting();
        item2.MarkTested();
        item2.ApproveDone();

        sprint.Backlog.BacklogItems.Add(item1);
        sprint.Backlog.BacklogItems.Add(item2);

        return sprint;
    }
}