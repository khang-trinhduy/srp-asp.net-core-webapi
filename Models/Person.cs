using System;
using System.ComponentModel.DataAnnotations;

namespace SRP.Models
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
    public abstract class Action
    {
        public Person Person { get; set; }
        public abstract void Execute();
        public Action(Person person)
        {
            Person = person;
        }
    }
    public class Talk : Action
    {
        public Talk(Person person, string sentences) : base(person)
        {
            Sentences = sentences;
        }
        public string Sentences { get; set; }
        public override void Execute() => System.Console.WriteLine($"{Person.FirstName}: {Sentences}");
    }
    public class Text : Action
    {
        public string Messages { get; set; }
        public Text(Person person, string messages) : base(person)
        {
            Messages = messages;
        }
        public override void Execute() => System.Console.WriteLine($"{Person.FirstName}: {Messages}");
    }
    public class Travel : Action
    {
        public string Place { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }
        public Travel(Person person, string place, DateTime time) : base(person)
        {
            Place = place;
            Time = time;
        }
        public override void Execute() => System.Console.WriteLine($"{Person.FirstName}: visited {Place} at {Time.ToString()}");
    }
    public class Display
    {
        public Action Action { get; set; }
        // public override string ToString() => return Action.Person.FirstName
    }
}