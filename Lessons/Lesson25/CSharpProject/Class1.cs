// Lesson 25  - Consuming C# From F#

namespace CSharpProject
{
    public class Person
    {
        // Listing 25.1 A simple C# class  - pg. 301
        public string Name { get; private set; }
        public Person(string name)
        {
            Name = name;
        }
        public void PrinName()
        {
            Console.WriteLine($"My name is {Name}");
        }
    }
}