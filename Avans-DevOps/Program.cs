
using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications;
using Avans_DevOps.domain.Pipeline;
using Avans_DevOps.domain.Pipeline.Actions;

var member1 = new User("Siem", "siem@example.com", true, new SmsNotificationStrategy());
var member2 = new User("Cas", "cas@example.com", true, new EmailNotificationStrategy());
var member3 = new User("John", "john@example.com", true, new EmailNotificationStrategy());

var project = new Project("Avans One", "Een betere versie van de slechte avans app.");
project.ProductOwner = member1;
project.AddTeamMember(member2);
project.AddTeamMember(member3);

var Backlogitem1 = new BacklogItem("Login", "", member3);
project.AddBacklogItem(Backlogitem1);

Backlogitem1.StartWork();
Backlogitem1.MarkReadyForTesting();
Backlogitem1.ReturnToTodo();

var sprint = new Sprint("Sprint 1", DateTime.Now, DateTime.Now);
project.AddSprint(sprint);
sprint.Backlog = project.ProductBacklog;


var actionFactory = new PipelineActionFactory();
var pipeline = new PipelineComposite("Dev pipeline");
pipeline.Add(actionFactory.CreateAction("checkout"));
pipeline.Add(actionFactory.CreateAction("build"));
pipeline.Add(actionFactory.CreateAction("unit-test"));
pipeline.Add(actionFactory.CreateAction("analysis"));
pipeline.Add(actionFactory.CreateAction("deploy"));
sprint.DevelopmentPipeline = pipeline;
