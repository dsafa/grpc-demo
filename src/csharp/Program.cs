using System;
using Demo;
using Google.Protobuf;
using System.IO;
using Grpc.Core;
using ServiceDemo;

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
                        Console.WriteLine(greeting.GreetingType);
                    }
                }
            }
            else
            {
                var channel = new Channel("localhost:6789", ChannelCredentials.Insecure);
                var client = new GreetingService.GreetingServiceClient(channel);

                var name = new Name
                {
                    FirstName = "john",
                    LastName = "doe",
                };

                Console.WriteLine("Saying hi to the server");
                var greeting = client.SayHi(name);
                Console.WriteLine($"Response: {greeting}");
            }
        }
    }
}
