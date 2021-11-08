// See https://aka.ms/new-console-template for more information
using TNuget.Package;
using Tooensure.ErrorHandling;

var group1 = new List<User>()
{
    new User("Shawn", "Doe"),
    new User("Billy", ""),
    new User("", "Doe"),
    new User("Tim", "Harry"),
};

var user1 = new User("Shawn", "Doe");
var user2 = new User("", "");

var response1 = new ServiceResponse<User>()
    .AddRequirement("First name Required", string.IsNullOrWhiteSpace(user2.FirstName))
    .AddRequirement("Last name Required", string.IsNullOrWhiteSpace(user2.LastName))
    .ErrorCheck();



Console.WriteLine(response1.Message);


// Requirments
