
using Avans_DevOps.domain;

var member1 = new User("Siem", "siem@example.com");
var member2 = new User("Cas", "cas@example.com");
var member3 = new User("John", "john@example.com");

var project = new Project("Avans One", "Een betere versie van de slechte avans app.");
project.ProductOwner = member1;
project.AddTeamMember(member2);
project.AddTeamMember(member3);

var Backlogitem1 = new BacklogItem("Login", "");
project.AddBacklogItem(Backlogitem1);

Backlogitem1.StartWork();
Backlogitem1.MarkReadyForTesting();
Console.WriteLine(Backlogitem1.GetStateName());