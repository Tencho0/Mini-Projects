namespace p1
{
    public class Person
    {
        public string name;

        public string Name { get; set; }

        public Person(string name)
        {
            this.Name = name;
        }

        public string SayHello()
        {
            string helloMessage = $"Hello, my name is {this.Name} and I am a person";

            return helloMessage;

        }

        public string SayHelloFromManager()
        {
            string helloMessage = $"Hello, my name is {this.Name} and I am a manager";

            return helloMessage;

        }

        public string SayHelloFromEmployee()
        {
            string helloMessage = $"Hello, my name is {this.Name} and I am a employee";

            return helloMessage;

        }

    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            Person person = new Person("Peter");
            string helloMessagePerson = person.SayHello();
            Console.WriteLine(helloMessagePerson);

            Person employee = new Person("John");
            string helloMessageEmployee = employee.SayHelloFromEmployee();
            Console.WriteLine(helloMessageEmployee);

            Person manager = new Person("Bob");
            string helloMessageManager = manager.SayHelloFromManager();
            Console.WriteLine(helloMessageManager);
        }

    }

}
