
using Avans_DevOps.domain;
using Avans_DevOps.domain.Notifications;

var member1 = new User("Siem", "siem@example.com", true, new EmailNotificationStrategy());
var member2 = new User("Cas", "cas@example.com", true, new EmailNotificationStrategy());
var member3 = new User("John", "john@example.com", true, new EmailNotificationStrategy());

var project = new Project("Avans One", "Een betere versie van de slechte avans app.");
project.ProductOwner = member1;
project.AddTeamMember(member2);
project.AddTeamMember(member3);

var Backlogitem1 = new BacklogItem("Login", "");
project.AddBacklogItem(Backlogitem1);

Backlogitem1.StartWork();
Backlogitem1.MarkReadyForTesting();
