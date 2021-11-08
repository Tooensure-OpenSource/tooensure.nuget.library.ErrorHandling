using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNuget.Package
{
    public class User
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public User() { }
        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Dictionary<string, bool> UserRequirements(User user)
        {
            var requriments = new Dictionary<string, bool>();

            requriments.Add("First name required", string.IsNullOrWhiteSpace(user.FirstName));

            requriments.Add("Last name required", string.IsNullOrWhiteSpace(user.LastName));

            return requriments;

        }

    }
}
