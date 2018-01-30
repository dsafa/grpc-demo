using System;
using Demo;
using Google.Protobuf;
using System.IO;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "proto")
            {
                var greeting = new Greeting();
                greeting.Name = new Name
                {
                    FirstName = "bob",
                    LastName = "bobby",
                };
                greeting.GreetingType = Greeting.Types.GreetingType.Morning;

                if (args.Length > 1 && args[1] == "output")
                {
                    using (var file = File.Create("greeting.dat"))
                    {
                        greeting.WriteTo(file);
                    }
                }
                else
                {
                    using (var inputFile = File.OpenRead("greeting.dat"))
                    {
                        greeting = Greeting.Parser.ParseFrom(inputFile);

                        Console.WriteLine(greeting);
                    }
                }
            }
        }
    }
}
