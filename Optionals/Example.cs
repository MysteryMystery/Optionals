using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optionals
{
    class Example
    {
        static void Main(string[] args)
        {
            var myDB = new Database();

            Optional<User> result = myDB.GetUser("John");
            if (result.IsPresent())
                Console.WriteLine("Found John!");
            else
                Console.WriteLine("Oh no we didn't find him! Let us do something else!");

            result = myDB.GetUser("Jim");
            result.IfPresent(
                    x => Console.WriteLine("Found him! Feel free to return things here too!")
                );

            var theObject = myDB.GetUser("James").OrElse(new User("Sophie"));
            Console.WriteLine(theObject.Name);

            Optionals.Of(new User("blah"));
        }
    }

    class Database
    {
        private List<User> db = new List<User>(
                new User[] {
                    new User("John"),
                    new User("Jim")
                }
            );

        public Optional<User> GetUser(String name)
        {
            User user = db.Find(x => x.Name == name);
            return user == null ? Optionals.Empty<User>() : Optionals.Of(user);
        }
    }

    class User
    {
        private string _name;
        public string Name
        {
            get => _name;
            private set {
                _name = value;
            }
        }

        public User(string name)
        {
            Name = name;
        }
    }
}
