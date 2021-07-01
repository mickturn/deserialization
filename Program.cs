using System;
using System.Text.Json;

namespace Experiments
{
    class Program
    {
        static void Main(string[] args)
        {
            // Our json objects look like this one.
            // Notice that Json keys do not match the Test class private fields which are prefixed with underscore.
            string json = @"{ ""id"" : 1, ""name"" : ""test"" }";
            var test = JsonSerializer.Deserialize<Test>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            test.ToString();
        }
    }

    public class Test
    {
        public ushort Id { get; } // Allows private _id field initialization, rise exception without.
        public string Name { get; } // Allows private _name field initialization, rise exception without.
        private readonly ushort _id;
        private readonly string _name;
        public Test(ushort id, string name)
        {
            // The private fields are being populated here.
            // But it works only when we add the two previous accessors.
            // Why not allowing private fields initialization without the need of useless accessors!
            _id = id;
            _name = name;
        }
        new public void ToString()
        {
            Console.WriteLine($"Private field _id has value: {_id}");
            Console.WriteLine($"Private field _name has value: {_name}");
            Console.WriteLine($"Public getter Id does not have the good value: {Id}");
            Console.WriteLine($"Public getter Name does not have the good value: {Name}");
        }
    }

}
