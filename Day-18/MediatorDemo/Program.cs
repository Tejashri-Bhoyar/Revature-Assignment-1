﻿
// chat room -> Mediator

// user1 -> user2 -> user3


var landingRunway = new Chatroom();

var sarah = new User("Sarah", landingRunway);
var bob = new User("Bob", landingRunway);
var alice = new User("Alice", landingRunway);

landingRunway.Register(sarah);
landingRunway.Register(bob);
landingRunway.Register(alice);

sarah.Send("Landing on Runway 1 at 11:56 AM");

class User
{
    public string Name { get; set; }

    Chatroom chatroom;

    public User(string name, Chatroom chatroom)
    {
        this.Name = name;
        this.chatroom = chatroom;
    }

    public void Send(string message)
    {
        Console.WriteLine($"{Name} sending message: {message}");
        chatroom.Send(message, this);
    }

    public void Receive(string message)
    {
        Console.WriteLine($"{Name} received message: {message}");
    }
}

// Mediator
class Chatroom
{
    public List<User> users = new();

    public void Register(User user)
    {
        users.Add(user);
    }

    public void Unregister(User user)
    {
        users.Remove(user);
    }


    public void Send(string message, User sender)
    {
        foreach (var receiver in users.Where(x => x != sender))
        {
            if (receiver == sender)
                continue;
            receiver.Receive(message);
        }
    }
}