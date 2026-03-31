
using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications.Strategy;
using Avans_DevOps.domain.Pipeline;
using Avans_DevOps.domain.Pipeline.Actions;
using Avans_DevOps.domain.Report;

var member1 = new User("Siem", "siem@example.com", true, new SmsNotificationStrategy());
var member2 = new User("Cas", "cas@example.com", true, new EmailNotificationStrategy());
var member3 = new User("John", "john@example.com", true, new EmailNotificationStrategy());

var project = new Project("Avans One", "Een betere versie van de slechte avans app.");
project.ProductOwner = member1;
project.AddTeamMember(member2);
project.AddTeamMember(member3);

project.AddBacklogItem("Login", "", member3);
var Backlogitem1 = project.ProductBacklog.BacklogItems[0];

Backlogitem1.StartWork();
Backlogitem1.MarkReadyForTesting();
Backlogitem1.MarkTesting();
Backlogitem1.MarkTested();
Backlogitem1.ApproveDone();

project.AddSprint("Sprint 1", DateTime.Now, DateTime.Now);
project.Sprints[0].Backlog = project.ProductBacklog;


var actionFactory = new PipelineActionFactory();
var pipeline = new PipelineComposite("Dev pipeline");
pipeline.Add(actionFactory.CreateAction("checkout"));
pipeline.Add(actionFactory.CreateAction("build"));
pipeline.Add(actionFactory.CreateAction("unit-test"));
pipeline.Add(actionFactory.CreateAction("analysis"));
pipeline.Add(actionFactory.CreateAction("deploy"));
project.Sprints[0].DevelopmentPipeline = pipeline;

new TxtSprintReportExporter().ExportReport(project.Sprints[0]);

Backlogitem1.AddComment("Cas, ben jij akkoord?", member1);
var comment1 = Backlogitem1.GetComments[0];
comment1.AddComment("Ja hoor! LGTM", member2);
